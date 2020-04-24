namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addattrcriadorponto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PontoInteresses", "CriadorPonto_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.PontoInteresses", "CriadorPonto_Id");
            AddForeignKey("dbo.PontoInteresses", "CriadorPonto_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PontoInteresses", "CriadorPonto_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PontoInteresses", new[] { "CriadorPonto_Id" });
            DropColumn("dbo.PontoInteresses", "CriadorPonto_Id");
        }
    }
}
