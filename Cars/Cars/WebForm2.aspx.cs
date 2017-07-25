using Cars.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace Cars
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private Button exportButton;
        private Button addCarButton;
        private List<Feature> features1 = new List<Feature>();
        private static CarsContext db = new CarsContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            loadExportButton();
            loadAddCarButton();           
            if (ViewState["features1"] != null)
            {
                features1 = (List<Feature>)ViewState["features1"];
            }
            FeatureError.Visible = false;      
        }

        protected void loadExportButton()
        {
            exportButton = new Button();
            exportButton.Text = "Export To XML";
            exportButton.Attributes.Add("style", "position:absolute;");
            exportButton.ViewStateMode = ViewStateMode.Enabled;
            exportButton.EnableViewState = true;
            exportButton.Click += exportToXML;

            navigation.Controls.Add(exportButton);
        }
        protected void loadAddCarButton()
        {
            addCarButton = new Button();
            addCarButton.Text = "Add car in the database";
            addCarButton.Attributes.Add("style", "position:absolute;");
            addCarButton.ViewStateMode = ViewStateMode.Enabled;
            addCarButton.EnableViewState = true;
            addCarButton.Click += addCarDB;

            navigation1.Controls.Add(addCarButton);
        }



        protected void exportToXML(Object sender, EventArgs e)
        {
            if(!IsValid || features1.Count() == 0)
            {
                return;
            }
            string xml = "";

            Car car = getCarFormValues();

            XmlSerializer serializer = new XmlSerializer(car.GetType());
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, car);
                xml = writer.ToString();
            }

            string projectPath = System.AppDomain.CurrentDomain.BaseDirectory;

            string xmlFileName = "Car_" + car.ManufacturerEn + "_"
                + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".xml";

            string xmlFilePath = projectPath + "Xmls_Exported/" + xmlFileName;

            File.WriteAllText(@xmlFilePath, xml);
        }

        private Car getCarFormValues()
        {
            Car car = new Car();
            car.ManufacturerBg = GivenNameText.Text.ToString();
            car.ManufacturerEn = GivenManEnText.Text.ToString();
            car.Model = GivenModelText.Text.ToString();
            car.YearOfProduction = int.Parse(GivenYearText.Text);
            car.BodyType = GivenBodyText.Text.ToString();
            car.Acceleration = double.Parse(GivenAccelerationText.Text);
            car.MaximumSpeed = int.Parse(GivenMaxSpeedText.Text);
            car.FuelTankVolume = int.Parse(GivenFuelTankVolumeText.Text);
            car.NumberOfDoors = int.Parse(GivenDoorsText.Text);
            car.NumberOfSeats = int.Parse(GivenSeatsText.Text);
            car.KerbWeightKG = int.Parse(GivenWeightText.Text);
            car.LengthInMM = int.Parse(GivenLengthText.Text);
            car.WidthInMM = int.Parse(GivenWidthText.Text);
            car.HeightInMM = int.Parse(GivenHeightText.Text);

            PowerTrain powerTrain = new PowerTrain();

            Engine engine = new Engine();
            engine.Fuel = GivenFuelText.Text.ToString();
            engine.Position = GivenPositionText.Text.ToString();
            engine.NumberOfCylinders = int.Parse(GivenCylindersText.Text);
            engine.PowerInHP = int.Parse(GivenPowerText.Text);
            engine.TorqueInNM = int.Parse(GivenTorqueText.Text);
            engine.CapacityInCM3 = int.Parse(GivenCapacityText.Text);
            engine.CompbinedConsumption = double.Parse(GivenConsumptionText.Text);
            engine.EmissionsGramsCO2perKM = int.Parse(GivenEmissionsText.Text);

            powerTrain.Engine = engine;

            Transmission transmission = new Transmission();
            transmission.Type = GivenTypeTransmisisonText.Text.ToString();
            transmission.NumberOfGears = int.Parse(GivenGearsText.Text);

            powerTrain.Transmission = transmission;

            car.PowerTrain = powerTrain;

            Chassi chassi = new Chassi();
            chassi.FrontSuspension = GivenFrontSuspensionText.Text.ToString();
            chassi.RearSuspension = GivenRearSuspensionText.Text.ToString();
            chassi.FrontBrakes = GivenFrontBrakesText.Text.ToString();
            chassi.RearBrakes = GivenRearBrakesText.Text.ToString();
            car.Chassi = chassi;

            List<Feature> features = new List<Feature>();
            foreach (Feature feature in features1)
            {
                Feature f = new Feature();
                f.name = feature.name;
                features.Add(f);
            }
            car.Features = features;
            return car;
        }
        

        protected void addCarDB(Object sender, EventArgs e)
        {
            if (!IsValid || features1.Count() == 0) return;
            Car car = getCarFormValues();
            db.Cars.Add(car);
            db.Engines.Add(car.PowerTrain.Engine);
            db.Transmissions.Add(car.PowerTrain.Transmission);
            db.Chassis.Add(car.Chassi);
            foreach(Feature f in car.Features) db.Features.Add(f);
            db.SaveChanges();
        }

        private bool isNotAdded(string feature)
        {
            foreach(Feature f in features1)
            {
                if (f.name.Equals(feature))
                {
                    return false;
                }
            }
            return true;
        }
        

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Feature feature = new Feature();
            feature.name = FeatureText.Text.ToString();
            if (isNotAdded(feature.name)) features1.Add(feature);
            else FeatureError.Visible = true;        
            ViewState["features1"] = features1;
        }
    }
}