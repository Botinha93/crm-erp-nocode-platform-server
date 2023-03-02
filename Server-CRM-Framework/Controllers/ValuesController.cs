using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server_CRM_Framework.Filters;


namespace Server_CRM_Framework.Models
{
    [Route("api/[controller]")]
    [LoginActionFilter]
    public class ValuesController : Controller
    {
        // GET api/<controller>/{entity}
        //Returns the entire library for said entity
        [HttpGet("{entity}")]
        public string Get(string entity)
        {
            return ValuesModel.get(entity);
        }
        // GET api/<controller>/{entity}/{equal}
        // Returns the result of a filtered querry for a entity, it may be a AND or a OR operation, defined by equal=true/false
        [HttpGet("{entity}/{equal}")]
        public string GetComplex(string entity, [FromBody]ExpandoObject value, Boolean equal = false)
        {
            if(value.Count() == 0)
            {
                return Get(entity);
            }
            return ValuesModel.getFilter(entity, value, equal);
        }
        [HttpGet("{entity}/tables/{table}")]
        public string GetTable(string entity, string table)
        {
            foreach(var regEntity in loader.entities)
            {
                if (regEntity.name.Equals(entity))
                {
                    foreach(var regTable in regEntity.tables)
                    {
                        if (regTable.name.Equals(table))
                        {
                            return ValuesModel.getFilter(regEntity.name, System.Text.Json.JsonSerializer.Deserialize<ExpandoObject>(regTable.condiditons), regTable.isEqual);
                        }
                    }
                }
            }
            return "";
        }

        //Usage: api/<controller>/{entity}/id?categoryIds=5f864cd0131362b3d85c29d4&categoryIds=5f873dcc292df694ef97b860
        //Returns one or more Itens by internal ID
        [HttpGet("{entity}/id")]
        public string GetID(string entity, [FromQuery] String[] categoryIds)
        {
            return ValuesModel.getID(entity, categoryIds);
        }
       // POST api/<controller>
       [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        //PUT api/{entity}
        //Puts a single entry for entity in the DB
        [HttpPut("{entity}")]
        public void Put(string entity, [FromBody]ExpandoObject value)
        {
            var data =  "{\"data\" : \""+DateTime.Now.ToString("yyyy-MM-dd")+"\"}";
            value.TryAdd("data", System.Text.Json.JsonSerializer.Deserialize<ExpandoObject>(data).First().Value);
            var owner = "{\"owner\" : \"" + UserModel.getUserFromToken(HttpContext.Request.Headers["token"])._id + "\"}";
            value.TryAdd("owner", System.Text.Json.JsonSerializer.Deserialize<ExpandoObject>(owner).First().Value);
            var active = "{\"active\" : false }";
            value.TryAdd("active", System.Text.Json.JsonSerializer.Deserialize<ExpandoObject>(active).First().Value);
            ValuesModel.Put(entity, value);
        }
        //Usage: api/<controller>/{entity}/id?categoryIds=5f864cd0131362b3d85c29d4
        //Updates values for registry categoryId
        [HttpPut("{entity}/id")]
        public void Update(string entity, [FromBody]ExpandoObject value, [FromQuery] String[] categoryIds)
        {
            if (categoryIds.Length > 1)
            {
                ValuesModel.Update(entity, categoryIds, value);
            }
            else
                ValuesModel.Update(entity, categoryIds[0], value);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{entity}/id")]
        public void Delete(string entity, [FromQuery] String[] categoryIds)
        {
            if (categoryIds.Length > 1)
            {
                ValuesModel.Delete(entity, categoryIds );
            }
            else
                ValuesModel.Delete(entity, categoryIds[0]);

        }
        public IActionResult Index()
        {
            return View();
        }



    }
}
