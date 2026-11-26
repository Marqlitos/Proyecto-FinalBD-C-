/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 06:54 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using ProyectoFBD.Backend;
using ProyectoFBD.Models;

namespace ProyectoFBD.FrontEnd
{
	/// <summary>
	/// Description of FormPrestamos.
	/// </summary>
	public partial class FormPrestamos : Form
	{
		private PrestamosDAO prestamosDao = new PrestamosDAO();
		private LibrosDAO librosDao = new LibrosDAO();
		private int idPrestamoSeleccionado = 0;
		
		public FormPrestamos()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			this.txtCodigoBarras.KeyDown += TxtCodigoBarrasKeyDown;
			this.dgvPrestamos.CellClick += DgvPrestamosCellClick;

			CargarPrestamosActivos();
			txtMatricula.Focus();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		private void CargarPrestamosActivos()
		{
			try
			{
				dgvPrestamos.DataSource = prestamosDao.ListarPrestamosActivos();
				idPrestamoSeleccionado = 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar préstamos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		private void VerificarLibroEscaneado()
		{
			try
			{
				Libro libro = librosDao.BuscarPorCodigoBarras(txtCodigoBarras.Text);
				if (libro != null)
				{
					lblInfoLibro.Text = string.Format("Libro: {0} (Disponibles: {1})", libro.Titulo, libro.CantidadDisponible);
				}
				else
				{
					lblInfoLibro.Text = "Libro: Código no encontrado";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		
		void BtnBuscarAlumnoClick(object sender, EventArgs e)
		{
			try
			{
				string info = prestamosDao.ConsultarDatosAlumno(txtMatricula.Text);
				if (info != null)
				{
					lblInfoAlumno.Text = "Alumno: " + info;
					txtCodigoBarras.Focus();
				}
				else
				{
					lblInfoAlumno.Text = "Alumno: No encontrado";
					MessageBox.Show("No existe ningún alumno con esa matrícula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		void TxtCodigoBarrasKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				VerificarLibroEscaneado();
			}
		}
		void BtnPrestarClick(object sender, EventArgs e)
		{
			try
			{
				string mensaje = prestamosDao.RegistrarPrestamo(
					txtMatricula.Text,
					txtCodigoBarras.Text,
					(int)numDias.Value
				);

				MessageBox.Show(mensaje, "Préstamo Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LimpiarFormulario();
				CargarPrestamosActivos();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Transacción Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		void DgvPrestamosCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow fila = dgvPrestamos.Rows[e.RowIndex];
				idPrestamoSeleccionado = Convert.ToInt32(fila.Cells["ID Préstamo"].Value);
			}
		}
		void BtnDevolverClick(object sender, EventArgs e)
		{
			try
			{
				int diasRetraso;
				string mensaje = prestamosDao.RegistrarDevolucion(idPrestamoSeleccionado, out diasRetraso);

				string detalle = diasRetraso > 0
					? string.Format("{0}\nDías de retraso calculados: {1} día(s).", mensaje, diasRetraso)
					: string.Format("{0}\nEntregado a tiempo (0 días de retraso).", mensaje);

				MessageBox.Show(detalle, "Devolución Procesada", MessageBoxButtons.OK, MessageBoxIcon.Information);
				CargarPrestamosActivos();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error en Devolución", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		void BtnLimpiarClick(object sender, EventArgs e)
		{
			LimpiarFormulario();
		}
		
		private void LimpiarFormulario()
		{
			txtMatricula.Clear();
			txtCodigoBarras.Clear();
			lblInfoAlumno.Text = "Alumno: ---";
			lblInfoLibro.Text = "Libro: ---";
			numDias.Value = 5;
			idPrestamoSeleccionado = 0;
			txtMatricula.Focus();
		}

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Estás seguro de que deseas Salir?",
                                                     "Confirmación", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                MessageBox.Show("Ventana Cerrada, ¡Hasta luego!.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
