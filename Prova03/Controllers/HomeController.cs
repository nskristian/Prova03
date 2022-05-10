using Microsoft.AspNetCore.Mvc;
using Prova03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova03.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DataModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var today = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
                    var birthdate = model.Data;

                    if (birthdate <= today)
                    {
                        int age = DateTime.Now.Year - model.Data.Year;

                        if (birthdate > today.AddYears(-age)) age--;

                        if (DateTime.Now.Day == model.Data.Day && DateTime.Now.Month == model.Data.Month)
                        {
                            TempData["anos"] = age + 1;
                            TempData["MensagemAniversario"] = "Feliz aniversário!";
                        }
                        TempData["anos"] = age;
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Data inválida";
                    }
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Erro: " + e.Message;
                }
            }
            return View();
        }
    }
}
