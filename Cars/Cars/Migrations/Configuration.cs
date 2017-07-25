namespace Cars.Migrations
{
    using Cars.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;

    // add-migration initial
    // update-database

    internal sealed class Configuration : DbMigrationsConfiguration<Cars.Models.CarsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Cars.Models.CarsContext context)
        {
            string projectPath = System.AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo dir = new System.IO.DirectoryInfo(projectPath + "../Xmls");
            int filesCount = dir.GetFiles().Length;
            Boolean isValid = true;
            Car car = null;            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Car));
            for (int fileNumber = 1; fileNumber <= filesCount; fileNumber++)
            {
                string xmlFilePath = projectPath + "../Xmls/XMLDocument" + fileNumber + ".xml";
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                settings.ValidationType = ValidationType.DTD;
                settings.XmlResolver = new XmlUrlResolver();
                settings.ValidationEventHandler += (senders, args) => { Debug.WriteLine(args.Message); isValid = false; };                
                XmlReader reader = XmlReader.Create(xmlFilePath, settings);                
                while (reader.Read()) ;
                if (!isValid)
                {
                    continue;
                }
               
                FileStream fileStream = new FileStream(xmlFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);                
                car = (Car)xmlSerializer.Deserialize(fileStream);
                context.Cars.AddOrUpdate(car);
            }

            context.SaveChanges();
        }
    }
}
