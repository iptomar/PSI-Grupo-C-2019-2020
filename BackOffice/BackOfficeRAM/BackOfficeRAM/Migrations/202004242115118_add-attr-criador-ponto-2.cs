namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addattrcriadorponto2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PontoInteresses", "AprovadoPor_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.PontoInteresses", "AprovadoPor_Id");
            AddForeignKey("dbo.PontoInteresses", "AprovadoPor_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PontoInteresses", "AprovadoPor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PontoInteresses", new[] { "AprovadoPor_Id" });
            DropColumn("dbo.PontoInteresses", "AprovadoPor_Id");
        }
    }
}
