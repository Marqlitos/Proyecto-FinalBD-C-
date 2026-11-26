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
using ProyectoFBD.Models;

namespace ProyectoFBD.FrontEnd
{
    public partial class FormAdmin : Form
    {
        private AdminDAO adminDao = new AdminDAO();
        private int idUsuarioSeleccionado = 0;

        public FormAdmin()
        {
            InitializeComponent();
            VerificarAccesoAdministrador();
            InicializarCombos();
            CargarUsuarios();

            this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void VerificarAccesoAdministrador()
        {
            if (!SesionActual.EsAdministrador())
            {
                MessageBox.Show("Acceso denegado: este módulo es exclusivo para administradores.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }

        private void InicializarCombos()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("administrador");
            cmbRol.Items.Add("operador");
            cmbRol.Items.Add("consulta");
            cmbRol.SelectedIndex = 1;

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("activo");
            cmbEstado.Items.Add("inactivo");
            cmbEstado.SelectedIndex = 0;
        }

        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource = adminDao.ListarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAuditoria()
        {
            try
            {
                dgvAuditoria.DataSource = adminDao.ListarAuditoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar bitácora de auditoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevo = new Usuario
                {
                    NombreCompleto = txtNombreCompleto.Text,
                    Username = txtUsername.Text,
                    Rol = cmbRol.SelectedItem.ToString(),
                    Estado = cmbEstado.SelectedItem.ToString()
                };

                adminDao.RegistrarUsuario(nuevo, txtPassword.Text);
                MessageBox.Show("Usuario creado con contraseña cifrada en SHA-256.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario editado = new Usuario
                {
                    IdUsuario = idUsuarioSeleccionado,
                    NombreCompleto = txtNombreCompleto.Text,
                    Username = txtUsername.Text,
                    Rol = cmbRol.SelectedItem.ToString(),
                    Estado = cmbEstado.SelectedItem.ToString()
                };

                adminDao.ActualizarUsuario(editado, txtPassword.Text);
                MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LimpiarCampos()
        {
            idUsuarioSeleccionado = 0;
            txtNombreCompleto.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRol.SelectedIndex = 1;
            cmbEstado.SelectedIndex = 0;
            txtNombreCompleto.Focus();
        }

    }
}
