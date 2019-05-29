using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practice03_WebAPI2.Controllers
{
    public class MybookController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "mybook1", "mybook2","mybook3" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "mybook of " + id; 
        }
    }
}
