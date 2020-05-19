using BackOfficeRAM.Models;
using BackOfficeRAM.ViewModels.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOfficeRAM.API
{
    public class RoteiroApiModel
    {
        public RoteiroApiModel(Roteiro roteiro)
        {
            IdRoteiro = roteiro.Id;
            NomeRoteiro = roteiro.Nome;
            Descricao = roteiro.Descricao;
            Pontos = new List<PontoApiModel>();
            foreach (var ponto in roteiro.PontosInteresse)
            {
                var modeloPonto = new PontoApiModel(ponto.Ponto);
                Pontos.Add(modeloPonto);
            }
        }

        public int IdRoteiro { get; set; }
        public string NomeRoteiro { get; set; }
        public string Descricao { get; set; }
        public List<PontoApiModel> Pontos { get; set; }
    }
}