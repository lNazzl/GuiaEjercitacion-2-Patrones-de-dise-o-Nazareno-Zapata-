/*using EjercicioB1;

var a = Contador.Instancia;
var b = Contador.Instancia;
Console.WriteLine(a.Siguiente());
Console.WriteLine(b.Siguiente());
Console.WriteLine(Contador.Instancia.Siguiente());
Console.WriteLine(ReferenceEquals(a, b));
*/
/*
using EjercicioB2;

var cuenta = new Cuenta(new SinPropina());
cuenta.Mostrar(20000);
cuenta.CambiarPropina(new Propina10());
cuenta.Mostrar(20000);
cuenta.CambiarPropina(new PropinaFija(1500));
cuenta.Mostrar(20000);
*/
/*using EjercicioB3;

var canal = new Canal();
var lu = new Fan("Lu");
canal.Suscribir(lu);
canal.Suscribir(new Fan("Tomi"));
canal.Suscribir(new Estadisticas());
canal.Publicar("Patrones en C#");
canal.Desuscribir(lu);
canal.Publicar("Observer en WinForms");
*/

//------------------------------------------------------------------------------------------------
/*
using EjercicioC1;

var alarma = new Alarma();
alarma.Suscribir(new AvisoUnico());
alarma.Suscribir(new Luz());
alarma.Sonar();
*/
/*
using EjercicioD1;

var termo = new Termometro();
termo.Suscribir(new PantallaCocina());
termo.Suscribir(new AlarmaCalor());
termo.Medir(25);
termo.Medir(34);
*/
/*
using EjercicioD2;

string tipoElegido = "JUBILADO";
IDescuento descuento = DescuentoFactory.Crear(tipoElegido);
Console.WriteLine(descuento.Aplicar(10000m).ToString("0")); // debe imprimir 8500
*/

using GuiaEjercitacion2.EjercicioF;

var playa = new Playa(10);

var pantalla = new PantallaLugares();
playa.Suscribir(pantalla);
playa.Suscribir(new CajaObserver());
playa.Suscribir(new AlertaOcupacionObserver());
playa.Suscribir(new BitacoraObserver());
// ... ingresan 8 vehículos con distintos códigos de tarifa ...
playa.Ingresar("AB123CD", "HORA");
playa.Ingresar("AC456EF", "ESTADIA");
playa.Ingresar("AD789GH", "NOCHE");
// ...
playa.Egresar("AB123CD", 150); // HORA, 2 h 30 min -> $ 3.600
playa.Egresar("AC456EF", 900); // ESTADIA, 15 h -> $ 9.600
playa.Desuscribir(pantalla); // la pantalla deja de mostrar
playa.Egresar("AD789GH", 600); // NOCHE -> $ 4.500
try { playa.Ingresar("AZ999ZZ", "SEMANAL"); }
catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); }
Bitacora.Instancia.MostrarTodo();