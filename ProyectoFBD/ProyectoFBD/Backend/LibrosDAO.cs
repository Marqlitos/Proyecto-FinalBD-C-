/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 05:21 p. m.
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
	/// Description of LibrosDAO.
	/// </summary>
	public class LibrosDAO
	{
		public DataTable ListarLibros()
		{
			DataTable tabla = new DataTable();
			using (MySqlConnection conn = ConexionBD.ObtenerConexion())
			{
				conn.Open();
				string query = @"SELECT id_libro AS 'ID',
                                        codigo_barras AS 'Código de Barras',
                                        titulo AS 'Título',
                                        autor AS 'Autor',
                                        editorial AS 'Editorial',
                                        categoria AS 'Categoría',
                                        cantidad_total AS 'Total',
                                        cantidad_disponible AS 'Disponibles'
                                 FROM libros
                                 ORDER BY id_libro DESC;";
				using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
				{
					adapter.Fill(tabla);
				}
			}
			return tabla;
		}

		public Libro BuscarPorCodigoBarras(string codigoBarras)
		{
			if (string.IsNullOrWhiteSpace(codigoBarras))
			{
				throw new ArgumentException("Escanea o escribe un código de barras válido.");
			}

			string codigoLimpio = codigoBarras.Trim();

			using (MySqlConnection conn = ConexionBD.ObtenerConexion())
			{
				conn.Open();

				// Ejecuta el procedimiento almacenado con parámetros OUT si el rol tiene permiso EXECUTE
				if (SesionActual.PuedeOperar())
				{
					using (MySqlCommand spCmd = new MySqlCommand("sp_consultar_libro_codigo", conn))
					{
						spCmd.CommandType = CommandType.StoredProcedure;
						spCmd.Parameters.AddWithValue("@p_codigo_barras", codigoLimpio);

						MySqlParameter outId = new MySqlParameter("@p_id_libro", MySqlDbType.Int32);
						outId.Direction = ParameterDirection.Output;
						spCmd.Parameters.Add(outId);

						MySqlParameter outTitulo = new MySqlParameter("@p_titulo", MySqlDbType.VarChar, 200);
						outTitulo.Direction = ParameterDirection.Output;
						spCmd.Parameters.Add(outTitulo);

						MySqlParameter outDisp = new MySqlParameter("@p_disponibles", MySqlDbType.Int32);
						outDisp.Direction = ParameterDirection.Output;
						spCmd.Parameters.Add(outDisp);

						spCmd.ExecuteNonQuery();

						if (outId.Value == DBNull.Value || outId.Value == null)
						{
							return null;
						}
					}
				}

				// Obtiene todos los campos del libro para rellenar el formulario
				string query = @"SELECT id_libro, codigo_barras, titulo, autor, editorial,
                                        categoria, cantidad_total, cantidad_disponible
                                 FROM libros
                                 WHERE codigo_barras = @codigo LIMIT 1;";

				using (MySqlCommand cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@codigo", codigoLimpio);
					using (MySqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							return new Libro
							{
								IdLibro = Convert.ToInt32(reader["id_libro"]),
								CodigoBarras = reader["codigo_barras"].ToString(),
								Titulo = reader["titulo"].ToString(),
								Autor = reader["autor"].ToString(),
								Editorial = reader["editorial"].ToString(),
								Categoria = reader["categoria"].ToString(),
								CantidadTotal = Convert.ToInt32(reader["cantidad_total"]),
								CantidadDisponible = Convert.ToInt32(reader["cantidad_disponible"])
							};
						}
					}
				}
			}

			return null;
		}

		public void RegistrarLibro(Libro libro)
		{
			if (string.IsNullOrWhiteSpace(libro.CodigoBarras) ||
			    string.IsNullOrWhiteSpace(libro.Titulo) ||
			    string.IsNullOrWhiteSpace(libro.Autor))
			{
				throw new ArgumentException("Código de barras, título y autor son obligatorios.");
			}

			try
			{
				using (MySqlConnection conn = ConexionBD.ObtenerConexion())
				{
					conn.Open();
					string query = @"INSERT INTO libros
                                     (codigo_barras, titulo, autor, editorial, categoria, cantidad_total, cantidad_disponible)
                                     VALUES (@codigo, @titulo, @autor, @editorial, @categoria, @total, @disp);";

					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@codigo", libro.CodigoBarras.Trim());
						cmd.Parameters.AddWithValue("@titulo", libro.Titulo.Trim());
						cmd.Parameters.AddWithValue("@autor", libro.Autor.Trim());
						cmd.Parameters.AddWithValue("@editorial", libro.Editorial.Trim());
						cmd.Parameters.AddWithValue("@categoria", libro.Categoria.Trim());
						cmd.Parameters.AddWithValue("@total", libro.CantidadTotal);
						cmd.Parameters.AddWithValue("@disp", libro.CantidadDisponible);
						cmd.ExecuteNonQuery();
					}
				}
			}
			catch (MySqlException ex)
			{
				if (ex.Number == 1062)
				{
					throw new Exception("Ya existe un libro registrado con ese código de barras.");
				}
				throw new Exception("Error de base de datos: " + ex.Message);
			}
		}

		public void ActualizarLibro(Libro libro)
		{
			if (libro.IdLibro <= 0)
			{
				throw new ArgumentException("Selecciona o escanea primero un libro existente.");
			}

			if (libro.CantidadDisponible > libro.CantidadTotal)
			{
				throw new ArgumentException("La cantidad disponible no puede ser mayor al total.");
			}

			try
			{
				using (MySqlConnection conn = ConexionBD.ObtenerConexion())
				{
					conn.Open();
					string query = @"UPDATE libros
                                     SET titulo = @titulo,
                                         autor = @autor,
                                         editorial = @editorial,
                                         categoria = @categoria,
                                         cantidad_total = @total,
                                         cantidad_disponible = @disp
                                     WHERE id_libro = @id;";

					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@titulo", libro.Titulo.Trim());
						cmd.Parameters.AddWithValue("@autor", libro.Autor.Trim());
						cmd.Parameters.AddWithValue("@editorial", libro.Editorial.Trim());
						cmd.Parameters.AddWithValue("@categoria", libro.Categoria.Trim());
						cmd.Parameters.AddWithValue("@total", libro.CantidadTotal);
						cmd.Parameters.AddWithValue("@disp", libro.CantidadDisponible);
						cmd.Parameters.AddWithValue("@id", libro.IdLibro);
						cmd.ExecuteNonQuery();
					}
				}
			}
			catch (MySqlException ex)
			{
				throw new Exception("Error al actualizar el libro: " + ex.Message);
			}
		}
	}
}
