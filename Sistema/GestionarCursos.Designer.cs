﻿namespace Sistema
{
    partial class GestionarCursos
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
            button1 = new Button();
            label2 = new Label();
            btnSalir = new Button();
            btnIngresar = new Button();
            button3 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(252, 223);
            button1.Name = "button1";
            button1.Size = new Size(296, 48);
            button1.TabIndex = 34;
            button1.Text = "Eliminar Cursos";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(290, 9);
            label2.Name = "label2";
            label2.Size = new Size(198, 32);
            label2.TabIndex = 33;
            label2.Text = "Gestionar Cursos";
            label2.Click += label2_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = SystemColors.Control;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(338, 392);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(129, 48);
            btnSalir.TabIndex = 32;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.LightGreen;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Location = new Point(252, 73);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(296, 48);
            btnIngresar.TabIndex = 31;
            btnIngresar.Text = "Agregar Cursos";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.LightGreen;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(252, 147);
            button3.Name = "button3";
            button3.Size = new Size(296, 48);
            button3.TabIndex = 36;
            button3.Text = "Editar Cursos";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.LightGreen;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(252, 313);
            button2.Name = "button2";
            button2.Size = new Size(296, 48);
            button2.TabIndex = 35;
            button2.Text = "Volver al menu";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Cursos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(btnSalir);
            Controls.Add(btnIngresar);
            Name = "Cursos";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Label label2;
        private Button btnSalir;
        private Button btnIngresar;
        private Button button3;
        private Button button2;
    }
}