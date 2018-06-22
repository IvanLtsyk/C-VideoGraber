using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParserCore.BL
{
    class HTMLLoader
    {
        private readonly HttpClient _client;
        
        public string ParseContentUrl { get; set; }

        public HTMLLoader()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetSourceByPageId()
        {

            var response = await _client.GetAsync(ParseContentUrl);
            string source = null;
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
