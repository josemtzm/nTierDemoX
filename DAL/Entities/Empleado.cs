namespace BLL
{
	public class Empleado
	{
		int empleadoID;
		string apellido;   
		string nombre;  
		string puesto;      
		string direccion;    
		string ciudad;       
		string region;     
		string codigoPostal; 
		string pais;    
		string extension;  

		public int EmpleadoID
		{
			get
			{
				return empleadoID;
			}
			set
			{
				empleadoID = value;
			}
		}

		public string Apellido
		{
			get
			{
				return apellido;
			}
			set
			{
				apellido  = value;
			}
		}

		public string Nombre
		{
			get
			{
				return nombre;
			}
			set
			{
				nombre = value;
			}
		}

		public string Puesto
		{
			get
			{
				return puesto;
			}
			set
			{
				puesto = value;
			}
		}

		public string Direccion
		{
			get
			{
				return direccion;
			}
			set
			{
				direccion = value;
			}
		}

		public string Ciudad
		{
			get
			{
				return ciudad;
			}
			set
			{
				ciudad = value;
			}
		}

		public string Region
		{
			get
			{
				return region;
			}
			set
			{
				region = value;
			}
		}

		public string CodigoPostal
		{
			get
			{
				return codigoPostal;
			}
			set
			{
				codigoPostal = value;
			}
		}

		public string Pais
		{
			get
			{
				return pais;
			}
			set
			{
				pais = value;
			}
		}

		public string Extension
		{
			get
			{
				return extension;
			}
			set
			{
				extension = value;
			}
		}
	}
}
