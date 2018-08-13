namespace EnvanterCreditWest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Changes", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Changes", "Date", c => c.DateTime(nullable: false));
        }
    }
}
