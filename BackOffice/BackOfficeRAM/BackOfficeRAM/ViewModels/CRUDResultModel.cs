using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOfficeRAM.ViewModels
{
    public class CRUDResultModel
    {
        public CRUDResultModel()
        {
            Mensagens = new List<string>();
        }

        public bool Sucesso { get; set; }
        public List<string> Mensagens { get; set; }
    }
}