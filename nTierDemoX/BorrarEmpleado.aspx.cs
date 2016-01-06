using System;
using System.Web;
using System.Web.UI;
using BLL;

namespace nTierDemoX
{
	
	public partial class BorrarEmpleado : System.Web.UI.Page
	{
		//    EmpleadoHelper empHelper = null;
		//    EmpleadoHelperWCF empHelper = null;
		int empID = 0;

		protected void Page_Load(object sender, EventArgs e)
		{
			string id = Request.QueryString["id"] as string;

			if (id == null)
			{
				Response.Redirect("Default.aspx");
			}

			try
			{
				empID = Convert.ToInt32(id.Trim());
				//empHelper = new EmpleadoHelper();
				//            empHelper = new EmpleadoHelperWCF();
				//            BLL_WCF.SrvEmpleado.Empleado emp = empHelper.ObtenerEmpleadoDetalle(empID);
				Empleado emp = DbContext.ObtenerEmpleadoDetalle(empID);

				lblEmpleadoID.Text = emp.EmpleadoID.ToString();
				lblApellido.Text = emp.Apellido;
				lblNombre.Text = emp.Nombre;
				lblPuesto.Text = emp.Puesto;
				lblDireccion.Text = emp.Direccion;
				lblCiudad.Text = emp.Ciudad;
				lblPais.Text = emp.Pais;
				lblRegion.Text = emp.Region;
				lblCodigoPostal.Text = emp.CodigoPostal;
				lblExtension.Text = emp.Extension;
			}
			catch(Exception)
			{
				Response.Redirect("Default.aspx");
			}
		}
		protected void btnNO_Click(object sender, EventArgs e)
		{
			Response.Redirect("Default.aspx");
		}

		protected void btnYES_Click(object sender, EventArgs e)
		{
			if (DbContext.BorrarEmpleado(empID) == true)
			{
				Response.Redirect("Default.aspx");
			}        
		}
	}
}

