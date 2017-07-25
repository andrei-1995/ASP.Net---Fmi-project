<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Cars.WebForm2" %>
<!DOCTYPE html>
<html>
<head>
    <title>Добавяне на нова кола</title>
</head>
<body>
    <form runat="server">    
    <h3>Добавяне на нова кола</h3>
    <div id="AddCarResult" runat="server" Visible="false">
        <asp:Label runat="server" ForeColor="Green">Добавянето на кола беше успешно!</asp:Label>
    </div>
    <div id="AddCarForm" runat="server">
        <asp:Label AssociatedControlID="GivenNameText" runat="server">Производител на български:</asp:Label><br />
        <asp:TextBox ID="GivenNameText" runat="server" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="GivenNameText" ErrorMessage="Полето за имe на производител на български е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <br />

        <asp:Label AssociatedControlID="GivenManEnText" runat="server">Производител на латиница:</asp:Label><br />
        <asp:TextBox ID="GivenManEnText" runat="server" />
        <asp:RegularExpressionValidator ControlToValidate="GivenManEnText" runat ="server" ValidationExpression="[\w -]+" ErrorMessage="Невалидно име на производител" ForeColor="Red" Display="Dynamic">Невалиден производител</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="GivenManEnText" ErrorMessage="Полето за имe на производител на латиница е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <br />

        <asp:Label AssociatedControlID="GivenModelText" runat="server">Модел:</asp:Label><br />
        <asp:TextBox ID="GivenModelText" runat="server" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="GivenModelText" ErrorMessage="Полето за модел е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <br />

        <asp:Label AssociatedControlID="GivenYearText" runat="server">Година на пускане в производство:</asp:Label><br />
        <asp:TextBox ID="GivenYearText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenYearText" runat="server" Type="Integer" ErrorMessage="Полето за година е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator ControlToValidate="GivenYearText" runat="server" Type="Integer" MinimumValue="1880" MaximumValue="2017"> Полето за година приема стойности от 1880 до 2017</asp:RangeValidator>
        <br /> 

        <asp:Label AssociatedControlID="GivenBodyText" runat="server">Тип на купето:</asp:Label><br />
        <asp:TextBox ID="GivenBodyText" runat="server" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="GivenBodyText" ErrorMessage="Полето за тип на купето е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <br /> <br /> 

        <h4>Двигател:</h4>
        <asp:Label AssociatedControlID="GivenFuelText" runat="server">Гориво:</asp:Label><br />
        <asp:TextBox ID="GivenFuelText" runat="server" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="GivenFuelText" ErrorMessage="Полето за тип гориво е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <br />

        <asp:Label AssociatedControlID="GivenPositionText" runat="server">Позиция на двигателя в колата</asp:Label><br />
        <asp:TextBox ID="GivenPositionText" runat="server" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="GivenPositionText" ErrorMessage="Полето за позиция на двигателя е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <br />
       
        <asp:Label AssociatedControlID="GivenCylindersText" runat="server">Брой цилиндри:</asp:Label><br />
        <asp:TextBox ID="GivenCylindersText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenCylindersText" runat="server" Type="Integer"  ErrorMessage="Полето за брой цилиндри е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenCylindersText" Type ="Integer" MinimumValue="1" MaximumValue="24">Полето за брой цилиндри приема стойности от 1 до 24</asp:RangeValidator>
        <br /> 

        <asp:Label AssociatedControlID="GivenPowerText" runat="server">Мощност:</asp:Label><br />
        <asp:TextBox ID="GivenPowerText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenPowerText" runat="server" Type="Integer"  ErrorMessage="Полето за мощност е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenPowerText" Type ="Integer" MinimumValue="1" MaximumValue="2000">Полето за мощност приема стойности от 1 до 2000</asp:RangeValidator>
        <br /> 
        
        <asp:Label AssociatedControlID="GivenTorqueText" runat="server">Въртящ момент:</asp:Label><br />
        <asp:TextBox ID="GivenTorqueText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenTorqueText" runat="server" Type="Integer"  ErrorMessage="Полето за въртящ момент е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenTorqueText" Type ="Integer" MinimumValue="1" MaximumValue="4000">Полето за въртящ момент приема стойности от 1 до 4000</asp:RangeValidator>
        <br /> 

        <asp:Label AssociatedControlID="GivenCapacityText" runat="server">Обем на двигателя в см3:</asp:Label><br />
        <asp:TextBox ID="GivenCapacityText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenCapacityText" runat="server" Type="Integer"  ErrorMessage="Полето за обем на двигателя е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenCapacityText" Type ="Integer" MinimumValue="50" MaximumValue="17000">Полето за обем на двигателя в см3 приема стойности от 50 до 17000</asp:RangeValidator>
        <br /> 

        <asp:Label AssociatedControlID="GivenConsumptionText" runat="server">Среден разход на гориво:</asp:Label><br />
        <asp:TextBox ID="GivenConsumptionText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenConsumptionText" runat="server" Type="Double"  ErrorMessage="Полето за среден разход е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenConsumptionText" Type ="Double" MinimumValue="1" MaximumValue="100">Полето за среден разход приема стойности от 1 до 100</asp:RangeValidator>
        <br /> 
        
        <asp:Label AssociatedControlID="GivenEmissionsText" runat="server">Вредни емисии: грамове CO2 на км.:</asp:Label><br />
        <asp:TextBox ID="GivenEmissionsText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenEmissionsText" runat="server" Type="Integer"  ErrorMessage="Полето за вредни емисии е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenEmissionsText" Type ="Integer" MinimumValue="1" MaximumValue="2000">Полето за вредни емисии приема стойности от 1 до 2000</asp:RangeValidator>
        <br /><br />

        <h4>Скоростна кутия:</h4>
        <asp:Label AssociatedControlID="GivenTypeTransmisisonText" runat="server">Тип скоростна кутия:</asp:Label><br />
        <asp:TextBox ID="GivenTypeTransmisisonText" runat="server" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="GivenTypeTransmisisonText" ErrorMessage="Полето за тип скоростна кутия е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <br />

         <asp:Label AssociatedControlID="GivenGearsText" runat="server">Брой скорости:</asp:Label><br />
        <asp:TextBox ID="GivenGearsText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenGearsText" runat="server" Type="Integer"  ErrorMessage="Полето за брой скорости е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenGearsText" Type ="Integer" MinimumValue="1" MaximumValue="24">Полето за брой скорости приема стойности от 1 до 24</asp:RangeValidator>
        <br />
       
        <asp:Label AssociatedControlID="GivenAccelerationText" runat="server">Ускорение 0-100км/ч:</asp:Label><br />
        <asp:TextBox ID="GivenAccelerationText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenAccelerationText" runat="server" Type="Double"  ErrorMessage="Полето за ускорение е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenAccelerationText" Type ="Double" MinimumValue="1" MaximumValue="50">Полето за среден разход приема стойности от 1 до 50</asp:RangeValidator>
        <br />
        
        <asp:Label AssociatedControlID="GivenMaxSpeedText" runat="server">Максимална скорост:</asp:Label><br />
        <asp:TextBox ID="GivenMaxSpeedText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenMaxSpeedText" runat="server" Type="Integer"  ErrorMessage="Полето за максимална скорост е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenMaxSpeedText" Type ="Integer" MinimumValue="50" MaximumValue="430">Полето за максимална скорост приема стойности от 50 до 430</asp:RangeValidator>
        <br />
        
        <asp:Label AssociatedControlID="GivenFuelTankVolumeText" runat="server">Обем на резервоара в литри:</asp:Label><br />
        <asp:TextBox ID="GivenFuelTankVolumeText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenFuelTankVolumeText" runat="server" Type="Integer"  ErrorMessage="Полето за обем на резервоара е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenFuelTankVolumeText" Type ="Integer" MinimumValue="10" MaximumValue="150">Полето за обем на резервоара приема стойности от 10 до 150</asp:RangeValidator>
        <br />
        
         <asp:Label AssociatedControlID="GivenDoorsText" runat="server">Брой врати:</asp:Label><br />
        <asp:TextBox ID="GivenDoorsText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenDoorsText" runat="server" Type="Integer"  ErrorMessage="Полето за брой врати е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenDoorsText" Type ="Integer" MinimumValue="1" MaximumValue="7">Полето за брой врати приема стойности от 1 до 7</asp:RangeValidator>
        <br />

         <asp:Label AssociatedControlID="GivenSeatsText" runat="server">Брой седалки:</asp:Label><br />
        <asp:TextBox ID="GivenSeatsText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenSeatsText" runat="server" Type="Integer"  ErrorMessage="Полето за брой седалки е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenSeatsText" Type ="Integer" MinimumValue="1" MaximumValue="20">Полето за брой врати приема стойности от 1 до 20</asp:RangeValidator>
        <br />
                
        <asp:Label AssociatedControlID="GivenWeightText" runat="server">Собствено тегло в кг.:</asp:Label><br />
        <asp:TextBox ID="GivenWeightText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenWeightText" runat="server" Type="Integer"  ErrorMessage="Полето за тегло е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenWeightText" Type ="Integer" MinimumValue="400" MaximumValue="3500">Полето за тегло приема стойности от 400 до 3500</asp:RangeValidator>
        <br />
                
        <asp:Label AssociatedControlID="GivenLengthText" runat="server">Дължина в мм:</asp:Label><br />
        <asp:TextBox ID="GivenLengthText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenLengthText" runat="server" Type="Integer"  ErrorMessage="Полето за дължина е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenLengthText" Type ="Integer" MinimumValue="1000" MaximumValue="10000">Полето за дължина приема стойности от 1000 до 10000</asp:RangeValidator>
        <br />

        <asp:Label AssociatedControlID="GivenWidthText" runat="server">Ширина в мм:</asp:Label><br />
        <asp:TextBox ID="GivenWidthText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenWidthText" runat="server" Type="Integer"  ErrorMessage="Полето за ширина е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenWidthText" Type ="Integer" MinimumValue="500" MaximumValue="5000">Полето за ширина приема стойности от 500 до 5000</asp:RangeValidator>
        <br />

        <asp:Label AssociatedControlID="GivenHeightText" runat="server">Височина в мм:</asp:Label><br />
        <asp:TextBox ID="GivenHeightText" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="GivenHeightText" runat="server" Type="Integer"  ErrorMessage="Полето за височина е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ControlToValidate="GivenHeightText" Type ="Integer" MinimumValue="100" MaximumValue="5000">Полето за височина приема стойности от 100 до 5000</asp:RangeValidator>
        <br /><br />

         <h4>Шаси:</h4>
        <asp:Label AssociatedControlID="GivenFrontSuspensionText" runat="server">Тип предно окачване:</asp:Label><br />
        <asp:TextBox ID="GivenFrontSuspensionText" runat="server" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="GivenFrontSuspensionText" ErrorMessage="Полето за тип предно окачване е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <br />

       <asp:Label AssociatedControlID="GivenRearSuspensionText" runat="server">Тип задно окачване:</asp:Label><br />
        <asp:TextBox ID="GivenRearSuspensionText" runat="server" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="GivenRearSuspensionText" ErrorMessage="Полето за тип задно окачване е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <br />

        <asp:Label AssociatedControlID="GivenFrontBrakesText" runat="server">Тип предни спирачки:</asp:Label><br />
        <asp:TextBox ID="GivenFrontBrakesText" runat="server" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="GivenFrontBrakesText" ErrorMessage="Полето за тип предни спирачки е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <br />

        <asp:Label AssociatedControlID="GivenRearBrakesText" runat="server">Тип задни спирачки:</asp:Label><br />
        <asp:TextBox ID="GivenRearBrakesText" runat="server" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="GivenRearBrakesText" ErrorMessage="Полето за тип задни спирачки е задължително" ForeColor="Red" Display="Dynamic">Задължително поле</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label AssociatedControlID="FeatureText" runat="server">Екстра:</asp:Label><br />
        <asp:TextBox ID="FeatureText" runat="server" />
        <asp:Label ID ="FeatureError" runat="server" Visible="False">Вече добави тази екстра!</asp:Label>                
        <asp:Button ID ="AddButton" runat ="server" OnClick ="AddButton_Click" Text="Добави екстра" />
        
         
        <div style="font-size: 20px; padding-top: 10px" id="navigation"  runat="server"/> <br />
        <div style="font-size: 20px; padding-top: 10px" id="navigation1"  runat="server"/>
    </div>
    </form>
</body>
</html>
