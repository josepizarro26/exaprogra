using System;

class examendeprogra

{
    // Constantes
    const int MAX_VEHICULOS = 15;
    const int NUMERO_CASETAS = 3;
    const double PRECIO_MOTO = 500;
    const double PRECIO_VEHICULO_LIVIANO = 700;
    const double PRECIO_CAMION_PESADO = 2700;
    const double PRECIO_AUTOBUS = 3700;

    // Vectores para almacenar los datos
    static int[] numeroFactura = new int[MAX_VEHICULOS];
    static string[] numeroPlaca = new string[MAX_VEHICULOS];
    static string[] fecha = new string[MAX_VEHICULOS];
    static string[] hora = new string[MAX_VEHICULOS];
    static int[] tipoVehiculo = new int[MAX_VEHICULOS];
    static int[] numeroCaseta = new int[MAX_VEHICULOS];
    static double[] montoPagar = new double[MAX_VEHICULOS];
    static double[] pagaCon = new double[MAX_VEHICULOS];
    static double[] vuelto = new double[MAX_VEHICULOS];
    static int cantidadVehiculos = 0;

    // Función principal
    static void Main(string[] args)
    {
        int opcion;

        do
        {
            Console.WriteLine("Menú Principal del Sistema:");
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Ingresar Paso Vehicular");
            Console.WriteLine("3. Consulta de vehículos x Número de Placa");
            Console.WriteLine("4. Modificar Datos Vehículos x número de Placa");
            Console.WriteLine("5. Reporte Todos los Datos de los vectores");
            Console.WriteLine("6. Salir");

            Console.WriteLine("Seleccione una opción:");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    InicializarVectores();
                    break;
                case 2:
                    IngresarPasoVehicular();
                    break;
                case 3:
                    ConsultarPorNumeroPlaca();
                    break;
                case 4:
                    ModificarDatosPorNumeroPlaca();
                    break;
                case 5:
                    ReportarTodosLosDatos();
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }

        } while (opcion != 6);
    }

    static void InicializarVectores()
    {
        for (int i = 0; i < MAX_VEHICULOS; i++)
        {
            numeroFactura[i] = 0;
            numeroPlaca[i] = " ";
            fecha[i] = " ";
            hora[i] = " ";
            tipoVehiculo[i] = 0;
            numeroCaseta[i] = 0;
            montoPagar[i] = 0;
            pagaCon[i] = 0;
            vuelto[i] = 0;
        }
        cantidadVehiculos = 0;
        Console.WriteLine("Vectores inicializados.");
    }

    static void IngresarPasoVehicular()
    {
        if (cantidadVehiculos >= MAX_VEHICULOS)
        {
            Console.WriteLine("No se pueden ingresar más vehículos. Límite alcanzado.");
            return;
        }

        Console.WriteLine("REGISTRAR FLUJO VEHICULAR");

        Console.Write("Número de Factura: ");
        numeroFactura[cantidadVehiculos] = int.Parse(Console.ReadLine());

        Console.Write("Número de Placa: ");
        numeroPlaca[cantidadVehiculos] = Console.ReadLine();

        Console.Write("Fecha: ");
        fecha[cantidadVehiculos] = Console.ReadLine();

        Console.Write("Hora: ");
        hora[cantidadVehiculos] = Console.ReadLine();

        Console.WriteLine("Tipo de vehículo (1= Moto, 2= Vehículo Liviano, 3= Camión o Pesado, 4= Autobús): ");
        tipoVehiculo[cantidadVehiculos] = int.Parse(Console.ReadLine());

        while (tipoVehiculo[cantidadVehiculos] < 1 || tipoVehiculo[cantidadVehiculos] > 4)
        {
            Console.WriteLine("Tipo de vehículo inválido. Inténtelo de nuevo.");
            Console.WriteLine("Tipo de vehículo (1= Moto, 2= Vehículo Liviano, 3= Camión o Pesado, 4= Autobús): ");
            tipoVehiculo[cantidadVehiculos] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Número de caseta (1, 2, 3): ");
        numeroCaseta[cantidadVehiculos] = int.Parse(Console.ReadLine());

        while (numeroCaseta[cantidadVehiculos] < 1 || numeroCaseta[cantidadVehiculos] > NUMERO_CASETAS)
        {
            Console.WriteLine("Número de caseta inválido. Inténtelo de nuevo.");
            Console.WriteLine("Número de caseta (1, 2, 3): ");
            numeroCaseta[cantidadVehiculos] = int.Parse(Console.ReadLine());
        }

        // Calcular monto a pagar
        switch (tipoVehiculo[cantidadVehiculos])
        {
            case 1:
                montoPagar[cantidadVehiculos] = PRECIO_MOTO;
                break;
            case 2:
                montoPagar[cantidadVehiculos] = PRECIO_VEHICULO_LIVIANO;
                break;
            case 3:
                montoPagar[cantidadVehiculos] = PRECIO_CAMION_PESADO;
                break;
            case 4:
                montoPagar[cantidadVehiculos] = PRECIO_AUTOBUS;
                break;
        }

        Console.WriteLine("Monto a pagar: {0}", montoPagar[cantidadVehiculos]);

        Console.Write("Paga con: ");
        pagaCon[cantidadVehiculos] = double.Parse(Console.ReadLine());

        vuelto[cantidadVehiculos] = pagaCon[cantidadVehiculos] - montoPagar[cantidadVehiculos];

        Console.WriteLine("Vuelto: {0}", vuelto[cantidadVehiculos]);

        cantidadVehiculos++;
    }

    static void ConsultarPorNumeroPlaca()
    {
        Console.Write("Ingrese el número de placa a consultar: ");
        string placa = Console.ReadLine();

        bool encontrado = false;
        for (int i = 0; i < cantidadVehiculos; i++)
        {
            if (numeroPlaca[i] == placa)
            {
                Console.WriteLine("Número de Factura: {0}", numeroFactura[i]);
                Console.WriteLine("Número de Placa: {0}", numeroPlaca[i]);
                Console.WriteLine("Fecha: {0}", fecha[i]);
                Console.WriteLine("Hora: {0}", hora[i]);
                Console.WriteLine("Tipo de vehículo: {0}", tipoVehiculo[i]);
                Console.WriteLine("Número de caseta: {0}", numeroCaseta[i]);
                Console.WriteLine("Monto a pagar: {0}", montoPagar[i]);
                Console.WriteLine("Paga con: {0}", pagaCon[i]);
                Console.WriteLine("Vuelto: {0}", vuelto[i]);
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron vehículos con la placa ingresada.");
        }
    }

    static void ModificarDatosPorNumeroPlaca()
    {
        Console.Write("Ingrese el número de placa para modificar los datos: ");
        string placa = Console.ReadLine();

        bool encontrado = false;
        for (int i = 0; i < cantidadVehiculos; i++)
        {
            if (numeroPlaca[i] == placa)
            {
                Console.WriteLine("Datos del vehículo con la placa {0}:", placa);
                Console.WriteLine("1. Fecha");
                Console.WriteLine("2. Hora");
                Console.WriteLine("3. Tipo de vehículo");
                Console.WriteLine("4. Numero de caseta");
                Console.WriteLine("5. Paga con");
                Console.WriteLine("Seleccione el dato que desea modificar: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nueva fecha: ");
                        fecha[i] = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Nueva hora: ");
                        hora[i] = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Nuevo tipo de vehículo (1=Moto, 2=Vehículo Liviano, 3=Camión o Pesado, 4=Autobús): ");
                        tipoVehiculo[i] = int.Parse(Console.ReadLine());
                        break;
                    case 4:
                        Console.Write("Nuevo número de caseta (1, 2, 3): ");
                        numeroCaseta[i] = int.Parse(Console.ReadLine());
                        break;
                    case 5:
                        Console.Write("Nuevo paga con: ");
                        pagaCon[i] = double.Parse(Console.ReadLine());
                        vuelto[i] = pagaCon[i] - montoPagar[i];
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron vehículos con la placa ingresada.");
        }
    }

    static void ReportarTodosLosDatos()
    {
        Console.WriteLine("Título del Reporte");
        Console.WriteLine("N factura    Placa           tipo de vehículo          caseta        monto Pagar   paga con     vuelto");
        Console.WriteLine("=============================================================================");
        for (int i = 0; i < cantidadVehiculos; i++)
        {
            Console.WriteLine("{0,-12} {1,-15} {2,-20} {3,-12} {4,-14} {5,-12} {6,-10}",
                numeroFactura[i], numeroPlaca[i], tipoVehiculo[i], numeroCaseta[i], montoPagar[i], pagaCon[i], vuelto[i]);
        }
        Console.WriteLine("=============================================================================");
        Console.WriteLine("Cantidad de vehículos: {0} \t total: {1:C}", cantidadVehiculos, CalcularTotal());
        Console.WriteLine("=============================================================================");
    }

    static double CalcularTotal()
    {
        double total = 0;
        for (int i = 0; i < cantidadVehiculos; i++)
        {
            total += montoPagar[i];
        }
        return total;
    }
}