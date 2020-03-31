using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BackOfficeRAM.Models;

namespace BackOfficeRAM.Controllers
{
    public class PontosInteresseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PontoInteresses
        public ActionResult Index()
        {
            return View(db.PontosInteresse.ToList());
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
            return View();
        }

        // POST: PontoInteresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Autor,Localizacao,Ano,TipoEdificio")] PontoInteresse pontoInteresse)
        {
            if (ModelState.IsValid)
            {
                db.PontosInteresse.Add(pontoInteresse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pontoInteresse);
        }

        // GET: PontoInteresses/Edit/5
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
            return View(pontoInteresse);
        }

        // POST: PontosInteresse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Autor,Localizacao,Ano,TipoEdificio")] PontoInteresse pontoInteresse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pontoInteresse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pontoInteresse);
        }

        // GET: PontosInteresse/Delete/5
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
        public ActionResult DeleteConfirmed(int id)
        {
            PontoInteresse pontoInteresse = db.PontosInteresse.Find(id);
            db.PontosInteresse.Remove(pontoInteresse);
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
