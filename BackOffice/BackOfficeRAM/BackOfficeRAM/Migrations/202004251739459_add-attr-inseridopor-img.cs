namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addattrinseridoporimg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Imagems", "InseridaPor_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Imagems", "InseridaPor_Id");
            AddForeignKey("dbo.Imagems", "InseridaPor_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Imagems", "InseridaPor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Imagems", new[] { "InseridaPor_Id" });
            DropColumn("dbo.Imagems", "InseridaPor_Id");
        }
    }
}
