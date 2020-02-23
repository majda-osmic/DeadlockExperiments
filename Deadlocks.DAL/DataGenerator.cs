using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Deadlocks.DAL
{
    internal class DataGenerator
    {
        private readonly string _uri = @"https://baconipsum.com/api/?type=meat-and-filler";

        private static readonly Lazy<HttpClient> _lazy = new Lazy<HttpClient>(() => new HttpClient());
        public static HttpClient HttpClientInstance => _lazy.Value;

        internal async Task<string> GenerateDataAsync()
        {
            var responseMessage = await HttpClientInstance.GetAsync(_uri);
            var result = await responseMessage.Content.ReadAsStringAsync();
            return result;
        }

        internal Task<string> GenerateDataAsyncEquivalent()
        {
            var unfinishedResponseMessageTask = HttpClientInstance.GetAsync(_uri);
            var unfinishedReadStringTask = unfinishedResponseMessageTask.ContinueWith(responseMessage => responseMessage.Result.Content.ReadAsStringAsync());
            return unfinishedReadStringTask.Unwrap();
        }

        internal async Task<string> GenerateDataAsync_ConfigureAwait()
        {
            var responseMessage = await HttpClientInstance.GetAsync(_uri).ConfigureAwait(false);
            var result = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return result;
        }
    }
}
