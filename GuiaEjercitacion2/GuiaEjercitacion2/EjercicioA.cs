using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GuiaEjercitacion2
{
    internal class EjercicioA
    {
        // ============================================

        // SECCIÓN A — Pregunta 1
        // Respuesta: [C. "El constructor de AppLogger() {}"]
        // ¿Por qué?: [Al hacer el constructor privado, hace que no se pueda crear una instancia nueva desde afuera de la clase]

        // ============================================

        // SECCIÓN A — Pregunta 2
        // Respuesta: [A. "La instancia se crea la primera vez que alguien lo pide, no antes"]
        // ¿Por qué?: [Se verifica que la instancia no haya sido creada antes, si es null la crea ahi nomas y la devuelve, si ya fue creada devuelve la que ya se habia creado.]

        // ============================================

        // SECCIÓN A — Pregunta 3
        // Respuesta: [D. "Reemplazar un condicional que elige entre variantes de un algoritmo por clases intercambiables detraz de una interfaz"]
        // ¿Por qué?: [Porque cada vez que se agrega una opcion a un if o un switch se tiene que modificar el codigo viejo y se puede romper todo, con strategy cada caso tiene su propia clase y no tocamos nada del codigo viejo]

        // SECCIÓN A — Pregunta 4
        // Respuesta: [B. Usa una estrategia a traves de la interfaz y le delega el calculo, sin saber cual es]
        // ¿Por qué?: [El contexto no le importa como hace las cuentas, le pide el resultado usando el contrato de la interfaz]

        // ============================================
        // SECCIÓN A — Pregunta 5
        // Respuesta: [C. "El medio de pago llega como texto ("QR", "EFECTIVO") desde un ComboBox y desde un JSON, y hay que crear el objeto correcto en varios lugares"]
        // ¿Por qué?: [La factory se encarga de que el programa no dependa de un texto que elije el usuario o de un texto en JSON, sino que da un unico lugar en el sistema que conoce las clases concretas y traduce el dato en el objeto correcto.]

        // ============================================
        // SECCIÓN A — Pregunta 6
        // Respuesta: [A. "En Factory Method, una superclase con lógica de negocio declara el método de creación y cada subclase decide qué producto concreto crear."]
        // ¿Por qué?: [El fatcory method usa herencia para delegar la creacion, mientras que la simple factory suele ser una clase estatica comun con un switch]

        // ============================================
        // SECCIÓN A — Pregunta 7
        // Respuesta: [B. "Una lista de referencias a objetos que implementan la interfaz suscriptora."]
        // ¿Por qué?: [El notificador guarda en una lista de quienes estan subscriptos mediante una interfaz para poder avisarles cuando pasa algo]

        // ============================================
        // SECCIÓN A — Pregunta 8
        // Respuesta: [D. "El controller le sigue avisando a un formulario destruido: puede saltar una excepción y el objeto nunca se libera de memoria."]
        // ¿Por qué?: [El notificador lo sigue teniendo en la lista, lo cual gasta memoria y lanza error de que el objeto ya no existe]

        // ============================================
        // SECCIÓN A — Pregunta 9
        // Respuesta: [A. "Notificador."]
        // ¿Por qué?: [El boton es el que avisa cuando ocurre el evento click, y los metodos son los que escuchan ese aviso]

        // ============================================
        // SECCIÓN A — Pregunta 10
        // Respuesta: [C. "Creás una clase que implementa la interfaz suscriptora y la suscribís en Program.cs."]
        // ¿Por qué?: [Permite agregar nueva funcionalidad agregando una clase nueva sin tocar el codigo que ya andaba bien]
    }
}
