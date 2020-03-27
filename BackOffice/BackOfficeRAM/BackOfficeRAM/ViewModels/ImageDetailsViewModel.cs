using BackOfficeRAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOfficeRAM.ViewModels
{
    public class ImageDetailsViewModel
    {
        public Imagem Imagem { get; set; }
        public PontoInteresse Ponto { get; set; }
    }
}