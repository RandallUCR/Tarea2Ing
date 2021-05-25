using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TareaDDD.Models;
using Domain.Model.Entities;
using Aplication;

namespace TareaDDD.Controllers
{
    public class CursoController : Controller
    {
        private readonly ILogger<CursoController> _logger;

        public CursoController(ILogger<CursoController> logger)
        {
            _logger = logger;
        }

        public IEnumerable<CursoViewModel> consultar(string filtro)
        {
            var listacursos = new CursoService().consultar(filtro);
            List<CursoViewModel> viewModel = new List<CursoViewModel>();

            foreach (Curso item in listacursos)
            {
                viewModel.Add(new CursoViewModel
                {
                    id = item.id,
                    siglas = item.siglas,
                    nombre = item.nombre,
                    creditos = item.creditos,
                    cupos = item.cupos
                }); 
            }
            return viewModel;
        }

        public string consultarById(int id){
            Curso curso = new CursoService().consultarById(id);
            return curso.id + "|" + curso.siglas + "|" + curso.nombre + "|" + curso.creditos + "|" + curso.cupos;
            //return "" + id + "";
        }

        public IActionResult Index()
        {
            ViewBag.lista = this.consultar("");
            return View();
        }

        public IActionResult Filtrar(string busqueda)
        {
            ViewBag.lista = this.consultar(busqueda);
            return View("Index");
        }

        public IActionResult Insertar(string siglas, string nombre, int creditos, int cupos)
        {
            CursoViewModel cvm = new CursoViewModel();
            cvm.siglas = siglas; cvm.nombre = nombre; cvm.creditos = creditos; cvm.cupos = cupos;

            var result = new CursoService().insertar(new Curso(cvm.siglas, cvm.nombre, cvm.creditos, cvm.cupos));

            ViewBag.Message = new MessageViewModel(result).toString();
            ViewBag.lista = this.consultar("");
            return View("Index");
        }

        public int Editar(int id_curso, string siglas_curso, string nombre_curso, int creditos_curso, int cupos_curso) {
            CursoViewModel cvm = new CursoViewModel();
            cvm.id = id_curso;
            cvm.siglas = siglas_curso;
            cvm.nombre = nombre_curso; 
            cvm.creditos = creditos_curso;
            cvm.cupos = cupos_curso;

            var result = new CursoService().editar(new Curso { id = cvm.id, siglas = cvm.siglas, nombre = cvm.nombre, creditos = cvm.creditos, cupos = cvm.cupos });

            ViewBag.Message = new MessageViewModel(result).toString();
            ViewBag.lista = this.consultar("");

            return result;
        }

        public int Eliminar(int id){
            return new CursoService().eliminar(id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
