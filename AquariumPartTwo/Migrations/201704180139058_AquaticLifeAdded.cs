namespace AquariumPartTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AquaticLifeAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AquaticLives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Color = c.String(),
                        Name = c.String(),
                        DateAddedToTank = c.DateTime(nullable: false),
                        IsInQuarantine = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AquaticLives");
        }
    }
}
