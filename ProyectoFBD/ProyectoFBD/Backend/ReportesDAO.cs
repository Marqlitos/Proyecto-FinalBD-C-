using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFBD.Backend
{
    internal class ReportesDAO
    {
        public DataTable ObtenerLibrosMasSolicitados()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"SELECT codigo_barras AS 'Código de Barras',
                                        titulo AS 'Título',
                                        autor AS 'Autor',
                                        total_prestamos AS 'Total Préstamos',
                                        cantidad_disponible AS 'Disponibles'
                                 FROM vw_reporte_libros_mas_solicitados;";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(tabla);
                }
            }
            return tabla;
        }

        public DataTable ObtenerAlumnosConPrestamosVencidos()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"SELECT matricula AS 'Matrícula',
                                        alumno AS 'Alumno',
                                        carrera AS 'Carrera',
                                        codigo_barras AS 'Código de Barras',
                                        libro_prestado AS 'Libro Prestado',
                                        fecha_prestamo AS 'Fecha Préstamo',
                                        fecha_limite AS 'Fecha Límite',
                                        dias_de_retraso AS 'Días de Retraso'
                                 FROM vw_reporte_alumnos_vencidos;";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(tabla);
                }
            }
            return tabla;
        }
    }
}
