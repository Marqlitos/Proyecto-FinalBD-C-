/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 05:23 p. m.
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
	/// Description of FormLibros.
	/// </summary>
	public partial class FormLibros : Form
	{
		private LibrosDAO librosDao = new LibrosDAO();
		private int idLibroSeleccionado = 0;
		
		public FormLibros()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			this.txtCodigoBarras.KeyDown += TxtCodigoBarrasKeyDown;
			this.dgvLibros.CellClick += DgvLibrosCellClick;

			AplicarPermisosPorRol();
			CargarTablaLibros();
			txtCodigoBarras.Focus();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void EjecutarBusquedaCodigo()
		{
			try
			{
				Libro encontrado = librosDao.BuscarPorCodigoBarras(txtCodigoBarras.Text);
				if (encontrado != null)
				{
					idLibroSeleccionado = encontrado.IdLibro;
					txtCodigoBarras.Text = encontrado.CodigoBarras;
					txtTitulo.Text = encontrado.Titulo;
					txtAutor.Text = encontrado.Autor;
					txtEditorial.Text = encontrado.Editorial;
					txtCategoria.Text = encontrado.Categoria;
					numTotal.Value = encontrado.CantidadTotal;
					numDisponible.Value = encontrado.CantidadDisponible;

					txtCodigoBarras.SelectAll();
				}
				else
				{
					idLibroSeleccionado = 0;
					if (SesionActual.PuedeOperar())
					{
						MessageBox.Show("Código no registrado. Puedes llenar los datos y dar clic en 'Registrar Nuevo'.", "Libro nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtTitulo.Focus();
					}
					else
					{
						MessageBox.Show("No se encontró ningún libro con ese código de barras.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtCodigoBarras.SelectAll();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		
		private void AplicarPermisosPorRol()
		{
			bool puedeEditar = SesionActual.PuedeOperar();
			btnGuardar.Enabled = puedeEditar;
			btnActualizar.Enabled = puedeEditar;
			txtTitulo.ReadOnly = !puedeEditar;
			txtAutor.ReadOnly = !puedeEditar;
			txtEditorial.ReadOnly = !puedeEditar;
			txtCategoria.ReadOnly = !puedeEditar;
			numTotal.Enabled = puedeEditar;
			numDisponible.Enabled = puedeEditar;
		}

		private void CargarTablaLibros()
		{
			try
			{
				dgvLibros.DataSource = librosDao.ListarLibros();
			}
			catch (Exception ex)
			{
				MessageBox.Show("No se pudo cargar el catálogo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void BtnCerrarSesionClick(object sender, EventArgs e)
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
		
		void BtnGuardarClick(object sender, EventArgs e)
		{
			try
			{
				Libro nuevo = new Libro
				{
					CodigoBarras = txtCodigoBarras.Text,
					Titulo = txtTitulo.Text,
					Autor = txtAutor.Text,
					Editorial = txtEditorial.Text,
					Categoria = txtCategoria.Text,
					CantidadTotal = (int)numTotal.Value,
					CantidadDisponible = (int)numDisponible.Value
				};

				librosDao.RegistrarLibro(nuevo);
				MessageBox.Show("Libro registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LimpiarCampos();
				CargarTablaLibros();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void BtnActualizarClick(object sender, EventArgs e)
		{try
			{
				Libro editado = new Libro
				{
					IdLibro = idLibroSeleccionado,
					CodigoBarras = txtCodigoBarras.Text,
					Titulo = txtTitulo.Text,
					Autor = txtAutor.Text,
					Editorial = txtEditorial.Text,
					Categoria = txtCategoria.Text,
					CantidadTotal = (int)numTotal.Value,
					CantidadDisponible = (int)numDisponible.Value
				};

				librosDao.ActualizarLibro(editado);
				MessageBox.Show("Datos del libro actualizados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LimpiarCampos();
				CargarTablaLibros();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void BtnLimpiarClick(object sender, EventArgs e)
		{
			LimpiarCampos();
		}
		
		void TxtCodigoBarrasKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true; // Evita el sonido de alerta de Windows
				EjecutarBusquedaCodigo();
			}
		}
		
		void BtnBuscarClick(object sender, EventArgs e)
		{
			EjecutarBusquedaCodigo();
		}
		
		void DgvLibrosCellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow fila = dgvLibros.Rows[e.RowIndex];
				idLibroSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
				txtCodigoBarras.Text = fila.Cells["Código de Barras"].Value.ToString();
				txtTitulo.Text = fila.Cells["Título"].Value.ToString();
				txtAutor.Text = fila.Cells["Autor"].Value.ToString();
				txtEditorial.Text = fila.Cells["Editorial"].Value.ToString();
				txtCategoria.Text = fila.Cells["Categoría"].Value.ToString();
				numTotal.Value = Convert.ToDecimal(fila.Cells["Total"].Value);
				numDisponible.Value = Convert.ToDecimal(fila.Cells["Disponibles"].Value);
			}
		}
		
		private void DgvLibrosCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow fila = dgvLibros.Rows[e.RowIndex];
				idLibroSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
				txtCodigoBarras.Text = fila.Cells["Código de Barras"].Value.ToString();
				txtTitulo.Text = fila.Cells["Título"].Value.ToString();
				txtAutor.Text = fila.Cells["Autor"].Value.ToString();
				txtEditorial.Text = fila.Cells["Editorial"].Value.ToString();
				txtCategoria.Text = fila.Cells["Categoría"].Value.ToString();
				numTotal.Value = Convert.ToDecimal(fila.Cells["Total"].Value);
				numDisponible.Value = Convert.ToDecimal(fila.Cells["Disponibles"].Value);
			}
		}

		private void LimpiarCampos()
		{
			idLibroSeleccionado = 0;
			txtCodigoBarras.Clear();
			txtTitulo.Clear();
			txtAutor.Clear();
			txtEditorial.Clear();
			txtCategoria.Clear();
			numTotal.Value = 1;
			numDisponible.Value = 1;
			txtCodigoBarras.Focus();
		}
			
	}
}
