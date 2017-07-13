using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ResultsTableTransformation
{
    public partial class ResultsViewer : Form
    {
        //report files
        const string _2015_2016 = @"../../ReportFiles\Results2015-2016.pdf";
        const string _2014_2015 = @"../../ReportFiles\Results2014-2015.pdf";
        const string _2013_2014 = @"../../ReportFiles\Results2013-2014.pdf";
        const string _2012_2013 = @"../../ReportFiles\Results2012-2013.pdf";
        const string _2011_2012 = @"../../ReportFiles\Results2011-2012.pdf";

        public ResultsViewer()
        {
            InitializeComponent();
        }

        private void btnDoStuff_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            string results =
                GetTableAsStringFromPDF(_2015_2016, 6);

            results += "\n" +
                GetTableAsStringFromPDF(_2014_2015, 8);

            results += "\n" +
                GetTableAsStringFromPDF(_2013_2014, 6);

            results += "\n" +
                GetTableAsStringFromPDF(_2012_2013, 6);

            results += "\n" +
                GetTableAsStringFromPDF(_2011_2012, 7);

            ExtractDataFromFile(_2015_2016, results);
        }

        private string GetTableAsStringFromPDF(string PdfFileName, int startPage)
        {
            iTextSharp.text.pdf.PdfReader pdfReader = new iTextSharp.text.pdf.PdfReader(PdfFileName);
            string sOut = string.Empty;

            for (int i = startPage; i <= pdfReader.NumberOfPages; i++)
            {
                iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();
                sOut += iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(pdfReader, i, its);
            }
            return sOut;
        }

        private void ExtractDataFromFile(string _2015_2016, string results)
        {
            List<ModuleResultsPercentageData> percentages = GenerateStats(results);

            percentages = percentages.OrderByDescending(p => p.score90_100 + p.score80_89 + p.score70_79).ToList();

            LoadStatsIntoListView(percentages);
        }

        private void LoadStatsIntoListView(List<ModuleResultsPercentageData> percentages)
        {
            foreach (ModuleResultsPercentageData item in percentages)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.ModuleName;
                lvi.SubItems.Add(item.SubmittedCount.ToString());
                lvi.SubItems.Add(item.score90_100.ToString());
                lvi.SubItems.Add(item.score80_89.ToString());
                lvi.SubItems.Add(item.score70_79.ToString());
                lvi.SubItems.Add(item.score60_69.ToString());
                lvi.SubItems.Add(item.score55_59.ToString());
                lvi.SubItems.Add(item.score50_54.ToString());
                lvi.SubItems.Add(item.score40_49.ToString());
                lvi.SubItems.Add(item.score30_39.ToString());
                lvi.SubItems.Add(item.score20_29.ToString());
                lvi.SubItems.Add(item.score0_19.ToString());
                listView1.Items.Add(lvi);
            }
        }

        private List<ModuleResultsPercentageData> GenerateStats(string results)
        {
            const string LineBreak = "\n";

            string[] lines = results.Split(new string[] { LineBreak }, StringSplitOptions.None);

            List<ModuleResultsData> data = new List<ModuleResultsData>();
            for (int i = 1; i < lines.Length; i++)
            {
                if (!lines[i].StartsWith("Course"))
                {
                    if (lines[i].Contains("Course"))
                    {
                        lines[i] = lines[i].Substring(0, lines[i].IndexOf("Course"));
                    }
                    string[] cols = lines[i].Split(new string[] { " " }, StringSplitOptions.None);
                    if (cols.Length < 17) continue;

                    string date = string.Concat(cols[1], cols[2], cols[3]);
                    if (data.Count(d => d.ModuleKey == cols[0]) == 0)
                    {
                        ModuleResultsData modules = new ModuleResultsData()
                        {
                            ModuleKey = cols[0],
                            SubmittedCount = int.Parse(cols[6]),
                            score0_19 = int.Parse(cols[16]),
                            score20_29 = int.Parse(cols[15]),
                            score30_39 = int.Parse(cols[14]),
                            score40_49 = int.Parse(cols[13]),
                            score50_54 = int.Parse(cols[12]),
                            score55_59 = int.Parse(cols[11]),
                            score60_69 = int.Parse(cols[10]),
                            score70_79 = int.Parse(cols[9]),
                            score80_89 = int.Parse(cols[8]),
                            score90_100 = int.Parse(cols[7]),
                        };
                        data.Add(modules);
                    }
                    else
                    {
                        ModuleResultsData existing = data.First(d => d.ModuleKey == cols[0]);
                        existing.SubmittedCount += int.Parse(cols[6]);
                        existing.score0_19 += int.Parse(cols[16]);
                        existing.score20_29 += int.Parse(cols[15]);
                        existing.score30_39 += int.Parse(cols[14]);
                        existing.score40_49 += int.Parse(cols[13]);
                        existing.score50_54 += int.Parse(cols[12]);
                        existing.score55_59 += int.Parse(cols[11]);
                        existing.score60_69 += int.Parse(cols[10]);
                        existing.score70_79 += int.Parse(cols[9]);
                        existing.score80_89 += int.Parse(cols[8]);
                        existing.score90_100 += int.Parse(cols[7]);
                    }
                }
            }

            List<ModuleResultsPercentageData> percentages = new List<ModuleResultsPercentageData>();
            foreach (ModuleResultsData item in data)
            {
                ModuleResultsPercentageData perc = new ModuleResultsPercentageData()
                {
                    ModuleName = item.ModuleName,
                    SubmittedCount = item.SubmittedCount,
                    score0_19 = PercentageOfTotal(item.SubmittedCount, item.score0_19),
                    score20_29 = PercentageOfTotal(item.SubmittedCount, item.score20_29),
                    score30_39 = PercentageOfTotal(item.SubmittedCount, item.score30_39),
                    score40_49 = PercentageOfTotal(item.SubmittedCount, item.score40_49),
                    score50_54 = PercentageOfTotal(item.SubmittedCount, item.score50_54),
                    score55_59 = PercentageOfTotal(item.SubmittedCount, item.score55_59),
                    score60_69 = PercentageOfTotal(item.SubmittedCount, item.score60_69),
                    score70_79 = PercentageOfTotal(item.SubmittedCount, item.score70_79),
                    score80_89 = PercentageOfTotal(item.SubmittedCount, item.score80_89),
                    score90_100 = PercentageOfTotal(item.SubmittedCount, item.score90_100)
                };
                percentages.Add(perc);
            }

            return percentages;
        }

        private double PercentageOfTotal(double total, double amount)
        {
            if (amount == 0)
            {
                return 0;
            }
            return Math.Round((amount / total) * 100, 2);
        }

        private class ModuleResultsData
        {
            private string _moduleKey;

            public string ModuleKey
            {
                get { return _moduleKey; }
                set
                {
                    _moduleKey = value;
                    if (ModuleMap.ContainsKey(_moduleKey))
                    {
                        ModuleName = ModuleMap[_moduleKey];
                    }
                }
            }
            public string ModuleName;
            public int SubmittedCount;
            public int score90_100;
            public int score80_89;
            public int score70_79;
            public int score60_69;
            public int score55_59;
            public int score50_54;
            public int score40_49;
            public int score30_39;
            public int score20_29;
            public int score0_19;
        }

        private class ModuleResultsPercentageData
        {
            public string ModuleName;
            public int SubmittedCount;
            public double score90_100;
            public double score80_89;
            public double score70_79;
            public double score60_69;
            public double score55_59;
            public double score50_54;
            public double score40_49;
            public double score30_39;
            public double score20_29;
            public double score0_19;
        }

        private static Dictionary<string, string> ModuleMap = new Dictionary<string, string>()
        {
            //Software tools
            { "ALG", "Algorithmics" },
            { "OOD", "Object-Oriented Design" },
            { "OOP", "Object-Oriented Programming" },
            { "DPA", "Design Patterns" },
            { "STE", "Software Testing" },
            { "ROP", "Robust Programming" },
            { "DAT", "Database Design" },
            { "FPR", "Functional Programming" },
            { "CPR", "Concurrent Programming" },
            { "APE", "Agile Engineering Practices" },
            { "XML", "Extensible Markup Language" },
            { "SOA", "Service Oriented Architectures" },
            { "CLO", "Cloud Computing and Big Data" },
            { "ESS", "Embedded Software and Systems" },
            { "MOB", "Mobile and Sensor Networks" },
            { "STC", "Service Oriented Architectures" },

            //Software methods
            { "SEM", "Software Engineering Mathematics" },
            { "CDS", "Concurrency and Distributed Systems" },
            { "PMO", "Performance Modelling" },
            { "SDM", "Software Development Management" },
            { "AGM", "Agile Methods" },
            { "IDE", "Interaction Design" },
            { "REN", "Requirements Engineering" },
            { "MRQ", "Management of Risk and Quality" },
            { "PRO", "Process Quality and Improvement" },
            { "SCS", "Safety Critical Systems" },
            { "EAR", "Enterprise Architecture" },

            //Software security
            { "SPR", "Security Principles" },
            { "SCP", "Secure Programming" },
        };
    }
}
