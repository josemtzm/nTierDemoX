<%@ Page Language="C#" Inherits="nTierDemoX.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default_2</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>
                Lista de todos los empleados</h3>
            <br />
            <asp:GridView ID="gvEmpleados" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False"
                AutoGenerateEditButton="True" OnRowCancelingEdit="gvEmpleados_RowCancelingEdit"
                OnRowEditing="gvEmpleados_RowEditing" OnRowUpdating="gvEmpleados_RowUpdating" BorderColor="Silver"
                BorderStyle="Solid" BorderWidth="1px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Empleado ID">
                        <EditItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("EmpleadoID") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEmpleadoID" runat="server" Text='<%# Bind("EmpleadoID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido Paterno">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtApellido" runat="server" Text='<%# Bind("Apellido") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblApellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("Nombre") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Puesto">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPuesto" runat="server" Text='<%# Bind("Puesto") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPuesto" runat="server" Text='<%# Bind("Puesto") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dirección">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDireccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDireccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ciudad">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCiudad" runat="server" Text='<%# Bind("Ciudad") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCiudad" runat="server" Text='<%# Bind("Ciudad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Región">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtRegion" runat="server" Text='<%# Bind("Region") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblRegion" runat="server" Text='<%# Bind("Region") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Código Postal">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCodigoPostal" runat="server" Text='<%# Bind("CodigoPostal") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCodigoPostal" runat="server" Text='<%# Bind("CodigoPostal") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="País">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPais" runat="server" Text='<%# Bind("Pais") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPais" runat="server" Text='<%# Bind("Pais") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Extensión">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtExtension" runat="server" Text='<%# Bind("Extension") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblExtension" runat="server" Text='<%# Bind("Extension") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField Text="Borrar" DataNavigateUrlFields="EmpleadoID" DataNavigateUrlFormatString="~/BorrarEmpleado.aspx?id={0}" />
                </Columns>
            </asp:GridView>
            &nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar nuevo empleado" OnClick="btnAgregar_Click" /><br />
            <br />
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label></div>
    </form>
</body>
</html>

