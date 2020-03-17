using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackOfficeRAM.Models
{
    public class Coordenada
    {
        [Key]
        public int Id { get; set; }
        public String ValorCoordenada { get; set; }
    }
}