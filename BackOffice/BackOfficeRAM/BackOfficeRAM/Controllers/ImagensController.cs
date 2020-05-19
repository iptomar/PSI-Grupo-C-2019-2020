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
    public class ImagensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Imagems
        public ActionResult Index(string searchStringImg)
        {

            var lista = from s in db.Imagens
                        select s;

            if (!String.IsNullOrEmpty(searchStringImg))
            {
                lista = lista.Where(s => s.Nome.Contains(searchStringImg) || s.Autor.Contains(searchStringImg) || s.PontoInteresse.Nome.Contains(searchStringImg));
            }

            if (User.IsInRole("registado externo"))
            {
                lista = lista.Where(i => i.InseridaPor.Equals(db.Users.Where(u => u.UserName.Equals(User.Identity.Name)).FirstOrDefault().UserName));
            }


            return View(lista.ToList());
        }

        // GET: Imagems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagem imagem = db.Imagens.Find(id);
            if (imagem == null)
            {
                return HttpNotFound();
            }
            ImageDetailsViewModel model = new ImageDetailsViewModel();
            model.Imagem = imagem;
            model.Ponto = imagem.PontoInteresse;
            return View(imagem);
        }

        // GET: Imagems/Create
        public ActionResult Create()
        {
            CreateEditImagemViewModel model = new CreateEditImagemViewModel();
            LoadPontos(ref model);
            if (model.PontosInteresse.Count() == 0)
            {
                return View("ErroPonto");
            }
            return View(model);
        }

        // POST: Imagems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEditImagemViewModel model, HttpPostedFileBase foto)
        {

            if (ModelState.IsValid)
            {
                var pontodb = db.PontosInteresse.Find(model.PontoEscolhido);

                pontodb.Imagens = pontodb.Imagens ?? new List<Imagem>();

                var imagem = new Imagem
                {
                    Autor = model.Autor,
                    Nome = model.Nome,
                    InseridaPor = db.Users.Where(u => u.UserName.Equals(User.Identity.Name)).FirstOrDefault().UserName
                };

                pontodb.Imagens.Add(imagem);


                if (foto != null)
                {
                    System.IO.Stream fs = foto.InputStream;
                    System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    imagem.ConteudoImagem = "data:image/png;base64," + base64String;
                }
                else
                {
                    ModelState.AddModelError("", "Ocorreu um erro no carregamento da foto");
                    LoadPontos(ref model);
                    return View(model);
                }




                db.SaveChanges();
                return RedirectToAction("Index");
            }
            LoadPontos(ref model);
            return View(model);
        }

        // GET: Imagems/Edit/5
        [Authorize(Roles = "administrador,utilizador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagem imagem = db.Imagens.Find(id);
            if (imagem == null)
            {
                return HttpNotFound();
            }
            CreateEditImagemViewModel model = new CreateEditImagemViewModel();
            LoadPontos(ref model);
            model.IdImagem = imagem.Id;
            model.Nome = imagem.Nome;
            model.Autor = imagem.Autor;
            model.Conteudo = imagem.ConteudoImagem;
            model.PontoEscolhido = imagem.PontoInteresse.Id;
            return View(model);
        }

        // POST: Imagems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "administrador,utilizador")]
        public ActionResult Edit(CreateEditImagemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var imagem = db.Imagens.Find(model.IdImagem);

                imagem.Autor = model.Autor;
                imagem.Nome = model.Nome;
                imagem.PontoInteresse = db.PontosInteresse.Find(model.PontoEscolhido);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            LoadPontos(ref model);
            return View(model);
        }

        // GET: Imagems/Delete/5
        [Authorize(Roles = "administrador,utilizador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagem imagem = db.Imagens.Find(id);
            if (imagem == null)
            {
                return HttpNotFound();
            }
            return View(imagem);
        }

        // POST: Imagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "administrador,utilizador")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imagem imagem = db.Imagens.Find(id);
            db.Imagens.Remove(imagem);
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

        [NonAction]
        public void LoadPontos(ref CreateEditImagemViewModel model)
        {
            IEnumerable<PontoInteresse> pontos;
            if (User.IsInRole("registado externo"))
            {

                //pontos = db.PontosInteresse.ToList().Where(p => p.CriadorPonto.Equals(db.Users.Where(u => u.UserName.Equals(User.Identity.Name))));
                //model.PontosInteresse = pontos.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Nome.ToString() });

                pontos = from s in db.PontosInteresse
                         select s;

                //remover o que tem criador a null
                pontos = pontos.Where(s => s.CriadorPonto != null);
                pontos = pontos.Where(s => s.CriadorPonto.Equals(User.Identity.Name));

                model.PontosInteresse = pontos.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Nome.ToString() });

            }
            else
            {
                pontos = db.PontosInteresse.ToList().Where(p => p.Visivel.Equals(true));

                model.PontosInteresse = pontos.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Nome.ToString() });
            }
        }

        public ActionResult SemPontos()
        {
            return View("ErroPonto");
        }
    }
}
