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
    public partial class FormAlumnos : Form
    {

        private AlumnosDAO alumnosDao = new AlumnosDAO();

        public FormAlumnos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.dgvAlumnos.CellClick += DgvAlumnosCellClick;

            InicializarComboEstado();
            AplicarPermisosPorRol();
            CargarTablaAlumnos();
            txtMatricula.Focus();
        }

        private void InicializarComboEstado()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("activo");
            cmbEstado.Items.Add("suspendido");
            cmbEstado.SelectedIndex = 0;
        }

        private void DgvAlumnosCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAlumnos.Rows[e.RowIndex];
                txtMatricula.Text = fila.Cells["Matrícula"].Value.ToString();
                txtMatricula.ReadOnly = true;
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellidos.Text = fila.Cells["Apellidos"].Value.ToString();
                txtCarrera.Text = fila.Cells["Carrera"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value != null ? fila.Cells["Correo"].Value.ToString() : "";
                cmbEstado.SelectedItem = fila.Cells["Estado"].Value.ToString();
            }
        }

        private void CargarTablaAlumnos()
        {
            try
            {
                dgvAlumnos.DataSource = alumnosDao.ListarAlumnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar alumnos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarPermisosPorRol()
        {
            // En BiblioTECNM.sql, solo el administrador tiene INSERT/UPDATE sobre alumnos
            bool puedeEditar = SesionActual.EsAdministrador();
            btnGuardar.Enabled = puedeEditar;
            btnActualizar.Enabled = puedeEditar;
            txtNombre.ReadOnly = !puedeEditar;
            txtApellidos.ReadOnly = !puedeEditar;
            txtCarrera.ReadOnly = !puedeEditar;
            txtCorreo.ReadOnly = !puedeEditar;
            cmbEstado.Enabled = puedeEditar;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno nuevo = new Alumno
                {
                    Matricula = txtMatricula.Text,
                    Nombre = txtNombre.Text,
                    Apellidos = txtApellidos.Text,
                    Carrera = txtCarrera.Text,
                    Correo = txtCorreo.Text,
                    Estado = cmbEstado.SelectedItem.ToString()
                };

                alumnosDao.RegistrarAlumno(nuevo);
                MessageBox.Show("Alumno registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarTablaAlumnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno encontrado = alumnosDao.BuscarPorMatricula(txtMatricula.Text);
                if (encontrado != null)
                {
                    txtMatricula.Text = encontrado.Matricula;
                    txtMatricula.ReadOnly = true;
                    txtNombre.Text = encontrado.Nombre;
                    txtApellidos.Text = encontrado.Apellidos;
                    txtCarrera.Text = encontrado.Carrera;
                    txtCorreo.Text = encontrado.Correo;
                    cmbEstado.SelectedItem = encontrado.Estado;
                }
                else
                {
                    MessageBox.Show("No se encontró ningún alumno con esa matrícula.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno editado = new Alumno
                {
                    Matricula = txtMatricula.Text,
                    Nombre = txtNombre.Text,
                    Apellidos = txtApellidos.Text,
                    Carrera = txtCarrera.Text,
                    Correo = txtCorreo.Text,
                    Estado = cmbEstado.SelectedItem.ToString()
                };

                alumnosDao.ActualizarAlumno(editado);
                MessageBox.Show("Datos del alumno actualizados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarTablaAlumnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAlumnos.Rows[e.RowIndex];
                txtMatricula.Text = fila.Cells["Matrícula"].Value.ToString();
                txtMatricula.ReadOnly = true;
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellidos.Text = fila.Cells["Apellidos"].Value.ToString();
                txtCarrera.Text = fila.Cells["Carrera"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value != null ? fila.Cells["Correo"].Value.ToString() : "";
                cmbEstado.SelectedItem = fila.Cells["Estado"].Value.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtMatricula.ReadOnly = false;
            txtMatricula.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtCarrera.Clear();
            txtCorreo.Clear();
            cmbEstado.SelectedIndex = 0;
            txtMatricula.Focus();
        }

    }
}
