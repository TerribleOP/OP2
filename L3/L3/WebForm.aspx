<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="L3.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Label ID="Label2" runat="server" Text="Turistų informacija:" CssClass="label" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="Table1" runat="server" CssClass="table"></asp:Table>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Viešbučių informacija:" CssClass="label" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="Table2" runat="server" CssClass="table"></asp:Table>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Maksimali pinigų suma:" CssClass="label"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Tik realieji skaičiai" OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Turistų failas (U17a.txt)" CssClass="label"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Netinkamas failas" OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Viešbučių failas (U17b.txt)" CssClass="label"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload2" runat="server" />
            <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Netinkamas failas" OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Skaičiuoti" CssClass="button" OnClick="Button1_Click" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Panaudoti viešbučiai:" CssClass="label" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="Table5" runat="server" CssClass="table"></asp:Table>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Nepanaudoti viešbučiai" CssClass="label" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="Table6" runat="server" CssClass="table"></asp:Table>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Maksimalus nakvynių skaičius:" CssClass="label" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="Table3" runat="server" CssClass="table"></asp:Table>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Turistai išleidę mažiau negu maksimumas:" CssClass="label" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="Table4" runat="server" CssClass="table"></asp:Table>
        </div>
    </form>
</body>
</html>
