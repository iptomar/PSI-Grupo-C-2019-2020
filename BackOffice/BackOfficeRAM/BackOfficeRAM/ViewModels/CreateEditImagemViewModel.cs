using BackOfficeRAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackOfficeRAM.ViewModels
{
    public class CreateEditImagemViewModel
    {
        public IEnumerable<SelectListItem> PontosInteresse  { get; set; }
        public int PontoEscolhido { get; set; }
        public int IdImagem { get; set; }
        public String Conteudo { get; set; }
        public String Nome { get; set; }
        public String Autor { get; set; }
    }
}