using Deadlocks.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Deadlocks.ASPNet.Controllers
{
    public class DataController : ApiController
    {
        private readonly AsyncDataAccessWrapper _dataAccess = new AsyncDataAccessWrapper();


        [HttpGet]
        public string Get() => "Pick a number";

        [HttpGet]
        public async Task<string> Get(int id)
        {
            switch (id)
            {
                case 1: return await _dataAccess.GetDataAsync_V1();
                case 2: return await _dataAccess.GetDataAsync_V2();
                case 3: return await _dataAccess.GetDataAsync_V3();
                case 4: return await _dataAccess.GetDataAsync_V4();
            }
            return "Try again";
        }
    }
}
