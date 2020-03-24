namespace BackOfficeRAM.Migrations
{
    using BackOfficeRAM.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;

    internal sealed class Configuration : DbMigrationsConfiguration<BackOfficeRAM.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BackOfficeRAM.Models.ApplicationDbContext context)
        {


            //if (_userManager.Find("admin", "123_Asd") == null)
            //{
            //    var user = new Funcionario { UserName = "admin", Email = "admin@storas.pt", Nome = "Chuck Norris", Fotografia = "norris.png", DataAdmissao = DateTime.Now, Sexo = "M", Morada = "Figueir� do Campo", DataNascimento = new DateTime(1956, 2, 3), Contacto = "999999999" };

            //    var resultado = _userManager.Create(user, "123_Asd");

            //    if (resultado.Succeeded)
            //    {
            //        _userManager.AddToRole(user.Id, "administrador");
            //    }
            //}

            //if (!context.Users.Any(u => u.UserName == "admin"))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    //var manager = new UserManager<ApplicationUser>(store);
            //    var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //    var user = new ApplicationUser { UserName = "admin" };

            //    manager.Create(user, "123_Asd");
            //    //manager.AddToRole(user.Id, "AppAdmin");
            //}






            var imagem1 = new Imagem { ConteudoImagem = "data:image/jpeg;base64,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" };
            context.Imagens.AddOrUpdate(imagem1);
            context.SaveChanges();



        }
    }
}
