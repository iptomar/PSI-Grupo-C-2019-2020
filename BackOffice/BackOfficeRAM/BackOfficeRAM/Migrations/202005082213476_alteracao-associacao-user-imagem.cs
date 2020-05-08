namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracaoassociacaouserimagem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Imagems", "InseridaPor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Imagems", new[] { "InseridaPor_Id" });
            AddColumn("dbo.Imagems", "InseridaPor", c => c.String());
            DropColumn("dbo.Imagems", "InseridaPor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Imagems", "InseridaPor_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Imagems", "InseridaPor");
            CreateIndex("dbo.Imagems", "InseridaPor_Id");
            AddForeignKey("dbo.Imagems", "InseridaPor_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
