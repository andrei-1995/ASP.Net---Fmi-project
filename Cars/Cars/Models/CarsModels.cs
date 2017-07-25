using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

// enable-migrations -ContextTypeName Cars.Models.CarsContext

namespace Cars.Models
{
    public class CarsContext : DbContext
    {
        public CarsContext() : base("DefaultConnection") { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Chassi> Chassis { get; set; }
        public DbSet<Feature> Features { get; set; }
    }

    [Serializable]
    [XmlRoot("car")]
    public class Car
    {
        [XmlIgnore]
        public int CarId { get; set; }

        [XmlElement("manufacturer_bg")]
        public string ManufacturerBg { get; set; }

        [XmlElement("manufacturer_en")]
        public string ManufacturerEn { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("year_of_production")]
        public int YearOfProduction { get; set; }
        
        [XmlElement("body_type")]
        public string BodyType { get; set; }

        [XmlElement("powertrain")]
        public virtual PowerTrain PowerTrain { get; set; }

        [XmlElement("acceleration")]
        public double Acceleration { get; set; }
        [XmlElement("maximum_speed")]
        public int MaximumSpeed { get; set; }
        [XmlElement("fuel_tank_volume")]
        public int FuelTankVolume { get; set; }

        [XmlElement("chassi")]
        public virtual Chassi Chassi { get; set; }

        [XmlElement("number_of_doors")]
        public int NumberOfDoors { get; set; }
        [XmlElement("number_of_seats")]
        public int NumberOfSeats { get; set; }
        [XmlElement("kerb_weight")]
        public int KerbWeightKG { get; set; }
        [XmlElement("length")]
        public int LengthInMM { get; set; }
        [XmlElement("width")]
        public int WidthInMM { get; set; }
        [XmlElement("height")]
        public int HeightInMM { get; set; }       

        [XmlArray("features"), XmlArrayItem("feature")]
        public virtual List<Feature> Features { get; set; }
    }

    [Serializable]
    [XmlRoot("powertrain")]
    public class PowerTrain
    {
        [XmlIgnore]
        [ForeignKey("Car")]
        public int PowerTrainId { get; set; }

        [XmlElement("engine")]
        public virtual Engine Engine { get; set; }

        [XmlElement("transmission")]
        public virtual Transmission Transmission { get; set; }

        public virtual Car Car { get; set; }
    }

    [Serializable]
    [XmlRoot("engine")]
    public class Engine
    {
        [XmlIgnore]
        [ForeignKey("PowerTrain")]
        public int EngineId { get; set; }

        [XmlAttribute("fuel")]
        public string Fuel { get; set; }        
        [XmlAttribute("number_of_cylinders")]
        public int NumberOfCylinders { get; set; }
        [XmlAttribute("position")]
        public string Position { get; set; }
        [XmlElement("power")]
        public int PowerInHP { get; set; }
        [XmlElement("torque")]
        public int TorqueInNM { get; set; }
        [XmlElement("capacity")]
        public int CapacityInCM3 { get; set; }
        [XmlElement("consumption")]
        public double CompbinedConsumption { get; set; }
        [XmlElement("emissions")]
        public int EmissionsGramsCO2perKM { get; set; }

        public virtual PowerTrain PowerTrain { get; set; }
    }

    [Serializable]
    [XmlRoot("transmission")]
    public class Transmission
    {
        [XmlIgnore]
        [ForeignKey("PowerTrain")]
        public int TransmissionId { get; set; }

        [XmlText]
        public string Type { get; set; }

        [XmlAttribute("number_of_gears")]
        public int NumberOfGears { get; set; }

        public virtual PowerTrain PowerTrain { get; set; }
    }

    [Serializable]
    [XmlRoot("chassi")]
    public class Chassi
    {
        [XmlIgnore]
        [ForeignKey("Car")]
        public int ChassiId { get; set; }

        [XmlElement("front_suspension")]
        public string FrontSuspension { get; set; }
        [XmlElement("rear_suspension")]
        public string RearSuspension { get; set; }
        [XmlElement("front_brakes")]
        public string FrontBrakes { get; set; }
        [XmlElement("rear_brakes")]
        public string RearBrakes { get; set; }

        public virtual Car Car { get; set; }
    }

    [Serializable]
    [XmlRoot("feature")]
    public class Feature
    {
        [XmlIgnore]
        public int FeatureId { get; set; }

        [XmlText]
        public string name { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}