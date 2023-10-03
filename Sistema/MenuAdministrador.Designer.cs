namespace Sistema
{
    partial class MenuAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAdministrador));
            label2 = new Label();
            btnSalir = new Button();
            btnIngresar = new Button();
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(279, 9);
            label2.Name = "label2";
            label2.Size = new Size(239, 32);
            label2.TabIndex = 28;
            label2.Text = "Menu Administrador";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = SystemColors.Control;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(337, 390);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(129, 48);
            btnSalir.TabIndex = 26;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.LightGreen;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Location = new Point(251, 96);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(296, 48);
            btnIngresar.TabIndex = 25;
            btnIngresar.Text = "Registrar Estudiante";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(251, 189);
            button1.Name = "button1";
            button1.Size = new Size(296, 48);
            button1.TabIndex = 29;
            button1.Text = "Gestionar Cursos";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.LightGreen;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(251, 286);
            button2.Name = "button2";
            button2.Size = new Size(296, 48);
            button2.TabIndex = 30;
            button2.Text = "Volver al menu";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-560, -315);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1920, 1080);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 31;
            pictureBox1.TabStop = false;
            // 
            // MenuAdministrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(btnSalir);
            Controls.Add(btnIngresar);
            Controls.Add(pictureBox1);
            Name = "MenuAdministrador";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Button btnSalir;
        private Button btnIngresar;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
    }
}