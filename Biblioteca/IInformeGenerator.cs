using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public interface IInformeGenerator
    {
        // Método para generar el informe
        Task<string> GenerateInformeAsync(int cursoId, string titulo);
    }

    // Interfaz para la generación de informes
    public interface IInformeGenerator1
    {
        // Método para generar informes
        void GenerateInforme(string cuatrimestre, string tituloInforme);
    }

}
