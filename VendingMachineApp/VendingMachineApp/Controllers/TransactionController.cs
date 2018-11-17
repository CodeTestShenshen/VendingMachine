﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VendingMachineApp.Controllers
{
    public class TransactionController : ApiController
    {
        // GET: api/Transaction
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Transaction/5
        [HttpGet]
        [Route ("Machine/{machineId}/Transaction/{id}")]
        public string Get(int machineId, int id)
        {
            return "value123";
        }

        // POST: api/Transaction
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Transaction/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Transaction/5
        public void Delete(int id)
        {
        }
    }
}