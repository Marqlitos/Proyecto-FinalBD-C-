/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 03:58 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProyectoFBD.Models
{
	/// <summary>
	/// Description of Usuario.
	/// </summary>
	public class Usuario
	{
		public int IdUsuario { 
			get; 
			set; 
		}
		
        public string NombreCompleto { 
			get; 
			set; 
		}
		
        public string Username { 
			get; 
			set; 
		}
		
        public string Rol { 
			get; 
			set; 
		}
		
        public string Estado { 
			get; 
			set; 
		}
	}
}
