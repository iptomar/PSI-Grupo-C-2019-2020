namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixrelacaoroteiroponto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PontoInteresses", "Roteiro_Id", "dbo.Roteiroes");
            DropIndex("dbo.PontoInteresses", new[] { "Roteiro_Id" });
            DropColumn("dbo.PontoInteresses", "Roteiro_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PontoInteresses", "Roteiro_Id", c => c.Int());
            CreateIndex("dbo.PontoInteresses", "Roteiro_Id");
            AddForeignKey("dbo.PontoInteresses", "Roteiro_Id", "dbo.Roteiroes", "Id");
        }
    }
}
