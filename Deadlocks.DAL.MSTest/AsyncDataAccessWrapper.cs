using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Deadlocks.DAL.MSTest
{
    [TestClass]
    public class AsyncDataAccessWrapperTest
    {

        [TestMethod]
        public async Task V1()
        {
            var result = await new AsyncDataAccessWrapper().GetDataAsync_V1();
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task V2()
        {
            var result = await new AsyncDataAccessWrapper().GetDataAsync_V2();
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task V3()
        {
            var result = await new AsyncDataAccessWrapper().GetDataAsync_V3();
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task V4()
        {
            var result = await new AsyncDataAccessWrapper().GetDataAsync_V4();
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
    }
}
