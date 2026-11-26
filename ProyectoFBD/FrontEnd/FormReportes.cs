using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFBD.Backend;

namespace ProyectoFBD.FrontEnd
{
    public partial class FormReportes : Form
    {
        private ReportesDAO reportesDao = new ReportesDAO();
        public FormReportes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            CargarLibrosMasSolicitados();
        }

        private void CargarLibrosMasSolicitados()
        {
            try
            {
                lblTituloReporte.Text = "Reporte: Libros Más Solicitados";
                dgvReportes.DataSource = reportesDao.ObtenerLibrosMasSolicitados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAlumnosVencidos()
        {
            try
            {
                lblTituloReporte.Text = "Reporte: Alumnos con Préstamos Vencidos";
                dgvReportes.DataSource = reportesDao.ObtenerAlumnosConPrestamosVencidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReporteLibros_Click(object sender, EventArgs e)
        {
            CargarLibrosMasSolicitados();
        }

        private void btnReporteVencidos_Click(object sender, EventArgs e)
        {
            CargarAlumnosVencidos();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Estás seguro de que deseas Salir?",
                                         "Confirmación", MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                 this.Close();
            }
            else
            {
                // Código que se ejecuta si el usuario hace clic en "No" o cierra la ventana
                MessageBox.Show("¡Operación cancelada!.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
