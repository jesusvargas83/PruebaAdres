using AddresFront.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AddresFront.Servicios;
using System.Security.Cryptography.X509Certificates;

namespace AddresFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicio _servicio;

        public HomeController(IServicio servicio)
        {
           _servicio = servicio;
        }

        public IActionResult Inicio()
        {
            ViewBag.Title = "Adres";
            return View();
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Gestión de Adquisiciones";
            List<Adquisicion> lista = await _servicio.Lista();
            return View(lista);
        }

        public async Task<IActionResult> Historial()
        {
            ViewBag.Title = "Historial de Adquisiciones";
            List<Historial> lista = await _servicio.Historial();
            return View(lista);
        }

        public async Task<IActionResult> Adquisicion(int id)
        {
            var modelo = new Adquisicion();
            ViewBag.Accion = "Nueva Adquisición";
            if (id != 0) {
                modelo = await _servicio.Obtener(id);
                ViewBag.Accion = "Editar Adquisición";
            }

            return View(modelo);
        }

        public async Task<IActionResult> GuardarCambios(Adquisicion objeto)
        {
            bool respuesta;
            var modelo = new Adquisicion();

            if (objeto.Id == 0)
            {
                respuesta = await _servicio.Guardar(objeto);

            }
            else {
                respuesta = await _servicio.Editar(objeto);
            }

            if (respuesta)
                return RedirectToAction("Index");
            else 
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var respuesta = await _servicio.Eliminar(Id);

            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
