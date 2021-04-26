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

        string arch = @"/Users/gerardo/Documents/UAS-FIC-PSW/JSON/clientes.json";
        // string arch = @"c:\clientes.json";

        List<Persona> Clientes;

        public ClientesController()
        {
            // Abre el archivo json
            StreamReader jsonStream = System.IO.File.OpenText(arch);
            // Leer el archivo json
            string json = jsonStream.ReadToEnd();
            Clientes = JsonConvert.DeserializeObject<List<Persona>>(json);
            jsonStream.Close();

        }

        public void ActualizarJSON()
        {
            string json = JsonConvert.SerializeObject(Clientes);
            StreamReader jsonStream = System.IO.File.OpenText(arch);
            System.IO.File.WriteAllText(arch, json);
            jsonStream.Close();
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
            string json;
            Persona Cliente;
            // Busca cliente con id
            Cliente = Clientes.Find(c => c.id == id);
            // Convierte a json el objeto cliente
            json = JsonConvert.SerializeObject(Cliente);

            return json;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Persona p)
        {
            Persona Cliente = new Persona(p.id, p.nombre, p.edad);
            Clientes.Add(Cliente);

            ActualizarJSON();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Persona p)
        {
            Persona Cliente;
            Cliente = Clientes.Find(c => c.id == id);
            Cliente.id = p.id;
            Cliente.nombre = p.nombre;
            Cliente.edad = p.edad;

            ActualizarJSON();


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Persona Cliente;

            Cliente = Clientes.Find(c => c.id == id);
            Clientes.Remove(Cliente);

            ActualizarJSON();





        }
    }
}
