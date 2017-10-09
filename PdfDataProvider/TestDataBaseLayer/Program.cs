using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfDataProvider;
using PdfDataProvider.DataModels;

namespace TestDataBaseLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            IPdfDataRequestor dataRequestor = PdfDataProviderFactory.GetTaskRequestor();
            PdfROLTestTask task = null;
            task = dataRequestor.GetNextROLTestData("sample");
            do
            {

                task.ROLStartTimeEvent = 899;
                task.ROLStartTimeUI = 5656;


                IPdfReportExecutionResult reporter = PdfDataProviderFactory.GetPdfTestReporter();
                reporter.ReportROLTestResult(task);
                task = dataRequestor.GetNextROLTestData("sample");

            } while (task != null);
        }
    }
}
