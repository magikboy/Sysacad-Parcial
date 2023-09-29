using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    private int numeroEstudianteIngresado;
    private List<Estudiante> estudiantes;
    public partial class PagoTarjeta : Form
    {
        public PagoTarjeta()
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            estudiantes = GuardarDatos.ReadStreamJSON("estudiantes.json");
            MostrarNumeroEstudiante();
        }

        private void MostrarNumeroEstudiante()
        {
            label1.Text = numeroEstudianteIngresado.ToString();
        }
    }
}
