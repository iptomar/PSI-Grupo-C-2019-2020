using BackOfficeRAM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackOfficeRAM.ViewModels
{
    public class CreateEditRoteiroViewModel
    {
        public IEnumerable<PontoInteresse> Pontos { get; set; }
        public Roteiro Roteiro { get; set; }
        public List<RoteiroPontoModel> PontosSeleccionados { get; set; }

    }

    public class RoteiroPontoModel
    {
        public int IdPonto { get; set; }
        [Range(0, double.MaxValue)]
        public int Posicao { get; set; }
    }

}