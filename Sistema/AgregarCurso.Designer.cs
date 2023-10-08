namespace Sistema
{
    partial class AgregarCurso
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
            textBox9 = new TextBox();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            label8 = new Label();
            label7 = new Label();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            textBox3 = new TextBox();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            textBox4 = new TextBox();
            btnIngresar = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            button2 = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Black;
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox9);
            groupBox1.Controls.Add(textBox8);
            groupBox1.Controls.Add(textBox7);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(numericUpDown3);
            groupBox1.Controls.Add(numericUpDown2);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(btnIngresar);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(33, 67);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(11, 11, 11, 11);
            groupBox1.Size = new Size(443, 679);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Curso";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(233, 611);
            button1.Name = "button1";
            button1.Size = new Size(195, 53);
            button1.TabIndex = 60;
            button1.Text = "Hardcodear Curso";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox9
            // 
            textBox9.BackColor = Color.FromArgb(64, 64, 64);
            textBox9.BorderStyle = BorderStyle.None;
            textBox9.ForeColor = Color.White;
            textBox9.Location = new Point(217, 470);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(123, 16);
            textBox9.TabIndex = 59;
            textBox9.Text = "Turno:";
            textBox9.TextChanged += textBox9_TextChanged;
            // 
            // textBox8
            // 
            textBox8.BackColor = Color.FromArgb(64, 64, 64);
            textBox8.BorderStyle = BorderStyle.None;
            textBox8.ForeColor = Color.White;
            textBox8.Location = new Point(334, 408);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(94, 16);
            textBox8.TabIndex = 57;
            textBox8.Text = "Division:";
            textBox8.TextChanged += textBox8_TextChanged;
            // 
            // textBox7
            // 
            textBox7.BackColor = Color.FromArgb(64, 64, 64);
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.ForeColor = Color.White;
            textBox7.Location = new Point(217, 408);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(94, 16);
            textBox7.TabIndex = 55;
            textBox7.Text = "Aula:";
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.FromArgb(64, 64, 64);
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.ForeColor = Color.White;
            textBox6.Location = new Point(15, 470);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(185, 16);
            textBox6.TabIndex = 52;
            textBox6.Text = "Dia:";
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.FromArgb(64, 64, 64);
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.ForeColor = Color.White;
            textBox5.Location = new Point(15, 408);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(185, 16);
            textBox5.TabIndex = 51;
            textBox5.Text = "Cuatrimestre:";
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(239, 513);
            label8.Name = "label8";
            label8.Size = new Size(59, 16);
            label8.TabIndex = 41;
            label8.Text = "Horario:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(295, 550);
            label7.Name = "label7";
            label7.Size = new Size(16, 16);
            label7.TabIndex = 40;
            label7.Text = "A";
            // 
            // numericUpDown3
            // 
            numericUpDown3.BackColor = Color.FromArgb(64, 64, 64);
            numericUpDown3.BorderStyle = BorderStyle.None;
            numericUpDown3.ForeColor = Color.White;
            numericUpDown3.Location = new Point(319, 547);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(48, 19);
            numericUpDown3.TabIndex = 39;
            numericUpDown3.ValueChanged += numericUpDown3_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = Color.FromArgb(64, 64, 64);
            numericUpDown2.BorderStyle = BorderStyle.None;
            numericUpDown2.ForeColor = Color.White;
            numericUpDown2.Location = new Point(239, 547);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(48, 19);
            numericUpDown2.TabIndex = 38;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(64, 64, 64);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.ForeColor = Color.White;
            textBox3.Location = new Point(15, 340);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(413, 16);
            textBox3.TabIndex = 36;
            textBox3.Text = "Profesor:";
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(15, 513);
            label5.Name = "label5";
            label5.Size = new Size(125, 16);
            label5.TabIndex = 35;
            label5.Text = "Cupos Disponible:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.FromArgb(64, 64, 64);
            numericUpDown1.BorderStyle = BorderStyle.None;
            numericUpDown1.ForeColor = Color.White;
            numericUpDown1.Location = new Point(15, 547);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(137, 19);
            numericUpDown1.TabIndex = 34;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(64, 64, 64);
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.ForeColor = Color.White;
            textBox4.Location = new Point(15, 194);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(413, 106);
            textBox4.TabIndex = 30;
            textBox4.Text = "Descripcion:";
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(64, 64, 64);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Location = new Point(15, 611);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(195, 53);
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
            textBox2.Location = new Point(15, 131);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(413, 16);
            textBox2.TabIndex = 24;
            textBox2.Text = "Nombre:";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(64, 64, 64);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(15, 68);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(413, 16);
            textBox1.TabIndex = 23;
            textBox1.Text = "Codigo:";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(150, 10);
            label2.Name = "label2";
            label2.Size = new Size(183, 28);
            label2.TabIndex = 30;
            label2.Text = "Agregar Curso";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(64, 64, 64);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(150, 762);
            button2.Name = "button2";
            button2.Size = new Size(195, 54);
            button2.TabIndex = 36;
            button2.Text = "Volver al menu";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // AgregarCurso
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(507, 830);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AgregarCurso";
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

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBox4;
        private Button btnIngresar;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Button button2;
        private Label label5;
        private TextBox textBox3;
        private Label label8;
        private Label label7;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox9;
        private TextBox textBox8;
        private Button button1;
    }
}