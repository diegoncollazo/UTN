namespace Events
{
    partial class Form1
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
            this.btnUnMensaje = new System.Windows.Forms.Button();
            this.btnEnFoco = new System.Windows.Forms.Button();
            this.btnDosMensajes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnUnMensaje
            // 
            this.btnUnMensaje.Location = new System.Drawing.Point(12, 12);
            this.btnUnMensaje.Name = "btnUnMensaje";
            this.btnUnMensaje.Size = new System.Drawing.Size(89, 23);
            this.btnUnMensaje.TabIndex = 0;
            this.btnUnMensaje.Text = "Un mensaje";
            this.btnUnMensaje.UseVisualStyleBackColor = true;
            this.btnUnMensaje.Click += new System.EventHandler(this.btnUnMensaje_Click);
            // 
            // btnEnFoco
            // 
            this.btnEnFoco.Location = new System.Drawing.Point(12, 67);
            this.btnEnFoco.Name = "btnEnFoco";
            this.btnEnFoco.Size = new System.Drawing.Size(89, 23);
            this.btnEnFoco.TabIndex = 1;
            this.btnEnFoco.Text = "En foco";
            this.btnEnFoco.UseVisualStyleBackColor = true;
            // 
            // btnDosMensajes
            // 
            this.btnDosMensajes.Location = new System.Drawing.Point(12, 123);
            this.btnDosMensajes.Name = "btnDosMensajes";
            this.btnDosMensajes.Size = new System.Drawing.Size(89, 23);
            this.btnDosMensajes.TabIndex = 2;
            this.btnDosMensajes.Text = "Dos mensajes";
            this.btnDosMensajes.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Un evento y un manejador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Un manejador y dos eventos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dos manejadores y un evento";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(153, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 20);
            this.textBox1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 206);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDosMensajes);
            this.Controls.Add(this.btnEnFoco);
            this.Controls.Add(this.btnUnMensaje);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUnMensaje;
        private System.Windows.Forms.Button btnEnFoco;
        private System.Windows.Forms.Button btnDosMensajes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}

