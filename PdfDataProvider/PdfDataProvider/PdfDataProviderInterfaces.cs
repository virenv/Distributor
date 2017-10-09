using PdfDataProvider.DataModels;
using PdfDataProvider.SqliteImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfDataProvider
{
    public interface IPdfReadOutLoudRunStarter
    {
        long StartPdfRun(string name, string description);
    }

    public interface IPdfDataRequestor
    {
        PdfROLTestTask GetNextROLTestData(string machineName);
    }

    public interface IPdfReportExecutionResult
    {
        void ReportROLTestResult(PdfROLTestTask task);
    }


}
