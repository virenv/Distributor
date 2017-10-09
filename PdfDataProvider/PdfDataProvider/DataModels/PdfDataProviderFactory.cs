using PdfDataProvider.SqliteImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDataProvider
{
    public class DataStoreProviderFactory
    {
        private static SqliteConnectionProvider connection = null;

        public static SqliteConnectionProvider GetDataSourceFactory()
        {
            if(connection == null)
            {
                connection = new SqliteConnectionProvider();
            }
            return connection;
        }
    }

    public class PdfDataProviderFactory
    {
        private static SqlitePdfTaskRequestor taskRequestor = new SqlitePdfTaskRequestor();
        private static IPdfReadOutLoudRunStarter runStarter = new SqlLiteReadOutLoudRunStarter();
        private static IPdfReportExecutionResult reporter = new SqlLiteTestReporter();
        public static IPdfDataRequestor GetTaskRequestor()
        {
            return taskRequestor;
        }

        public static IPdfReadOutLoudRunStarter GetReadOutLoudRunStarter()
        {
            return runStarter;
        }

        public static IPdfReportExecutionResult GetPdfTestReporter()
        {
            return reporter;
        }
    }
}
