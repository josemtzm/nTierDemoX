<%@ Page Language="C#" Inherits="nTierDemoX.AgregarEmpleado" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>AgregarEmpleado</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <strong>Agregar nuevo empleado:<br />
        </strong>
        <br />
        <table style="width: 320px">
            <tr>
                <td>
                    Apellido</td>
                <td>
                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Nombre</td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Puesto</td>
                <td>
                    <asp:TextBox ID="txtPuesto" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Direcci髇</td>
                <td>
                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Ciudad</td>
                <td>
                    <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Regi髇</td>
                <td>
                    <asp:TextBox ID="txtRegion" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    C骴igo Postal</td>
                <td>
                    <asp:TextBox ID="txtCodigoPostal" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Pa韘</td>
                <td>
                    <asp:TextBox ID="txtPais" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Extensi髇</td>
                <td>
                    <asp:TextBox ID="txtExtension" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnYES" runat="server" OnClick="btnYES_Click" Text="Guardar" />
        <asp:Button ID="btnNO" runat="server" OnClick="btnNO_Click" Text="Cancelar" /></div>
    </form>
</body>
</html>

