namespace Sistema
{
    partial class ListaInformes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaInformes));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            button1 = new Button();
            label2 = new Label();
            btnSalir = new Button();
            btnIngresar = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(785, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(343, 575);
            panel1.TabIndex = 38;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 95);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(294, 301);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(64, 64, 64);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.Gray;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(244, 470);
            button2.Name = "button2";
            button2.Size = new Size(338, 54);
            button2.TabIndex = 37;
            button2.Text = "Volver al menu";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Gray;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(244, 155);
            button1.Name = "button1";
            button1.Size = new Size(338, 54);
            button1.TabIndex = 36;
            button1.Text = "Informe de estudiantes inscritos en un curso ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(271, 16);
            label2.Name = "label2";
            label2.Size = new Size(282, 28);
            label2.TabIndex = 35;
            label2.Text = "Lista Reportes/Informes";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Black;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Century Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(7, 10);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(34, 34);
            btnSalir.TabIndex = 34;
            btnSalir.Text = "X";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(64, 64, 64);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(244, 86);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(338, 54);
            btnIngresar.TabIndex = 33;
            btnIngresar.Text = "Informe de inscripciones por período";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(64, 64, 64);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.Gray;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(244, 224);
            button3.Name = "button3";
            button3.Size = new Size(338, 54);
            button3.TabIndex = 39;
            button3.Text = "Informe de ingresos por conceptos de pago";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(64, 64, 64);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = Color.Gray;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(244, 296);
            button4.Name = "button4";
            button4.Size = new Size(338, 54);
            button4.TabIndex = 40;
            button4.Text = "Informe de estadísticas de Cuatrimeste";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(64, 64, 64);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseOverBackColor = Color.Gray;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button5.ForeColor = Color.White;
            button5.Location = new Point(244, 366);
            button5.Name = "button5";
            button5.Size = new Size(338, 54);
            button5.TabIndex = 41;
            button5.Text = "Informe de listas de espera de cursos";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // ListaInformes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1128, 575);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(btnSalir);
            Controls.Add(btnIngresar);
            Controls.Add(button3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ListaInformes";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ListaInformes";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button button2;
        private Button button1;
        private Label label2;
        private Button btnSalir;
        private Button btnIngresar;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}