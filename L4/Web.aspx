<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Web.aspx.cs" Inherits="L4.Web" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 600px">

            <asp:Label ID="Label1" runat="server" Text="Initial data" CssClass="label"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Panel ID="TablesContainer1" runat="server"></asp:Panel>
            <br />
            
            <asp:Button ID="Button1" runat="server" Text="Calculate" OnClick="Button1_Click" />

            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>


            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
            <br />

            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>

        </div>
    </form>
</body>
</html>
