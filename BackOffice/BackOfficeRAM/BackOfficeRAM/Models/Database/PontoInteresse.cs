using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackOfficeRAM.Models
{
    public class PontoInteresse
    {
        [Key]
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public int MyProperty { get; set; }
        public List<Coordenada> Coordenadas { get; set; }
        public List<Imagem> Imagens { get; set; }
    }
}