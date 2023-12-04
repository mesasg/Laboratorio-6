namespace Laboratorio_6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnInciarJuego = new System.Windows.Forms.Button();
            this.txtBlancas = new System.Windows.Forms.TextBox();
            this.txtNegras = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.puntosNegras = new System.Windows.Forms.Label();
            this.puntosBlanca = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelPuntos = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelPuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInciarJuego
            // 
            this.btnInciarJuego.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInciarJuego.Location = new System.Drawing.Point(936, 355);
            this.btnInciarJuego.Name = "btnInciarJuego";
            this.btnInciarJuego.Size = new System.Drawing.Size(156, 72);
            this.btnInciarJuego.TabIndex = 1;
            this.btnInciarJuego.Text = "Nueva Partida";
            this.btnInciarJuego.UseVisualStyleBackColor = true;
            this.btnInciarJuego.Click += new System.EventHandler(this.btnIniciarJuego_Click);
            // 
            // txtBlancas
            // 
            this.txtBlancas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlancas.Location = new System.Drawing.Point(805, 123);
            this.txtBlancas.Name = "txtBlancas";
            this.txtBlancas.Size = new System.Drawing.Size(192, 34);
            this.txtBlancas.TabIndex = 2;
            // 
            // txtNegras
            // 
            this.txtNegras.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNegras.Location = new System.Drawing.Point(1049, 123);
            this.txtNegras.Name = "txtNegras";
            this.txtNegras.Size = new System.Drawing.Size(194, 34);
            this.txtNegras.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(803, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Jugador Blancas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1055, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Jugador Negras";
            // 
            // puntosNegras
            // 
            this.puntosNegras.AutoSize = true;
            this.puntosNegras.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puntosNegras.Location = new System.Drawing.Point(291, 103);
            this.puntosNegras.Name = "puntosNegras";
            this.puntosNegras.Size = new System.Drawing.Size(0, 25);
            this.puntosNegras.TabIndex = 6;
            // 
            // puntosBlanca
            // 
            this.puntosBlanca.AutoSize = true;
            this.puntosBlanca.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puntosBlanca.Location = new System.Drawing.Point(43, 103);
            this.puntosBlanca.Name = "puntosBlanca";
            this.puntosBlanca.Size = new System.Drawing.Size(0, 25);
            this.puntosBlanca.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(145, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "Puntos";
            // 
            // panelPuntos
            // 
            this.panelPuntos.Controls.Add(this.pictureBox2);
            this.panelPuntos.Controls.Add(this.label5);
            this.panelPuntos.Controls.Add(this.pictureBox1);
            this.panelPuntos.Controls.Add(this.puntosBlanca);
            this.panelPuntos.Controls.Add(this.puntosNegras);
            this.panelPuntos.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelPuntos.Location = new System.Drawing.Point(835, 202);
            this.panelPuntos.Name = "panelPuntos";
            this.panelPuntos.Size = new System.Drawing.Size(372, 147);
            this.panelPuntos.TabIndex = 11;
            this.panelPuntos.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Laboratorio_6.Properties.Resources.nQ;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(281, 45);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 46);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Laboratorio_6.Properties.Resources.bQ;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(33, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 46);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(936, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 73);
            this.button1.TabIndex = 12;
            this.button1.Text = "Terminar partida";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1087, 637);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 75);
            this.button2.TabIndex = 13;
            this.button2.Text = "Mejores Puntajes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(39, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 654);
            this.panel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1268, 736);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panelPuntos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNegras);
            this.Controls.Add(this.txtBlancas);
            this.Controls.Add(this.btnInciarJuego);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Ajedrez";
            this.panelPuntos.ResumeLayout(false);
            this.panelPuntos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnInciarJuego;
        private System.Windows.Forms.TextBox txtBlancas;
        private System.Windows.Forms.TextBox txtNegras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label puntosNegras;
        private System.Windows.Forms.Label puntosBlanca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelPuntos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

