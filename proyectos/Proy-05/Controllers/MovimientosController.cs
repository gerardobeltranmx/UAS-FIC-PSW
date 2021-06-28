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
    public class MovimientosController : Controller
    {

        // GET: api/values
        [HttpGet("Todos")]
        public ActionResult Todos()
        {
            MovimientosResult Respuesta = new MovimientosResult();

            Datos db = new Datos();

            try
            {
                if (db.Movimientos != null)
                {
                 //  string json = JsonConvert.SerializeObject(db.Movimientos);
                    Respuesta.Datos = db.Movimientos.ToList();  //  json;
                }
                else
                    throw new MovimientosException("No tenemos Movimientos para mostrar");
            }
            catch (MovimientosException ex)
            {
                Respuesta.estado = false;
                Respuesta.Mensaje = ex.Message;
            }

            return Ok(Respuesta);

        }

        // GET: api/values
        [HttpGet("TodosOrdenadosPorCliente")]
        public ActionResult TodosOrdenadosPorNombre()
        {
            MovimientosResult Respuesta = new MovimientosResult();

            Datos db = new Datos();


            // Acceso con Linq to SQL (Ordenamiento)
            // Select * from Movimientos order by edad
            // var ListaMovimientos = from c in db.Movimientos orderby c.edad select c;
            // Select id, nombre from Movimientos order by nombre;                      
            var ListaMovimientos = from c in db.Movimientos
                                    orderby c.idcliente
                                    select new {
                                                c.id,
                                                c.tipo,
                                                c.cantidad

                                            };


            try
            {
                if (ListaMovimientos != null)
                {
                    //  string json = JsonConvert.SerializeObject(db.Movimientos);
                    Respuesta.Datos = ListaMovimientos;  //  json;
                }
                else
                    throw new MovimientosException("No tenemos Movimientos para mostrar");
            }
            catch (MovimientosException ex)
            {
                Respuesta.estado = false;
                Respuesta.Mensaje = ex.Message;
            }

            return Ok(Respuesta);

        }



        /*
        // GET api/values/5
        [HttpGet("Buscar/{id}")]
        public ActionResult Buscar(int id)
        {

            string json;
            Cliente BuscarCliente;
            MovimientosResult Respuesta = new MovimientosResult();
            // Busca cliente con id

            try
            {
                Datos db = new Datos();
                //BuscarCliente = db.Movimientos.Find(id);
                // Buscar cliente usando Linq to SQL
                BuscarCliente = (from c in db.Movimientos
                                 where c.id == id
                                 select c).FirstOrDefault<Cliente>();

                if (BuscarCliente == null)
                {
                    throw new MovimientosException("Cliente no existe");
                }
                else
                {
                    // Convierte a json el objeto cliente
                   // json = JsonConvert.SerializeObject(BuscarCliente);
                    Respuesta.estado = true;
                    Respuesta.Datos = BuscarCliente;

                }
            }
            catch (MovimientosException ex)
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
            MovimientosResult Respuesta = new MovimientosResult();

            try
            {
                Datos db = new Datos();
                Cliente ClienteBuscar, ClienteNuevo;
                ClienteBuscar = db.Movimientos.Find(c.id);

                if (ClienteBuscar == null)
                {
                    ClienteNuevo = new Cliente(c.nombre, c.edad);
                    db.Movimientos.Add(ClienteNuevo);
                    db.SaveChanges();
                    Respuesta.Datos = ClienteNuevo;
                }
                else
                {
                    throw new MovimientosException("El Id ya esta en uso");
                }

            }
            catch (MovimientosException ex)
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
            MovimientosResult Respuesta = new MovimientosResult();
            try
            {
                Datos db = new Datos();
                BuscarCliente = db.Movimientos.Find(id);

                if (BuscarCliente == null)
                {
                    throw new MovimientosException("Cliente no existe");
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
            catch (MovimientosException ex)
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
            MovimientosResult Respuesta = new MovimientosResult();

            Cliente BuscarCliente;
            try
            {
                Datos db = new Datos();
                BuscarCliente = db.Movimientos.Find(id);

                if (BuscarCliente == null)
                {
                    throw new MovimientosException("Cliente no existe para borrar!"); 
                }
                else {
                    db.Movimientos.Remove(BuscarCliente);

                    db.SaveChanges();
                    Respuesta.estado = true;
                    Respuesta.Datos = BuscarCliente;
                }

            }
            catch(MovimientosException ex)
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
          */
    }
}
