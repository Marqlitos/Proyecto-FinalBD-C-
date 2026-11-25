/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 05:23 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ProyectoFBD.FrontEnd
{
	partial class FormLibros
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox txtCodigoBarras;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtTitulo;
		private System.Windows.Forms.TextBox txtAutor;
		private System.Windows.Forms.TextBox txtEditorial;
		private System.Windows.Forms.TextBox txtCategoria;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Button btnGuardar;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLibros));
			this.txtCodigoBarras = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtTitulo = new System.Windows.Forms.TextBox();
			this.txtAutor = new System.Windows.Forms.TextBox();
			this.txtEditorial = new System.Windows.Forms.TextBox();
			this.txtCategoria = new System.Windows.Forms.TextBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.btnGuardar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			this.SuspendLayout();
			// 
			// txtCodigoBarras
			// 
			this.txtCodigoBarras.Location = new System.Drawing.Point(295, 32);
			this.txtCodigoBarras.MaxLength = 13;
			this.txtCodigoBarras.Name = "txtCodigoBarras";
			this.txtCodigoBarras.Size = new System.Drawing.Size(193, 22);
			this.txtCodigoBarras.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Window;
			this.label1.Location = new System.Drawing.Point(12, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Buscar por Codigo de Barras:";
			// 
			// btnBuscar
			// 
			this.btnBuscar.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.Location = new System.Drawing.Point(494, 12);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(75, 63);
			this.btnBuscar.TabIndex = 33;
			this.btnBuscar.UseVisualStyleBackColor = false;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.Window;
			this.label2.Location = new System.Drawing.Point(12, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 23);
			this.label2.TabIndex = 34;
			this.label2.Text = "Titulo:";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.Window;
			this.label3.Location = new System.Drawing.Point(12, 110);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 23);
			this.label3.TabIndex = 35;
			this.label3.Text = "Autor:";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.Window;
			this.label4.Location = new System.Drawing.Point(12, 138);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 23);
			this.label4.TabIndex = 36;
			this.label4.Text = "Editorial:";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.Window;
			this.label5.Location = new System.Drawing.Point(12, 168);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(102, 23);
			this.label5.TabIndex = 37;
			this.label5.Text = "Categoria:";
			// 
			// txtTitulo
			// 
			this.txtTitulo.Location = new System.Drawing.Point(120, 82);
			this.txtTitulo.Name = "txtTitulo";
			this.txtTitulo.Size = new System.Drawing.Size(184, 22);
			this.txtTitulo.TabIndex = 38;
			// 
			// txtAutor
			// 
			this.txtAutor.Location = new System.Drawing.Point(120, 111);
			this.txtAutor.Name = "txtAutor";
			this.txtAutor.Size = new System.Drawing.Size(184, 22);
			this.txtAutor.TabIndex = 39;
			// 
			// txtEditorial
			// 
			this.txtEditorial.Location = new System.Drawing.Point(120, 139);
			this.txtEditorial.Name = "txtEditorial";
			this.txtEditorial.Size = new System.Drawing.Size(184, 22);
			this.txtEditorial.TabIndex = 40;
			// 
			// txtCategoria
			// 
			this.txtCategoria.Location = new System.Drawing.Point(120, 167);
			this.txtCategoria.Name = "txtCategoria";
			this.txtCategoria.Size = new System.Drawing.Size(184, 22);
			this.txtCategoria.TabIndex = 41;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(513, 83);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(184, 22);
			this.numericUpDown1.TabIndex = 42;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.SystemColors.Window;
			this.label6.Location = new System.Drawing.Point(321, 82);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(134, 23);
			this.label6.TabIndex = 43;
			this.label6.Text = "Numero Total:";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.Window;
			this.label7.Location = new System.Drawing.Point(321, 111);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(186, 23);
			this.label7.TabIndex = 45;
			this.label7.Text = "Numero Disponible:";
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(513, 112);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(184, 22);
			this.numericUpDown2.TabIndex = 44;
			// 
			// btnGuardar
			// 
			this.btnGuardar.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
			this.btnGuardar.Location = new System.Drawing.Point(751, 12);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(75, 63);
			this.btnGuardar.TabIndex = 46;
			this.btnGuardar.UseVisualStyleBackColor = false;
			// 
			// FormLibros
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GrayText;
			this.ClientSize = new System.Drawing.Size(838, 357);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.numericUpDown2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.txtCategoria);
			this.Controls.Add(this.txtEditorial);
			this.Controls.Add(this.txtAutor);
			this.Controls.Add(this.txtTitulo);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnBuscar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtCodigoBarras);
			this.Name = "FormLibros";
			this.Text = "FormLibros";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
