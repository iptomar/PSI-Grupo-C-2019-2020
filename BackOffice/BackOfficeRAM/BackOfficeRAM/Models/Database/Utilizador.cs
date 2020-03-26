using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackOfficeRAM.Models.Database
{
    public class Utilizador : ApplicationUser
    {
        public String Nome { get; set; }
    }
}