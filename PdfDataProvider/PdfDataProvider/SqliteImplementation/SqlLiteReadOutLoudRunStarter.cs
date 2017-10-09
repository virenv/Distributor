using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDataProvider.SqliteImplementation
{
    struct TestRunState
    {
        public const string NotStarted = "NOT_STARTED";
        public const string Running = "RUNNING";
        public const string Completed = "COMPLETED";
    }

    class SqlLiteReadOutLoudRunStarter : IPdfReadOutLoudRunStarter
    {
        private const string insertRunQuery = "INSERT INTO PDF_TEST_RUNS('NAME', 'DESCRIPTION', 'RUN_STATE') VALUES ('@Name', '@Description', '@Runstate')";

        public long StartPdfRun(string name, string description)
        {
            string query = insertRunQuery.Replace("@Name", name);
            query = query.Replace("@Description", description);
            query = query.Replace("@Runstate", TestRunState.NotStarted);
            return DataStoreProviderFactory.GetDataSourceFactory().InsertRecord(query);
        }
    }
}
