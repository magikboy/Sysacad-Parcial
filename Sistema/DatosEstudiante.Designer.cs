namespace Sistema
{
    partial class DatosEstudiante
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
            button3 = new Button();
            label19 = new Label();
            textBox1 = new TextBox();
            label16 = new Label();
            label10 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            checkBox1 = new CheckBox();
            button1 = new Button();
            label9 = new Label();
            label8 = new Label();
            textBox7 = new TextBox();
            label7 = new Label();
            textBox6 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            btnSalir = new Button();
            label17 = new Label();
            label18 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Black;
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(textBox7);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(115, 86);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(673, 485);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Estudiante";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(64, 64, 64);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(314, 382);
            button3.Name = "button3";
            button3.Size = new Size(105, 37);
            button3.TabIndex = 45;
            button3.Text = "Confirmar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(13, 314);
            label19.Name = "label19";
            label19.Size = new Size(198, 17);
            label19.TabIndex = 44;
            label19.Text = "Agregar Historial Academico:";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(64, 64, 64);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(13, 349);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(291, 108);
            textBox1.TabIndex = 43;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(113, 282);
            label16.Name = "label16";
            label16.Size = new Size(91, 17);
            label16.TabIndex = 42;
            label16.Text = "Cuatrimestre";
            label16.Click += label16_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(13, 282);
            label10.Name = "label10";
            label10.Size = new Size(95, 17);
            label10.TabIndex = 41;
            label10.Text = "Cuatrimestre:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(87, 240);
            label15.Name = "label15";
            label15.Size = new Size(62, 17);
            label15.TabIndex = 40;
            label15.Text = "Telefono";
            label15.Click += label15_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(91, 189);
            label14.Name = "label14";
            label14.Size = new Size(53, 17);
            label14.TabIndex = 39;
            label14.Text = "Correo";
            label14.Click += label14_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(91, 143);
            label13.Name = "label13";
            label13.Size = new Size(69, 17);
            label13.TabIndex = 38;
            label13.Text = "Direccion";
            label13.Click += label13_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(89, 92);
            label12.Name = "label12";
            label12.Size = new Size(61, 17);
            label12.TabIndex = 37;
            label12.Text = "Apellido";
            label12.Click += label12_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(91, 44);
            label11.Name = "label11";
            label11.Size = new Size(61, 17);
            label11.TabIndex = 36;
            label11.Text = "Nombre";
            label11.Click += label11_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.Location = new Point(339, 186);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(155, 21);
            checkBox1.TabIndex = 34;
            checkBox1.Text = "Ocultar Contraseña";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(424, 228);
            button1.Name = "button1";
            button1.Size = new Size(105, 37);
            button1.TabIndex = 33;
            button1.Text = "Confirmar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(339, 41);
            label9.Name = "label9";
            label9.Size = new Size(146, 17);
            label9.TabIndex = 33;
            label9.Text = "Cambiar Contraseña";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(339, 146);
            label8.Name = "label8";
            label8.Size = new Size(55, 17);
            label8.TabIndex = 13;
            label8.Text = "Nueva:";
            // 
            // textBox7
            // 
            textBox7.BackColor = Color.FromArgb(64, 64, 64);
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox7.ForeColor = Color.White;
            textBox7.Location = new Point(424, 143);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(182, 16);
            textBox7.TabIndex = 12;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(339, 92);
            label7.Name = "label7";
            label7.Size = new Size(54, 17);
            label7.TabIndex = 11;
            label7.Text = "Actual:";
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.FromArgb(64, 64, 64);
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox6.ForeColor = Color.White;
            textBox6.Location = new Point(424, 88);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(182, 16);
            textBox6.TabIndex = 10;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(13, 240);
            label6.Name = "label6";
            label6.Size = new Size(66, 17);
            label6.TabIndex = 9;
            label6.Text = "Telefono:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(13, 189);
            label5.Name = "label5";
            label5.Size = new Size(57, 17);
            label5.TabIndex = 7;
            label5.Text = "Correo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(13, 143);
            label4.Name = "label4";
            label4.Size = new Size(73, 17);
            label4.TabIndex = 5;
            label4.Text = "Direccion:";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(13, 92);
            label3.Name = "label3";
            label3.Size = new Size(65, 17);
            label3.TabIndex = 3;
            label3.Text = "Apellido:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(13, 44);
            label1.Name = "label1";
            label1.Size = new Size(65, 17);
            label1.TabIndex = 1;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(330, 9);
            label2.Name = "label2";
            label2.Size = new Size(258, 30);
            label2.TabIndex = 29;
            label2.Text = "Datos Del Estudiante";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(64, 64, 64);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(287, 589);
            button2.Name = "button2";
            button2.Size = new Size(338, 54);
            button2.TabIndex = 32;
            button2.Text = "Volver al menu";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Black;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btnSalir.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(12, 6);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(27, 37);
            btnSalir.TabIndex = 31;
            btnSalir.Text = "X";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label17.ForeColor = Color.White;
            label17.Location = new Point(481, 49);
            label17.Name = "label17";
            label17.Size = new Size(54, 17);
            label17.TabIndex = 73;
            label17.Text = "label17";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label18.ForeColor = Color.White;
            label18.Location = new Point(353, 49);
            label18.Name = "label18";
            label18.Size = new Size(139, 17);
            label18.TabIndex = 72;
            label18.Text = "Numero Estudiante :";
            // 
            // DatosEstudiante
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(937, 670);
            Controls.Add(label17);
            Controls.Add(label18);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(btnSalir);
            Controls.Add(groupBox1);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DatosEstudiante";
            Opacity = 0.95D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
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
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label6;
        private Label label4;
        private Label label3;
        private Button button2;
        private Button btnSalir;
        private Label label9;
        private Label label8;
        private TextBox textBox7;
        private Label label7;
        private TextBox textBox6;
        private Button button1;
        private CheckBox checkBox1;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label5;
        private Label label16;
        private Label label10;
        private Label label17;
        private Label label18;
        private Label label19;
        private TextBox textBox1;
        private Button button3;
    }
}