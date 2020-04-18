namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addroteiros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roteiroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.Int(nullable: false),
                        posicao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PontoInteresses", "Roteiro_Id", c => c.Int());
            CreateIndex("dbo.PontoInteresses", "Roteiro_Id");
            AddForeignKey("dbo.PontoInteresses", "Roteiro_Id", "dbo.Roteiroes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PontoInteresses", "Roteiro_Id", "dbo.Roteiroes");
            DropIndex("dbo.PontoInteresses", new[] { "Roteiro_Id" });
            DropColumn("dbo.PontoInteresses", "Roteiro_Id");
            DropTable("dbo.Roteiroes");
        }
    }
}
