using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebLibrary;
using WebLibrary.Helpers;

namespace WebService.Helpers
{
    public class WebServiceHelper : IWebServiceHelper
    {
        private static readonly TimeSpan s_postTimeOut = TimeSpan.FromMilliseconds(ConfigHelper.AllConfig.HttpClientTimeOut.ToInt32());

        public WebServiceHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private readonly IHttpClientFactory _httpClientFactory;

        public string Get(string uri)
        {
            return GetAsync(uri).GetAwaiter().GetResult();
        }

        public async Task<string> GetAsync(string uri)
        {
            var response = await CreateHttpClient().GetAsync(uri);
            return await response.Content.ReadAsStringAsync();
        }

        public string Post(string uri, string jsonString)
        {
            return PostAsync(uri, jsonString).GetAwaiter().GetResult();
        }

        public string Post(string uri, StringContent content)
        {
            return PostAsync(uri, content).GetAwaiter().GetResult();
        }

        public Task<string> PostAsync(string uri, string jsonString)
        {
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return PostAsync(uri, content);
        }

        public async Task<string> PostAsync(string uri, StringContent content)
        {
            var response = await CreateHttpClient().PostAsync(uri, content);
            return await response.Content.ReadAsStringAsync();
        }

        public string SoapService(string uri, string requestString, string soapAction)
        {
            return SoapServiceAsync(uri, requestString, soapAction).GetAwaiter().GetResult();
        }

        public async Task<string> SoapServiceAsync(string uri, string requestString, string soapAction)
        {
            var client = CreateHttpClient();

            using var contentPost = new StringContent(requestString, Encoding.UTF8, "text/xml");
            contentPost.Headers.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            contentPost.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
            contentPost.Headers.Add("SoapAction", soapAction);

            var response = await client.PostAsync(uri, contentPost);
            return await response.Content.ReadAsStringAsync();
        }

        private HttpClient CreateHttpClient()
        {
            var client = _httpClientFactory.CreateClient();
            client.Timeout = s_postTimeOut;

            return client;
        }
    }
}
