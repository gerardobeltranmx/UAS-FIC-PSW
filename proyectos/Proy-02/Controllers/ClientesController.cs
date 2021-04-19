using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proy_02.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proy_02.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        
        List<Persona> Clientes = new List<Persona>();

        public ClientesController()
        {
            Clientes.Add(new Persona(1, "Hugo", 11));
            Clientes.Add(new Persona(2, "Paco", 12));
            Clientes.Add(new Persona(3, "Luis", 13));
        }

        // GET: api/values
        [HttpGet]
        public string Get()
        {
            string json;

            json = JsonConvert.SerializeObject(Clientes);

            return json;
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
