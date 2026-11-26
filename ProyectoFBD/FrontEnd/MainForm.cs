using System;
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
                label1.Text = string.Format(
                    "Usuario: {0}  |  Rol: {1}",
                    SesionActual.UsuarioLogueado.NombreCompleto,
                    SesionActual.UsuarioLogueado.Rol.ToUpper()
                );
            }
        }

        private void AplicarPermisosPorRol()
        {
            btnLibros.Enabled = true;
            btnReportes.Enabled = true;
            btnPrestamos.Enabled = SesionActual.PuedeOperar();
            btnAlumnos.Enabled = SesionActual.PuedeOperar();
            btnAdmin.Enabled = SesionActual.EsAdministrador();
        }

        void BtnLibrosClick(object sender, EventArgs e)
        {
            ProyectoFBD.FrontEnd.FormLibros frm = new ProyectoFBD.FrontEnd.FormLibros();
            frm.ShowDialog();
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
		void BtnPrestamosClick(object sender, EventArgs e)
		{
			ProyectoFBD.FrontEnd.FormPrestamos frm = new ProyectoFBD.FrontEnd.FormPrestamos();
    		frm.ShowDialog();
		}
		void Label1Click(object sender, EventArgs e)
		{
	
		}

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            ProyectoFBD.FrontEnd.FormAlumnos frm = new ProyectoFBD.FrontEnd.FormAlumnos();
            frm.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            new ProyectoFBD.FrontEnd.FormReportes().ShowDialog();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            new ProyectoFBD.FrontEnd.FormAdmin().ShowDialog();
        }
    }
}