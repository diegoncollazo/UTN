namespace TestDos
{
    partial class frmTestDos
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
            this.btnBotonUno = new System.Windows.Forms.Button();
            this.btnBotonDos = new System.Windows.Forms.Button();
            this.btnBotonTres = new System.Windows.Forms.Button();
            this.brnOperar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBotonUno
            // 
            this.btnBotonUno.Location = new System.Drawing.Point(12, 31);
            this.btnBotonUno.Name = "btnBotonUno";
            this.btnBotonUno.Size = new System.Drawing.Size(75, 23);
            this.btnBotonUno.TabIndex = 0;
            this.btnBotonUno.Text = "button1";
            this.btnBotonUno.UseVisualStyleBackColor = true;
            // 
            // btnBotonDos
            // 
            this.btnBotonDos.Location = new System.Drawing.Point(93, 31);
            this.btnBotonDos.Name = "btnBotonDos";
            this.btnBotonDos.Size = new System.Drawing.Size(75, 23);
            this.btnBotonDos.TabIndex = 1;
            this.btnBotonDos.Text = "button2";
            this.btnBotonDos.UseVisualStyleBackColor = true;
            // 
            // btnBotonTres
            // 
            this.btnBotonTres.Location = new System.Drawing.Point(174, 31);
            this.btnBotonTres.Name = "btnBotonTres";
            this.btnBotonTres.Size = new System.Drawing.Size(75, 23);
            this.btnBotonTres.TabIndex = 2;
            this.btnBotonTres.Text = "button3";
            this.btnBotonTres.UseVisualStyleBackColor = true;
            // 
            // brnOperar
            // 
            this.brnOperar.Location = new System.Drawing.Point(93, 75);
            this.brnOperar.Name = "brnOperar";
            this.brnOperar.Size = new System.Drawing.Size(75, 23);
            this.brnOperar.TabIndex = 3;
            this.brnOperar.Text = "Operar";
            this.brnOperar.UseVisualStyleBackColor = true;
            this.brnOperar.Click += new System.EventHandler(this.brnOperar_Click);
            // 
            // frmTestDos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 110);
            this.Controls.Add(this.brnOperar);
            this.Controls.Add(this.btnBotonTres);
            this.Controls.Add(this.btnBotonDos);
            this.Controls.Add(this.btnBotonUno);
            this.Name = "frmTestDos";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnBotonUno;
        public System.Windows.Forms.Button btnBotonDos;
        public System.Windows.Forms.Button btnBotonTres;
        private System.Windows.Forms.Button brnOperar;
    }
}

