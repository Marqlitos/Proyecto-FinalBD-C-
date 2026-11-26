using MySql.Data.MySqlClient;
using ProyectoFBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFBD.Backend
{
    internal class AdminDAO
    {
        public DataTable ListarUsuarios()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"SELECT id_usuario AS 'ID',
                                        nombre_completo AS 'Nombre Completo',
                                        username AS 'Usuario',
                                        rol AS 'Rol',
                                        estado AS 'Estado',
                                        fecha_creacion AS 'Fecha Creación'
                                 FROM usuarios_sistema
                                 ORDER BY id_usuario ASC;";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(tabla);
                }
            }
            return tabla;
        }

        public void RegistrarUsuario(Usuario usuario, string passwordPlano)
        {
            if (string.IsNullOrWhiteSpace(usuario.NombreCompleto) ||
                string.IsNullOrWhiteSpace(usuario.Username) ||
                string.IsNullOrWhiteSpace(passwordPlano))
            {
                throw new ArgumentException("Nombre completo, usuario y contraseña inicial son obligatorios.");
            }

            string hash = CalcularSha256(passwordPlano);

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"INSERT INTO usuarios_sistema (nombre_completo, username, password_hash, rol, estado)
                                     VALUES (@nom, @user, @pass, @rol, @est);";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nom", usuario.NombreCompleto.Trim());
                        cmd.Parameters.AddWithValue("@user", usuario.Username.Trim());
                        cmd.Parameters.AddWithValue("@pass", hash);
                        cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                        cmd.Parameters.AddWithValue("@est", usuario.Estado);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    throw new Exception("Ese nombre de usuario ya existe en el sistema.");
                }
                throw new Exception("Error al registrar usuario: " + ex.Message);
            }
        }

        public void ActualizarUsuario(Usuario usuario, string nuevaPasswordPlano)
        {
            if (usuario.IdUsuario <= 0)
            {
                throw new ArgumentException("Selecciona primero un usuario de la tabla.");
            }

            if (string.IsNullOrWhiteSpace(usuario.NombreCompleto) ||
                string.IsNullOrWhiteSpace(usuario.Username))
            {
                throw new ArgumentException("Nombre completo y usuario son obligatorios.");
            }

            if (SesionActual.UsuarioLogueado != null &&
                usuario.IdUsuario == SesionActual.UsuarioLogueado.IdUsuario &&
                (usuario.Estado != "activo" || usuario.Rol != "administrador"))
            {
                throw new InvalidOperationException("No puedes desactivar ni quitar el rol de administrador a tu propia sesión activa.");
            }

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    bool cambiarPassword = !string.IsNullOrWhiteSpace(nuevaPasswordPlano);

                    string query = cambiarPassword
                        ? @"UPDATE usuarios_sistema
                            SET nombre_completo = @nom,
                                username = @user,
                                password_hash = @pass,
                                rol = @rol,
                                estado = @est
                            WHERE id_usuario = @id;"
                        : @"UPDATE usuarios_sistema
                            SET nombre_completo = @nom,
                                username = @user,
                                rol = @rol,
                                estado = @est
                            WHERE id_usuario = @id;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nom", usuario.NombreCompleto.Trim());
                        cmd.Parameters.AddWithValue("@user", usuario.Username.Trim());
                        if (cambiarPassword)
                        {
                            cmd.Parameters.AddWithValue("@pass", CalcularSha256(nuevaPasswordPlano));
                        }
                        cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                        cmd.Parameters.AddWithValue("@est", usuario.Estado);
                        cmd.Parameters.AddWithValue("@id", usuario.IdUsuario);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    throw new Exception("Ese nombre de usuario ya pertenece a otra cuenta.");
                }
                throw new Exception("Error al actualizar usuario: " + ex.Message);
            }
        }

        public DataTable ListarAuditoria()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"SELECT id_auditoria AS 'ID',
                                        tabla_afectada AS 'Tabla',
                                        tipo_operacion AS 'Operación',
                                        fecha_hora AS 'Fecha y Hora',
                                        usuario_responsable AS 'Usuario BD',
                                        info_anterior AS 'Valor Anterior',
                                        info_nueva AS 'Valor Nuevo'
                                 FROM auditoria
                                 ORDER BY id_auditoria DESC;";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(tabla);
                }
            }
            return tabla;
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
