using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proy_02.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        
        List<Models.Persona> Clientes = new List<Models.Persona>();

        public ClientesController()
        {
            Clientes.Add(new Models.Persona(1, "Hugo", 11));
            Clientes.Add(new Models.Persona(2, "Paco", 12));
            Clientes.Add(new Models.Persona(3, "Luis", 13));
        }

        // GET: api/values
        [HttpGet]
        public string Get()
        {
            return "cadena2";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
