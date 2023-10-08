namespace Sistema
{
    partial class RegistrarEstudiante
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
            groupBox1 = new GroupBox();
            button1 = new Button();
            textBox6 = new TextBox();
            label7 = new Label();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            textBox5 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            btnIngresar = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            btnSalir = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Black;
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(btnIngresar);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 60);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10, 11, 10, 11);
            groupBox1.Size = new Size(328, 547);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Estudiante";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(188, 479);
            button1.Name = "button1";
            button1.Size = new Size(121, 53);
            button1.TabIndex = 41;
            button1.Text = "Harcodear Est";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.FromArgb(64, 64, 64);
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.ForeColor = Color.White;
            textBox6.Location = new Point(14, 362);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(296, 15);
            textBox6.TabIndex = 39;
            textBox6.Text = "Numero Estudiante";
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(13, 414);
            label7.Name = "label7";
            label7.Size = new Size(132, 15);
            label7.TabIndex = 38;
            label7.Text = "Contraseña provisoria?";
            label7.Click += label7_Click;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.ForeColor = Color.White;
            checkBox2.Location = new Point(194, 447);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(46, 21);
            checkBox2.TabIndex = 37;
            checkBox2.Text = "NO";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(79, 447);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(37, 21);
            checkBox1.TabIndex = 36;
            checkBox1.Text = "SI";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.FromArgb(64, 64, 64);
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.ForeColor = Color.White;
            textBox5.Location = new Point(14, 294);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(296, 15);
            textBox5.TabIndex = 34;
            textBox5.Text = "Telefono";
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(64, 64, 64);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.ForeColor = Color.White;
            textBox3.Location = new Point(14, 230);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(296, 15);
            textBox3.TabIndex = 31;
            textBox3.Text = "Email";
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(64, 64, 64);
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.ForeColor = Color.White;
            textBox4.Location = new Point(14, 167);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(296, 15);
            textBox4.TabIndex = 30;
            textBox4.Text = "Direccion";
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(64, 64, 64);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Location = new Point(13, 479);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(123, 53);
            btnIngresar.TabIndex = 25;
            btnIngresar.Text = "Registar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(64, 64, 64);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(14, 113);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(296, 15);
            textBox2.TabIndex = 24;
            textBox2.Text = "Apellido";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(64, 64, 64);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(14, 50);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(296, 17);
            textBox1.TabIndex = 23;
            textBox1.Text = "Nombre";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 10);
            label2.Name = "label2";
            label2.Size = new Size(223, 32);
            label2.TabIndex = 28;
            label2.Text = "Registar Estudiante";
            label2.Click += label2_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(64, 64, 64);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(106, 614);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(129, 54);
            btnSalir.TabIndex = 26;
            btnSalir.Text = "Volver";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // RegistrarEstudiante
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = Color.Black;
            ClientSize = new Size(354, 675);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(btnSalir);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegistrarEstudiante";
            Opacity = 0.95D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += RegistrarEstudiante_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void RegistrarEstudiante_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnSalir;
        private Button btnIngresar;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label7;
        private TextBox textBox6;
        private Button button1;
    }
}