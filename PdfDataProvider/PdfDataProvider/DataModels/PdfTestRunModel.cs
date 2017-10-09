using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDataProvider.DataModels
{
    class PdfTestRunModel
    {
        public long ID
        {
            get; set;
        }

        public string NAME
        {
            get; set;
        }

        public string DESCRIPTION
        {
            get; set;
        }

        public DateTime START_DATE
        {
            get; set;
        }

        public DateTime END_DATE
        {
            get; set;
        }

        public string RUN_STATE
        {
            get; set;
        }
    }
}
