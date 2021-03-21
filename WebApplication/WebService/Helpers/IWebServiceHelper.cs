using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Helpers
{
    public interface IWebServiceHelper
    {
        // GET
        string Get(string uri);
        Task<string> GetAsync(string uri);

        // POST
        string Post(string uri, string jsonString);
        string Post(string uri, StringContent content);
        Task<string> PostAsync(string uri, string jsonString);
        Task<string> PostAsync(string uri, StringContent content);

        // SOAP
        string SoapService(string uri, string requestString, string soapAction);
        Task<string> SoapServiceAsync(string uri, string requestString, string soapAction);
    }
}
