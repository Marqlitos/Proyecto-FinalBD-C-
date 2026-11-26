/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 06:52 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using MySql.Data.MySqlClient;
using ProyectoFBD.Models;

namespace ProyectoFBD.Backend
{
	/// <summary>
	/// Description of PrestamosDAO.
	/// </summary>
	public class PrestamosDAO
	{
		public DataTable ListarPrestamosActivos()
		{
			DataTable tabla = new DataTable();
			using (MySqlConnection conn = ConexionBD.ObtenerConexion())
			{
				conn.Open();
				string query = @"SELECT p.id_prestamo AS 'ID Préstamo',
                                        p.matricula AS 'Matrícula',
                                        CONCAT(a.nombre, ' ', a.apellidos) AS 'Alumno',
                                        l.codigo_barras AS 'Código Barras',
                                        l.titulo AS 'Libro',
                                        p.fecha_prestamo AS 'Fecha Préstamo',
                                        p.fecha_limite AS 'Fecha Límite',
                                        fn_dias_retraso(p.id_prestamo) AS 'Días Retraso'
                                 FROM prestamos p
                                 INNER JOIN alumnos a ON p.matricula = a.matricula
                                 INNER JOIN libros l ON p.id_libro = l.id_libro
                                 WHERE p.estado = 'activo'
                                 ORDER BY p.fecha_limite ASC;";

				using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
				{
					adapter.Fill(tabla);
				}
			}
			return tabla;
		}

		public string ConsultarDatosAlumno(string matricula)
		{
			if (string.IsNullOrWhiteSpace(matricula))
				return null;

			using (MySqlConnection conn = ConexionBD.ObtenerConexion())
			{
				conn.Open();
				string query = "SELECT nombre, apellidos, carrera, estado FROM alumnos WHERE matricula = @mat LIMIT 1;";
				using (MySqlCommand cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@mat", matricula.Trim());
					using (MySqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							return string.Format("{0} {1} ({2}) - Estado: {3}",
							                     reader["nombre"],
							                     reader["apellidos"],
							                     reader["carrera"],
							                     reader["estado"].ToString().ToUpper());
						}
					}
				}
			}
			return null;
		}

		public string RegistrarPrestamo(string matricula, string codigoBarras, int diasPrestamo)
		{
			if (string.IsNullOrWhiteSpace(matricula) || string.IsNullOrWhiteSpace(codigoBarras))
			{
				throw new ArgumentException("Ingresa la matrícula del alumno y escanea el código de barras del libro.");
			}

			if (SesionActual.UsuarioLogueado == null)
			{
				throw new InvalidOperationException("No hay una sesión de usuario activa.");
			}

			using (MySqlConnection conn = ConexionBD.ObtenerConexion())
			{
				conn.Open();
				using (MySqlCommand cmd = new MySqlCommand("sp_registrar_prestamo", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@p_matricula", matricula.Trim());
					cmd.Parameters.AddWithValue("@p_codigo_barras", codigoBarras.Trim());
					cmd.Parameters.AddWithValue("@p_id_usuario", SesionActual.UsuarioLogueado.IdUsuario);
					cmd.Parameters.AddWithValue("@p_dias_prestamo", diasPrestamo);

					MySqlParameter outMensaje = new MySqlParameter("@p_mensaje", MySqlDbType.VarChar, 150);
					outMensaje.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(outMensaje);

					cmd.ExecuteNonQuery();

					string mensaje = outMensaje.Value != null ? outMensaje.Value.ToString() : "Sin respuesta del servidor.";
					if (mensaje.StartsWith("Error"))
					{
						throw new Exception(mensaje);
					}

					return mensaje;
				}
			}
		}

		public string RegistrarDevolucion(int idPrestamo, out int diasRetraso)
		{
			diasRetraso = 0;
			if (idPrestamo <= 0)
			{
				throw new ArgumentException("Selecciona un préstamo activo de la tabla para devolver.");
			}

			using (MySqlConnection conn = ConexionBD.ObtenerConexion())
			{
				conn.Open();
				using (MySqlCommand cmd = new MySqlCommand("sp_registrar_devolucion", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@p_id_prestamo", idPrestamo);

					MySqlParameter outDias = new MySqlParameter("@p_dias_retraso", MySqlDbType.Int32);
					outDias.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(outDias);

					MySqlParameter outMensaje = new MySqlParameter("@p_mensaje", MySqlDbType.VarChar, 150);
					outMensaje.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(outMensaje);

					cmd.ExecuteNonQuery();

					if (outDias.Value != null && outDias.Value != DBNull.Value)
					{
						diasRetraso = Convert.ToInt32(outDias.Value);
					}

					string mensaje = outMensaje.Value != null ? outMensaje.Value.ToString() : "Sin respuesta del servidor.";
					if (mensaje.StartsWith("Error"))
					{
						throw new Exception(mensaje);
					}

					return mensaje;
				}
			}
		}
	}
}
