using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Practice05_MacaronsData;

namespace Practice05_MacaronAPI.Controllers
{
    public class MacaronController : ApiController
    {

        public IEnumerable<Macaron> Get()
        {
            using (MacaronsEntity entities = new MacaronsEntity())
            {
                return entities.Macarons.ToList();
            }
        }

        //public Macaron Get(int id)
        //{
        //    using (MacaronsEntity entities = new MacaronsEntity())
        //    {
        //        return entities.Macarons.FirstOrDefault(e => e.ID == id);
        //    }
        //}

        public HttpResponseMessage Get(int id)
        {
            using (MacaronsEntity entities = new MacaronsEntity())
            {
                var entity = entities.Macarons.FirstOrDefault(e => e.ID == id);

                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Macaron with ID  " + id.ToString() + " is not exist, please check again");
                }
            }
        }

    }
}
