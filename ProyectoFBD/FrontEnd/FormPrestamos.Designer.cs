/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 06:54 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ProyectoFBD.FrontEnd
{
	partial class FormPrestamos
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtMatricula;
		private System.Windows.Forms.Button btnBuscarAlumno;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label lblInfoAlumno;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCodigoBarras;
		private System.Windows.Forms.Label lblInfoLibro;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.NumericUpDown numDias;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnPrestar;
		private System.Windows.Forms.Button btnDevolver;
		private System.Windows.Forms.Button btnCerrarSesion;
		private System.Windows.Forms.Button btnLimpiar;
		private System.Windows.Forms.DataGridView dgvPrestamos;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrestamos));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.btnBuscarAlumno = new System.Windows.Forms.Button();
            this.lblInfoAlumno = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnPrestar = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblInfoLibro = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.numDias = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hacer Préstamo de un Libro:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Matricula:";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(194, 79);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(216, 22);
            this.txtMatricula.TabIndex = 2;
            // 
            // btnBuscarAlumno
            // 
            this.btnBuscarAlumno.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnBuscarAlumno.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarAlumno.Image")));
            this.btnBuscarAlumno.Location = new System.Drawing.Point(335, 107);
            this.btnBuscarAlumno.Name = "btnBuscarAlumno";
            this.btnBuscarAlumno.Size = new System.Drawing.Size(75, 63);
            this.btnBuscarAlumno.TabIndex = 34;
            this.toolTip1.SetToolTip(this.btnBuscarAlumno, "Buscar Alumno");
            this.btnBuscarAlumno.UseVisualStyleBackColor = false;
            this.btnBuscarAlumno.Click += new System.EventHandler(this.BtnBuscarAlumnoClick);
            // 
            // lblInfoAlumno
            // 
            this.lblInfoAlumno.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblInfoAlumno.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfoAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoAlumno.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblInfoAlumno.Location = new System.Drawing.Point(16, 173);
            this.lblInfoAlumno.Name = "lblInfoAlumno";
            this.lblInfoAlumno.Size = new System.Drawing.Size(394, 23);
            this.lblInfoAlumno.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(12, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 23);
            this.label4.TabIndex = 37;
            this.label4.Text = "Codigo de Barras:";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(194, 239);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(216, 22);
            this.txtCodigoBarras.TabIndex = 38;
            this.txtCodigoBarras.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCodigoBarrasKeyDown);
            // 
            // btnPrestar
            // 
            this.btnPrestar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnPrestar.Image = ((System.Drawing.Image)(resources.GetObject("btnPrestar.Image")));
            this.btnPrestar.Location = new System.Drawing.Point(335, 360);
            this.btnPrestar.Name = "btnPrestar";
            this.btnPrestar.Size = new System.Drawing.Size(75, 63);
            this.btnPrestar.TabIndex = 44;
            this.toolTip1.SetToolTip(this.btnPrestar, "Prestar Libro");
            this.btnPrestar.UseVisualStyleBackColor = false;
            this.btnPrestar.Click += new System.EventHandler(this.BtnPrestarClick);
            // 
            // btnDevolver
            // 
            this.btnDevolver.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnDevolver.Image = ((System.Drawing.Image)(resources.GetObject("btnDevolver.Image")));
            this.btnDevolver.Location = new System.Drawing.Point(254, 360);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(75, 63);
            this.btnDevolver.TabIndex = 45;
            this.toolTip1.SetToolTip(this.btnDevolver, "Devolver Libro");
            this.btnDevolver.UseVisualStyleBackColor = false;
            this.btnDevolver.Click += new System.EventHandler(this.BtnDevolverClick);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.Image")));
            this.btnCerrarSesion.Location = new System.Drawing.Point(12, 360);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(75, 63);
            this.btnCerrarSesion.TabIndex = 50;
            this.toolTip1.SetToolTip(this.btnCerrarSesion, "Cerrar Ventana");
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(173, 360);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 63);
            this.btnLimpiar.TabIndex = 51;
            this.toolTip1.SetToolTip(this.btnLimpiar, "Limpiar");
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiarClick);
            // 
            // lblInfoLibro
            // 
            this.lblInfoLibro.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblInfoLibro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfoLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoLibro.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblInfoLibro.Location = new System.Drawing.Point(16, 206);
            this.lblInfoLibro.Name = "lblInfoLibro";
            this.lblInfoLibro.Size = new System.Drawing.Size(394, 23);
            this.lblInfoLibro.TabIndex = 40;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(498, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(343, 22);
            this.dateTimePicker1.TabIndex = 41;
            // 
            // numDias
            // 
            this.numDias.Location = new System.Drawing.Point(194, 268);
            this.numDias.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numDias.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDias.Name = "numDias";
            this.numDias.Size = new System.Drawing.Size(216, 22);
            this.numDias.TabIndex = 42;
            this.numDias.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(12, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 23);
            this.label6.TabIndex = 43;
            this.label6.Text = "Cantidad a prestar:";
            // 
            // dgvPrestamos
            // 
            this.dgvPrestamos.AllowUserToAddRows = false;
            this.dgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamos.Location = new System.Drawing.Point(417, 59);
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.ReadOnly = true;
            this.dgvPrestamos.RowHeadersWidth = 51;
            this.dgvPrestamos.RowTemplate.Height = 24;
            this.dgvPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrestamos.Size = new System.Drawing.Size(424, 364);
            this.dgvPrestamos.TabIndex = 52;
            this.dgvPrestamos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPrestamosCellClick);
            // 
            // FormPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(853, 435);
            this.Controls.Add(this.dgvPrestamos);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.btnPrestar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numDias);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblInfoLibro);
            this.Controls.Add(this.txtCodigoBarras);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblInfoAlumno);
            this.Controls.Add(this.btnBuscarAlumno);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormPrestamos";
            this.Text = "FormPrestamos";
            ((System.ComponentModel.ISupportInitialize)(this.numDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
