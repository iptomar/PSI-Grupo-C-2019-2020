using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BackOfficeRAM.Models;
using BackOfficeRAM.ViewModels.API;

namespace BackOfficeRAM.API
{
    public class RamAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RoteirosAPI
        // retorna todos os roteiros
        public IEnumerable<RoteiroApiModel> GetRoteiros()
        {
            return db.Roteiroes.ToList().Select(p => new RoteiroApiModel(p));
        }

        // GET: api/RoteirosAPI/5
        [ResponseType(typeof(Roteiro))]
        public RoteiroApiModel GetRoteiro(int id)
        {
            Roteiro roteiro = db.Roteiroes.Find(id);
            if (roteiro == null)
            {
                return null;
            }

            return new RoteiroApiModel(roteiro);
        }

        // GET: api/PontosAPI/5
        [ResponseType(typeof(PontoInteresse))]
        public PontoApiDetalheModel GetPontoInteresse(int id)
        {
            PontoInteresse pontoInteresse = db.PontosInteresse.Find(id);
            if (pontoInteresse == null)
            {
                return null;
            }

            return new PontoApiDetalheModel(pontoInteresse);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PontoInteresseExists(int id)
        {
            return db.PontosInteresse.Count(e => e.Id == id) > 0;
        }
    }
}