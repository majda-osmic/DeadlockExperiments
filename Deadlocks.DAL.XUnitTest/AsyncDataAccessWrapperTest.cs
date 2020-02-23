using System;
using System.Threading.Tasks;
using Xunit;

namespace Deadlocks.DAL.XUnitTest
{
    public class AsyncDataAccessWrapperTest
    {
        [Fact]
        public async Task V1()
        {
            var result = await new AsyncDataAccessWrapper().GetDataAsync_V1();
            Assert.False(string.IsNullOrEmpty(result));
        }

        [Fact]
        public async Task V2()
        {
            var result = await new AsyncDataAccessWrapper().GetDataAsync_V2();
            Assert.False(string.IsNullOrEmpty(result));
        }

        [Fact]
        public async Task V3()
        {
            var result = await new AsyncDataAccessWrapper().GetDataAsync_V3();
            Assert.False(string.IsNullOrEmpty(result));
        }

        [Fact]
        public async Task V4()
        {
            var result = await new AsyncDataAccessWrapper().GetDataAsync_V4();
            Assert.False(string.IsNullOrEmpty(result));
        }
    }
}
