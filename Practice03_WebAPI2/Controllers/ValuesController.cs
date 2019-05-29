using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practice03_WebAPI2.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {

        static List<string> dodams = new List<string>()
        {
            "dodam0","dodam1","dodam2","dodam3","dodam4","dodam5"
        };    
        
        // GET api/values
        public IEnumerable<string> Get()
        {
            return dodams;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return dodams[id];
        }

        // POST api/values
        // CREATE
        public void Post([FromBody]string value)
        {
            dodams.Add(value);
        }


        // PUT api/values/5
        // UPDATE
        public void Put(int id, [FromBody]string value)
        {

            dodams[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            dodams.RemoveAt(id);
        }
    }
}
