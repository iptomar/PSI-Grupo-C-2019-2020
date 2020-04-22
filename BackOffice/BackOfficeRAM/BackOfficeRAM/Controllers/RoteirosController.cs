using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BackOfficeRAM.Models;
using BackOfficeRAM.Models.Database;
using BackOfficeRAM.ViewModels;

namespace BackOfficeRAM.Controllers
{
    [Authorize]
    public class RoteirosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Roteiros
        public ActionResult Index(string searchString)
        {
            var roteiro = from s in db.Roteiroes
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                roteiro = roteiro.Where(s => s.Nome.Contains(searchString) || s.Descricao.Contains(searchString));
            }
            return View(roteiro.ToList());
        }

        // GET: Roteiros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roteiro roteiro = db.Roteiroes.Find(id);
            if (roteiro == null)
            {
                return HttpNotFound();
            }
            return View(roteiro);
        }

        // GET: Roteiros/Create
        public ActionResult Create()
        {
            CreateEditRoteiroViewModel model = new CreateEditRoteiroViewModel();
            model.Pontos = db.PontosInteresse.ToList();
            return View(model);
        }

        // POST: Roteiros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEditRoteiroViewModel model)
        {
            ModelState.Remove("model.Roteiro.Id");
            if (ModelState.IsValid)
            {
                var roteiro = model.Roteiro;
                roteiro.PontosInteresse = new List<PontoRoteiro>();
                foreach (var item in model.PontosSeleccionados)
                {
                    roteiro.PontosInteresse.Add(new PontoRoteiro
                    {
                        Posicao = model.PontosSeleccionados.IndexOf(item) + 1,
                        Ponto = db.PontosInteresse.FirstOrDefault(i => i.Id == item.IdPonto)
                    }); ;
                }



                db.Roteiroes.Add(model.Roteiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Roteiros/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Roteiro roteiro = db.Roteiroes.Find(id);
            //if (roteiro == null)
            //{
            //    return HttpNotFound();
            //}
            //var model = new CreateEditRoteiroViewModel();
            //model.PontosSeleccionados = new List<RoteiroPontoModel>();
            //model.Roteiro = roteiro;
            //model.Pontos = db.PontosInteresse.ToList();

            //var rotPontosModel = new RoteiroPontoModel();
            //foreach (var item in roteiro.PontosInteresse)
            //{
            //    rotPontosModel.IdPonto = item.Ponto.Id;
            //    rotPontosModel.Posicao = item.Posicao;
            //    var result=model.PontosSeleccionados.Append(rotPontosModel);
            //}

            //return View(model);

            return RedirectToAction("Index");
        }

        // POST: Roteiros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateEditRoteiroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oldRoteiro = db.Roteiroes.Find(model.Roteiro.Id);

                //foreach (var coordenada in oldPontoInteresse.CoordenadasPoligono.ToList())
                //{
                //    if (model.PontoInteresse.CoordenadasPoligono == null || !model.PontoInteresse.CoordenadasPoligono.Any(c => c.Id == coordenada.Id))
                //        oldPontoInteresse.CoordenadasPoligono.Remove(coordenada);
                //}

                //if (model.PontoInteresse.CoordenadasPoligono != null)
                //{
                //    foreach (var novaCoordenada in model.PontoInteresse.CoordenadasPoligono.Where(x => x.Id == 0).ToList())
                //    {
                //        oldPontoInteresse.CoordenadasPoligono.Add(novaCoordenada);
                //    }
                //}

                oldRoteiro.Nome = model.Roteiro.Nome;
                oldRoteiro.Descricao = model.Roteiro.Descricao;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Roteiros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roteiro roteiro = db.Roteiroes.Find(id);
            if (roteiro == null)
            {
                return HttpNotFound();
            }
            return View(roteiro);
        }

        // POST: Roteiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Roteiro roteiro = db.Roteiroes.Find(id);
            foreach (var linha in db.PontoRoteiro)
            {
                if (linha.Roteiro.Id == id)
                {
                    db.PontoRoteiro.Remove(linha);
                }
            }
            db.Roteiroes.Remove(roteiro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
