using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackOfficeRAM.ViewModels
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel(){}
        public HomeIndexViewModel(TempDataDictionary tempData) 
        {
            if (tempData.ContainsKey("CRUD"))
                CRUDResult = (CRUDResultModel)tempData["CRUD"];
        }

        public CRUDResultModel CRUDResult { get; set; }
        public int NumPontos { get; set; }
        public int NumImagens { get; set; }
        public int NumRoteiros { get; set; }
    }
}