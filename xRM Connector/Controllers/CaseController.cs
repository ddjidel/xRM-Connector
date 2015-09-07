using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace xRM_Connector.Controllers
{
    public class CaseController : ApiController
    {
        // GET: api/Case
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Case/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Case
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Case/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Case/5
        public void Delete(int id)
        {
        }
    }
}
