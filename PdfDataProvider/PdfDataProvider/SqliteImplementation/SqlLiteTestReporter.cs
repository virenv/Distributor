using PdfDataProvider.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDataProvider.SqliteImplementation
{
    class SqlLiteTestReporter : IPdfReportExecutionResult
    {
        private const string updateReportQuery = "UPDATE PDF_ROL_TEST_REPORT SET ROL_START_TIME_UI = @StartTimeUI, ROL_START_TIME_EVENT = @StartTimeEvent WHERE ID = @ID";
        // Simple task of this method is to report the data. That is all
        public void ReportROLTestResult(PdfROLTestTask task)
        {
            string query = updateReportQuery.Replace("@StartTimeUI", Convert.ToString(task.ROLStartTimeUI));
            query = query.Replace("@StartTimeEvent", Convert.ToString(task.ROLStartTimeEvent));
            query = query.Replace("@ID", Convert.ToString(task.ReportID));
            DataStoreProviderFactory.GetDataSourceFactory().UpdateRecord(query);
        }
    }
}
