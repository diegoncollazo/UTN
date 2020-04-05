namespace MiComiquería
{
    partial class FrmComics
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxAcciones = new System.Windows.Forms.GroupBox();
            this.btnVender = new System.Windows.Forms.Button();
            this.richTextBoxVentas = new System.Windows.Forms.RichTextBox();
            this.listBoxProductos = new System.Windows.Forms.ListBox();
            this.lblProductos = new System.Windows.Forms.Label();
            this.lblVentas = new System.Windows.Forms.Label();
            this.richTextBoxDetalle = new System.Windows.Forms.RichTextBox();
            this.groupBoxAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAcciones
            // 
            this.groupBoxAcciones.Controls.Add(this.btnVender);
            this.groupBoxAcciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAcciones.Location = new System.Drawing.Point(565, 12);
            this.groupBoxAcciones.Name = "groupBoxAcciones";
            this.groupBoxAcciones.Size = new System.Drawing.Size(311, 97);
            this.groupBoxAcciones.TabIndex = 8;
            this.groupBoxAcciones.TabStop = false;
            this.groupBoxAcciones.Text = "Acciones";
            // 
            // btnVender
            // 
            this.btnVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVender.Location = new System.Drawing.Point(127, 38);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(75, 23);
            this.btnVender.TabIndex = 0;
            this.btnVender.Text = "Vender";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // richTextBoxVentas
            // 
            this.richTextBoxVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxVentas.Location = new System.Drawing.Point(12, 272);
            this.richTextBoxVentas.Name = "richTextBoxVentas";
            this.richTextBoxVentas.Size = new System.Drawing.Size(864, 128);
            this.richTextBoxVentas.TabIndex = 7;
            this.richTextBoxVentas.Text = "";
            // 
            // listBoxProductos
            // 
            this.listBoxProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxProductos.FormattingEnabled = true;
            this.listBoxProductos.Location = new System.Drawing.Point(12, 25);
            this.listBoxProductos.Name = "listBoxProductos";
            this.listBoxProductos.Size = new System.Drawing.Size(533, 225);
            this.listBoxProductos.TabIndex = 6;
            this.listBoxProductos.SelectedIndexChanged += new System.EventHandler(this.listBoxProductos_SelectedIndexChanged);
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.Location = new System.Drawing.Point(11, 9);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(98, 13);
            this.lblProductos.TabIndex = 11;
            this.lblProductos.Text = "Lista de Productos:";
            // 
            // lblVentas
            // 
            this.lblVentas.AutoSize = true;
            this.lblVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentas.Location = new System.Drawing.Point(11, 256);
            this.lblVentas.Name = "lblVentas";
            this.lblVentas.Size = new System.Drawing.Size(86, 13);
            this.lblVentas.TabIndex = 10;
            this.lblVentas.Text = "Lista de Ventas: ";
            // 
            // richTextBoxDetalle
            // 
            this.richTextBoxDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxDetalle.Location = new System.Drawing.Point(565, 115);
            this.richTextBoxDetalle.Name = "richTextBoxDetalle";
            this.richTextBoxDetalle.Size = new System.Drawing.Size(311, 135);
            this.richTextBoxDetalle.TabIndex = 9;
            this.richTextBoxDetalle.Text = "";
            // 
            // FrmComics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 412);
            this.Controls.Add(this.groupBoxAcciones);
            this.Controls.Add(this.richTextBoxVentas);
            this.Controls.Add(this.listBoxProductos);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.lblVentas);
            this.Controls.Add(this.richTextBoxDetalle);
            this.Name = "FrmComics";
            this.Text = "Comiquería";
            this.Load += new System.EventHandler(this.FrmComics_Load);
            this.groupBoxAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAcciones;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.RichTextBox richTextBoxVentas;
        private System.Windows.Forms.ListBox listBoxProductos;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Label lblVentas;
        private System.Windows.Forms.RichTextBox richTextBoxDetalle;
    }
}

