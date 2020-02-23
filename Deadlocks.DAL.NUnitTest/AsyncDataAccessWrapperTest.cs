using NUnit.Framework;
using System.Threading.Tasks;

namespace Deadlocks.DAL.NUnitTest
{
    public class Tests
    {
        [Test]
        public async Task V1()
        {
            var result = await new AsyncDataAccessWrapper().GetDataAsync_V1();
            Assert.False(string.IsNullOrEmpty(result));
        }

        [Test]
        public async Task V2()
        {
            var result = await new AsyncDataAccessWrapper().GetDataAsync_V2();
            Assert.False(string.IsNullOrEmpty(result));
        }

        [Test]
        public async Task V3()
        {
            var result = await new AsyncDataAccessWrapper().GetDataAsync_V3();
            Assert.False(string.IsNullOrEmpty(result));
        }

        [Test]
        public async Task V4()
        {
            var result = await new AsyncDataAccessWrapper().GetDataAsync_V4();
            Assert.False(string.IsNullOrEmpty(result));
        }
    }
}