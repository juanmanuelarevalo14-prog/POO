    public class Program
    {
       
        public static void Main(string[] args)
        {
            Automovil miAuto = new Automovil();

            miAuto.Marca = "Mazda";
            miAuto.Anio = 2024;
            miAuto.Modelo = "XL";
            miAuto.Velocidadactual = 0;

            miAuto.MostrarInformacion();
        }

        public class Automovil

        {
            public string Marca;
            public string Modelo;
            public int Anio;
            public double Velocidadactual;


            public void Acelerar(double inc) { Velocidadactual += inc; }
            public void Frenar(double dec)
            {
                if (Velocidadactual - dec >= 0) Velocidadactual -= dec;
                else Velocidadactual = 0;
            }

            public void MostrarInformacion()
            {
                Console.WriteLine($"marca: {Marca}");
                Console.WriteLine($"modelo: {Modelo}");
                Console.WriteLine($"anio: {Anio}");
                Console.WriteLine($"velocidadactual: {Velocidadactual} Km/h");             } 

           }
    }
    
