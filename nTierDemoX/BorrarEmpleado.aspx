<%@ Page Language="C#" Inherits="nTierDemoX.BorrarEmpleado" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>BorrarEmpleado</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Confirmaci髇 para borrar el empleado:<br />
        <br />
        <table style="width: 320px">
            <tr>
                <td>
                    Empleado ID</td>
                <td>
                    <asp:Label ID="lblEmpleadoID" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Apellido</td>
                <td>
                    <asp:Label ID="lblApellido" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Nombre</td>
                <td>
                    <asp:Label ID="lblNombre" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Puesto</td>
                <td>
                    <asp:Label ID="lblPuesto" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Direcci髇</td>
                <td>
                    <asp:Label ID="lblDireccion" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Ciudad</td>
                <td>
                    <asp:Label ID="lblCiudad" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Regi髇</td>
                <td>
                    <asp:Label ID="lblRegion" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    C骴igo Postal</td>
                <td>
                    <asp:Label ID="lblCodigoPostal" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Pa韘</td>
                <td>
                    <asp:Label ID="lblPais" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Extensi髇</td>
                <td>
                    <asp:Label ID="lblExtension" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
        </table>
    
    </div>
        <br />
        縀sta seguro que desea borrar el registro?: &nbsp; &nbsp;
        <asp:Button ID="btnYES" runat="server" Text="Si" OnClick="btnYES_Click" />
        <asp:Button ID="btnNO" runat="server" Text="No" OnClick="btnNO_Click" /><br />
        <br />
    </form>
</body>
</html>

