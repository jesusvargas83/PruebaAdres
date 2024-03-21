using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdresBack.Models;
using System.Diagnostics.Contracts;
using System;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;



namespace AdresBack.Controllers
{
    [EnableCors()]
    [Route("api/[controller]")]
    [ApiController]
    public class AdquisicionController : ControllerBase
    {

        public readonly ADQUISICIONESContext _dbcontext;

        public AdquisicionController(ADQUISICIONESContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("lista")]
        public IActionResult ListarAdquisiciones()
        {
            List<Adquisicion> Lista = new List<Adquisicion>();

            try
            {
                Lista = _dbcontext.Adquisiciones.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", response = Lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = "Lista" });
            }
        }

        [HttpGet]
        [Route("historial")]
        public IActionResult Historial()
        {
            List<Historial> Lista = new List<Historial>();

            try
            {
                Lista = _dbcontext.Historial.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", response = Lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = "Lista" });
            }
        }

        [HttpGet]
        [Route("obtener/{id:int}")]
        public IActionResult Obtener(int id)
        {
            var objeto = _dbcontext.Adquisiciones.Find(id);
            if (objeto == null)
            {
                return BadRequest("No se encontró !!");
            }

            try
            {
                objeto = _dbcontext.Adquisiciones.Where(p => p.Id == id).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", response = objeto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = objeto });
            }
        }

        [HttpPost]
        [Route("guardar")]
        public ActionResult Guardar([FromBody] Adquisicion objeto)
        {
            try
            {
               var obj = _dbcontext.Adquisiciones.Add(objeto);

                var oHistorial = new Historial();
                oHistorial.IdAdquisicion = obj.Entity.Id;
                oHistorial.Fecha = DateTime.Now;
                oHistorial.Descripcion = JsonConvert.SerializeObject(objeto);
                oHistorial.Tipo = "C";
              
                _dbcontext.SaveChanges();
                oHistorial.IdAdquisicion = obj.Entity.Id;
                _dbcontext.Historial.Add(oHistorial);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        [HttpPut]
        [Route("editar")]
        public ActionResult Editar([FromBody] Adquisicion objeto)
        {
            var oAdquisicion = _dbcontext.Adquisiciones.Find(objeto.Id);
            if (oAdquisicion == null)
            {
                return BadRequest("No se encontró !!");
            }

            try
            {
                

                oAdquisicion.Presupuesto =  objeto.Presupuesto;
                oAdquisicion.UnidadAdministrativa =  objeto.UnidadAdministrativa;
                oAdquisicion.BienesServicios = objeto.BienesServicios;
                oAdquisicion.Cantidad =  objeto.Cantidad;
                oAdquisicion.ValorUnitario =  objeto.ValorUnitario;
                oAdquisicion.ValorUnitario =  objeto.ValorTotal;
                oAdquisicion.FechaAdquisicion =  objeto.FechaAdquisicion;
                oAdquisicion.EntidadProveedora =  objeto.EntidadProveedora;
                oAdquisicion.Documentacion =  objeto.Documentacion;

                _dbcontext.Adquisiciones.Update(oAdquisicion);
                _dbcontext.SaveChanges();

                //GUARDAR EN HISTORICO
                var oHistorial = new Historial();

                oHistorial.IdAdquisicion = objeto.Id;
                oHistorial.Fecha = DateTime.Now;
                oHistorial.Descripcion = JsonConvert.SerializeObject(oAdquisicion);
                oHistorial.Tipo = "A";
                _dbcontext.Historial.Add(oHistorial);
               
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public IActionResult Eliminar(int id) {
            var oAdquisicion = _dbcontext.Adquisiciones.Find(id);
            if (oAdquisicion == null)
            {
                return BadRequest("No se encontró !!");
            }

            try
            {

                _dbcontext.Adquisiciones.Remove(oAdquisicion);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }
    }
}
