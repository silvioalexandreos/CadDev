using Business.Report;
using Business.Repository;
using Business.Repository.Service.Developer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DeveloperController : Controller
    {
        private IDeveloperService _service;
        public DeveloperController(IDeveloperService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //public IActionResult Index()
        //{
            
        //    return View();
        //}
        //public IActionResult CadastroDesenvolvedor()
        //{
        //    ViewBag.Listas = new Business.Report.Level().Lista();
        //    return View();
        //}
        
        //[HttpPost]
        //public void SalvarDeveloper(Database.Developer developer)
        //{

        //    var devFun = new Business.Repository.FuncionarioRepository();

        //    devFun.SalvarFuncionario(developer);
        //    Response.Redirect("CadastroDesenvolvedor");

        //}

        //public IActionResult CadastroNivel()
        //{
        //    ViewBag.Listas = new Business.Report.Level().Lista();

        //    return View();
        //}

        //[HttpPost]
        //public void SalvarNivel(Database.Level level)
        //{

        //    var lev = new Business.Repository.FuncaoRepository();
        //    lev.SalvarFuncao(level);

        //    Response.Redirect("CadastroNivel");
        //}
        //[HttpGet]
        //public IActionResult RelatorioDesenvolvedor()
        //{
        //    ViewBag.Relatorio = new Business.Report.RelatorioFuncionarioBusiness().RelatorioDesenvolvedores();
        //    return View();
        //}
    }
}
