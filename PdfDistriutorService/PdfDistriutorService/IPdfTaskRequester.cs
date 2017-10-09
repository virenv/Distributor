using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PdfDistriutorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPdfTaskRequester" in both code and config file together.
    [ServiceContract]
    public interface IPdfTaskRequester
    {
        [WebGet(UriTemplate = "RequestTask/{machineName}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string RequestPdfROLTask(string machineName);
    }
}
