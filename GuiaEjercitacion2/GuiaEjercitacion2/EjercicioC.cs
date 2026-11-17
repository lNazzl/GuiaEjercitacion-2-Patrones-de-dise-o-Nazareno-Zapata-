using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2
{
    internal class EjercicioC
    {
    }
}
namespace EjercicioC1
{
    public interface IAlarmaObserver
    {
        void Actualizar(Alarma alarma);
    }
    public class Alarma
    {
        private readonly List<IAlarmaObserver> _observadores = new List<IAlarmaObserver>();
        public void Suscribir(IAlarmaObserver o) => _observadores.Add(o);
        public void Desuscribir(IAlarmaObserver o) => _observadores.Remove(o);
        public void Sonar()
        {
            Console.WriteLine("¡Riiiing!");
            foreach (var o in _observadores) // ← algo está mal acá
                o.Actualizar(this);
        }
    }
    public class AvisoUnico : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma)
        {
            Console.WriteLine("Me avisaron una vez y me doy de baja");
            alarma.Desuscribir(this);
        }
    }
    public class Luz : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma) => Console.WriteLine("Luz encendida");
    }

    // ============================================
    // SECCIÓN C1 — Pregunta 1
    // ¿Cuál es el error y de qué tipo es?:
    // Respuesta: [Es un error de ejecucion y es de tipo InvalidOperationException]

    // ============================================

    // SECCIÓN C1 — Pregunta 2
    //¿Por qué ocurre?:
    // Respuesta: [Ocurre porque en el metodo sonar() se recorre la lista de observadores con un foreach, y al querer darse de baja modificando la lista mientras se esta recorriendo hace que se rompa el programa]

    // ============================================
    // SECCIÓN C1 — Pregunta 2
    // ¿Cómo se corrige?:
    // Respuesta: [Se tiene que recorrer una copia de la lista usando ToList() en el foreach del notificador
    // foreach(var o in observadores.ToList())]


}
namespace EjercicioC2
{
    public interface IEnvioStrategy
    {
        decimal Calcular(decimal pesoKg);
    }
    public class EnvioStrategy : IEnvioStrategy
    {
        private readonly string _tipo;
        public EnvioStrategy(string tipo) => _tipo = tipo;
        public decimal Calcular(decimal pesoKg)
        {
            if (_tipo == "Moto") return 1500 + pesoKg * 100; // ← ¿esto es Strategy?
            if (_tipo == "Camion") return 8000 + pesoKg * 40;
            return 3000 + pesoKg * 70;
        }
    }
    // ============================================
    // SECCIÓN C2 — Pregunta 1
    // ¿Cuál es el error y de qué tipo es?:
    // Respuesta: [Es un error de diseño, no esta aplicando el patron Strategy]

    // ============================================
    // SECCIÓN C2 — Pregunta 2
    // ¿Qué pasa cuando llega un tipo nuevo, por ejemplo "Bicicleta"?:
    // Respuesta: [El programa se descajeta porque se tiene que modificar el if para meter el nuevo tipo rompiendo el principio de Open/Closed]

    // ============================================
    // SECCIÓN C2 — Pregunta 3
    // ¿Cómo se corrige? (escribí las clases):
    // Respuesta: [Hay que sacar ese if de una sola clase y armar una clase separada por cada tipo de envio haciendo que todas herenden la interfaz
    //
    // public class EnvioMoto : IEnvioStrategy {
    //     public decimal Calcular(decimal pesoKg) => 1500 + pesoKg * 100;
    // }
    // public class EnvioCamion : IEnvioStrategy {
    //     public decimal Calcular(decimal pesoKg) => 8000 + pesoKg * 40;
    // }
    // public class EnvioEstandar : IEnvioStrategy {
    //     public decimal Calcular(decimal pesoKg) => 3000 + pesoKg * 70;
    // }
    // ]
}
/*
namespace EjercicioC3
{
    public interface INotificador
    {
        void Enviar(string destino, string mensaje);
    }
    public class NotificadorMail : INotificador {  }
    public class NotificadorSms : INotificador { }
    public static class NotificadorFactory
    {
        public static INotificador Crear(string canal)
        {
            if (canal == "MAIL") return new NotificadorMail();
            if (canal == "SMS") return new NotificadorSms();
        } // ← algo está mal acá
    }
    // ============================================
    // SECCIÓN C3 — Pregunta 1
    // ¿Cuál es el error y de qué tipo es?:
    // Respuesta: [Es un Error de compilacion. El metodo crear promete retornar algo pero si el teto que le pasamos no entra en ningun if entonces no termina retornando nada]

    // ============================================
    // SECCIÓN C3 — Pregunta 2
    // ¿Cómo se corrige?:
    // Respuesta: [Hay que agregarle un "default" o excepcion final para que retorne algo o avise de un error.]
    // throw new ArgumentException($"Canal desconocido: {canal}");

    // ============================================
    // SECCIÓN C3 — Pregunta 3
    // ¿Por qué conviene lanzar una excepción con un mensaje claro y no devolver null?:
    // Respuesta: [Porque si devuelve null el programa va a seguir corriendo y se va a romper mas adelante haciendo que no se pueda saber con exactitud en donde hubo un fallo
    // Si lanzamos una excepcion podemos saber rapido en donde hay que tocar para arreglar el fallo.]
}
*/


