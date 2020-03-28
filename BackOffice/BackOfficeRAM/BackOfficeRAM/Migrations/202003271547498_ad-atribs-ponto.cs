namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adatribsponto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coordenadas", "Latitude", c => c.String());
            AddColumn("dbo.Coordenadas", "Longitude", c => c.String());
            AddColumn("dbo.PontoInteresses", "Localização", c => c.String());
            AddColumn("dbo.PontoInteresses", "Autor", c => c.String());
            AddColumn("dbo.PontoInteresses", "Data", c => c.DateTime(nullable: false));
            AddColumn("dbo.PontoInteresses", "TipoEdificio", c => c.String());
            AddColumn("dbo.PontoInteresses", "CoordenadaIcon_Id", c => c.Int());
            CreateIndex("dbo.PontoInteresses", "CoordenadaIcon_Id");
            AddForeignKey("dbo.PontoInteresses", "CoordenadaIcon_Id", "dbo.Coordenadas", "Id");
            DropColumn("dbo.Coordenadas", "ValorCoordenada");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coordenadas", "ValorCoordenada", c => c.String());
            DropForeignKey("dbo.PontoInteresses", "CoordenadaIcon_Id", "dbo.Coordenadas");
            DropIndex("dbo.PontoInteresses", new[] { "CoordenadaIcon_Id" });
            DropColumn("dbo.PontoInteresses", "CoordenadaIcon_Id");
            DropColumn("dbo.PontoInteresses", "TipoEdificio");
            DropColumn("dbo.PontoInteresses", "Data");
            DropColumn("dbo.PontoInteresses", "Autor");
            DropColumn("dbo.PontoInteresses", "Localização");
            DropColumn("dbo.Coordenadas", "Longitude");
            DropColumn("dbo.Coordenadas", "Latitude");
        }
    }
}
