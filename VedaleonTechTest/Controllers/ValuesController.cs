using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VedaleonTechTest.Controllers
{
    public class ValuesController : ApiController
    {
        string[] items = { "value1", "value2", "value3", "value4" };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return items;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return items[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
