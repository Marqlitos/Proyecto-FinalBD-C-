/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 03:50 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ProyectoFBD
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button btnLibros;
		private System.Windows.Forms.Button btnPrestamos;
		private System.Windows.Forms.Button btnAlumnos;
		private System.Windows.Forms.Button btnReportes;
		private System.Windows.Forms.Button btnAdmin;
		private System.Windows.Forms.Button btnCerrarSesion;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblBienvenida;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.btnLibros = new System.Windows.Forms.Button();
			this.btnPrestamos = new System.Windows.Forms.Button();
			this.btnAlumnos = new System.Windows.Forms.Button();
			this.btnReportes = new System.Windows.Forms.Button();
			this.btnAdmin = new System.Windows.Forms.Button();
			this.btnCerrarSesion = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.lblBienvenida = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label1.Location = new System.Drawing.Point(644, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(331, 56);
			this.label1.TabIndex = 23;
			this.label1.Text = "BiblioTecnm";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(272, 22);
			this.dateTimePicker1.TabIndex = 24;
			// 
			// btnLibros
			// 
			this.btnLibros.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.btnLibros.Image = ((System.Drawing.Image)(resources.GetObject("btnLibros.Image")));
			this.btnLibros.Location = new System.Drawing.Point(87, 173);
			this.btnLibros.Name = "btnLibros";
			this.btnLibros.Size = new System.Drawing.Size(75, 63);
			this.btnLibros.TabIndex = 27;
			this.toolTip1.SetToolTip(this.btnLibros, "Catálogo y Código de Barras");
			this.btnLibros.UseVisualStyleBackColor = false;
			// 
			// btnPrestamos
			// 
			this.btnPrestamos.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.btnPrestamos.Image = ((System.Drawing.Image)(resources.GetObject("btnPrestamos.Image")));
			this.btnPrestamos.Location = new System.Drawing.Point(185, 173);
			this.btnPrestamos.Name = "btnPrestamos";
			this.btnPrestamos.Size = new System.Drawing.Size(75, 63);
			this.btnPrestamos.TabIndex = 28;
			this.toolTip1.SetToolTip(this.btnPrestamos, "Préstamos y Devoluciones");
			this.btnPrestamos.UseVisualStyleBackColor = false;
			// 
			// btnAlumnos
			// 
			this.btnAlumnos.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.btnAlumnos.Image = ((System.Drawing.Image)(resources.GetObject("btnAlumnos.Image")));
			this.btnAlumnos.Location = new System.Drawing.Point(277, 173);
			this.btnAlumnos.Name = "btnAlumnos";
			this.btnAlumnos.Size = new System.Drawing.Size(75, 63);
			this.btnAlumnos.TabIndex = 29;
			this.btnAlumnos.UseVisualStyleBackColor = false;
			// 
			// btnReportes
			// 
			this.btnReportes.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.btnReportes.Image = ((System.Drawing.Image)(resources.GetObject("btnReportes.Image")));
			this.btnReportes.Location = new System.Drawing.Point(369, 173);
			this.btnReportes.Name = "btnReportes";
			this.btnReportes.Size = new System.Drawing.Size(75, 63);
			this.btnReportes.TabIndex = 30;
			this.btnReportes.UseVisualStyleBackColor = false;
			// 
			// btnAdmin
			// 
			this.btnAdmin.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.btnAdmin.Image = ((System.Drawing.Image)(resources.GetObject("btnAdmin.Image")));
			this.btnAdmin.Location = new System.Drawing.Point(460, 173);
			this.btnAdmin.Name = "btnAdmin";
			this.btnAdmin.Size = new System.Drawing.Size(75, 63);
			this.btnAdmin.TabIndex = 31;
			this.btnAdmin.UseVisualStyleBackColor = false;
			// 
			// btnCerrarSesion
			// 
			this.btnCerrarSesion.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.btnCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.Image")));
			this.btnCerrarSesion.Location = new System.Drawing.Point(12, 474);
			this.btnCerrarSesion.Name = "btnCerrarSesion";
			this.btnCerrarSesion.Size = new System.Drawing.Size(75, 63);
			this.btnCerrarSesion.TabIndex = 32;
			this.btnCerrarSesion.UseVisualStyleBackColor = false;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label3.Location = new System.Drawing.Point(12, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(190, 36);
			this.label3.TabIndex = 34;
			this.label3.Text = "Bienvenido:";
			// 
			// lblBienvenida
			// 
			this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBienvenida.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblBienvenida.Location = new System.Drawing.Point(208, 46);
			this.lblBienvenida.Name = "lblBienvenida";
			this.lblBienvenida.Size = new System.Drawing.Size(190, 36);
			this.lblBienvenida.TabIndex = 35;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.ClientSize = new System.Drawing.Size(987, 549);
			this.Controls.Add(this.lblBienvenida);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnCerrarSesion);
			this.Controls.Add(this.btnAdmin);
			this.Controls.Add(this.btnReportes);
			this.Controls.Add(this.btnAlumnos);
			this.Controls.Add(this.btnPrestamos);
			this.Controls.Add(this.btnLibros);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "ProyectoFBD";
			this.ResumeLayout(false);

		}
	}
}
