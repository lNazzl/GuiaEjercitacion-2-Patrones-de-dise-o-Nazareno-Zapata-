using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class TarifaEstadia : ITarifa
    {
        public string Nombre => "ESTADIA";
        public decimal Calcular(int minutos)
        {
            if (minutos <= 720) 
                return 6000m;
            int minutosExtra = minutos - 720;
            double horasExtra = Math.Ceiling(minutosExtra / 60.0);
            return 6000m + (decimal)horasExtra * 1200m;
        }
    }
}
