using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RESTfulBestPathAPI.Controllers
{
    [Route("api/[controller]")]
    public class MapsController : Controller
    {
        // GET api/values LEAVE FOR SANITY CHECK
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "working", "GET" };
        }
        //----------------------------------------------

		// GET api/maps/{mapID}/path/{endID}
		[HttpGet("{id}/path/{start}/{end}")]
        public string Get(string id, string start, string end)
        {
			if (id== "testmap"){
				return "access testmap success";
			}
            return "value";
        }

		// PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}
       
        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
