namespace practica3;
class Program
{
   static void Main(string[] args)
   {
      const string MSJE_INGRESAR_DNI = "Ingrese su DNI: ";
      const string MSJE_ERROR_DNI = "El DNI ingresado no es valido, intente nuevamente: ";
      const string MSJE_INGRESAR_YATE = "Ingrese el nombre del yate: ";
      const string MSJE_INGRESAR_YATE_ERROR = "No tenemos stock de ese yate, intente nuevamente: ";
      const string MSJE_INGRESAR_PAGO = "Ingresar Efectivo: E, Tarjeta: T:";
      const string MSJE_INGRESAR_PAGO_ERROR = "Metodo de pago invalido, intente nuevamente: ";
      const string MSJE_INGRESAR_EMPLEADO = "Ingresar el numero de empleado, entre 0 y 4: ";
      const string MSJE_INGRESAR_EMPLEADO_ERROR = "Numero incorrecto, ingresar el numero de empleado, entre 0 y 4: ";
      const int FIN_PROGRAMA = 22;
      const char EFECTIVO = 'E';
      const char TARJETA = 'T';
      string[] tipoYate = new string[] { "Megayate", "Catamaran", "Velero", "Grande", "Pequeño" };
      string[] nombreEmpleado = new string[] { "AGUS", "FER", "SAN", "RESS", "TESS" };
      int[] ventasEmplado = new int[] { 0, 0, 0, 0, 0 };

      int[] precioUnitarioYate = new int[] { 1000, 800, 500, 300, 100 };
      int[] stockYate = new int[] { 1, 2, 3, 4, 5 };
      int[] yateVendido = new int[] { 0, 0, 0, 0, 0 };


      int dni, numeroEmpleadoActual = 0, indiceYateActual, empleadoMaxVenta = 0, numeroEmpleadoMaxVenta;
      double totalVentas = 0, precioActual = 0, totalEfectivo = 0, totalTarjeta = 0, precioActualEfectivo, diferenciaPago;
      string nombreYateComprar, primeraLetraMayuscula;
      char metodoPago;

      dni = IngresarDni(MSJE_INGRESAR_DNI, MSJE_ERROR_DNI);

      while (dni != FIN_PROGRAMA)
      {
         nombreYateComprar = IngresarMensaje(MSJE_INGRESAR_YATE);
         primeraLetraMayuscula = CapitalizeString(nombreYateComprar);

         indiceYateActual = Array.IndexOf(tipoYate, primeraLetraMayuscula);
         
         while (indiceYateActual == -1 || stockYate[indiceYateActual] <= 0)
         {
            nombreYateComprar = IngresarMensaje(MSJE_INGRESAR_YATE_ERROR);
            primeraLetraMayuscula = CapitalizeString(nombreYateComprar);

            indiceYateActual = Array.IndexOf(tipoYate, primeraLetraMayuscula);
         }
stockYate[indiceYateActual]--;
         yateVendido[indiceYateActual]++;
         metodoPago = IngresarChar(MSJE_INGRESAR_PAGO, MSJE_INGRESAR_PAGO_ERROR, EFECTIVO, TARJETA);
         precioActual = precioUnitarioYate[indiceYateActual];

         numeroEmpleadoActual = IngresarInt(MSJE_INGRESAR_EMPLEADO, MSJE_INGRESAR_EMPLEADO_ERROR, 0, 4);
         ventasEmplado[numeroEmpleadoActual]++;
         /*precio yate*/
         if (metodoPago == EFECTIVO)
         {
            precioActualEfectivo = precioActual * .9;

            totalEfectivo += precioActualEfectivo;
            Console.WriteLine($"El cliente con DNI: {dni} deberá pagar {precioActualEfectivo}");

         }
         else
         {

            totalTarjeta += precioActual;
            Console.WriteLine($"El cliente con DNI: {dni} deberá pagar {precioActual}");

         }


         dni = IngresarDni(MSJE_INGRESAR_DNI, MSJE_ERROR_DNI);


      }
      totalVentas = totalEfectivo + totalTarjeta;

      for (int i = 0; i < tipoYate.Length; i++)
      {
         Console.WriteLine($"{tipoYate[i]}:  {yateVendido[i]} unidades");
      }



      //empleado con mayor ventas
      for (int i = 0; i < ventasEmplado.Length; i++)
      {
         if (ventasEmplado[i] > empleadoMaxVenta)
         {
            empleadoMaxVenta = i;
         }
      }
      numeroEmpleadoMaxVenta = Array.IndexOf(ventasEmplado, ventasEmplado[empleadoMaxVenta]);
      Console.WriteLine($"El empleado que mas vendio fue: {nombreEmpleado[numeroEmpleadoMaxVenta]}, con un total de {ventasEmplado[numeroEmpleadoMaxVenta]} venta/s");
      Console.WriteLine($"El total recaudado fue: " + totalVentas);

      if (totalEfectivo > totalTarjeta)
      {
         diferenciaPago = totalEfectivo - totalTarjeta;
         Console.WriteLine($"Se recaudo {diferenciaPago} mas en efectivo");
      }
      else if (totalEfectivo < totalTarjeta)
      {
         diferenciaPago = totalTarjeta - totalEfectivo;
         Console.WriteLine($"Se recaudo {diferenciaPago} mas en tarjeta");
      }
      else
      {
         Console.WriteLine("No hubo diferencia entre lo recaudado en tarjeta y efectivo");

      }

      /*
          vectores
              - tiposYates
              - precioUnitarioYate
              - stockYate
              - nombre empleados
              - yateVendido

              dni
              while 

                  nombreYateComprar
                  formaPage E/T
                  int ingresarInt (comparar con empleado)

                  por cada venta:
                      dni cliente, lo que debe pagar

                  dni proxima venta

              mostrar:
                  -  cantidad de yates vendidos por unidad
                  - empleado que mas vendio
                  - diferencia efectivo y tarjeta


      */

   }

   static string IngresarMensaje(string mensaje)
   {
      Console.WriteLine(mensaje);
      return Console.ReadLine();


   }

   static int IngresarDni(string mensaje, string error)
   {
      Console.WriteLine(mensaje);
      int msje = int.Parse(Console.ReadLine());

      while (msje.ToString().Length != 2)
      {
         Console.WriteLine(error);

         msje = int.Parse(Console.ReadLine());

      }
      return msje;
   }
   static int IngresarInt(string mensaje, string error, int min = int.MinValue, int max = int.MaxValue)
   {
      Console.WriteLine(mensaje);
      int msje = int.Parse(Console.ReadLine());

      while (msje.ToString().Length < min && msje.ToString().Length > max)
      {
         Console.WriteLine(error);

         msje = int.Parse(Console.ReadLine());

      }
      return msje;
   }
   static char IngresarChar(string mensaje, string error, char opcionUno, char opcionDos)
   {
      Console.WriteLine(mensaje);
      char msje = char.ToUpper(Console.ReadLine()[0]);

      while (msje != opcionUno && msje != opcionDos)
      {
         Console.WriteLine(error);

         msje = char.ToUpper(Console.ReadLine()[0]);
      }
      return msje;
   }

   static string CapitalizeString(string texto)
   {
      return char.ToUpper(texto[0]) + texto.Substring(1); ;
   }
   static double SumarFila(int[,] matriz, int fila)
   {
      double total = 0;
      for (int i = 0; i < matriz.GetLength(0); i++)
      {
         Console.WriteLine(matriz[fila, i]);
         total += matriz[fila, i];
      }
      return total;
   }
}
