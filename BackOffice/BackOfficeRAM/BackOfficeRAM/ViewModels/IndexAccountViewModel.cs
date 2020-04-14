using BackOfficeRAM.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOfficeRAM.ViewModels
{
    public class IndexAccountViewModel
    {
        public IEnumerable<ApplicationUser> Utilizadores { get; set; }
        public IEnumerable<IdentityRole> Funcoes { get; set; }
    }
}