using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proy_04.Models;

namespace Proy_04
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {

        string arch = @"JSON/clientes.json";

        List<Persona> Clientes;

        private void CargarJSON()
        {
            // Abre el archivo json
            StreamReader jsonStream = System.IO.File.OpenText(arch);
            // Leer el archivo json
            string json = jsonStream.ReadToEnd();
            Clientes = JsonConvert.DeserializeObject<List<Persona>>(json);
            jsonStream.Close();

        }

        private void ActualizarJSON()
        {
            string json = JsonConvert.SerializeObject(Clientes);
            StreamReader jsonStream = System.IO.File.OpenText(arch);
            System.IO.File.WriteAllText(arch, json);
            jsonStream.Close();
        }

        // GET: api/values
        [HttpGet]
        public ActionResult Get()
        {
            string json;
            ClientesResultados Resultado = new ClientesResultados();
            try
            {
                CargarJSON();
                if (Clientes.Count > 0)
                {
                    json = JsonConvert.SerializeObject(Clientes);
                    Resultado.JSON = json;
                }
                else
                    throw new ClientesException("No hay Clientes");
            }
            catch (ClientesException ex)
            {
                Resultado.estado = false;
                Resultado.MensajeError = ex.Message;
            }
            catch (IOException )
            {
                Resultado.estado = false;

                Resultado.MensajeError = "Error en la fuente de datos";
            }
            catch (Exception ex)
            {
                Resultado.estado = false;

                Resultado.MensajeError = ex.Message;
            }
            
            return Ok(Resultado);
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            string json;
            Persona Cliente;
            ClientesResultados Resultado = new ClientesResultados();
            try
            {

                CargarJSON();
                // Busca cliente con id
                Cliente = Clientes.Find(c => c.id == id);

                if (Cliente == null)
                    throw new ClientesException("No existe el Cliente");

                // Convierte a json el objeto cliente
                json = JsonConvert.SerializeObject(Cliente);
                Resultado.JSON = json;
            }
            catch (ClientesException ex)
            {
                Resultado.estado = false;
                Resultado.MensajeError = ex.Message;
            }

            return Ok(Resultado);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Persona p)
        {
            Persona Cliente=null;
            string json;
            ClientesResultados Resultado = new ClientesResultados();
            try
            {
                CargarJSON();
                // Busca cliente con id
                Cliente = Clientes.Find(c => c.id == p.id);

                if (Cliente != null)
                    throw new ClientesException("El Id del Cliente ya esta en uso");

                Cliente = new Persona(p.id, p.nombre, p.edad);
                Clientes.Add(Cliente);
                ActualizarJSON();
            }
            catch (ClientesException ex){
                Resultado.estado = false;
                Resultado.MensajeError = ex.Message;
            }
            finally
            {
                json = JsonConvert.SerializeObject(Cliente);
                Resultado.JSON = json;
            }

            return Ok(Resultado);


        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Persona p)
        {
            Persona Cliente = null;
            string json;
            ClientesResultados Resultado = new ClientesResultados();
            try
            {

                CargarJSON();
                // Busca cliente con id
                Cliente = Clientes.Find(c => c.id == id);

                if (Cliente == null)
                    throw new ClientesException(string.Format("El Id {0:D} del Cliente no existe",id));

                Cliente.id = p.id;
                Cliente.nombre = p.nombre;
                Cliente.edad = p.edad;

                ActualizarJSON();
            }
            catch (ClientesException ex)
            {
                Resultado.estado = false;
                Resultado.MensajeError = ex.Message;
                Cliente = p;
            }
            finally
            {
                json = JsonConvert.SerializeObject(Cliente);
                Resultado.JSON = json;
            }

            return Ok(Resultado);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Persona Cliente;
            ClientesResultados Resultado = new ClientesResultados();
            try
            {
                CargarJSON();
                // Busca cliente con id
                Cliente = Clientes.Find(c => c.id == id);

                if (Cliente == null)
                    throw new ClientesException(string.Format("No existe el Cliente con Id {0:D}",id));

                string json = JsonConvert.SerializeObject(Cliente);
                Resultado.JSON = json;
                Clientes.Remove(Cliente);
                ActualizarJSON();
            }
            catch(ClientesException ex)
            {
                Resultado.estado = false;
                Resultado.MensajeError = ex.Message;
            }
  

            return Ok(Resultado);
        }

    }
}