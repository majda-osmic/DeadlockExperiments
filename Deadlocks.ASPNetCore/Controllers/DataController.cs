using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deadlocks.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deadlocks.ASPNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly AsyncDataAccessWrapper _dataAccess = new AsyncDataAccessWrapper();


        [HttpGet]
        public string Get()
        {
            return "Pick a number";
        }

        [HttpGet("{id}")]
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