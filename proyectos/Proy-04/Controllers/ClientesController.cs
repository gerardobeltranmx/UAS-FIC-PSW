using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proy_04.Models;

namespace Proy_04.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {

        string arch = @"JSON/clientes.json";
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
            ClientesResult Respuesta = new ClientesResult();

            try
            {
                if (Clientes.Count > 0)
                {
                    json = JsonConvert.SerializeObject(Clientes);
                    Respuesta.JSON = json;
                }
                else
                    throw new ClientesException("No tenemos clientes para mostrar");
            }
            catch (ClientesException ex)
            {
                Respuesta.estado = false;
                Respuesta.Mensaje = ex.Message;
            }

            return Ok(Respuesta);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            string json;
            Persona Cliente;
            ClientesResult Respuesta = new ClientesResult();
            // Busca cliente con id

            try
            {
                Cliente = Clientes.Find(c => c.id == id);

                if (Cliente == null)
                {
                    throw new ClientesException("Cliente no existe");
                }
                else
                {
                    // Convierte a json el objeto cliente
                    json = JsonConvert.SerializeObject(Cliente);
                    Respuesta.estado = true;
                    Respuesta.JSON = json;

                }
            }
            catch(ClientesException ex)
            {
                Respuesta.estado = false;
                Respuesta.Mensaje = ex.Message;
            }


            return Ok(Respuesta);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Persona p)
        {
            ClientesResult Respuesta = new ClientesResult();

            try
            {
                Persona ClienteBuscar, ClienteNuevo;
                ClienteBuscar = Clientes.Find(c => c.id == p.id);

                if (ClienteBuscar == null) {
                    ClienteNuevo = new Persona(p.id, p.nombre, p.edad);
                    Clientes.Add(ClienteNuevo);
                    ActualizarJSON();
                    Respuesta.JSON = JsonConvert.SerializeObject(ClienteNuevo);
                }
                else
                {
                    throw new ClientesException("El Id ya esta en uso");
                }

            }
            catch (ClientesException ex)
            {
                Respuesta.estado = false;
                Respuesta.Mensaje = ex.Message;
            }


            return Ok(Respuesta);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Persona p)
        {

            Persona Cliente, ClienteBuscar;
            ClientesResult Respuesta = new ClientesResult();
            try
            {
                Cliente = Clientes.Find(c => c.id == id);

                if (Cliente == null)
                {
                    throw new ClientesException("Cliente no existe");
                }

                

                ClienteBuscar = Clientes.Find(c => c.id == p.id);

                if (ClienteBuscar == null)
                {
                    Cliente.id = p.id;
                    Cliente.nombre = p.nombre;
                    Cliente.edad = p.edad;
                    Respuesta.JSON = JsonConvert.SerializeObject(p);
                    ActualizarJSON();
                }
                else
                {
                    throw new ClientesException("El Id " + p.id +
                                    " Ya esta en uso por el cliente: " + ClienteBuscar.nombre);
                }
            }
            catch (ClientesException ex) {
                Respuesta.estado = false;
                Respuesta.Mensaje = ex.Message;
                Respuesta.JSON = JsonConvert.SerializeObject(p);
            }
            return Ok(Respuesta);

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
