namespace Sistema
{
    partial class PagoTarjeta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagoTarjeta));
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            textBox5 = new TextBox();
            label1 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox7 = new TextBox();
            label8 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            button2 = new Button();
            btnIngresar = new Button();
            pictureBox2 = new PictureBox();
            label11 = new Label();
            label10 = new Label();
            pictureBox5 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.TarjetaFrente;
            pictureBox1.Location = new Point(-16, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(600, 300);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(132, 51);
            label3.Name = "label3";
            label3.Size = new Size(115, 15);
            label3.TabIndex = 107;
            label3.Text = "Numero Estudiante :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(141, 9);
            label2.Name = "label2";
            label2.Size = new Size(148, 32);
            label2.TabIndex = 106;
            label2.Text = "Menu Pagos";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(238, 51);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 109;
            label4.Text = "Numero";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(32, 198);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(57, 23);
            textBox1.TabIndex = 110;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(95, 198);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(57, 23);
            textBox2.TabIndex = 111;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(158, 198);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(57, 23);
            textBox3.TabIndex = 112;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(221, 198);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(57, 23);
            textBox4.TabIndex = 113;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(158, 227);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(42, 23);
            numericUpDown2.TabIndex = 114;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(238, 227);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(42, 23);
            numericUpDown1.TabIndex = 115;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(32, 264);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(215, 23);
            textBox5.TabIndex = 116;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(124, 227);
            label1.Name = "label1";
            label1.Size = new Size(28, 13);
            label1.TabIndex = 117;
            label1.Text = "Mes";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(206, 227);
            label5.Name = "label5";
            label5.Size = new Size(27, 13);
            label5.TabIndex = 118;
            label5.Text = "Año";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(95, 173);
            label6.Name = "label6";
            label6.Size = new Size(85, 13);
            label6.TabIndex = 119;
            label6.Text = "Numero Tarjeta";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(32, 248);
            label7.Name = "label7";
            label7.Size = new Size(49, 13);
            label7.TabIndex = 120;
            label7.Text = "Nombre";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(190, 458);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(57, 23);
            textBox7.TabIndex = 122;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(253, 462);
            label8.Name = "label8";
            label8.Size = new Size(28, 13);
            label8.TabIndex = 123;
            label8.Text = "CVV";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.logo_mastercard;
            pictureBox3.Location = new Point(300, 135);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(118, 60);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 124;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.visa_logo;
            pictureBox4.Location = new Point(300, 135);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(118, 60);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 125;
            pictureBox4.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = Color.LightGreen;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(79, 688);
            button2.Name = "button2";
            button2.Size = new Size(296, 48);
            button2.TabIndex = 128;
            button2.Text = "Volver al menu";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.LightGreen;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Location = new Point(79, 623);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(296, 48);
            btnIngresar.TabIndex = 126;
            btnIngresar.Text = "Ir a Pagar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.TarjetaReverso;
            pictureBox2.Location = new Point(-45, 306);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(600, 300);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(110, 577);
            label11.Name = "label11";
            label11.Size = new Size(51, 15);
            label11.TabIndex = 133;
            label11.Text = "Numero";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(79, 577);
            label10.Name = "label10";
            label10.Size = new Size(35, 15);
            label10.TabIndex = 134;
            label10.Text = "Total:";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(-738, -166);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(1920, 1080);
            pictureBox5.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox5.TabIndex = 135;
            pictureBox5.TabStop = false;
            // 
            // PagoTarjeta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 748);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(button2);
            Controls.Add(btnIngresar);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(label8);
            Controls.Add(textBox7);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(numericUpDown1);
            Controls.Add(numericUpDown2);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox5);
            Name = "PagoTarjeta";
            Text = "Pagar";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private TextBox textBox5;
        private Label label1;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox7;
        private Label label8;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Button button2;
        private Button btnIngresar;
        private PictureBox pictureBox2;
        private Label label11;
        private Label label10;
        private PictureBox pictureBox5;
    }
}