﻿using BackOfficeRAM.Models;
using BackOfficeRAM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackOfficeRAM.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.NumPontos = db.PontosInteresse.Count();
            model.NumImagens = db.Imagens.Count();
            model.NumRoteiros = db.Roteiroes.Count();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}