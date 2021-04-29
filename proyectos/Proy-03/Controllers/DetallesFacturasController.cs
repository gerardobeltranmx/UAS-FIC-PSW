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
    public class DetallesFacturasController : Controller
    {

        string arch = @"JSON/detallesFacturas.json";
        
        List<DetalleFactura> Detalles;

        public DetallesFacturasController()
        {
            // Abre el archivo json
            StreamReader jsonStream = System.IO.File.OpenText(arch);
            // Leer el archivo json
            string json = jsonStream.ReadToEnd();
            Detalles = JsonConvert.DeserializeObject<List<DetalleFactura>>(json);
            jsonStream.Close();

        }

        private void ActualizarJSON()
        {
            string json = JsonConvert.SerializeObject(Detalles);
            StreamReader jsonStream = System.IO.File.OpenText(arch);
            System.IO.File.WriteAllText(arch, json);
            jsonStream.Close();
        }



        // GET: api/values
        [HttpGet]
        public string Get()
        {
            string json;
            json = JsonConvert.SerializeObject(Detalles);
            return json;
        }

        // GET api/values/5
        [HttpGet("/api/facturas/{idFactura}/detalles")]
        public string Get(int idFactura)
        {
            string json;
            List<DetalleFactura> DetallesFiltrado;
            DetallesFiltrado = Detalles.Where(d => d.idFactura == idFactura).ToList();

            json = JsonConvert.SerializeObject(DetallesFiltrado);

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
