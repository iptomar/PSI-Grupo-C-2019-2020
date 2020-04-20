using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackOfficeRAM.Models.Database
{
    public class PontoRoteiro
    {
        [Key]
        public int Id { get; set; }
        public int Posicao { get; set; }

        public virtual PontoInteresse Ponto { get; set; }
        public virtual Roteiro Roteiro { get; set; }
    }
}