/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 04:04 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProyectoFBD.Models
{
	/// <summary>
	/// Description of SesionActual.
	/// </summary>
	public static class SesionActual
	{
		public static Usuario UsuarioLogueado { get; set; }

        public static bool EsAdministrador()
        {
            return UsuarioLogueado != null && UsuarioLogueado.Rol == "administrador";
        }

        public static bool PuedeOperar()
        {
            return UsuarioLogueado != null && 
                   (UsuarioLogueado.Rol == "administrador" || UsuarioLogueado.Rol == "operador");
        }

        public static void CerrarSesion()
        {
            UsuarioLogueado = null;
        }
	}
}
