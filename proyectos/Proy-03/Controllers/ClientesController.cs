using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proy_03.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proy_03.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {

        string arch = @"/Users/gerardo/JSON/clientes.json";
        // string arch = @"c:\clientes.json";

        List<Persona> Clientes;

        public ClientesController()
        {
            // Abre el archivo json
            StreamReader jsonStream = System.IO.File.OpenText(arch);
            // Leer el archivo json
            string json = jsonStream.ReadToEnd();
            Clientes = JsonConvert.DeserializeObject<List<Persona>>(json);

        }



        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
