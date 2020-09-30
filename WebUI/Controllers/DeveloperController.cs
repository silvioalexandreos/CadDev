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
        public IActionResult CadastroNivel()
        {
            return View();
        }
        public IActionResult RelatorioDesenvolvedor()
        {
            ViewBag.Relatorio = new Business.Report.RelatorioFuncionarioBusiness().RelatorioDesenvolvedores();
            return View();
        }
    }
}
