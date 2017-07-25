namespace Cars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        ManufacturerBg = c.String(),
                        ManufacturerEn = c.String(),
                        Model = c.String(),
                        YearOfProduction = c.Int(nullable: false),
                        BodyType = c.String(),
                        Acceleration = c.Double(nullable: false),
                        MaximumSpeed = c.Int(nullable: false),
                        FuelTankVolume = c.Int(nullable: false),
                        NumberOfDoors = c.Int(nullable: false),
                        NumberOfSeats = c.Int(nullable: false),
                        KerbWeightKG = c.Int(nullable: false),
                        LengthInMM = c.Int(nullable: false),
                        WidthInMM = c.Int(nullable: false),
                        HeightInMM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarId);
            
            CreateTable(
                "dbo.Chassis",
                c => new
                    {
                        ChassiId = c.Int(nullable: false),
                        FrontSuspension = c.String(),
                        RearSuspension = c.String(),
                        FrontBrakes = c.String(),
                        RearBrakes = c.String(),
                    })
                .PrimaryKey(t => t.ChassiId)
                .ForeignKey("dbo.Cars", t => t.ChassiId)
                .Index(t => t.ChassiId);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        FeatureId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.FeatureId);
            
            CreateTable(
                "dbo.PowerTrains",
                c => new
                    {
                        PowerTrainId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PowerTrainId)
                .ForeignKey("dbo.Cars", t => t.PowerTrainId)
                .Index(t => t.PowerTrainId);
            
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        EngineId = c.Int(nullable: false),
                        Fuel = c.String(),
                        NumberOfCylinders = c.Int(nullable: false),
                        Position = c.String(),
                        PowerInHP = c.Int(nullable: false),
                        TorqueInNM = c.Int(nullable: false),
                        CapacityInCM3 = c.Int(nullable: false),
                        CompbinedConsumption = c.Double(nullable: false),
                        EmissionsGramsCO2perKM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EngineId)
                .ForeignKey("dbo.PowerTrains", t => t.EngineId)
                .Index(t => t.EngineId);
            
            CreateTable(
                "dbo.Transmissions",
                c => new
                    {
                        TransmissionId = c.Int(nullable: false),
                        Type = c.String(),
                        NumberOfGears = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransmissionId)
                .ForeignKey("dbo.PowerTrains", t => t.TransmissionId)
                .Index(t => t.TransmissionId);
            
            CreateTable(
                "dbo.FeatureCars",
                c => new
                    {
                        Feature_FeatureId = c.Int(nullable: false),
                        Car_CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Feature_FeatureId, t.Car_CarId })
                .ForeignKey("dbo.Features", t => t.Feature_FeatureId, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.Car_CarId, cascadeDelete: true)
                .Index(t => t.Feature_FeatureId)
                .Index(t => t.Car_CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transmissions", "TransmissionId", "dbo.PowerTrains");
            DropForeignKey("dbo.Engines", "EngineId", "dbo.PowerTrains");
            DropForeignKey("dbo.PowerTrains", "PowerTrainId", "dbo.Cars");
            DropForeignKey("dbo.FeatureCars", "Car_CarId", "dbo.Cars");
            DropForeignKey("dbo.FeatureCars", "Feature_FeatureId", "dbo.Features");
            DropForeignKey("dbo.Chassis", "ChassiId", "dbo.Cars");
            DropIndex("dbo.FeatureCars", new[] { "Car_CarId" });
            DropIndex("dbo.FeatureCars", new[] { "Feature_FeatureId" });
            DropIndex("dbo.Transmissions", new[] { "TransmissionId" });
            DropIndex("dbo.Engines", new[] { "EngineId" });
            DropIndex("dbo.PowerTrains", new[] { "PowerTrainId" });
            DropIndex("dbo.Chassis", new[] { "ChassiId" });
            DropTable("dbo.FeatureCars");
            DropTable("dbo.Transmissions");
            DropTable("dbo.Engines");
            DropTable("dbo.PowerTrains");
            DropTable("dbo.Features");
            DropTable("dbo.Chassis");
            DropTable("dbo.Cars");
        }
    }
}
