namespace Sistema
{
    partial class MenuEstudiante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuEstudiante));
            button2 = new Button();
            button1 = new Button();
            label2 = new Label();
            btnSalir = new Button();
            btnIngresar = new Button();
            button3 = new Button();
            label1 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.LightGreen;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(252, 316);
            button2.Name = "button2";
            button2.Size = new Size(296, 48);
            button2.TabIndex = 35;
            button2.Text = "Volver al menu";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(252, 164);
            button1.Name = "button1";
            button1.Size = new Size(296, 48);
            button1.TabIndex = 34;
            button1.Text = "Cursos y Horarios";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(305, 9);
            label2.Name = "label2";
            label2.Size = new Size(198, 32);
            label2.TabIndex = 33;
            label2.Text = "Menu Estudiante";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = SystemColors.Control;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(338, 392);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(129, 48);
            btnSalir.TabIndex = 32;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.LightGreen;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Location = new Point(252, 89);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(296, 48);
            btnIngresar.TabIndex = 31;
            btnIngresar.Text = "Datos";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.LightGreen;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(252, 242);
            button3.Name = "button3";
            button3.Size = new Size(296, 48);
            button3.TabIndex = 36;
            button3.Text = "Realizar Pagos";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(429, 47);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 38;
            label1.Text = "Num Est";
            label1.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(317, 47);
            label3.Name = "label3";
            label3.Size = new Size(115, 15);
            label3.TabIndex = 39;
            label3.Text = "Numero Estudiante :";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-560, -315);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1920, 1080);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 40;
            pictureBox1.TabStop = false;
            // 
            // MenuEstudiante
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(btnSalir);
            Controls.Add(btnIngresar);
            Controls.Add(pictureBox1);
            Name = "MenuEstudiante";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private Label label2;
        private Button btnSalir;
        private Button btnIngresar;
        private Button button3;
        private Label label1;
        private Label label3;
        private PictureBox pictureBox1;
    }
}