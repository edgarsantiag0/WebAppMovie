namespace WebAppMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailable");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
