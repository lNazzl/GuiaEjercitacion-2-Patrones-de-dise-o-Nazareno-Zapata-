using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class Playa
    {
        private readonly int _capacidadMax;
        private readonly Dictionary<string, ITarifa> _vehiculosEnPlaya = new Dictionary<string, ITarifa>();
        private readonly List<IPlayaObserver> _observadores = new List<IPlayaObserver>();

        public Playa(int capacidad) => _capacidadMax = capacidad;

        public void Suscribir(IPlayaObserver o )
        {
            if(!_observadores.Contains(o))
            {
                _observadores.Add(o);
            }
        }

        public void Desuscribir(IPlayaObserver o ) => _observadores.Remove(o);

        public void Notificar(EventoPlaya evento)
        {
            foreach (var o in _observadores.ToList())
                o.Actualizar(evento);
        }

        public void Ingresar(string patente, string codigoTarifa)
        {
            if (string.IsNullOrWhiteSpace(patente))
                throw new ArgumentException("Patente vacia.");
            if (_vehiculosEnPlaya.ContainsKey(patente))
                throw new InvalidOperationException("Vehiculo ya ingresado");
            if (_vehiculosEnPlaya.Count >= _capacidadMax)
                throw new InvalidOperationException("Playa llena.");

            var tarifa = TarifaFactory.Crear(codigoTarifa);
            _vehiculosEnPlaya.Add(patente, tarifa);

            int libres = _capacidadMax - _vehiculosEnPlaya.Count;
            Notificar(new EventoPlaya { Tipo = TipoEventoPlaya.Ingreso, Patente = patente, LugaresLibres = libres });   
        }

        public decimal Egresar(string patente, int minutos)
        {
            if (!_vehiculosEnPlaya.ContainsKey(patente))
                throw new KeyNotFoundException("Vehiculo no encontrado.");

            var tarifa = _vehiculosEnPlaya[patente];
            decimal importe = tarifa.Calcular(minutos);
            _vehiculosEnPlaya.Remove(patente);

            int libres = _capacidadMax - _vehiculosEnPlaya.Count;
            Notificar(new EventoPlaya { Tipo = TipoEventoPlaya.Egreso, Patente = patente, Importe = importe, LugaresLibres = libres });
            return importe;
        }
    }
}
