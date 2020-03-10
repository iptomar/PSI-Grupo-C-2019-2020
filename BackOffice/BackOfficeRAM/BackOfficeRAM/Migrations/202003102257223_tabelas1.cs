namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabelas1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coordenadas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValorCoordenada = c.String(),
                        PontoInteresse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PontoInteresses", t => t.PontoInteresse_Id)
                .Index(t => t.PontoInteresse_Id);
            
            CreateTable(
                "dbo.Imagems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConteudoImagem = c.String(),
                        PontoInteresse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PontoInteresses", t => t.PontoInteresse_Id)
                .Index(t => t.PontoInteresse_Id);
            
            CreateTable(
                "dbo.PontoInteresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Imagems", "PontoInteresse_Id", "dbo.PontoInteresses");
            DropForeignKey("dbo.Coordenadas", "PontoInteresse_Id", "dbo.PontoInteresses");
            DropIndex("dbo.Imagems", new[] { "PontoInteresse_Id" });
            DropIndex("dbo.Coordenadas", new[] { "PontoInteresse_Id" });
            DropTable("dbo.PontoInteresses");
            DropTable("dbo.Imagems");
            DropTable("dbo.Coordenadas");
        }
    }
}
