namespace Sistema
{
    partial class InformePorPeriodo
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
            textBox1 = new TextBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
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
            btnSalir.Location = new Point(323, 379);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(129, 48);
            btnSalir.TabIndex = 36;
            btnSalir.Text = "Volver";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(64, 64, 64);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Location = new Point(115, 185);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(159, 47);
            btnIngresar.TabIndex = 25;
            btnIngresar.Text = "Realizar Informe";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(64, 64, 64);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(13, 55);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(369, 16);
            textBox1.TabIndex = 23;
            textBox1.Text = "Nombre Del Informe";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Black;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(btnIngresar);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(194, 89);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(399, 263);
            groupBox1.TabIndex = 35;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informe";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(191, 122);
            label1.Name = "label1";
            label1.Size = new Size(21, 19);
            label1.TabIndex = 38;
            label1.Text = "A";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(227, 122);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(155, 23);
            dateTimePicker2.TabIndex = 27;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(13, 122);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(155, 23);
            dateTimePicker1.TabIndex = 26;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(185, 34);
            label2.Name = "label2";
            label2.Size = new Size(442, 28);
            label2.TabIndex = 37;
            label2.Text = "Informe de inscripciones por período";
            // 
            // InformePorPeriodo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InformePorPeriodo";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InformePorPeriodo";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        #endregion

        private Button btnSalir;
        private Button btnIngresar;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
    }
}