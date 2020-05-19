namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracaoassociacaouserponto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PontoInteresses", "AprovadoPor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PontoInteresses", "CriadorPonto_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PontoInteresses", new[] { "AprovadoPor_Id" });
            DropIndex("dbo.PontoInteresses", new[] { "CriadorPonto_Id" });
            AddColumn("dbo.PontoInteresses", "AprovadoPor", c => c.String());
            AddColumn("dbo.PontoInteresses", "CriadorPonto", c => c.String());
            DropColumn("dbo.PontoInteresses", "AprovadoPor_Id");
            DropColumn("dbo.PontoInteresses", "CriadorPonto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PontoInteresses", "CriadorPonto_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.PontoInteresses", "AprovadoPor_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.PontoInteresses", "CriadorPonto");
            DropColumn("dbo.PontoInteresses", "AprovadoPor");
            CreateIndex("dbo.PontoInteresses", "CriadorPonto_Id");
            CreateIndex("dbo.PontoInteresses", "AprovadoPor_Id");
            AddForeignKey("dbo.PontoInteresses", "CriadorPonto_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PontoInteresses", "AprovadoPor_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
