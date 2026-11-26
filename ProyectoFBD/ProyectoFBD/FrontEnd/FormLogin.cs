/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 04:07 p. m.
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
	/// Description of FormLogin.
	/// </summary>
	public partial class FormLogin : Form
	{
		private AuthDAO authDao = new AuthDAO();
		public FormLogin()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			this.StartPosition = FormStartPosition.CenterScreen;
			this.AcceptButton = btnIngresar;
		}
		
		void BtnIngresarClick(object sender, EventArgs e)
		{
			try
			{
				Usuario usuario = authDao.IniciarSesion(txtUsuario.Text, txtPassword.Text);

				if (usuario != null)
				{
					MainForm menu = new MainForm();
					menu.Show();
					this.Hide();
				}
				else
				{
					MessageBox.Show("Usuario o contraseña incorrectos.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtPassword.Clear();
					txtPassword.Focus();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		void BtnSalirClick(object sender, EventArgs e)
		{
			DialogResult respuesta = MessageBox.Show("¿Estás seguro de que deseas Salir?",
			                                         "Confirmación", MessageBoxButtons.YesNo,
			                                         MessageBoxIcon.Question);
			if (respuesta == DialogResult.Yes)
			{
				MessageBox.Show("Sesion Cerrada, ¡Hasta luego!.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
