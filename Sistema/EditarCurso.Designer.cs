﻿namespace Sistema
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
            label10 = new Label();
            textBox3 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label7 = new Label();
            label5 = new Label();
            label6 = new Label();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            textBox4 = new TextBox();
            label1 = new Label();
            label3 = new Label();
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
            groupBox1.BackColor = Color.Gainsboro;
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(numericUpDown3);
            groupBox1.Controls.Add(numericUpDown2);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnIngresar);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(12, 75);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(415, 520);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Curso";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(13, 294);
            label10.Name = "label10";
            label10.Size = new Size(58, 15);
            label10.TabIndex = 47;
            label10.Text = "Profesor:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(13, 328);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(296, 23);
            textBox3.TabIndex = 46;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(200, 373);
            label8.Name = "label8";
            label8.Size = new Size(52, 15);
            label8.TabIndex = 45;
            label8.Text = "Horario:";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(254, 405);
            label9.Name = "label9";
            label9.Size = new Size(15, 15);
            label9.TabIndex = 44;
            label9.Text = "A";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(278, 403);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(42, 23);
            numericUpDown3.TabIndex = 43;
            numericUpDown3.ValueChanged += numericUpDown3_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(200, 403);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(42, 23);
            numericUpDown2.TabIndex = 42;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(95, 26);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 37;
            label7.Text = "Nombre";
            label7.Click += label7_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(8, 373);
            label5.Name = "label5";
            label5.Size = new Size(109, 15);
            label5.TabIndex = 35;
            label5.Text = "Cupos Disponibles:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(13, 26);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 36;
            label6.Text = "Curso a editar:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(13, 403);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(66, 23);
            numericUpDown1.TabIndex = 34;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(13, 189);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 33;
            label4.Text = "Descripcion";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(13, 207);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(300, 60);
            textBox4.TabIndex = 30;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(13, 52);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 29;
            label1.Text = "Nombre Del Curso:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(13, 122);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 27;
            label3.Text = "Codigo Del Curso:";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.LightGreen;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Location = new Point(123, 460);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(159, 47);
            btnIngresar.TabIndex = 25;
            btnIngresar.Text = "Editar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(13, 149);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(296, 23);
            textBox2.TabIndex = 24;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(13, 82);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(296, 23);
            textBox1.TabIndex = 23;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(135, 9);
            label2.Name = "label2";
            label2.Size = new Size(146, 32);
            label2.TabIndex = 31;
            label2.Text = "Editar Curso";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = SystemColors.Control;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(152, 601);
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
            BackColor = Color.LightGray;
            ClientSize = new Size(438, 661);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(btnSalir);
            Name = "EditarCurso";
            Text = "Form2";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private Label label1;
        private Label label3;
        private Button btnIngresar;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Button btnSalir;
        private NumericUpDown numericUpDown1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private TextBox textBox4;
        private Label label10;
        private TextBox textBox3;
    }
}