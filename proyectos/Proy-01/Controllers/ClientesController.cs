﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proy_01.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            return "Estos son todos los clientes!!!!";
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Este es el cliente numero: " + id.ToString() ;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
