// Sistemas de inventario de software
//una empreesa de desarrollo de software gestiona dos tipos de empleados
//con distinta escritura salarial:
//Dev: Salario base + bono variable por cada proyecto completo.
//Gerentes: Salario base + bono fijo por gestion directiva
//Objetivo: Calcular el salario total y mostrar la información consolidada utilizando Herencia y polimorfismo

using System;


public class HelloWorld {

    public class Empleado {
        private string nombre ;
        private int edad;
        protected decimal salarioBase;

        public Empleado(string nombre, int edad, decimal salarioBase){
            this.nombre = nombre;
            this.edad = edad;
            this.salarioBase = salarioBase;
        }

        public string nombre {
            get {return nombre;}
            set {
                if(string.IsNullOrwhiteSpace(value))
                    throw new ArgumentExecption("El nombre no debe estar vacio.");
                nombre = value;
    
            }
        }
        public int Edad {
            get{return edad;}
            set {
                if(value < 18 || value > 65)
                    throw new ArgumentExecption("Edad no valida para trabajar !!");
                edad = value;
            }
        }

        public virtual decimal CalcularSalario(){
            return salarioBase;
        }
        public virtual string MostrarInfo(){
            return $"Nombre: {nombre}, Edad: {edad}, Salario Total: {CalcularSalario():C}";
       }

    public class Gerente: Empleado {
        private const decimal BonoGestion = 800.000;

        public Gerente(string nombre, int edad, decimal salarioBase)
            : base(nombre, edad, salarioBase)
        {
        }
              

        public override decimal CalcularSalario(){
            return salarioBase + BonoGestion;
        }

        public override string MostrarInfo(){
            return base.MostarInfo() + "| Rol: Gerente";
        }
    }

    public static void Main(string[] args){
        List<Empleado> empleados = new List<Empleado> {
            new Gerente("Juan Arevalo", 18, 4000000)
        };
        foreach(Empleado e in empleados){
            Console.WriteLine(e.MostrarInfo());
        }
    }
}
}
