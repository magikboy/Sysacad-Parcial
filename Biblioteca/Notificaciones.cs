using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class NotificacionEventArgs : EventArgs
    {
        public int NumeroNotificaciones { get; set; }

        public NotificacionEventArgs(int numeroNotificaciones)
        {
            NumeroNotificaciones = numeroNotificaciones;
        }
    }

    public class NotificacionManejada
    {
        private int numeroNotificaciones;

        // Definir el evento que se dispara en el icono de notificaciones
        public event EventHandler<NotificacionEventArgs> NotificacionClicada;

        public NotificacionManejada()
        {
            // Inicializar el número de notificaciones
            numeroNotificaciones = 1;
        }

        // Método para simular el clic en el icono de notificaciones
        public void SimularClicNotificaciones()
        {
            // Incrementar el número de notificaciones
            numeroNotificaciones++;

            // Disparar el evento con el número actual de notificaciones
            OnNotificacionClicada();
        }

        protected virtual void OnNotificacionClicada()
        {
            // Disparar el evento con el número actual de notificaciones
            NotificacionClicada?.Invoke(this, new NotificacionEventArgs(numeroNotificaciones));

            // Resetear el número de notificaciones
            numeroNotificaciones = 0;
        }
    }
}
