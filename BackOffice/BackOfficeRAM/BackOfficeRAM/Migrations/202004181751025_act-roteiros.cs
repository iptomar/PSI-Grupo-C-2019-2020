namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actroteiros : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roteiroes", "Descricao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roteiroes", "Descricao");
        }
    }
}
