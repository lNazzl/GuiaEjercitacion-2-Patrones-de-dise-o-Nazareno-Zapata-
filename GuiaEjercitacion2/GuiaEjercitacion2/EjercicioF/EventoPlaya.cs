using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public enum TipoEventoPlaya { Ingreso, Egreso}
    public class EventoPlaya
    {
        public TipoEventoPlaya Tipo { get; set;}
        public string Patente {  get; set;}
        public decimal Importe { get; set;}
        public int LugaresLibres {  get; set;}
    }
}
