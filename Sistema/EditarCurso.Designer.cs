namespace Sistema
{
    partial class EditarCurso
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
            textBox9 = new TextBox();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox3 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            textBox4 = new TextBox();
            label1 = new Label();
            btnIngresar = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            btnSalir = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Black;
            groupBox1.Controls.Add(textBox9);
            groupBox1.Controls.Add(textBox8);
            groupBox1.Controls.Add(textBox7);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(numericUpDown3);
            groupBox1.Controls.Add(numericUpDown2);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnIngresar);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 75);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(399, 605);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Curso";
            // 
            // textBox9
            // 
            textBox9.BackColor = Color.FromArgb(64, 64, 64);
            textBox9.BorderStyle = BorderStyle.None;
            textBox9.ForeColor = Color.White;
            textBox9.Location = new Point(199, 424);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(108, 16);
            textBox9.TabIndex = 61;
            textBox9.Text = "Turno:";
            textBox9.TextChanged += textBox9_TextChanged;
            // 
            // textBox8
            // 
            textBox8.BackColor = Color.FromArgb(64, 64, 64);
            textBox8.BorderStyle = BorderStyle.None;
            textBox8.ForeColor = Color.White;
            textBox8.Location = new Point(299, 369);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(83, 16);
            textBox8.TabIndex = 59;
            textBox8.Text = "Division:";
            textBox8.TextChanged += textBox8_TextChanged;
            // 
            // textBox7
            // 
            textBox7.BackColor = Color.FromArgb(64, 64, 64);
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.ForeColor = Color.White;
            textBox7.Location = new Point(199, 369);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(83, 16);
            textBox7.TabIndex = 57;
            textBox7.Text = "Aula:";
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.FromArgb(64, 64, 64);
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.ForeColor = Color.White;
            textBox6.Location = new Point(13, 424);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(162, 16);
            textBox6.TabIndex = 54;
            textBox6.Text = "Dia:";
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.FromArgb(64, 64, 64);
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.ForeColor = Color.White;
            textBox5.Location = new Point(13, 369);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(162, 16);
            textBox5.TabIndex = 53;
            textBox5.Text = "Cuatrimestre:";
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(64, 64, 64);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.ForeColor = Color.White;
            textBox3.Location = new Point(13, 312);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(369, 16);
            textBox3.TabIndex = 46;
            textBox3.Text = "Profesor:";
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(200, 476);
            label8.Name = "label8";
            label8.Size = new Size(53, 16);
            label8.TabIndex = 45;
            label8.Text = "Horario:";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(248, 496);
            label9.Name = "label9";
            label9.Size = new Size(15, 15);
            label9.TabIndex = 44;
            label9.Text = "A";
            // 
            // numericUpDown3
            // 
            numericUpDown3.BackColor = Color.FromArgb(64, 64, 64);
            numericUpDown3.BorderStyle = BorderStyle.None;
            numericUpDown3.ForeColor = Color.White;
            numericUpDown3.Location = new Point(271, 494);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(42, 19);
            numericUpDown3.TabIndex = 43;
            numericUpDown3.ValueChanged += numericUpDown3_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = Color.FromArgb(64, 64, 64);
            numericUpDown2.BorderStyle = BorderStyle.None;
            numericUpDown2.ForeColor = Color.White;
            numericUpDown2.Location = new Point(200, 494);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(42, 19);
            numericUpDown2.TabIndex = 42;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(13, 476);
            label5.Name = "label5";
            label5.Size = new Size(116, 16);
            label5.TabIndex = 35;
            label5.Text = "Cupos Disponibles:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.FromArgb(64, 64, 64);
            numericUpDown1.BorderStyle = BorderStyle.None;
            numericUpDown1.ForeColor = Color.White;
            numericUpDown1.Location = new Point(13, 494);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(66, 19);
            numericUpDown1.TabIndex = 34;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(64, 64, 64);
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.ForeColor = Color.White;
            textBox4.Location = new Point(13, 207);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(369, 60);
            textBox4.TabIndex = 30;
            textBox4.Text = "Descripcion:";
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(13, 52);
            label1.Name = "label1";
            label1.Size = new Size(116, 16);
            label1.TabIndex = 29;
            label1.Text = "Nombre Del Curso:";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(64, 64, 64);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Location = new Point(123, 545);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(159, 47);
            btnIngresar.TabIndex = 25;
            btnIngresar.Text = "Editar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(64, 64, 64);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(13, 149);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(369, 16);
            textBox2.TabIndex = 24;
            textBox2.Text = "Codigo Del Curso:";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(64, 64, 64);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(13, 82);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(369, 16);
            textBox1.TabIndex = 23;
            textBox1.Text = "Nombre Del Curso:";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(129, 9);
            label2.Name = "label2";
            label2.Size = new Size(151, 28);
            label2.TabIndex = 31;
            label2.Text = "Editar Curso";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(64, 64, 64);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(151, 686);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(129, 48);
            btnSalir.TabIndex = 30;
            btnSalir.Text = "Volver";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // EditarCurso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(422, 746);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(btnSalir);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditarCurso";
            Opacity = 0.95D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button btnIngresar;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Button btnSalir;
        private NumericUpDown numericUpDown1;
        private Label label5;
        private Label label8;
        private Label label9;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
    }
}