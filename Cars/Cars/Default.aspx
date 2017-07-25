<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cars._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="font-size: 20px; padding-top: 10px" id="navigation"  runat="server">Car: </div>

    <div id="body" runat="server"></div>

    <div id="tables" visible="false" runat="server">
        <asp:GridView runat="server" ID="carInfo"
            UpdateMethod="updateCar" AutoGenerateEditButton="true"
            ItemType="Cars.Models.Car" DataKeyNames="CarId" 
            SelectMethod="getCarInfo"
            AutoGenerateColumns="false">

            <Columns>
                <asp:BoundField DataField="ManufacturerBg" HeaderText="Manufacturer In Bulgarian" />
                <asp:BoundField DataField="ManufacturerEn" HeaderText="Manufacturer In English" />
                <asp:BoundField DataField="Model" HeaderText="Car's model" />
                <asp:BoundField DataField="YearOfProduction" HeaderText="Year of production" />
                <asp:BoundField DataField="BodyType" HeaderText="Body type" />
                <asp:BoundField DataField="Acceleration" HeaderText="Acceleration: 0-100km/h in seconds" />                
                <asp:BoundField DataField="MaximumSpeed" HeaderText="Maximum speed" />

                <asp:BoundField DataField="FuelTankVolume" HeaderText="Fuel tank volume in litres" />
                <asp:BoundField DataField="NumberOfDoors" HeaderText="Number of doors" />
                <asp:BoundField DataField="NumberOfSeats" HeaderText="Number of seats" />
                <asp:BoundField DataField="KerbWeightKG" HeaderText="Kerb weight in kilograms" />
                <asp:BoundField DataField="LengthInMM" HeaderText="Car's length in milimeters" />                
                <asp:BoundField DataField="WidthInMM" HeaderText="Car's width in milimeters" />                
                <asp:BoundField DataField="HeightInMM" HeaderText="Car's height in milimeters" />              
                
            </Columns>

        </asp:GridView>

        <br />

        <asp:GridView runat="server" ID="carEngine"
            ItemType="Cars.Models.Engine" DataKeyNames="EngineId"
            UpdateMethod="updateEngine" AutoGenerateEditButton="true" 
            SelectMethod="getCarEngine"
            AutoGenerateColumns="false">

            <Columns>
                <asp:BoundField DataField="Fuel" HeaderText="Fuel type" />
                <asp:BoundField DataField="Position" HeaderText="Engine's posision in car's body" />
                <asp:BoundField DataField="NumberOfCylinders" HeaderText="Number of cylinders" />
                <asp:BoundField DataField="PowerInHP" HeaderText="Engine's power in horsepowers" />
                <asp:BoundField DataField="TorqueInNM" HeaderText="Engine's torque in newton meters" />
                <asp:BoundField DataField="CapacityInCM3" HeaderText="Engine's capacity in cm3" />
                <asp:BoundField DataField="CompbinedConsumption" HeaderText="Combined consumption in letres" />
                <asp:BoundField DataField="EmissionsGramsCO2perKM" HeaderText="Grams CO2 per km" />                
            </Columns>
                      
        </asp:GridView>

         <br />

         <asp:GridView runat="server" ID="carTransmission"
            ItemType="Cars.Models.Transmission" DataKeyNames="TransmissionId"
            UpdateMethod="updateTransmission" AutoGenerateEditButton="true" 
            SelectMethod="getCarTransmission"
            AutoGenerateColumns="false">

            <Columns>
                <asp:BoundField DataField="Type" HeaderText="Transmission's type" />
                <asp:BoundField DataField="NumberOfGears" HeaderText="Number of gears" />
            </Columns>

        </asp:GridView>

         <br />

        <asp:GridView runat="server" ID="carChassi"
            ItemType="Cars.Models.Chassi" DataKeyNames="ChassiId"
            UpdateMethod="updateChassi" AutoGenerateEditButton="true" 
            SelectMethod="getCarChassi"
            AutoGenerateColumns="false">

            <Columns>
                <asp:BoundField DataField="FrontSuspension" HeaderText="Front suspension's type" />
                <asp:BoundField DataField="RearSuspension" HeaderText="Rear suspension's type" />
                <asp:BoundField DataField="FrontBrakes" HeaderText="Type of the front brakes " />
                <asp:BoundField DataField="RearBrakes" HeaderText="Type of the rear brakes" />
            </Columns>

        </asp:GridView>

         <br />

        <asp:GridView runat="server" ID="carFeatures"
            ItemType="Cars.Models.Feature" DataKeyNames="FeatureId"
            UpdateMethod="updateFeature" AutoGenerateEditButton="true" 
            SelectMethod="getCarFeatures"
            AutoGenerateColumns="false">

            <Columns>
                <asp:BoundField DataField="name" HeaderText="Feature's name" />
            </Columns>

        </asp:GridView>

    </div>

</asp:Content>
