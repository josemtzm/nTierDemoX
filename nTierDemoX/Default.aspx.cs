using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace nTierDemoX
{
	
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			lblResult.Text = string.Empty;
			//empHelper = new BLL.EmpleadoHelper();
//			empHelper = new EmpleadoHelperWCF();
			if (IsPostBack == false)
			{
				BindData();
			}
		}

		private void BindData()
		{
//			gvEmpleados.DataSource = empHelper.ObtenerEmpleadosLista();
			gvEmpleados.DataSource = DbContext.ObtenerEmpleadosLista();
			gvEmpleados.DataBind();
		}


		protected void gvEmpleados_RowEditing(object sender, GridViewEditEventArgs e)
		{
			gvEmpleados.EditIndex = e.NewEditIndex;
			BindData();
		}

		protected void gvEmpleados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			gvEmpleados.EditIndex = -1;
			BindData();
		}

		protected void gvEmpleados_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			Label lblID = gvEmpleados.Rows[e.RowIndex].FindControl("lblID") as Label;

			TextBox txtLastName = gvEmpleados.Rows[e.RowIndex].FindControl("txtApellido") as TextBox;
			TextBox txtFirstName = gvEmpleados.Rows[e.RowIndex].FindControl("txtNombre") as TextBox;
			TextBox txtTitle = gvEmpleados.Rows[e.RowIndex].FindControl("txtPuesto") as TextBox;
			TextBox txtAddress = gvEmpleados.Rows[e.RowIndex].FindControl("txtDireccion") as TextBox;
			TextBox txtCity = gvEmpleados.Rows[e.RowIndex].FindControl("txtCiudad") as TextBox;
			TextBox txtRegion = gvEmpleados.Rows[e.RowIndex].FindControl("txtRegion") as TextBox;
			TextBox txtPostalCode = gvEmpleados.Rows[e.RowIndex].FindControl("txtCodigoPostal") as TextBox;
			TextBox txtCountry = gvEmpleados.Rows[e.RowIndex].FindControl("txtPais") as TextBox;
			TextBox txtExtension = gvEmpleados.Rows[e.RowIndex].FindControl("txtExtension") as TextBox;


			if (lblID != null && txtLastName != null && txtFirstName != null && txtTitle != null &&
				txtAddress != null && txtCity != null && txtRegion != null &&
				txtPostalCode != null && txtCountry != null && txtExtension != null)
			{
//				BLL_WCF.SrvEmpleado.Empleado empleado = new BLL_WCF.SrvEmpleado.Empleado();
				Empleado empleado = new Empleado();

				empleado.EmpleadoID = Convert.ToInt32(lblID.Text.Trim());
				empleado.Apellido = txtLastName.Text;
				empleado.Nombre = txtFirstName.Text;
				empleado.Puesto = txtTitle.Text;
				empleado.Direccion = txtAddress.Text;
				empleado.Ciudad = txtCity.Text;
				empleado.Region = txtRegion.Text;
				empleado.CodigoPostal = txtPostalCode.Text;
				empleado.Pais = txtCountry.Text;
				empleado.Extension = txtExtension.Text;

				if (DbContext.ActualizarEmpleado(empleado) == true)
				{
					lblResult.Text = "Se actualiz� el registro correctamente";
				}
				else
				{
					lblResult.Text = "Fall� al actualizar el registro";
				}

				gvEmpleados.EditIndex = -1;
				BindData();
			}
		}
		protected void btnAgregar_Click(object sender, EventArgs e)
		{
			Response.Redirect("AgregarEmpleado.aspx");
		}
	}
}

