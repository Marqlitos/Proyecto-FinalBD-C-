/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 03:50 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProyectoFBD.Backend;
using ProyectoFBD.Models;
namespace ProyectoFBD
{
	public partial class MainForm : Form
	{
		private bool cerrandoSesion = false;

		public MainForm()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			this.FormClosing += MainFormFormClosing;
			CargarDatosSesion();
			AplicarPermisosPorRol();
		}

		private void CargarDatosSesion()
		{
			if (SesionActual.UsuarioLogueado != null)
			{
				lblBienvenida.Text = string.Format(
					"Usuario: {0}  |  Rol: {1}",
					SesionActual.UsuarioLogueado.NombreCompleto,
					SesionActual.UsuarioLogueado.Rol.ToUpper()
				);
			}
		}

		private void AplicarPermisosPorRol()
		{
			// Todos los roles pueden consultar libros y ver reportes
			btnLibros.Enabled = true;
			btnReportes.Enabled = true;

			// Operador y Administrador pueden gestionar préstamos y alumnos
			btnPrestamos.Enabled = SesionActual.PuedeOperar();
			btnAlumnos.Enabled = SesionActual.PuedeOperar();

			// Solo el Administrador accede a usuarios del sistema y auditoría
			btnAdmin.Enabled = SesionActual.EsAdministrador();
		}

		void BtnCerrarSesionClick(object sender, EventArgs e)
		{
			cerrandoSesion = true;
			SesionActual.CerrarSesion();
			ConexionBD.RestablecerConexionBase();

			ProyectoFBD.FrontEnd.FormLogin login = new ProyectoFBD.FrontEnd.FormLogin();
			login.Show();
			this.Close();
		}

		private void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (!cerrandoSesion)
			{
				Application.Exit();
			}
		}
	}
}
