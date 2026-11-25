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
			this.txtCodigoBarras = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtCodigoBarras
			// 
			this.txtCodigoBarras.Location = new System.Drawing.Point(199, 50);
			this.txtCodigoBarras.Name = "txtCodigoBarras";
			this.txtCodigoBarras.Size = new System.Drawing.Size(100, 22);
			this.txtCodigoBarras.TabIndex = 0;
			// 
			// FormLibros
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GrayText;
			this.ClientSize = new System.Drawing.Size(913, 550);
			this.Controls.Add(this.txtCodigoBarras);
			this.Name = "FormLibros";
			this.Text = "FormLibros";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
