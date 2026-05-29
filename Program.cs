using System;


namespace MiPrograma
{
    class Program
    {
        const int NUM_ASIGNATURAS = 5;
        const int NOTA_APROBACION = 51;
        static void Main()
        {
            string nombre, apellido, carnet, carrera;
            int paralelo;

            Console.WriteLine("   SISTEMA DE GESTION ACADEMICA   ");

            do
            {
                Console.WriteLine("Nombre del estudiante: ");
                nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("Error: el nombre no puede estar vacio");
                }

            } while (string.IsNullOrWhiteSpace(nombre));

            do
            {
                Console.Write("ingrese el apellido: ");
                apellido = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(apellido))
                {
                    Console.WriteLine("error:el apellido no puede estar vacio");
                }

            } while (string.IsNullOrWhiteSpace(apellido));

            do
            {
                Console.Write("Ingrese el carnet: ");
                carnet = Console.ReadLine();
                if (!long.TryParse(carnet, out _) || carnet.Length < 6)
                {
                    Console.WriteLine("error: el carnet debe ser numerico y tener minimo 6 digitos");
                }
            } while (!long.TryParse(carnet, out _) || carnet.Length < 6);

            do
            {
                Console.WriteLine("carreras validas: ");
                Console.WriteLine(" INGENIERIA EN SISTEMAS");
                Console.WriteLine(" INGENIERIA INDUSTRIAL ");
                Console.WriteLine(" INGENIERIA CIVIL");
                Console.WriteLine(" INGENIERIA ELECTRONICA");
                Console.WriteLine(" ingrese su carrera: ");
                carrera = Console.ReadLine();
                if (carrera != "INGENIERIA EN SISTEMAS" && carrera != "INGENIERIA INDUSTRIAL" && carrera != "INGENIERIA ELECTRONICA" && carrera != "INGENIERIA CIVIL")
                {
                    Console.WriteLine("CARRERA NO VALIDA");

                }
            } while (carrera != "INGENIERIA EN SISTEMAS" && carrera != "INGENIERIA INDUSTRIAL" && carrera != "INGENIERIA ELECTRONICA" && carrera != "INGENIERIA CIVIL");

            do
            {
                Console.Write("ingrese paralelo: ");
                if (!int.TryParse(Console.ReadLine(), out paralelo) || paralelo <= 0)
                {
                    Console.WriteLine("el paralelo debe ser un numero positivo");
                    paralelo = 0;
                }

            } while (paralelo <= 0);

            double sumaNotas = 0;
            int aprobadas = 0;

            for (int i = 1; i <= NUM_ASIGNATURAS; i++)
            {
                Console.WriteLine("asignatura" + i);
                double nota = ValidarNota();
                sumaNotas += nota;
                if (nota >= NOTA_APROBACION)
                {
                    aprobadas++;

                }
            }


            double promedio = sumaNotas / NUM_ASIGNATURAS;
            double bono = CalculoBono(carnet);
            double PromedioFinal = promedio + bono;
            string estado;
            if (promedio >= NOTA_APROBACION)
            {
                estado = "APROBADO";
            }
            else
            {
                estado = "REPROBADO";
            }

            string clasificacion = TipoClasificacion(PromedioFinal);

            Console.WriteLine("        resultados        ");
            Console.WriteLine($"nombre estudiante: {nombre} {apellido}");
            Console.WriteLine($"carnet del estudiante: {carnet}");
            Console.WriteLine($"carrera del estudiante: {carrera}");
            Console.WriteLine($"paralelo del estudiante: {paralelo}");
            Console.WriteLine($"asignaturas aprobadas: {aprobadas}");
            Console.WriteLine($"promedio: {promedio}");
            Console.WriteLine($"estado academico del estudiante: {estado}");
            Console.WriteLine($"el bono del estudiante: {bono:F2}");
            Console.WriteLine($"el promedio final es: {PromedioFinal}");
            Console.WriteLine($"la clasificaion del estudiante es: {clasificacion}");



        }
        static double ValidarNota()

        {
            double nota;

            do
            {
                Console.Write("ingrese la nota (0-100): ");
                if (!double.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 100)
                {
                    Console.WriteLine("nota invalida: debe estar entre 0-100");
                    nota = -1;
                }
            } while (nota < 0 || nota > 100);
            return nota;

        }


        static double CalculoBono(string carnet)
        {
            string DosDigitos = carnet.Substring(carnet.Length - 2);
            int num = int.Parse(DosDigitos);
            double bono = num * 0.07;
            return bono;

        }

        static string TipoClasificacion(double PromedioFinal)
        {
            if (PromedioFinal >= 90)
            {
                return ("excelente");
            }
            else if (PromedioFinal >= 70)
            {
                return ("bueno");
            }
            else if (PromedioFinal >= 51)
            {
                return ("regular");
            }
            else
            {
                return ("observado");
            }
        }

    }

}