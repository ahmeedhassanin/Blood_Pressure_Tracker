<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="All_DietPlans_Form.aspx.cs" Inherits="New.All_DietPlans_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
        .auto-style1 {
            height: 715px;
            width: 100%;

  
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
            
        }
         </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style1" style="background-image: url('Imgfile/neww.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: center center; font-weight: bold; font-style: normal;">
        <div style="font-weight: bold; font-style: normal">
            <br />
            <asp:GridView ID="GridView2" runat="server" Height="252px" Width="799px">
            </asp:GridView>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" Height="273px" Width="802px">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                    <asp:BoundField DataField="Veges" HeaderText="Veges" SortExpression="Veges" />
                    <asp:BoundField DataField="Fruit" HeaderText="Fruit" SortExpression="Fruit" />
                    <asp:BoundField DataField="Meat" HeaderText="Meat" SortExpression="Meat" />
                    <asp:BoundField DataField="Drinks" HeaderText="Drinks" SortExpression="Drinks" />
                    <asp:BoundField DataField="Milk" HeaderText="Milk" SortExpression="Milk" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBnewConnectionString %>" SelectCommand="SELECT * FROM [DietPlan]"></asp:SqlDataSource>
            <br />
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" Height="51px" Width="109px" />
    </form>
</body>
</html>
