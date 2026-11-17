using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class TarifaHora : ITarifa
    {
        public string Nombre => "HORA";
        public decimal Calcular(int minutos)
        {
            double horas = Math.Ceiling(minutos / 60.0);
            return (decimal)horas * 1200m;
        }
    }
}
