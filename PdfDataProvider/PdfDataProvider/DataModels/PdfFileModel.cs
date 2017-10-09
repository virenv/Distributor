using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDataProvider.DataModels
{
    public class PdfFileModel
    {
        public string NAME { get; set; }
        public string FILEPATH { get; set; }
        public int ID { get; set; }
        public string CATEGORY { get; set; }
    }

    public class PdfROLTestTask
    {
        [JsonProperty]
        private PdfFileModel pdfFile;

        public PdfROLTestTask(PdfFileModel file, long reportId)
        {
            pdfFile = file;
            ReportID = reportId;
        }

        public PdfFileModel getPdfFile()
        {
            return pdfFile;
        }

        public long ReportID
        {
            get;
            
            private set;
        }

        public double ROLStartTimeUI
        {
            get;
            set;
        }

        public double ROLStartTimeEvent
        {
            get;
            set;
        }

        public string MachineName
        {
            get;
            set;
        }
    }

}
