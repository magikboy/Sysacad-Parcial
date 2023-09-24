namespace Sistema
{
    partial class ConsultarHorario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultarHorario));
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            btnSalir = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(376, 48);
            label3.Name = "label3";
            label3.Size = new Size(115, 15);
            label3.TabIndex = 53;
            label3.Text = "Numero Estudiante :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(481, 48);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 52;
            label1.Text = "Num Est";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(359, 9);
            label2.Name = "label2";
            label2.Size = new Size(218, 32);
            label2.TabIndex = 51;
            label2.Text = "Consultar Horarios";
            // 
            // button2
            // 
            button2.BackColor = Color.LightGreen;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(322, 542);
            button2.Name = "button2";
            button2.Size = new Size(296, 48);
            button2.TabIndex = 55;
            button2.Text = "Volver al menu";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = SystemColors.Control;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(404, 596);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(129, 48);
            btnSalir.TabIndex = 54;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(47, 81);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(862, 455);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 56;
            pictureBox1.TabStop = false;
            // 
            // ConsultarHorario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(962, 656);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(btnSalir);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "ConsultarHorario";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label1;
        private Label label2;
        private Button button2;
        private Button btnSalir;
        private PictureBox pictureBox1;
    }
}