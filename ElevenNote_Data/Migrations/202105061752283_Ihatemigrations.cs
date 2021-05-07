namespace ElevenNote_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ihatemigrations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "Subject", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Note", "Subject");
        }
    }
}
