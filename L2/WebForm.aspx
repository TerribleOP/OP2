<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="L2.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Label ID="Label2" runat="server" Text="Turistų informacija:" CssClass="label"></asp:Label>
            <br />
            <asp:Table ID="Table1" runat="server" CssClass="table"></asp:Table>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Viešbučių informacija:" CssClass="label"></asp:Label>
            <br />
            <asp:Table ID="Table2" runat="server" CssClass="table"></asp:Table>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Maksimali pinigų suma:" CssClass="label"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Tik realieji skaičiai" OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Skaičiuoti" CssClass="button" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Table ID="Table5" runat="server" CssClass="table"></asp:Table>
            <br />
            <asp:Table ID="Table6" runat="server" CssClass="table"></asp:Table>
            <br />
            <br />
            <asp:Table ID="Table3" runat="server" CssClass="table"></asp:Table>
            <br />
            <br />
            <asp:Table ID="Table4" runat="server" CssClass="table"></asp:Table>
        </div>
    </form>
</body>
</html>