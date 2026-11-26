/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 04:06 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using ProyectoFBD.Models;

namespace ProyectoFBD.Backend
{
	/// <summary>
	/// Description of AuthDAO.
	/// </summary>
	public class AuthDAO
	{
		public Usuario IniciarSesion(string username, string passwordPlano)
		{
			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(passwordPlano))
			{
				throw new ArgumentException("Debes ingresar usuario y contraseña.");
			}

			string hashIngresado = CalcularSha256(passwordPlano);
			ConexionBD.RestablecerConexionBase();

			using (MySqlConnection conn = ConexionBD.ObtenerConexion())
			{
				conn.Open();
				string query = @"SELECT id_usuario, nombre_completo, username, rol, estado
                                 FROM usuarios_sistema
                                 WHERE username = @user AND password_hash = @pass LIMIT 1;";

				using (MySqlCommand cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@user", username.Trim());
					cmd.Parameters.AddWithValue("@pass", hashIngresado);

					using (MySqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							string estado = reader["estado"].ToString();
							if (estado != "activo")
							{
								throw new UnauthorizedAccessException("Esta cuenta se encuentra inactiva. Contacta al administrador.");
							}

							Usuario user = new Usuario
							{
								IdUsuario = Convert.ToInt32(reader["id_usuario"]),
								NombreCompleto = reader["nombre_completo"].ToString(),
								Username = reader["username"].ToString(),
								Rol = reader["rol"].ToString(),
								Estado = estado
							};

							// Cambiamos la conexión de MySQL al usuario restringido según su rol
							ConexionBD.ConfigurarConexionPorRol(user.Rol);
							SesionActual.UsuarioLogueado = user;

							return user;
						}
					}
				}
			}

			return null; // Credenciales incorrectas
		}

		private string CalcularSha256(string texto)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					sb.Append(bytes[i].ToString("x2"));
				}
				return sb.ToString();
			}
		}
	}
}
