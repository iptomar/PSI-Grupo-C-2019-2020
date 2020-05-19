using BackOfficeRAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackOfficeRAM.ViewModels.API
{
    public class PontoApiModel
    {
        public PontoApiModel(PontoInteresse ponto)
        {
            Id = ponto.Id;
            Nome = ponto.Nome;
            TipoEdificio = ponto.TipoEdificio;
            CoordenadasPoligono = ponto.CoordenadasPoligono.Select(i => new CoordenadasPoligonoApiModel(i));
            LatitudeIcone = ponto.CoordenadaIcon.Latitude;
            LongitudeIcone = ponto.CoordenadaIcon.Longitude;
        }
        public int Id { get; set; }
        public String Nome { get; set; }
        public String TipoEdificio { get; set; }

        public String LatitudeIcone { get; set; }
        public String LongitudeIcone { get; set; }

        public IEnumerable<CoordenadasPoligonoApiModel> CoordenadasPoligono { get; set; }

        public class CoordenadasPoligonoApiModel
        {
            public CoordenadasPoligonoApiModel(Coordenada coord)
            {
                Latitude = coord.Latitude;
                Longitude = coord.Longitude;
            }
            public String Latitude { get; set; }
            public String Longitude { get; set; }
        }




    }
}