using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    /*
     config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ); 
     */
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" }; // 전체조회 select * from emp
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value"; // 조건조회 select * from emp where empno=7788
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            // insert ... >> insert into
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            // update >> update emp ....
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            // delete from emp...
        }
    }
}
