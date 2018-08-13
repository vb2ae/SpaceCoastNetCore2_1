using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using spaceCoastNetCore2.Demo.Models;

namespace spaceCoastNetCore2.Demo.Controllers
{
    [Route("api/[controller]")]
    public class SQLiteController : Controller
    {
        IDataAccess dataAccess;

        public SQLiteController(IDataAccess data)
        {
            dataAccess = data;
        }


        // GET: api/values
        [HttpGet]
        public List<Name> Get()
        {
            return dataAccess.GetNames();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Name Get(int id)
        {
            return dataAccess.GetName(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            dataAccess.InsertName(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            dataAccess.UpdateName(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dataAccess.DeleteName(id);
        }
    }

}
