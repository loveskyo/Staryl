using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Staryl.API.Controllers
{
    public class WeixinController : BaseController
    {
        // GET api/login
        [HttpGet]
        public HttpResponseMessage Get()
        {
            string[] values = new string[] { "value1", "value2" };
            return values.toJson();  
        }

        // GET api/login/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/login
        [HttpPost]
        public void Post([FromBody]string value)
        {
            string v = Convert.ToString(HttpContext.Current.Session["a"]);
        }

        // PUT api/login/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/login/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
