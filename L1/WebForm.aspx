<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="L1.WebForm" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    .tables-container { display: flex; gap: 20px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 500px">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"/>
            <asp:Label ID="Label1" runat="server" Text="Eilutes(N):"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="Do not leave empty spaces" Text="*"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox1" ForeColor="Red" Text="*" OnServerValidate="CustomValidator1_ServerValidate" ErrorMessage="Digit, 1<=N<=20"></asp:CustomValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Stulpeliai(M):"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ForeColor="Red" ErrorMessage="Do not leave empty spaces" Text="*"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="TextBox2" ForeColor="Red" Text="*" OnServerValidate="CustomValidator2_ServerValidate" ErrorMessage="Digit, 1<=M<=30"></asp:CustomValidator>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />

            <div class="tables-container">
                <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both"></asp:Table>
                <asp:Table ID="Table2" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both"></asp:Table>
            </div>

            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
