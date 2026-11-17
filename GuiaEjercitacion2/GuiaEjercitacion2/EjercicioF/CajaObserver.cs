using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class CajaObserver : IPlayaObserver
    {
        private decimal _recaudadoTotal = 0;
        public void Actualizar(EventoPlaya evento)
        {
            if (evento.Tipo == TipoEventoPlaya.Egreso)
            {
                _recaudadoTotal += evento.Importe;
                Console.WriteLine($"[Caja] Cobrado ${evento.Importe} a {evento.Patente}. Recaudado: ${_recaudadoTotal}.");
            }
        }

    }
}
