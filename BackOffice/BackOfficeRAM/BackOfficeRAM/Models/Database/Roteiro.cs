using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackOfficeRAM.Models
{
    public class Roteiro
    {
        [Key]
        public int Id { get; set; }
        public String Nome { get; set; }
        public int posicao { get; set; }
        public String Descricao { get; set; }
        public virtual List<PontoInteresse> PontoInteresse { get; set; }
    }
}