namespace AquariumPartTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AquariumAquaticLifeOceanAdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AquaticLifeAquariums", "AquaticLife_Id", "dbo.AquaticLives");
            DropForeignKey("dbo.AquaticLifeAquariums", "Aquarium_Id", "dbo.Aquaria");
            DropForeignKey("dbo.OceanAquaticLives", "Ocean_Id", "dbo.Oceans");
            DropForeignKey("dbo.OceanAquaticLives", "AquaticLife_Id", "dbo.AquaticLives");
            DropIndex("dbo.AquaticLifeAquariums", new[] { "AquaticLife_Id" });
            DropIndex("dbo.AquaticLifeAquariums", new[] { "Aquarium_Id" });
            DropIndex("dbo.OceanAquaticLives", new[] { "Ocean_Id" });
            DropIndex("dbo.OceanAquaticLives", new[] { "AquaticLife_Id" });
            CreateTable(
                "dbo.AquariumAquaticLifeOceans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AquariumId = c.Int(nullable: false),
                        AquaticLifeId = c.Int(nullable: false),
                        OceanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aquaria", t => t.AquariumId, cascadeDelete: true)
                .ForeignKey("dbo.AquaticLives", t => t.AquaticLifeId, cascadeDelete: true)
                .ForeignKey("dbo.Oceans", t => t.OceanId, cascadeDelete: true)
                .Index(t => t.AquariumId)
                .Index(t => t.AquaticLifeId)
                .Index(t => t.OceanId);
            
            DropTable("dbo.AquaticLifeAquariums");
            DropTable("dbo.OceanAquaticLives");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OceanAquaticLives",
                c => new
                    {
                        Ocean_Id = c.Int(nullable: false),
                        AquaticLife_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ocean_Id, t.AquaticLife_Id });
            
            CreateTable(
                "dbo.AquaticLifeAquariums",
                c => new
                    {
                        AquaticLife_Id = c.Int(nullable: false),
                        Aquarium_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AquaticLife_Id, t.Aquarium_Id });
            
            DropForeignKey("dbo.AquariumAquaticLifeOceans", "OceanId", "dbo.Oceans");
            DropForeignKey("dbo.AquariumAquaticLifeOceans", "AquaticLifeId", "dbo.AquaticLives");
            DropForeignKey("dbo.AquariumAquaticLifeOceans", "AquariumId", "dbo.Aquaria");
            DropIndex("dbo.AquariumAquaticLifeOceans", new[] { "OceanId" });
            DropIndex("dbo.AquariumAquaticLifeOceans", new[] { "AquaticLifeId" });
            DropIndex("dbo.AquariumAquaticLifeOceans", new[] { "AquariumId" });
            DropTable("dbo.AquariumAquaticLifeOceans");
            CreateIndex("dbo.OceanAquaticLives", "AquaticLife_Id");
            CreateIndex("dbo.OceanAquaticLives", "Ocean_Id");
            CreateIndex("dbo.AquaticLifeAquariums", "Aquarium_Id");
            CreateIndex("dbo.AquaticLifeAquariums", "AquaticLife_Id");
            AddForeignKey("dbo.OceanAquaticLives", "AquaticLife_Id", "dbo.AquaticLives", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OceanAquaticLives", "Ocean_Id", "dbo.Oceans", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AquaticLifeAquariums", "Aquarium_Id", "dbo.Aquaria", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AquaticLifeAquariums", "AquaticLife_Id", "dbo.AquaticLives", "Id", cascadeDelete: true);
        }
    }
}
