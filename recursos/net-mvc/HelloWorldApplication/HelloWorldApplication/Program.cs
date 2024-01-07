using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace HelloWorldApplication
{

    public class Alumno
    {
        public string Nombre { get; set; }
        public int Nota { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Ejemplos de tipos de datos
            
            //Enteros
            int intNum = 9;
            long longNum = 999999;
            
            //Decimales
            float floatNum = 9.99F;
            double doubleNum = 99.999;
            decimal decimalNum = 99.9999M;

            //Caracteres y cadenas
            char letter = 'A';
            string site = "www.maf.mx";

            //Booleanos
            bool boleano = false;

            var num = 99;
            var str = "hello";
            var bo = false;

            var valores = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var pares = new List<int>();

            var suma = 0;

            //Se usa un foreach para sumar todods los elemtnos
            foreach (var valor in valores) {
                suma += valor;
            }

            //Se usa un foreach para saber cuales elementos son pares 
            foreach (var valor in valores) {
                if (valor % 2 == 0) {
                    pares.Add(valor);
                }
            }

            Console.WriteLine("El valor de la suma de los valores es: " + suma.ToString());
            Console.WriteLine("Los elementos pares son: ");

            foreach (var valor in pares)
            {
                Console.WriteLine(valor);
            }

            suma = 0;
            pares = new List<int>();

            //Uso LINQ para hacer una suma de todos los elementos
            suma = valores.Sum();

            //Uso LINQ para devolver cuales elementos son pares
            pares = valores.Where( x => x % 2 == 0).ToList();

            Console.WriteLine("El valor de la suma de los valores es: " + suma.ToString());
            Console.WriteLine("Los elementos pares son:");

            foreach (var valor in pares)
            {
                Console.WriteLine(valor);
            }

            var alumnos = new List<Alumno> {
                new Alumno { Nombre = "Pedro", Nota = 5},
                new Alumno { Nombre = "Jorge", Nota = 8},
                new Alumno { Nombre = "Manuel", Nota = 6},
                new Alumno { Nombre = "Andres", Nota =3}
            };

            var nombresAlumnos = alumnos.Select(x => x.Nombre).ToList();

            Console.WriteLine("Nombres de Alumnos:");

            foreach (var valor in nombresAlumnos)
            {
                Console.WriteLine(valor);
            }

            var alumnosAprobados = alumnos.Where(x => x.Nota > 5).ToList();

            Console.WriteLine("Alumnos Aprobados:");

            foreach (var valor in alumnosAprobados)
            {
                Console.WriteLine("Nombre: " + valor.Nombre + "Nota: " + valor.Nota );
            }

            var primero = alumnos.First();
            Console.WriteLine("Primer Elemento {Nombre:"+ primero.Nombre + ",Nota:" + primero.Nota + "}");

            var ultimo = alumnos.Last();
            Console.WriteLine("Ultimo Elemento {Nombre:" + ultimo.Nombre + ",Nota:" + ultimo.Nota + "}");

            Console.WriteLine("Ordenado de Menor a Mayor:");

            var ordenadoDeMenorAMayor = alumnos.OrderBy(x => x.Nota).ToList();
            foreach (var valor in ordenadoDeMenorAMayor)
            {
                Console.WriteLine("Nombre: " + valor.Nombre + " Nota: " + valor.Nota);
            }

            Console.WriteLine("Ordenado de Mayor a Menor:");

            var ordenadoDeMayorAMenor = alumnos.OrderByDescending(x => x.Nota).ToList();
            foreach (var valor in ordenadoDeMayorAMenor)
            {
                Console.WriteLine("Nombre: " + valor.Nombre + " Nota: " + valor.Nota);
            }

            var sumaNotas = alumnos.Sum(x => x.Nota);

            Console.WriteLine("Suma de todas las notas: " + sumaNotas.ToString());

            var notaMaxima = alumnos.Max(x => x.Nota);

            Console.WriteLine("La nota maxima es: "+ notaMaxima.ToString());

            var notaMinima = alumnos.Min(x => x.Nota);

            Console.WriteLine("La nota minima es: " + notaMinima.ToString());

            var promedio = alumnos.Average(x => x.Nota);

            Console.WriteLine("El promedio de las notas es: " + promedio.ToString());

            

            var todosAprobados = alumnos.All(x => x.Nota > 5);

            Console.WriteLine("Todos los alumnos  estan aprobados?" + todosAprobados.ToString());

            var algunAprobado = alumnos.Any(x => x.Nota > 5);

            Console.WriteLine("Algun alumno aprobo? " + algunAprobado.ToString());


            Console.WriteLine("Presione cualquier tecla alfanumerica para continuar...");
            Console.ReadKey();
        }
    }
}