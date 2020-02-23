using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Deadlocks.DAL
{
    internal class DataGenerator
    {
        private readonly HttpClient _httpClient = new HttpClient(); //TODO: lazy singleton
        private readonly string _uri = @"https://baconipsum.com/api/?type=meat-and-filler";

        internal async Task<string> GenerateDataAsync()
        {
            var responseMessage = await _httpClient.GetAsync(_uri);
            var result = await responseMessage.Content.ReadAsStringAsync();
            return result;
        }

        internal async Task<string> GenerateDataAsync_ConfigureAwait()
        {
            var responseMessage = await _httpClient.GetAsync(_uri).ConfigureAwait(false);
            var result = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return result;
        }
    }
}
