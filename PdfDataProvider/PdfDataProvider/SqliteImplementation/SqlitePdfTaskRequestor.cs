using PdfDataProvider.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDataProvider.SqliteImplementation
{
    
    /*
     * This class holds the responsibility to maintain the current pagination state. 
     */
    class SqlitePdfTaskRequestor : IPdfDataRequestor
    {
        private const string nextTaskCommand = "Select * from PDF_FILES where ID = @CurrentId";
        private const string currentOpenRunCommand = "Select * from PDF_TEST_RUNS where RUN_STATE = '" +  TestRunState.NotStarted + "'";
        private const string insertTestReportCommand = "INSERT into PDF_ROL_TEST_REPORT(PDF_FILE_ID, TEST_RUN_ID, ROL_MACHINE_NAME) VALUES (@PdfFileId, @TestRunId, '@MachineName')";
        private const string tableName = "PDF_FILES";
        private const string runTableName = "PDF_TEST_RUNS";
        private const string rolTestReportTable = "PDF_ROL_TEST_REPORT";

        SqliteConnectionProvider connection;
        int currentState = 0;

        public SqlitePdfTaskRequestor()
        {
            connection = DataStoreProviderFactory.GetDataSourceFactory();
        }

        public PdfROLTestTask GetNextROLTestData(string machineName)
        {
            PdfFileModel file =  connection.SelectExactlyOneItem<PdfFileModel>(nextTaskCommand.Replace("@CurrentId", Convert.ToString(++currentState)), tableName);

            // Early return if file is null. This means that all the files have been assigned to test machinesA
            if( file == null)
            {
                return null;
            }

            currentState = file.ID;
            PdfTestRunModel run = connection.SelectExactlyOneItem<PdfTestRunModel>(currentOpenRunCommand, runTableName);

            // Create new record
            string query = insertTestReportCommand.Replace("@PdfFileId", Convert.ToString(file.ID));
            query = query.Replace("@TestRunId", Convert.ToString(run.ID));
            query = query.Replace("@MachineName", machineName);

            // Create the task object model
            var task = new PdfROLTestTask(file, connection.InsertRecord(query));
            task.MachineName = machineName;
            return task;
        }
    }
}
