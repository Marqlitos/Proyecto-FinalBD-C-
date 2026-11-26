using MySql.Data.MySqlClient;
using ProyectoFBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFBD.Backend
{
    public class AlumnosDAO
    {
        public DataTable ListarAlumnos()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"SELECT matricula AS 'Matrícula',
                                        nombre AS 'Nombre',
                                        apellidos AS 'Apellidos',
                                        carrera AS 'Carrera',
                                        correo AS 'Correo',
                                        estado AS 'Estado'
                                 FROM alumnos
                                 ORDER BY apellidos ASC, nombre ASC;";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(tabla);
                }
            }
            return tabla;
        }

        public Alumno BuscarPorMatricula(string matricula)
        {
            if (string.IsNullOrWhiteSpace(matricula))
            {
                throw new ArgumentException("Ingresa una matrícula para buscar.");
            }

            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"SELECT matricula, nombre, apellidos, carrera, correo, estado
                                 FROM alumnos
                                 WHERE matricula = @mat LIMIT 1;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mat", matricula.Trim());
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Alumno
                            {
                                Matricula = reader["matricula"].ToString(),
                                Nombre = reader["nombre"].ToString(),
                                Apellidos = reader["apellidos"].ToString(),
                                Carrera = reader["carrera"].ToString(),
                                Correo = reader["correo"] != DBNull.Value ? reader["correo"].ToString() : "",
                                Estado = reader["estado"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void RegistrarAlumno(Alumno alumno)
        {
            if (string.IsNullOrWhiteSpace(alumno.Matricula) ||
                string.IsNullOrWhiteSpace(alumno.Nombre) ||
                string.IsNullOrWhiteSpace(alumno.Apellidos) ||
                string.IsNullOrWhiteSpace(alumno.Carrera))
            {
                throw new ArgumentException("Matrícula, nombre, apellidos y carrera son obligatorios.");
            }

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"INSERT INTO alumnos (matricula, nombre, apellidos, carrera, correo, estado)
                                     VALUES (@mat, @nom, @ape, @car, @cor, @est);";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@mat", alumno.Matricula.Trim().ToUpper());
                        cmd.Parameters.AddWithValue("@nom", alumno.Nombre.Trim());
                        cmd.Parameters.AddWithValue("@ape", alumno.Apellidos.Trim());
                        cmd.Parameters.AddWithValue("@car", alumno.Carrera.Trim());
                        cmd.Parameters.AddWithValue("@cor", string.IsNullOrWhiteSpace(alumno.Correo) ? (object)DBNull.Value : alumno.Correo.Trim());
                        cmd.Parameters.AddWithValue("@est", alumno.Estado);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    throw new Exception("Ya existe un alumno con esa matrícula o correo electrónico.");
                }
                throw new Exception("Error de base de datos: " + ex.Message);
            }
        }

        public void ActualizarAlumno(Alumno alumno)
        {
            if (string.IsNullOrWhiteSpace(alumno.Matricula))
            {
                throw new ArgumentException("Selecciona o busca primero un alumno existente.");
            }

            if (string.IsNullOrWhiteSpace(alumno.Nombre) ||
                string.IsNullOrWhiteSpace(alumno.Apellidos) ||
                string.IsNullOrWhiteSpace(alumno.Carrera))
            {
                throw new ArgumentException("Nombre, apellidos y carrera son obligatorios.");
            }

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"UPDATE alumnos
                                     SET nombre = @nom,
                                         apellidos = @ape,
                                         carrera = @car,
                                         correo = @cor,
                                         estado = @est
                                     WHERE matricula = @mat;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nom", alumno.Nombre.Trim());
                        cmd.Parameters.AddWithValue("@ape", alumno.Apellidos.Trim());
                        cmd.Parameters.AddWithValue("@car", alumno.Carrera.Trim());
                        cmd.Parameters.AddWithValue("@cor", string.IsNullOrWhiteSpace(alumno.Correo) ? (object)DBNull.Value : alumno.Correo.Trim());
                        cmd.Parameters.AddWithValue("@est", alumno.Estado);
                        cmd.Parameters.AddWithValue("@mat", alumno.Matricula.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    throw new Exception("Ese correo electrónico ya pertenece a otro alumno.");
                }
                throw new Exception("Error al actualizar el alumno: " + ex.Message);
            }
        }
    }
}