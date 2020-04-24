using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BackOfficeRAM.Models;
using BackOfficeRAM.ViewModels;

namespace BackOfficeRAM.Controllers
{
    [Authorize]
    public class PontosInteresseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "administrador,utilizador")]
        public ActionResult IndexAprovacao()
        {
            //retorna para a view os pontos que estão ocultos (pendentes de aprovação)
            return View(db.PontosInteresse.Where(p => p.Visivel.Equals(false)));
        }

        [Authorize(Roles = "administrador,utilizador")]
        public ActionResult Aprovar(int id)
        {
            var ponto = db.PontosInteresse.Where(p => p.Id.Equals(id)).FirstOrDefault();
            ponto.Visivel = true;
            ponto.AprovadoPor = db.Users.Where(u => u.UserName.Equals(User.Identity.Name)).FirstOrDefault();
            db.SaveChanges();
            return RedirectToAction("IndexAprovacao");
        }

        [Authorize(Roles = "administrador,utilizador")]
        public ActionResult Rejeitar(int id)
        {
            var ponto = db.PontosInteresse.Where(p => p.Id.Equals(id)).FirstOrDefault();
            db.PontosInteresse.Remove(ponto);
            db.SaveChanges();
            return RedirectToAction("IndexAprovacao");
        }

        // GET: PontoInteresses
        public ActionResult Index(string searchString)
        {

            var pontos = from s in db.PontosInteresse
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                pontos = pontos.Where(s => s.Nome.Contains(searchString) || s.Descricao.Contains(searchString) || s.Localizacao.Contains(searchString));
            }


            pontos = pontos.Where(p => p.Visivel.Equals(true));


            return View(pontos.ToList());
        }

        // GET: PontoInteresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PontoInteresse pontoInteresse = db.PontosInteresse.Find(id);
            if (pontoInteresse == null)
            {
                return HttpNotFound();
            }
            return View(pontoInteresse);
        }

        // GET: PontoInteresses/Create
        public ActionResult Create()
        {
            var model = new CreateEditPontoInteresseViewModel();

            return View(model);
        }

        // POST: PontoInteresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEditPontoInteresseViewModel model)
        {
            if (model.PontoInteresse.CoordenadasPoligono != null)
            {
                foreach (var item in model.PontoInteresse.CoordenadasPoligono)
                    ModelState.Remove("PontoInteresse.CoordenadasPoligono[" + model.PontoInteresse.CoordenadasPoligono.IndexOf(item) + "].Id");
            }
            if (ModelState.IsValid)
            {
                if (User.IsInRole("administrador") || User.IsInRole("utilizador"))
                {
                    model.PontoInteresse.Visivel = true;
                }
                else
                {
                    model.PontoInteresse.Visivel = false;
                }
                model.PontoInteresse.CriadorPonto = db.Users.Where(u => u.UserName.Equals(User.Identity.Name)).FirstOrDefault();
                db.PontosInteresse.Add(model.PontoInteresse);
                db.SaveChanges();
                if (User.IsInRole("registado externo"))
                {
                    return View("InfoAprovacao");
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: PontoInteresses/Edit/5
        [Authorize(Roles = "administrador,utilizador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PontoInteresse pontoInteresse = db.PontosInteresse.Find(id);
            if (pontoInteresse == null)
            {
                return HttpNotFound();
            }
            var model = new CreateEditPontoInteresseViewModel();
            model.PontoInteresse = pontoInteresse;

            return View(model);
        }

        // POST: PontosInteresse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "administrador,utilizador")]
        public ActionResult Edit(CreateEditPontoInteresseViewModel model)
        {
            if (model.PontoInteresse.CoordenadasPoligono != null)
            {
                foreach (var item in model.PontoInteresse.CoordenadasPoligono)
                    ModelState.Remove("PontoInteresse.CoordenadasPoligono[" + model.PontoInteresse.CoordenadasPoligono.IndexOf(item) + "].Id");
            }

            if (ModelState.IsValid)
            {
                var oldPontoInteresse = db.PontosInteresse.Find(model.PontoInteresse.Id);

                foreach (var coordenada in oldPontoInteresse.CoordenadasPoligono.ToList())
                {
                    if (model.PontoInteresse.CoordenadasPoligono == null || !model.PontoInteresse.CoordenadasPoligono.Any(c => c.Id == coordenada.Id))
                        oldPontoInteresse.CoordenadasPoligono.Remove(coordenada);
                }

                if (model.PontoInteresse.CoordenadasPoligono != null)
                {
                    foreach (var novaCoordenada in model.PontoInteresse.CoordenadasPoligono.Where(x => x.Id == 0).ToList())
                    {
                        oldPontoInteresse.CoordenadasPoligono.Add(novaCoordenada);
                    }
                }

                oldPontoInteresse.Ano = model.PontoInteresse.Ano;
                oldPontoInteresse.Autor = model.PontoInteresse.Autor;
                oldPontoInteresse.Descricao = model.PontoInteresse.Descricao;
                oldPontoInteresse.Localizacao = model.PontoInteresse.Localizacao;
                oldPontoInteresse.TipoEdificio = model.PontoInteresse.TipoEdificio;
                oldPontoInteresse.CoordenadaIcon = model.PontoInteresse.CoordenadaIcon;
                oldPontoInteresse.Nome = model.PontoInteresse.Nome;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: PontosInteresse/Delete/5
        [Authorize(Roles = "administrador,utilizador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PontoInteresse pontoInteresse = db.PontosInteresse.Find(id);
            if (pontoInteresse == null)
            {
                return HttpNotFound();
            }
            return View(pontoInteresse);
        }

        // POST: PontosInteresse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "administrador,utilizador")]
        public ActionResult DeleteConfirmed(int id)
        {
            PontoInteresse pontoInteresse = db.PontosInteresse.Find(id);
            if (pontoInteresse.CoordenadasPoligono != null)
            {
                foreach (var item in pontoInteresse.CoordenadasPoligono.ToList())
                {
                    db.Coordenadas.Remove(item);
                }
            }
            if (pontoInteresse.CoordenadaIcon != null)
            {
                db.Coordenadas.Remove(pontoInteresse.CoordenadaIcon);
            }
            db.PontosInteresse.Remove(pontoInteresse);
            try
            {

                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("ErroKey");
            }
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
