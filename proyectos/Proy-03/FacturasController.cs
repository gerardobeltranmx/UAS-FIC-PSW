using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proy_03.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proy_03
{
    [Route("api/[controller]")]
    public class FacturasController : Controller
    {
        string arch = @"JSON/facturas.json";
        // string arch = @"c:\clientes.json";

        List<Factura> Facturas;

        public FacturasController()
        {
            // Abre el archivo json
            StreamReader jsonStream = System.IO.File.OpenText(arch);
            // Leer el archivo json
            string json = jsonStream.ReadToEnd();
            Facturas = JsonConvert.DeserializeObject<List<Factura>>(json);
            jsonStream.Close();

        }

        private void ActualizarJSON()
        {
            string json = JsonConvert.SerializeObject(Facturas);
            StreamReader jsonStream = System.IO.File.OpenText(arch);
            System.IO.File.WriteAllText(arch, json);
            jsonStream.Close();
        }


      
        [HttpGet()]
        public string Get()
        {
            string json;
            json = JsonConvert.SerializeObject(Facturas);
            return json;
        }


        // GET api/values/5
        [HttpGet("/api/clientes/{idCliente}/facturas")] // api/1/facturas
        public string Get(int idCliente)
        {
            string json;

            List<Factura> FacturasCliente;
            FacturasCliente = Facturas.Where(f => f.idCliente == idCliente).ToList();

            json = JsonConvert.SerializeObject(FacturasCliente);
            return json;
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
