namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atribimagens : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Imagems", "Nome", c => c.String());
            AddColumn("dbo.Imagems", "Autor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Imagems", "Autor");
            DropColumn("dbo.Imagems", "Nome");
        }
    }
}
