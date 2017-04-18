namespace AquariumPartTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AquariumAquaticLifeManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AquariumAquaticLifeAquariums", "AquariumAquaticLife_Id", "dbo.AquariumAquaticLives");
            DropForeignKey("dbo.AquariumAquaticLifeAquariums", "Aquarium_Id", "dbo.Aquaria");
            DropForeignKey("dbo.AquaticLifeAquariumAquaticLives", "AquaticLife_Id", "dbo.AquaticLives");
            DropForeignKey("dbo.AquaticLifeAquariumAquaticLives", "AquariumAquaticLife_Id", "dbo.AquariumAquaticLives");
            DropIndex("dbo.AquariumAquaticLifeAquariums", new[] { "AquariumAquaticLife_Id" });
            DropIndex("dbo.AquariumAquaticLifeAquariums", new[] { "Aquarium_Id" });
            DropIndex("dbo.AquaticLifeAquariumAquaticLives", new[] { "AquaticLife_Id" });
            DropIndex("dbo.AquaticLifeAquariumAquaticLives", new[] { "AquariumAquaticLife_Id" });
            CreateTable(
                "dbo.AquaticLifeAquariums",
                c => new
                    {
                        AquaticLife_Id = c.Int(nullable: false),
                        Aquarium_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AquaticLife_Id, t.Aquarium_Id })
                .ForeignKey("dbo.AquaticLives", t => t.AquaticLife_Id, cascadeDelete: true)
                .ForeignKey("dbo.Aquaria", t => t.Aquarium_Id, cascadeDelete: true)
                .Index(t => t.AquaticLife_Id)
                .Index(t => t.Aquarium_Id);
            
            DropTable("dbo.AquariumAquaticLives");
            DropTable("dbo.AquariumAquaticLifeAquariums");
            DropTable("dbo.AquaticLifeAquariumAquaticLives");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AquaticLifeAquariumAquaticLives",
                c => new
                    {
                        AquaticLife_Id = c.Int(nullable: false),
                        AquariumAquaticLife_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AquaticLife_Id, t.AquariumAquaticLife_Id });
            
            CreateTable(
                "dbo.AquariumAquaticLifeAquariums",
                c => new
                    {
                        AquariumAquaticLife_Id = c.Int(nullable: false),
                        Aquarium_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AquariumAquaticLife_Id, t.Aquarium_Id });
            
            CreateTable(
                "dbo.AquariumAquaticLives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AquariumId = c.Int(nullable: false),
                        AquaticLifeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AquaticLifeAquariums", "Aquarium_Id", "dbo.Aquaria");
            DropForeignKey("dbo.AquaticLifeAquariums", "AquaticLife_Id", "dbo.AquaticLives");
            DropIndex("dbo.AquaticLifeAquariums", new[] { "Aquarium_Id" });
            DropIndex("dbo.AquaticLifeAquariums", new[] { "AquaticLife_Id" });
            DropTable("dbo.AquaticLifeAquariums");
            CreateIndex("dbo.AquaticLifeAquariumAquaticLives", "AquariumAquaticLife_Id");
            CreateIndex("dbo.AquaticLifeAquariumAquaticLives", "AquaticLife_Id");
            CreateIndex("dbo.AquariumAquaticLifeAquariums", "Aquarium_Id");
            CreateIndex("dbo.AquariumAquaticLifeAquariums", "AquariumAquaticLife_Id");
            AddForeignKey("dbo.AquaticLifeAquariumAquaticLives", "AquariumAquaticLife_Id", "dbo.AquariumAquaticLives", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AquaticLifeAquariumAquaticLives", "AquaticLife_Id", "dbo.AquaticLives", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AquariumAquaticLifeAquariums", "Aquarium_Id", "dbo.Aquaria", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AquariumAquaticLifeAquariums", "AquariumAquaticLife_Id", "dbo.AquariumAquaticLives", "Id", cascadeDelete: true);
        }
    }
}
