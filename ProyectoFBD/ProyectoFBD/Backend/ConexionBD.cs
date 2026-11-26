/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 04:05 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using MySql.Data.MySqlClient;

namespace ProyectoFBD.Backend
{
	/// <summary>
	/// Description of ConexionBD.
	/// </summary>
	public class ConexionBD
	{
		private static string cadenaBase = "Server=localhost;Database=bibliotecnm;Uid=usr_admin;Pwd=AdminBiblio2026!;SslMode=none;AllowPublicKeyRetrieval=True;";
        private static string cadenaActiva = cadenaBase;

        public static MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cadenaActiva);
        }

        public static void ConfigurarConexionPorRol(string rol)
        {
            switch (rol.ToLower())
            {
                case "administrador":
                    cadenaActiva = "Server=localhost;Database=bibliotecnm;Uid=usr_admin;Pwd=AdminBiblio2026!;SslMode=none;AllowPublicKeyRetrieval=True;";
                    break;
                case "operador":
                    cadenaActiva = "Server=localhost;Database=bibliotecnm;Uid=usr_operador;Pwd=OpBiblio2026!;SslMode=none;AllowPublicKeyRetrieval=True;";
                    break;
                case "consulta":
                    cadenaActiva = "Server=localhost;Database=bibliotecnm;Uid=usr_consulta;Pwd=ConsBiblio2026!;SslMode=none;AllowPublicKeyRetrieval=True;";
                    break;
                default:
                    cadenaActiva = cadenaBase;
                    break;
            }
        }

        public static void RestablecerConexionBase()
        {
            cadenaActiva = cadenaBase;
        }
	}
}
