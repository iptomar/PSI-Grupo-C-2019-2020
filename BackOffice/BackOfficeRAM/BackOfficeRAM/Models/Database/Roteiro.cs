using BackOfficeRAM.Models.Database;
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
        public String Descricao { get; set; }

        //tem vários pontos
        public virtual ICollection<PontoRoteiro> PontosInteresse { get; set; }
    }
}