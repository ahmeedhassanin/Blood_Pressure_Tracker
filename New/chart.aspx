<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chart.aspx.cs" Inherits="New.chart" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        
<table style="border: 1px solid black; font-family: Arial">
<tr>
    <td>
        <b>Select Chart Type:</b>
    </td>
    <td>
          <asp:DropDownList ID="DropDownList1" Autopostback="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
</tr>
<tr>
    <td colspan="2">
        <asp:Chart ID="Chart1" runat="server" Width="1212px" Height="552px">
            <Titles>
                <asp:Title Text="Blood_Pressure_chart">
                </asp:Title>
            </Titles>
            <Series>
                <asp:Series Name="Series1" ChartArea="ChartArea1">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" Name="Series2">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisX Title="Date">
                    </AxisX>
                    <AxisY Title="Pressure">
                    </AxisY>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <br />
        <div>
    </div>
            </td>
</tr>
</table>
       </div> 
        <p>
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" Height="51px" Width="108px" />
        </p>
    </form>
</body>
</html>
