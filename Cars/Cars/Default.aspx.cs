using Cars.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace Cars
{
    public partial class _Default : System.Web.UI.Page
    {
        private static List<Car> cars;
        private DropDownList carsDropdown;
        private Button exportButton;
        private static Car selectedCar;
        private static CarsContext db = new CarsContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else
            {

                int carId; Int32.TryParse(carsDropdown.SelectedValue, out carId);

                if (carId > 0)
                {
                    body.Visible = false;
                    tables.Visible = true;
                    loadExportButton();
                }
                else
                {
                    body.Visible = true;
                    tables.Visible = false;
                    removeExportButton();
                }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            loadCars();
            loadDropdown();
            navigation.Controls.Add(carsDropdown);
            displayAll();
        }

        protected void exportToXML(Object sender, EventArgs e)
        {
            string xml = "";

            Car car = new Car();
            car.ManufacturerBg = selectedCar.ManufacturerBg;
            car.ManufacturerEn = selectedCar.ManufacturerEn;
            car.Model = selectedCar.Model;
            car.YearOfProduction = selectedCar.YearOfProduction;
            car.BodyType = selectedCar.BodyType;
            car.Acceleration = selectedCar.Acceleration;
            car.MaximumSpeed = selectedCar.MaximumSpeed;
            car.FuelTankVolume = selectedCar.FuelTankVolume;
            car.NumberOfDoors = selectedCar.NumberOfDoors;
            car.NumberOfSeats = selectedCar.NumberOfSeats;
            car.KerbWeightKG = selectedCar.KerbWeightKG;
            car.LengthInMM = selectedCar.LengthInMM;
            car.WidthInMM = selectedCar.WidthInMM;
            car.HeightInMM = selectedCar.HeightInMM;

            PowerTrain powerTrain = new PowerTrain();

            Engine engine = new Engine();
            engine.Fuel = selectedCar.PowerTrain.Engine.Fuel;
            engine.Position = selectedCar.PowerTrain.Engine.Fuel;
            engine.NumberOfCylinders = selectedCar.PowerTrain.Engine.NumberOfCylinders;
            engine.PowerInHP = selectedCar.PowerTrain.Engine.PowerInHP;
            engine.TorqueInNM = selectedCar.PowerTrain.Engine.TorqueInNM;
            engine.CapacityInCM3 = selectedCar.PowerTrain.Engine.CapacityInCM3;
            engine.CompbinedConsumption = selectedCar.PowerTrain.Engine.CompbinedConsumption;
            engine.EmissionsGramsCO2perKM = selectedCar.PowerTrain.Engine.EmissionsGramsCO2perKM;

            powerTrain.Engine = engine;

            Transmission transmission = new Transmission();
            transmission.Type = selectedCar.PowerTrain.Transmission.Type;
            transmission.NumberOfGears = selectedCar.PowerTrain.Transmission.NumberOfGears;

            powerTrain.Transmission = transmission;

            car.PowerTrain = powerTrain;

            Chassi chassi = new Chassi();
            chassi.FrontSuspension = selectedCar.Chassi.FrontSuspension;
            chassi.RearSuspension = selectedCar.Chassi.RearSuspension;
            chassi.FrontBrakes = selectedCar.Chassi.FrontBrakes;
            chassi.RearBrakes = selectedCar.Chassi.RearBrakes;
            car.Chassi = chassi;

            List<Feature> features = new List<Feature>();
            foreach (Feature feature in selectedCar.Features)
            {
                Feature f = new Feature();
                f.name = feature.name;
                features.Add(f);
            }
            car.Features = features;


            XmlSerializer serializer = new XmlSerializer(car.GetType());
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, car);
                xml = writer.ToString();
            }

            string projectPath = System.AppDomain.CurrentDomain.BaseDirectory;

            string xmlFileName = "Car_" + selectedCar.ManufacturerEn + "_"
                + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".xml";

            string xmlFilePath = projectPath + "Xmls_Exported/" + xmlFileName;

            File.WriteAllText(@xmlFilePath, xml);
        }

        protected void display(Object sender, EventArgs e)
        {
            body.Controls.Clear();

            int carId; Int32.TryParse(carsDropdown.SelectedValue, out carId);

            if (carId > 0)
            {
                displayCar(carId, true);
            }
            else
            {
                displayAll();
                removeExportButton();
            }
        }

        public void updateCar(int carId)
        {
            using (CarsContext db = new CarsContext())
            {
                Car car = null;
                car = db.Cars.Find(carId);

                if (car == null)
                {
                    return;
                }

                TryUpdateModel(car);
                db.SaveChanges();

                car = cars.FirstOrDefault(b => b.CarId == carId);
                TryUpdateModel(car);
            }
        }

        public void updateEngine(int engineId)
        {
            using (CarsContext db = new CarsContext())
            {
                Engine engine = null;
                engine = db.Engines.Find(engineId);

                if (engine == null)
                {
                    return;
                }

                TryUpdateModel(engine);
                db.SaveChanges();

                engine = cars.FirstOrDefault(b => b.CarId == selectedCar.CarId).PowerTrain.Engine;
                TryUpdateModel(engine);
            }
        }

        public void updateTransmission(int transmissionId)
        {
            using (CarsContext db = new CarsContext())
            {
                Transmission tr = null;
                tr = db.Transmissions.Find(transmissionId);

                if (tr == null)
                {
                    return;
                }

                TryUpdateModel(tr);
                db.SaveChanges();

                tr = cars.FirstOrDefault(b => b.CarId == selectedCar.CarId).PowerTrain.Transmission;
                TryUpdateModel(tr);
            }
        }

        public void updateChassi(int chassiId)
        {
            using (CarsContext db = new CarsContext())
            {
                Chassi chassi = null;
                chassi = db.Chassis.Find(chassiId);

                if (chassi == null)
                {
                    return;
                }

                TryUpdateModel(chassi);
                db.SaveChanges();

                chassi = cars.FirstOrDefault(b => b.CarId == selectedCar.CarId).Chassi;
                TryUpdateModel(chassi);
            }
        }

        public void updateFeature(int featureId)
        {
            using (CarsContext db = new CarsContext())
            {
                Feature feature = null;
                feature = db.Features.Find(featureId);

                if (feature == null)
                {
                    return;
                }

                TryUpdateModel(feature);
                db.SaveChanges();

                feature = cars.FirstOrDefault(b => b.CarId == selectedCar.CarId).Features.FirstOrDefault(f => f.FeatureId == featureId);
                TryUpdateModel(feature);
            }
        }


        protected void displayCar(int carId, Boolean selected = false, Boolean all = false)
        {
            Car car = getCar(carId);

            if (selected)
            {
                selectedCar = car;
            }

            if (all)
            {
                body.Controls.Add(new LiteralControl("<hr><h2>" + car.ManufacturerEn + " (" + car.ManufacturerBg + ") -" +
                    car.Model + " " + car.YearOfProduction + " г.</h2>"));

                body.Controls.Add(new LiteralControl("<h3>Двигател: </h3>"));
                body.Controls.Add(new LiteralControl("<p>Гориво: " + car.PowerTrain.Engine.Fuel + "</p>"));
                body.Controls.Add(new LiteralControl("<p>Позиция в колата: " + car.PowerTrain.Engine.Position + "</p>"));
                body.Controls.Add(new LiteralControl("<p>Брой цилиндри: " + car.PowerTrain.Engine.NumberOfCylinders + "</p>"));
                body.Controls.Add(new LiteralControl("<p>Мощност в кс: " + car.PowerTrain.Engine.PowerInHP + "</p>"));
                body.Controls.Add(new LiteralControl("<p>Въртящ момент в НМ: " + car.PowerTrain.Engine.TorqueInNM + "</p>"));
                body.Controls.Add(new LiteralControl("<p>Обем на двигателя в см3: " + car.PowerTrain.Engine.CapacityInCM3 + "</p>"));
                body.Controls.Add(new LiteralControl("<p>Среден разход на гориво в литри: " + car.PowerTrain.Engine.CompbinedConsumption + "</p>"));
                body.Controls.Add(new LiteralControl("<p>Вредни емисии: грамове CO2 на км.: " + car.PowerTrain.Engine.EmissionsGramsCO2perKM + "</p>"));

                body.Controls.Add(new LiteralControl("<h3>Скоростна кутия: </h3>"));
                body.Controls.Add(new LiteralControl("<p>Вид: " + car.PowerTrain.Transmission.Type + "</p>"));
                body.Controls.Add(new LiteralControl("<p>Брой скорости: " + car.PowerTrain.Transmission.NumberOfGears + "</p>"));

                body.Controls.Add(new LiteralControl("<h3>Тип на купето: " + car.BodyType + "</h3>"));
                body.Controls.Add(new LiteralControl("<h3>Ускорение 0-100км/ч: " + car.Acceleration + "</h3>"));
                body.Controls.Add(new LiteralControl("<h3>Максимална скорост: " + car.MaximumSpeed + "</h3>"));
                body.Controls.Add(new LiteralControl("<h3>Обем на резервоара в литри: " + car.FuelTankVolume + "</h3>"));
                body.Controls.Add(new LiteralControl("<h3>Брой врати: " + car.NumberOfDoors + "</h3>"));
                body.Controls.Add(new LiteralControl("<h3>Брой седалки: " + car.NumberOfSeats + "</h3>"));
                body.Controls.Add(new LiteralControl("<h3>Собствено тегло в кг.: " + car.KerbWeightKG + "</h3>"));
                body.Controls.Add(new LiteralControl("<h3>Дължина в мм: " + car.LengthInMM + "</h3>"));
                body.Controls.Add(new LiteralControl("<h3>Ширина в мм: " + car.WidthInMM + "</h3>"));
                body.Controls.Add(new LiteralControl("<h3>Височина в мм: " + car.HeightInMM + "</h3>"));

                body.Controls.Add(new LiteralControl("<h3>Шаси: </h3>"));
                body.Controls.Add(new LiteralControl("<p>Предно окачване: " + car.Chassi.FrontSuspension + "</p>"));
                body.Controls.Add(new LiteralControl("<p>Задно окачване: " + car.Chassi.RearSuspension + "</p>"));
                body.Controls.Add(new LiteralControl("<p>Предни спирачки: " + car.Chassi.FrontBrakes + "</p>"));
                body.Controls.Add(new LiteralControl("<p>Задни спирачки: " + car.Chassi.RearBrakes + "</p>"));

                foreach (Feature feature in car.Features)
                {
                    body.Controls.Add(new LiteralControl("<h3>Екстра: " + feature.name + "</h3>"));
                }
            }
            else
            {
                body.Controls.Clear();
                body.Controls.Add(new LiteralControl("<hr>"));

                carInfo.DataBind();
                carEngine.DataBind();
                carTransmission.DataBind();
                carChassi.DataBind();
                carFeatures.DataBind();
                tables.Visible = true;
            }
        }

        protected void displayAll()
        {
            foreach (Car car in cars)
            {
                displayCar(car.CarId, false, true);
            }
        }

        protected Car getCar(int carId)
        {
            foreach (Car car in cars)
            {
                if (car.CarId == carId)
                {
                    return car;
                }
            }

            return null;
        }

        protected void loadCars()
        {
            var query = db.Cars;

            cars = query.ToList();
        }

        public IQueryable<Car> getCarInfo()
        {
            var query = from x in db.Cars where x.CarId == selectedCar.CarId select x;

            return query;
        }

        public IQueryable<Engine> getCarEngine()
        {
            var query = from x in db.Engines where x.EngineId == selectedCar.CarId select x;
            return query;

        }

        public IQueryable<Transmission> getCarTransmission()
        {
            var query = from x in db.Transmissions where x.TransmissionId == selectedCar.CarId select x;

            return query;

        }

        public IQueryable<Chassi> getCarChassi()
        {
            var query = from x in db.Chassis where x.ChassiId == selectedCar.CarId select x;

            return query;
        }

        public IQueryable<Feature> getCarFeatures()
        {
            var query = (from x in selectedCar.Features select x).AsQueryable();

            return query;
        }

        protected void loadDropdown()
        {
            carsDropdown = new DropDownList();
            carsDropdown.AutoPostBack = true;
            carsDropdown.SelectedIndexChanged += display;

            ListItem firstItem = new ListItem();

            firstItem.Text = "All Cars";
            firstItem.Value = "0";
            carsDropdown.Items.Add(firstItem);

            foreach (Car car in cars)
            {
                ListItem item = new ListItem();
                item.Text = car.ManufacturerEn + " " + car.Model;
                item.Value = "" + car.CarId;
                carsDropdown.Items.Add(item);
            }
        }

        protected void loadExportButton()
        {
            exportButton = new Button();
            exportButton.Text = "Export To XML";
            exportButton.Attributes.Add("style", "position:absolute; left: 1200px");
            exportButton.ViewStateMode = ViewStateMode.Enabled;
            exportButton.EnableViewState = true;
            exportButton.Click += exportToXML;

            navigation.Controls.Add(exportButton);
        }

        protected void removeExportButton()
        {
            navigation.Controls.Remove(exportButton);
        }        
    }
}