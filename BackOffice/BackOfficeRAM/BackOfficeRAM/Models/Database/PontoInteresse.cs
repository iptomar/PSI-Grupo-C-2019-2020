﻿using System;
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
        public String Localizacao { get; set; }
        public String Autor { get; set; }
        public String Ano { get; set; }
        public String TipoEdificio { get; set; }
        public String Descricao { get; set; }
        public Coordenada CoordenadaIcon { get; set; }
        public List<Coordenada> CoordenadasPoligono { get; set; }
        public virtual List<Imagem> Imagens { get; set; }
    }
}