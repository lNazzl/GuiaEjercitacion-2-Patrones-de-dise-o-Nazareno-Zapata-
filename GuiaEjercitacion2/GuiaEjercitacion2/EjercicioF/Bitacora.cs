using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class Bitacora
    {
        private static Bitacora _instancia;
        private int _contador = 0;
        private List<string> _registros = new List<string>();

        private Bitacora() { }

        public static Bitacora Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Bitacora();
                return _instancia;
            }
        }

        public void Registrar(string texto)
        {
            _contador++;
            _registros.Add($"{_contador:00}. {texto}");
        }

        public void MostrarTodo()
        {
            Console.WriteLine("Bitacora");
            foreach (var r in _registros)
                Console.WriteLine(r);
        }
    }
}
