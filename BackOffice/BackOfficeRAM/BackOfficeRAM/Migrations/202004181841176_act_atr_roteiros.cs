namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class act_atr_roteiros : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roteiroes", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roteiroes", "Nome", c => c.Int(nullable: false));
        }
    }
}
