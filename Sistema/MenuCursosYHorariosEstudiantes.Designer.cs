namespace Sistema
{
    partial class MenuCursosYHorariosEstudiantes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuCursosYHorariosEstudiantes));
            label3 = new Label();
            label1 = new Label();
            button2 = new Button();
            button1 = new Button();
            label2 = new Label();
            btnSalir = new Button();
            btnIngresar = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(317, 48);
            label3.Name = "label3";
            label3.Size = new Size(115, 15);
            label3.TabIndex = 47;
            label3.Text = "Numero Estudiante :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(438, 48);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 46;
            label1.Text = "Num Est";
            label1.Click += label1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.LightGreen;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(252, 317);
            button2.Name = "button2";
            button2.Size = new Size(296, 48);
            button2.TabIndex = 44;
            button2.Text = "Volver al menu";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(252, 203);
            button1.Name = "button1";
            button1.Size = new Size(296, 48);
            button1.TabIndex = 43;
            button1.Text = "Consultar Horarios";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(236, 9);
            label2.Name = "label2";
            label2.Size = new Size(312, 32);
            label2.TabIndex = 42;
            label2.Text = "Menu De Cursos y Horarios";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = SystemColors.Control;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(338, 393);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(129, 48);
            btnSalir.TabIndex = 41;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.LightGreen;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Location = new Point(252, 115);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(296, 48);
            btnIngresar.TabIndex = 40;
            btnIngresar.Text = "Inscripcion Cursos";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-560, -315);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1920, 1080);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 48;
            pictureBox1.TabStop = false;
            // 
            // MenuCursosYHorariosEstudiantes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(btnSalir);
            Controls.Add(btnIngresar);
            Controls.Add(pictureBox1);
            Name = "MenuCursosYHorariosEstudiantes";
            Text = "Menu Cursos y Horario";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label1;
        private Button button2;
        private Button button1;
        private Label label2;
        private Button btnSalir;
        private Button btnIngresar;
        private PictureBox pictureBox1;
    }
}