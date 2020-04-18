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
            return View();
        }

        // POST: Roteiros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,posicao")] Roteiro roteiro)
        {
            if (ModelState.IsValid)
            {
                db.Roteiroes.Add(roteiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roteiro);
        }

        // GET: Roteiros/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Roteiros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,posicao")] Roteiro roteiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roteiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roteiro);
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
