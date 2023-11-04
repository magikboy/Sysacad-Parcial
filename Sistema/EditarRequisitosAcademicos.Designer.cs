namespace Sistema
{
    partial class EditarRequisitosAcademicos
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
            btnSalir = new Button();
            btnIngresar = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            groupBox1 = new GroupBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(64, 64, 64);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(162, 552);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(129, 48);
            btnSalir.TabIndex = 33;
            btnSalir.Text = "Volver";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(64, 64, 64);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Location = new Point(109, 385);
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
            textBox2.Location = new Point(13, 112);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(369, 16);
            textBox2.TabIndex = 24;
            textBox2.Text = "Codigo Del Curso";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(64, 64, 64);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(13, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(369, 16);
            textBox1.TabIndex = 23;
            textBox1.Text = "Nombre Del Curso";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Black;
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(btnIngresar);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(39, 79);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(399, 455);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Curso";
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.FromArgb(64, 64, 64);
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.ForeColor = Color.White;
            textBox5.Location = new Point(13, 333);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(369, 16);
            textBox5.TabIndex = 28;
            textBox5.Text = "CréditosAcumulados";
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(64, 64, 64);
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.ForeColor = Color.White;
            textBox4.Location = new Point(13, 263);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(369, 16);
            textBox4.TabIndex = 27;
            textBox4.Text = "PreRequisitos";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(64, 64, 64);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.ForeColor = Color.White;
            textBox3.Location = new Point(13, 190);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(369, 16);
            textBox3.TabIndex = 26;
            textBox3.Text = "PromedioAcadémico";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(101, 26);
            label2.Name = "label2";
            label2.Size = new Size(273, 28);
            label2.TabIndex = 34;
            label2.Text = "Editar Requisitos Curso";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.ForeColor = Color.White;
            label1.Location = new Point(224, 61);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 35;
            label1.Text = "label1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 26);
            label3.Name = "label3";
            label3.Size = new Size(131, 17);
            label3.TabIndex = 29;
            label3.Text = "Nombre Del Curso:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 81);
            label4.Name = "label4";
            label4.Size = new Size(128, 17);
            label4.TabIndex = 30;
            label4.Text = "Codigo Del Curso:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 157);
            label5.Name = "label5";
            label5.Size = new Size(221, 17);
            label5.TabIndex = 31;
            label5.Text = "Promedio Academico Del Curso:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 231);
            label6.Name = "label6";
            label6.Size = new Size(241, 17);
            label6.TabIndex = 32;
            label6.Text = "PreRequisitos Academico Del Curso:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 301);
            label7.Name = "label7";
            label7.Size = new Size(298, 17);
            label7.TabIndex = 33;
            label7.Text = "CreditosAcumulados Academicos Del Curso:";
            // 
            // EditarRequisitosAcademicos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(481, 629);
            Controls.Add(label1);
            Controls.Add(btnSalir);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditarRequisitosAcademicos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditarRequisitosAcademicos";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalir;
        private Button btnIngresar;
        private TextBox textBox2;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
    }
}