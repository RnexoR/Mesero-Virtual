using System;

namespace Proyecto_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            int dato;
            bool continuar = false;
            // Cliente
            Cliente objCliente = new Cliente(0, "", "");


            // INICIO DEL PROGRAMA 'MESERO VIRTUAL'
            do
            {
                // ELEGIR TIPO DE CLIENTE
                dato = objCliente.tipoCliente();


                // RUTA PARA CREAR PERFIL DE CLIENTE
                switch (dato)
                {
                    case 1: // cliente esporadico
                        objCliente.crearCliente("Ninguno");
                        objCliente.Descuento = 1;
                        Console.Clear();
                        continuar = true;
                        break;

                    case 2: // cliente regular
                        objCliente.crearCliente("9%");
                        objCliente.Descuento = 0.91;
                        Console.Clear();
                        continuar = true;
                        break;

                    case 3: // empleado como cliente
                        objCliente.crearCliente("", "15%");
                        objCliente.Descuento = 0.85;
                        Console.Clear();
                        continuar = true;
                        break;

                    case 4: // salir
                        Console.WriteLine();
                        Console.WriteLine("Esperamos verle pronto...");
                        Console.WriteLine("Presione [ENTER] para salir");
                        Console.ReadKey();
                        continuar = true;
                        break;

                    // -----
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Indique alguna de las opciones dadas...");
                        Console.WriteLine("Presione [ENTER] para volver");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            } while (!(continuar));


            // Pedido
            Menu objPedido = new Menu(0, "", "", 0, 0, 0);
            
            if (dato != 4)
            {
                do
                {
                    // MOSTRAR MENU Y HACER PEDIDO
                    dato = objPedido.hacerPedido();
                } while (dato != 5);


                // MOSTRAR FACTURA
                objPedido.mostrarFactura(objCliente.Factura, objPedido.Acumulador, objCliente.Descuento);
            }

        }
    }


    // CLASES PUBLICAS
    // ---


    // PERSONAS
    public class Persona
    {
        private string nombre;
        private int cedula;

        public int Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value.ToUpper(); }


        // Elegir Tipo de Cliente
        public int tipoCliente()
        {
            Console.WriteLine();
            Console.WriteLine(" -- Bienvenid@ a Mc Donalds --");
            Console.WriteLine(" Se encuentra en la Interfaz de Mesero Virtual");
            Console.WriteLine();
            Console.WriteLine(" Indique Quien Esta Realizando la Compra");
            Console.WriteLine();
            Console.WriteLine(" 1) Cliente Esporadico");
            Console.WriteLine(" 2) Cliente Regular");
            Console.WriteLine(" 3) Empleado Fuera de Turno");
            Console.WriteLine(" 4) Salir");
            Console.WriteLine("____________________________");
            Console.WriteLine("Elija una sola opcion: ");
            int d = int.Parse(Console.ReadLine());
            Console.Clear();

            return d;
        }
    }


    // CLIENTES
    public class Cliente : Persona
    {
        private double descuento;
        private string desc;
        private string factura;
        
        public Cliente(double descuento, string desc, string factura)
        {
            this.Descuento = descuento;
            this.Desc = desc;
            this.Factura = factura;
        }

        public double Descuento { get => descuento; set => descuento = value; }
        public string Desc { get => desc; set => desc = value; }
        public string Factura { get => factura; set => factura = value; }


        // Crear Cliente Esporadico o Regular
        public string crearCliente(string Desc)
        {
            Console.WriteLine();
            Console.WriteLine(" Indique su nombre: ");
            Nombre = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine(" Indique su cedula: (solo numeros)");
            Cedula = int.Parse(Console.ReadLine());

            Factura = " Nombre: " + Nombre + "\n Cedula: " + Cedula + "\n Descuento: " + Desc;
            return Factura;
        }


        // Crear Empleado como Cliente
        public string crearCliente(string Id, string Desc)
        {
            Console.WriteLine();
            Console.WriteLine(" Indique su nombre: ");
            Nombre = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(" Indique su cedula: (solo numeros)");
            Cedula = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine(" Indique su ID de empleado: ");
            Id = Console.ReadLine();

            Factura = " Nombre: "+ Nombre + "\n Cedula: "+ Cedula +"\n ID de Empleado: "+ Id
                +"\n Descuento: "+ Desc;
            return Factura;
        }
    }


    public class Menu : Cliente
    {
        private int cantidad;
        private int monto;
        private int acumulador = 0;

        public Menu(double descuento, string desc, string factura,
            int cantidad, int monto, int acumulador) 
            : base(descuento, desc, factura)
        {
            this.cantidad = cantidad;
            this.Monto = monto;
            this.Acumulador = acumulador;
        }

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Monto { get => monto; set => monto = value; }
        public int Acumulador { get => acumulador; set => acumulador = value; }


        // Mostrar Menu
        public int hacerPedido()
        {
            Console.WriteLine();
            Console.WriteLine(" -- MENU de MC Donalds --");
            Console.WriteLine();
            Console.WriteLine(" 1) Papas Fritas");
            Console.WriteLine(" 2) Helado Sundae");
            Console.WriteLine(" 3) Hamburguesa Mc Doble");
            Console.WriteLine(" 4) Cajita Feliz");
            Console.WriteLine(" 5) Terminar Pedido");
            Console.WriteLine("____________________________");
            Console.WriteLine(" Elija una sola opcion: ");
            Console.WriteLine(" Actualmente lleva ${0}, descuento aun no aplicado", Acumulador);
            Monto = int.Parse(Console.ReadLine());

            if (Monto > 5)
            {
                Console.WriteLine();
                Console.WriteLine("Indique alguna de las opciones dadas...");
                Console.WriteLine("Presione [ENTER] para volver");
                Console.ReadKey();
            }
            
            if (Monto < 5)
            {
                Console.WriteLine();
                Console.WriteLine("Indique la cantidad que desea: ");
                Cantidad = int.Parse(Console.ReadLine());
                Acumulador = Acumulador + (Monto * Cantidad);
            }
            

            Console.Clear();
            return Monto;
        }


        // Mostrar Factura
        public void mostrarFactura(string cFactura, int pAcumulador, double cDescuento)
        {
            Console.WriteLine();
            Console.WriteLine(" -- FACTURA --");
            Console.WriteLine();
            Console.WriteLine(cFactura);
            Console.WriteLine(" Monto de Pedido: $" + pAcumulador);
            Console.WriteLine("\n Total a Pagar: $" + pAcumulador * cDescuento);
            Console.WriteLine();
            Console.WriteLine(" Esperamos Verle Pronto!");
            Console.WriteLine();
            Console.WriteLine(" Presione [ENTER] para Terminar");
            Console.ReadKey();
        }
    }
}
