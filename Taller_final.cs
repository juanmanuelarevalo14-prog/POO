using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_POO_juan_arevalo
{
    internal class Program
    {
        public class Empleado
        {
            private string nombre;
            private int edad;
            protected decimal salarioBase;

            public Empleado(string nombre, int edad, decimal salarioBase)
            {
                this.nombre = nombre;
                this.edad = edad;
                this.salarioBase = salarioBase;
            }

            public string Nombre
            {
                get { return nombre; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("El nombre no debe estar vacío.");
                    nombre = value;
                }
            }

            public int Edad
            {
                get { return edad; }
                set
                {
                    if (value < 18 || value > 65)
                        throw new ArgumentException("Edad no válida para trabajar.");
                    edad = value;
                }
            }

            public virtual decimal CalcularSalario()
            {
                return salarioBase;
            }

            public virtual string MostrarInfo()
            {
                return $"Nombre: {nombre}, Edad: {edad}, Salario total: {CalcularSalario():N0}";
            }
        }

        public class Gerente : Empleado
        {
            private const decimal bonoGestion = 800000;

            public Gerente(string nombre, int edad, decimal salarioBase)
                : base(nombre, edad, salarioBase) { }

            public override decimal CalcularSalario()
            {
                return salarioBase + bonoGestion;
            }

            public override string MostrarInfo()
            {
                return base.MostrarInfo() + " | Rol: gerente";
            }
        }
      
        public class HabitacionHotel
        {
            private int numero;
            private string tipo;
            private decimal precioPorNoche;
            private bool estaOcupada;
            private string nombreHuesped;

            public HabitacionHotel(int numero, string tipo, decimal precioPorNoche, bool estaOcupada, string nombreHuesped = "")
            {
                Numero = numero;
                Tipo = tipo;
                PrecioPorNoche = precioPorNoche;
                EstaOcupada = estaOcupada;
                NombreHuesped = nombreHuesped;
            }

            public int Numero { get => numero; set => numero = value; }
            public string Tipo { get => tipo; set => tipo = value; }
            
            public decimal PrecioPorNoche 
            { 
                get => precioPorNoche; 
                set => precioPorNoche = value; 
            }

            public bool EstaOcupada { get => estaOcupada; set => estaOcupada = value; }
            public string NombreHuesped { get => nombreHuesped; set => nombreHuesped = value; }

            public void AplicarDescuento(int porcentaje)
            {
                if (porcentaje <= 0 || porcentaje > 100) return;

                decimal descuento = precioPorNoche * (porcentaje / 100m);
                decimal precioNuevo = precioPorNoche - descuento;

                if (precioNuevo <= 0)
                {
                    Console.WriteLine($"Aviso: El descuento dejaría la habitación {numero} en $0 o negativo. No aplicado.");
                }
                else
                {
                    precioPorNoche = precioNuevo;
                    Console.WriteLine($"Descuento aplicado a la habitación {numero}. Nuevo precio: ${precioPorNoche:N0}");
                }
            }
          
            public string ObtenerDatosResumen()
            {
                string estado = estaOcupada ? $"Ocupada por: {nombreHuesped}" : "Libre";
                return $"[{numero}] {tipo} - ${precioPorNoche:N0} - {estado}";
            }
        }

        public static void Main(string[] args)
        { 
            List<Empleado> empleados = new List<Empleado> {
                new Gerente("Juan Manuel Arévalo", 18, 4000000),
                new Gerente("Andres Ramirez", 23, 7000000)
            };

            Console.WriteLine("=== INFORMACIÓN DE EMPLEADOS ===");
            foreach (Empleado e in empleados)
            {
                Console.WriteLine(e.MostrarInfo());
            }

            List<HabitacionHotel> habitaciones = new List<HabitacionHotel>
            {
                new HabitacionHotel(101, "Individual", 50000, true, "Juana Pérez"),
                new HabitacionHotel(102, "Doble", 90000, false),
                new HabitacionHotel(103, "Suite", 150000, true, "Carlos Gómez")
            };

            Console.WriteLine("\n=== ESTADO DE LAS HABITACIONES ===");
            foreach (HabitacionHotel hab in habitaciones)
            {
                Console.WriteLine(hab.ObtenerDatosResumen());
            }

            habitaciones[1].AplicarDescuento(10);

            int libres = 0;
            int ocupadas = 0;
            decimal sumaPrecios = 0;

            foreach (HabitacionHotel hab in habitaciones)
            {
                if (hab.EstaOcupada)
                {
                    ocupadas++;
                }
                else
                {
                    libres++;
                }
                sumaPrecios += hab.PrecioPorNoche;
            }

            decimal precioPromedio = habitaciones.Count > 0 ? sumaPrecios / habitaciones.Count : 0;

            Console.WriteLine("\n=== MÉTRICAS FINALES DEL HOTEL ===");
            Console.WriteLine($"Habitaciones Libres: {libres}");
            Console.WriteLine($"Habitaciones Ocupadas: {ocupadas}");
            Console.WriteLine($"Precio Promedio: ${precioPromedio:N0}");
        }
    }
}
