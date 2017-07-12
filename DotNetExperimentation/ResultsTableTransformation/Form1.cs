using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace ResultsTableTransformation
{
    public partial class Form1 : Form
    {
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

            return;
            var connectionString = GetConnectionString();

            var adapter = new OleDbDataAdapter("SELECT * FROM [ModuleData$]", connectionString);
            var ds = new DataSet();

            adapter.Fill(ds, "anyNameHere");

            var data = ds.Tables["anyNameHere"].AsEnumerable();

            List<ModuleResultsData> moduleResults = new List<ModuleResultsData>();

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

            //foreach (DataRow dataRow in data)
            //{
            //    ModuleResultsData results = new ModuleResultsData()
            //    {
            //        ModuleKey = dataRow[CourseKey].ToString(),
            //        SubmittedCount = int.Parse(dataRow[Submitted].ToString()),
            //        score90_100 = int.Parse(dataRow[_90].ToString()),
            //        score80_89 = int.Parse(dataRow[_80].ToString()),
            //        score70_79 = int.Parse(dataRow[_70].ToString()),
            //        score60_69 = int.Parse(dataRow[_60].ToString()),
            //        score55_59 = int.Parse(dataRow[_55].ToString()),
            //        score50_54 = int.Parse(dataRow[_50].ToString()),
            //        score40_49 = int.Parse(dataRow[_40].ToString()),
            //        score30_39 = int.Parse(dataRow[_30].ToString()),
            //        score20_29 = int.Parse(dataRow[_20].ToString()),
            //        score0_19 = int.Parse(dataRow[_0].ToString())
            //    };
            //    moduleResults.Add(results);
            //}

            //foreach (var res in moduleResults)
            //{

            //}
        }

        private class ModuleResultsData
        {
            public string ModuleKey;
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

        private string GetConnectionString()
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            // XLSX - Excel 2007, 2010, 2012, 2013
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
            props["Extended Properties"] = "Excel 12.0 XML";
            props["Data Source"] = @"C:\Users\User\Downloads\Oxford2015-2016ModuleResults.xlsx";

            // XLS - Excel 2003 and Older
            //props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            //props["Extended Properties"] = "Excel 8.0";
            //props["Data Source"] = "C:\\MyExcel.xls";

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }

            return sb.ToString();
        }
    }
}
