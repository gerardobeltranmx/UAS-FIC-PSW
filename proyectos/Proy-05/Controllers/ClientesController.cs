using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proy_05.Helpers;
using Proy_05.Models;

namespace Proy_05.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {

        // GET: api/values
        [HttpGet("Todos")]
        public ActionResult Todos()
        {
            ClientesResult Respuesta = new ClientesResult();

            Datos db = new Datos();

            try
            {
                if (db.Clientes != null)
                {
                 //  string json = JsonConvert.SerializeObject(db.Clientes);
                    Respuesta.Datos = db.Clientes.ToList();  //  json;
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

        // GET: api/values
        [HttpGet("TodosOrdenadosPorNombre")]
        public ActionResult TodosOrdenadosPorNombre()
        {
            ClientesResult Respuesta = new ClientesResult();

            Datos db = new Datos();


            // Acceso con Linq to SQL (Ordenamiento)
            var ListaClientes = from c in db.Clientes orderby c.edad select c;
                                    


            try
            {
                if (ListaClientes != null)
                {
                    //  string json = JsonConvert.SerializeObject(db.Clientes);
                    Respuesta.Datos = ListaClientes;  //  json;
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
        [HttpGet("Buscar/{id}")]
        public ActionResult Buscar(int id)
        {

            string json;
            Cliente BuscarCliente;
            ClientesResult Respuesta = new ClientesResult();
            // Busca cliente con id

            try
            {
                Datos db = new Datos();
                BuscarCliente = db.Clientes.Find(id);

                if (BuscarCliente == null)
                {
                    throw new ClientesException("Cliente no existe");
                }
                else
                {
                    // Convierte a json el objeto cliente
                   // json = JsonConvert.SerializeObject(BuscarCliente);
                    Respuesta.estado = true;
                    Respuesta.Datos = BuscarCliente;

                }
            }
            catch (ClientesException ex)
            {
                Respuesta.estado = false;
                Respuesta.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                Respuesta.estado = false;
                Respuesta.Mensaje = ex.Message;
            }


            return Ok(Respuesta);
        }


        // POST api/values
        [HttpPost("Nuevo")]
        public ActionResult Nuevo([FromBody] Cliente c)
        {
            ClientesResult Respuesta = new ClientesResult();

            try
            {
                Datos db = new Datos();
                Cliente ClienteBuscar, ClienteNuevo;
                ClienteBuscar = db.Clientes.Find(c.id);

                if (ClienteBuscar == null)
                {
                    ClienteNuevo = new Cliente(c.nombre, c.edad);
                    db.Clientes.Add(ClienteNuevo);
                    db.SaveChanges();
                    Respuesta.Datos = ClienteNuevo;
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
            catch (Exception ex)
            {
                Respuesta.estado = false;
                Respuesta.Mensaje = ex.Message;
            }


            return Ok(Respuesta);
        }


        // PUT api/values/5
        [HttpPut("Actualizar/{id}")]
        public ActionResult Actualizar(int id, [FromBody] Cliente c)
        {

             Cliente BuscarCliente;
            ClientesResult Respuesta = new ClientesResult();
            try
            {
                Datos db = new Datos();
                BuscarCliente = db.Clientes.Find(id);

                if (BuscarCliente == null)
                {
                    throw new ClientesException("Cliente no existe");
                }
                else
                {
                    BuscarCliente.nombre = c.nombre;
                    BuscarCliente.edad = c.edad;
                    db.SaveChanges();
                    Respuesta.estado = true;
                    Respuesta.Datos = BuscarCliente;

                }
  
            }
            catch (ClientesException ex)
            {
                Respuesta.estado = false;
                Respuesta.Mensaje = ex.Message;
                Respuesta.Datos = c;
            }
            catch(Exception )
            {
                Respuesta.estado = false;
                Respuesta.Mensaje = "Se presento un error en el sistema, consulta al administrador";
                Respuesta.Datos =c;

            }
            return Ok(Respuesta);

        }
        // DELETE api/values/5
        [HttpDelete("Eliminar/{id}")]
        public ActionResult Eliminar(int id)
        {
            ClientesResult Respuesta = new ClientesResult();

            Cliente BuscarCliente;
            try
            {
                Datos db = new Datos();
                BuscarCliente = db.Clientes.Find(id);

                if (BuscarCliente == null)
                {
                    throw new ClientesException("Cliente no existe para borrar!"); 
                }
                else {
                    db.Clientes.Remove(BuscarCliente);

                    db.SaveChanges();
                    Respuesta.estado = true;
                    Respuesta.Datos = BuscarCliente;
                }

            }
            catch(ClientesException ex)
            {
                Respuesta.estado = false;
                Respuesta.Mensaje = ex.Message;
            }
            catch (Exception)
            {
                Respuesta.estado = false;
                Respuesta.Mensaje = "Falla en el sistema reporte al administrador!";
            }

            return Ok(Respuesta);
        }

    }
}
