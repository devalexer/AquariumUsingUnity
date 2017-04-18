namespace AquariumPartTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OceanAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oceans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AverageTemperature = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Oceans");
        }
    }
}
