using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2
{
    internal class EjercicioB
    {

    }
}
namespace EjercicioB1
{
    public class Contador
    {
        private static Contador _instancia;
        private int _valor = 0;
        private Contador() { Console.WriteLine("Creando contador"); }
        public static Contador Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Contador();
                return _instancia;
            }
        }
        public int Siguiente()
        {
            _valor++;
            return _valor;
        }
    }
    // ============================================

    // SECCIÓN B1 — Pregunta 1
    // Que Imprime?: [
    // "Creando contador
    // 1
    // 2
    // 3
    // True"]

    // ============================================

    // SECCIÓN B1 — Pregunta 2
    // ¿Cuántas veces aparece "Creando contador" y por qué?:
    // Respuesta: [Aparece una sola vez, al ser el constructor privado y al aplicar singleton el objeto se crea una unica vez la primera vez que se lo pide, y devuelve siempre la misma instancia ]

    // ============================================

    // SECCIÓN B1 — Pregunta 3
    // ¿Por qué b.Siguiente() no devuelve 1?:
    // Respuesta: [Porque a y b apuntan al mismo objeto en memoria]

    // =======================================
}

namespace EjercicioB2
{
    public interface IPropina
    {
        string Nombre { get; }
        decimal Calcular(decimal total);
    }
    public class SinPropina : IPropina
    {
        public string Nombre => "Sin propina";
        public decimal Calcular(decimal total) => 0;
    }
    public class Propina10 : IPropina
    {
        public string Nombre => "10%";
        public decimal Calcular(decimal total) => total * 0.10m;
    }
    public class PropinaFija : IPropina
    {
        private readonly decimal _monto;
        public PropinaFija(decimal monto) => _monto = monto;
        public string Nombre => "Fija";
        public decimal Calcular(decimal total) => _monto;
    }
    public class Cuenta
    {
        private IPropina _propina;
        public Cuenta(IPropina propina) => _propina = propina;
        public void CambiarPropina(IPropina propina) => _propina = propina;
        public void Mostrar(decimal total)
        {
            decimal final = total + _propina.Calcular(total);
            Console.WriteLine($"{_propina.Nombre}: {final:0}");
        }
    }

    // ============================================

    // SECCIÓN B2 — Pregunta 1
    // ¿Qué imprime?:

    // Respuesta: [
    // Sin propina: 20000
    // 10%: 22000
    // Fija: 21500]

    // ============================================

    // SECCIÓN B2 — Pregunta 2
    // En este código, ¿quién es el contexto y quiénes son las estrategias?:
    // Respuesta: [El contexto es la clase cuenta por que es la que usa la propina y hace la cuenta final sin importarle como se calcula.
    // Las estrategias son: "SinPropina", "Propina10" y "PropinaFija",]

    // ============================================

    // SECCIÓN B2 — Pregunta 3
    // ¿Qué hubo que modificar de Cuenta para poder usar PropinaFija? ¿Qué principio se cumple?:
    // Respuesta: [No se tuvo que modificar nada, solo se creo la clase nueva "PropinaFija" y se la pasamos cumpliendo con el principio Open/Closed]


}

namespace EjercicioB3
{
    public interface IObservador
    {
        void Actualizar(string video);
    }
    public class Canal
    {
        private readonly List<IObservador> _suscriptores = new List<IObservador>();
        public void Suscribir(IObservador o) => _suscriptores.Add(o);
        public void Desuscribir(IObservador o) => _suscriptores.Remove(o);
        public void Publicar(string video)
        {
            Console.WriteLine($"Nuevo video: {video}");
            foreach (var s in _suscriptores.ToList())
                s.Actualizar(video);
        }
    }
    public class Fan : IObservador
    {
        private readonly string _nombre;
        public Fan(string nombre) => _nombre = nombre;
        public void Actualizar(string video) => Console.WriteLine($" {_nombre} mira {video}");
    }
    public class Estadisticas : IObservador
    {
        private int _avisos = 0;
        public void Actualizar(string video)
        {
            _avisos++;
            Console.WriteLine($" Avisos registrados: {_avisos}");
        }
    }

    // ============================================

    // SECCIÓN B3 — Pregunta 1
    // ¿Qué imprime?:
    // Respuesta: [
    // "Nuevo video: Patrones en C#
    // Lu mira Patrones en C#
    // Tomi mira Patrones en C#
    // Avisos registrados: 1
    // Nuevo video: Observer en WinForms
    // Tomi mira Observer en WinForms
    // Avisos registrado: 2"]

    // ============================================

    // SECCIÓN B3 — Pregunta 2
    // ¿Por qué Lu no aparece en la segunda publicación?:
    // Respuesta: [Porque durante el programa se ejecuto "canal.Desuscribir(lu)" por lo que fue eliminada de la lista de interesados y el canal ya no le avisa nada]

    // ============================================

    // SECCIÓN B3 — Pregunta 2
    // ¿Canal conoce la clase Fan? ¿Cómo te das cuenta mirando el código?:
    // Respuesta: [El canal no conoce la clase Fan, te das cuenta porque en la clase canal la lista es de tipo IObservador, por lo que interactua con interfacse y no con clases concretas]

    // ============================================
}

