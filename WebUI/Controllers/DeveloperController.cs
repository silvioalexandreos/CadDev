using Business.Report;
using Business.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class DeveloperController : Controller
    {

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult CadastroDesenvolvedor()
        {
            ViewBag.Listas = new Business.Report.Level().Lista();
            return View();
        }
        
        [HttpPost]
        public void SalvarDeveloper(Database.Developer developer)
        {

            var devFun = new Business.Repository.FuncionarioRepository();

            devFun.SalvarFuncionario(developer);
            Response.Redirect("CadastroDesenvolvedor");

        }

        public IActionResult CadastroNivel()
        {
            ViewBag.Listas = new Business.Report.Level().Lista();

            return View();
        }

        [HttpPost]
        public void SalvarNivel(Database.Level level)
        {

            var lev = new Business.Repository.FuncaoRepository();
            lev.SalvarFuncao(level);

            Response.Redirect("CadastroNivel");
        }
        public IActionResult RelatorioDesenvolvedor()
        {
            ViewBag.Relatorio = new Business.Report.RelatorioFuncionarioBusiness().RelatorioDesenvolvedores();
            return View();
        }
    }
}
