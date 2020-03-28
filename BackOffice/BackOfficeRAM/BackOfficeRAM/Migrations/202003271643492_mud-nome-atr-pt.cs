namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mudnomeatrpt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PontoInteresses", "Localizacao", c => c.String());
            DropColumn("dbo.PontoInteresses", "Localização");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PontoInteresses", "Localização", c => c.String());
            DropColumn("dbo.PontoInteresses", "Localizacao");
        }
    }
}
