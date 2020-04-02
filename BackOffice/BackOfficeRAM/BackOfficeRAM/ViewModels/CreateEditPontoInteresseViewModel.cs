using BackOfficeRAM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackOfficeRAM.ViewModels
{
    public class CreateEditPontoInteresseViewModel
    {
        public CreateEditPontoInteresseViewModel()
        {
            PontoInteresse = new PontoInteresse();
            TiposEdificios = new List<SelectListItem>
            {
                new SelectListItem{Value="Monumento", Text="Monumento"},
                new SelectListItem{Value="XPTO", Text="XPTO"},
            };
        }

        public PontoInteresse PontoInteresse { get; set; }

        public List<SelectListItem> TiposEdificios { get; set; }

    }
}