using Newtonsoft.Json;
using PdfDataProvider;
using PdfDataProvider.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PdfDistriutorService
{
    // The task of this service is to return PdfTask
    public class PdfTaskRequesterService : IPdfTaskRequester
    {
        public string RequestPdfROLTask(string machineName)
        {
            IPdfDataRequestor dataRequestor = PdfDataProviderFactory.GetTaskRequestor();
            PdfROLTestTask testTask = dataRequestor.GetNextROLTestData(machineName);
            return JsonConvert.SerializeObject(testTask);
            
        }
    }
}
