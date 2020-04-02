using BackOfficeRAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOfficeRAM.ViewModels.API
{
    public class PontoApiDetalheModel
    {




        public PontoApiDetalheModel(PontoInteresse ponto)
        {
            Localizacao = ponto.Localizacao;
            Autor = ponto.Autor;
            Ano = ponto.Ano;
            Descricao = ponto.Descricao;
            //Ingredientes = produto.Ingredientes.Select(i => new IngredienteModel(i));
            Imagens = ponto.Imagens.Select(i=>new ImagensApiModel(i));

        }

        public String Localizacao { get; set; }
        public String Autor { get; set; }
        public String Ano { get; set; }
        public String Descricao { get; set; }
        public IEnumerable<ImagensApiModel> Imagens { get; set; }


        public class ImagensApiModel
        {
            public ImagensApiModel(Imagem img)
            {
                Legenda = img.Nome;
                Autor = img.Autor;
                Conteudo = img.ConteudoImagem;
            }
            public String Legenda { get; set; }
            public String Autor { get; set; }
            public String Conteudo { get; set; }
        }





    }
}