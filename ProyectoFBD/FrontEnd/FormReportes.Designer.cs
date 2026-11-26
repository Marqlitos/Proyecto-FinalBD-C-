namespace ProyectoFBD.FrontEnd
{
    partial class FormReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportes));
            this.label1 = new System.Windows.Forms.Label();
            this.lblTituloReporte = new System.Windows.Forms.Label();
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.btnReporteLibros = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnReporteVencidos = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reporte de Libros:";
            // 
            // lblTituloReporte
            // 
            this.lblTituloReporte.AutoSize = true;
            this.lblTituloReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloReporte.ForeColor = System.Drawing.SystemColors.Info;
            this.lblTituloReporte.Location = new System.Drawing.Point(12, 51);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new System.Drawing.Size(280, 20);
            this.lblTituloReporte.TabIndex = 1;
            this.lblTituloReporte.Text = "Reporte: Libros Más Solicitados";
            // 
            // dgvReportes
            // 
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new System.Drawing.Point(16, 74);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.RowHeadersWidth = 51;
            this.dgvReportes.RowTemplate.Height = 24;
            this.dgvReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportes.Size = new System.Drawing.Size(772, 265);
            this.dgvReportes.TabIndex = 2;
            // 
            // btnReporteLibros
            // 
            this.btnReporteLibros.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnReporteLibros.Image = ((System.Drawing.Image)(resources.GetObject("btnReporteLibros.Image")));
            this.btnReporteLibros.Location = new System.Drawing.Point(632, 345);
            this.btnReporteLibros.Name = "btnReporteLibros";
            this.btnReporteLibros.Size = new System.Drawing.Size(75, 63);
            this.btnReporteLibros.TabIndex = 53;
            this.toolTip1.SetToolTip(this.btnReporteLibros, "Libros Más Solicitados");
            this.btnReporteLibros.UseVisualStyleBackColor = false;
            this.btnReporteLibros.Click += new System.EventHandler(this.btnReporteLibros_Click);
            // 
            // btnReporteVencidos
            // 
            this.btnReporteVencidos.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnReporteVencidos.Image = ((System.Drawing.Image)(resources.GetObject("btnReporteVencidos.Image")));
            this.btnReporteVencidos.Location = new System.Drawing.Point(713, 345);
            this.btnReporteVencidos.Name = "btnReporteVencidos";
            this.btnReporteVencidos.Size = new System.Drawing.Size(75, 63);
            this.btnReporteVencidos.TabIndex = 54;
            this.toolTip1.SetToolTip(this.btnReporteVencidos, "Alumnos con Préstamos Vencidos");
            this.btnReporteVencidos.UseVisualStyleBackColor = false;
            this.btnReporteVencidos.Click += new System.EventHandler(this.btnReporteVencidos_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.Image")));
            this.btnCerrarSesion.Location = new System.Drawing.Point(12, 375);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(75, 63);
            this.btnCerrarSesion.TabIndex = 58;
            this.toolTip1.SetToolTip(this.btnCerrarSesion, "Cerrar Ventana");
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnReporteVencidos);
            this.Controls.Add(this.btnReporteLibros);
            this.Controls.Add(this.dgvReportes);
            this.Controls.Add(this.lblTituloReporte);
            this.Controls.Add(this.label1);
            this.Name = "FormReportes";
            this.Text = "FormReportes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTituloReporte;
        private System.Windows.Forms.DataGridView dgvReportes;
        private System.Windows.Forms.Button btnReporteLibros;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnReporteVencidos;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}