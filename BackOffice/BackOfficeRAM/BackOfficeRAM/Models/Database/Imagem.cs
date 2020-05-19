using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackOfficeRAM.Models
{
    public class Imagem
    {
        [Key]
        public int Id { get; set; }
        public string ConteudoImagem { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public virtual PontoInteresse PontoInteresse { get; set; }
        public virtual string InseridaPor { get; set; }
    }
}