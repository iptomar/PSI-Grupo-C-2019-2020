using BackOfficeRAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackOfficeRAM.ViewModels.API
{
    public class PontoApiModel 
    {
        public PontoApiModel(PontoInteresse ponto)
        {
            Id = ponto.Id;
            Nome = ponto.Nome;
            TipoEdificio = ponto.TipoEdificio;
        }
        public int Id { get; set; }
        public String Nome { get; set; }
        public String TipoEdificio { get; set; }
    }
}