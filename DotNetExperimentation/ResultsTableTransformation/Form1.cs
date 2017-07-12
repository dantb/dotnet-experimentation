using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ResultsTableTransformation
{
    public partial class Form1 : Form
    {
        const string CourseKey = "Course";
        const string Submitted = "Submitted";
        const string _90 = "90-100";
        const string _80 = "80-89";
        const string _70 = "70-79";
        const string _60 = "60-69";
        const string _55 = "55-59";
        const string _50 = "50-54";
        const string _40 = "40-49";
        const string _30 = "30-39";
        const string _20 = "20-29";
        const string _0 = "20-";

        public Form1()
        {
            InitializeComponent();
        }

        public static string GetTableAsStringFromPDF(string PdfFileName)
        {
            iTextSharp.text.pdf.PdfReader pdfReader = new iTextSharp.text.pdf.PdfReader(PdfFileName);
            string sOut = string.Empty;

            int tableStartPage = 6;

            for (int i = tableStartPage; i <= pdfReader.NumberOfPages; i++)
            {
                iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();
                sOut += iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(pdfReader, i, its);
            }
            return sOut;
        }

        private void btnDoStuff_Click(object sender, EventArgs e)
        {
            string results = 
                GetTableAsStringFromPDF(@"C:\Users\User\Downloads\OxfordResults2015-2016.pdf");

            const string LineBreak = "\n";

            string[] lines = results.Split(new string[] { LineBreak }, StringSplitOptions.None);

            List<ModuleResultsData> data = new List<ModuleResultsData>();
            for (int i = 1; i < lines.Length; i++)
            {
                if (!lines[i].Contains("Course"))
                {
                    string[] cols = lines[i].Split(new string[] { " " }, StringSplitOptions.None);
                    string date = string.Concat(cols[1], cols[2], cols[3]);
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
            }

            foreach (ModuleResultsData item in data)
            {

            }
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

        private static Dictionary<string, string> ModuleMap = new Dictionary<string, string>()
        {
            { "STE", "Software Testing" },
            //{ "STE", "Software Testing" },
            //{ "STE", "Software Testing" },
            //{ "STE", "Software Testing" },
            //{ "STE", "Software Testing" },
            //{ "STE", "Software Testing" },
            //{ "STE", "Software Testing" },
            //{ "STE", "Software Testing" },
            //{ "STE", "Software Testing" },
            //{ "STE", "Software Testing" },
            //{ "STE", "Software Testing" },
            //{ "STE", "Software Testing" },
            //{ "STE", "Software Testing" },
            //{ "STE", "Software Testing" },
        };
    }
}
