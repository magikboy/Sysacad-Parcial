namespace Sistema
{
    partial class ElegirCurso
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
            components = new System.ComponentModel.Container();
            button2 = new Button();
            label2 = new Label();
            groupBox1 = new GroupBox();
            label1 = new Label();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            groupBox4 = new GroupBox();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            groupBox3 = new GroupBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            guardarDatosBindingSource = new BindingSource(components);
            button1 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guardarDatosBindingSource).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.LightGreen;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(22, 530);
            button2.Name = "button2";
            button2.Size = new Size(171, 48);
            button2.TabIndex = 39;
            button2.Text = "Volver al menu";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(127, 21);
            label2.Name = "label2";
            label2.Size = new Size(143, 32);
            label2.TabIndex = 38;
            label2.Text = "Elegir Curso";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Gainsboro;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(12, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(388, 83);
            groupBox1.TabIndex = 37;
            groupBox1.TabStop = false;
            groupBox1.Text = "Elegir Curso";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(13, 26);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 29;
            label1.Text = "Codigo Del Curso:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(13, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(362, 23);
            textBox1.TabIndex = 23;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Gainsboro;
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Location = new Point(12, 184);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(10);
            groupBox2.Size = new Size(388, 315);
            groupBox2.TabIndex = 38;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cursos Disponibles:";
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.Gainsboro;
            groupBox4.Controls.Add(label16);
            groupBox4.Controls.Add(label15);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(label10);
            groupBox4.Location = new Point(187, 20);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(10);
            groupBox4.Size = new Size(168, 282);
            groupBox4.TabIndex = 40;
            groupBox4.TabStop = false;
            groupBox4.Text = "Codigos:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(13, 248);
            label16.Name = "label16";
            label16.Size = new Size(45, 15);
            label16.TabIndex = 43;
            label16.Text = "Codigo";
            label16.Click += label16_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(13, 214);
            label15.Name = "label15";
            label15.Size = new Size(45, 15);
            label15.TabIndex = 42;
            label15.Text = "Codigo";
            label15.Click += label15_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(13, 180);
            label14.Name = "label14";
            label14.Size = new Size(45, 15);
            label14.TabIndex = 41;
            label14.Text = "Codigo";
            label14.Click += label14_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(13, 142);
            label13.Name = "label13";
            label13.Size = new Size(45, 15);
            label13.TabIndex = 40;
            label13.Text = "Codigo";
            label13.Click += label13_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(13, 103);
            label12.Name = "label12";
            label12.Size = new Size(45, 15);
            label12.TabIndex = 39;
            label12.Text = "Codigo";
            label12.Click += label12_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(13, 68);
            label11.Name = "label11";
            label11.Size = new Size(45, 15);
            label11.TabIndex = 38;
            label11.Text = "Codigo";
            label11.Click += label11_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(13, 36);
            label10.Name = "label10";
            label10.Size = new Size(45, 15);
            label10.TabIndex = 37;
            label10.Text = "Codigo";
            label10.Click += label10_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Gainsboro;
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(13, 20);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(10);
            groupBox3.Size = new Size(168, 282);
            groupBox3.TabIndex = 39;
            groupBox3.TabStop = false;
            groupBox3.Text = "Nombres:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(0, 248);
            label9.Name = "label9";
            label9.Size = new Size(45, 15);
            label9.TabIndex = 36;
            label9.Text = "Codigo";
            label9.Click += label9_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(0, 214);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 35;
            label8.Text = "Codigo";
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(0, 180);
            label7.Name = "label7";
            label7.Size = new Size(45, 15);
            label7.TabIndex = 34;
            label7.Text = "Codigo";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(0, 142);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 33;
            label6.Text = "Codigo";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(0, 103);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 32;
            label5.Text = "Codigo";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(0, 68);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 31;
            label4.Text = "Codigo";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 36);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 30;
            label3.Text = "Codigo";
            label3.Click += label3_Click;
            // 
            // guardarDatosBindingSource
            // 
            guardarDatosBindingSource.DataSource = typeof(Biblioteca.GuardarDatosEstudiantes);
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(216, 530);
            button1.Name = "button1";
            button1.Size = new Size(171, 48);
            button1.TabIndex = 40;
            button1.Text = "Elegir";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_2;
            // 
            // ElegirCurso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(411, 599);
            Controls.Add(button1);
            Controls.Add(groupBox2);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Name = "ElegirCurso";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guardarDatosBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void label16_Click(object sender, EventArgs e)
        {
        }

        #endregion

        private Button button2;
        private Label label2;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private BindingSource guardarDatosBindingSource;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button button1;
    }
}