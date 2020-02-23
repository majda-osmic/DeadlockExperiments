using System;
using System.Threading.Tasks;

namespace Deadlocks.DAL
{
    public class AsyncDataAccessWrapper
    {
        private readonly DataGenerator _generator;

        public AsyncDataAccessWrapper()
        {
            _generator = new DataGenerator();
        }

        public async Task<string> GetDataAsync_V1()
        {
            return await _generator.GenerateDataAsync_NoConfigureAwait();
        }

        public async Task<string> GetDataAsync_V2()
        {
            return _generator.GenerateDataAsync_NoConfigureAwait().Result;
        }

        public async Task<string> GetDataAsync_V3()
        {
            return await _generator.GenerateDataAsync_ConfigureAwait();
        }

        public async Task<string> GetDataAsync_V4()
        {
            return _generator.GenerateDataAsync_ConfigureAwait().Result;
        }
    }
}
