<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="L5.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
</head>
<body style="height: 600px">
    <form id="form1" runat="server">
        <div style="height: 605px; margin-left: 80px;">
            <br />
            <br />
            <asp:Panel ID="TablesContainer1" runat="server"></asp:Panel>
            <br />
            <br />
            <asp:Panel ID="TablesContainer2" runat="server"></asp:Panel>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Skaičiuoti" />
            <br />
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Netinkamas skaičius" ValidateEmptyText="True" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Atrinkti" Visible="False" />
            <br />
            <br />
            
            <asp:Table ID="Table2" runat="server"></asp:Table>
            <br />
            <br />
            <asp:Table ID="Table3" runat="server"></asp:Table>
            <br />
            <br />
            <asp:Table ID="Table4" runat="server"></asp:Table>
            <br />
            <br />
            <asp:Table ID="Table5" runat="server"></asp:Table>
            <br />
        </div>
    </form>
</body>
</html>
