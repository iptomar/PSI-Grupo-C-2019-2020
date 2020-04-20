namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacaotblrelacaoptrot : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PontoRoteiroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Posicao = c.Int(nullable: false),
                        Ponto_Id = c.Int(),
                        Roteiro_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PontoInteresses", t => t.Ponto_Id)
                .ForeignKey("dbo.Roteiroes", t => t.Roteiro_Id)
                .Index(t => t.Ponto_Id)
                .Index(t => t.Roteiro_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PontoRoteiroes", "Roteiro_Id", "dbo.Roteiroes");
            DropForeignKey("dbo.PontoRoteiroes", "Ponto_Id", "dbo.PontoInteresses");
            DropIndex("dbo.PontoRoteiroes", new[] { "Roteiro_Id" });
            DropIndex("dbo.PontoRoteiroes", new[] { "Ponto_Id" });
            DropTable("dbo.PontoRoteiroes");
        }
    }
}
