namespace CineSimulacroSegundoParcial;
class Program
{
   static void Main(string[] args)
   {
      const string MSJE_INGRESO_ENTRADAS = "Cuantas entradas queres comprar? Max 6";
      const string MSJE_INGRESO_DNI = "Ingresar DNI:";
      const string MSJE_INGRESO_DNI_ERROR = "El DNI ingresado es invalido, deben ser 3 numeros:";
      const string MSJE_INGRESO_POSICION = "Elegir posicion con 2 numeros consecutivos, fila y columna:";
      const string MSJE_INGRESO_POSICION_ERROR = "Posición no disponible, intentar nuevamente";

      const string MSJE_NUMERO_RESERVA = "El numero de reserva es: {0}";
      const string MSJE_IMPORTE = "Se debe abonar ${0} por las {1} entradas";
      const string MSJE_RECAUDACION = "El promedio recaudado es de {0} por venta";
      const string MSJE_MAX_RESERVA = "La reserva mas cara fue {0} por un total de {1}";

      const string MSJE_ERROR_VALIDAR_ASIENTO = "La posición esta ocupada, intente nuevamente: ";

      const int TOTAL_ENTRADAS = 30;
      const int CANT_ENTRADAS_MAX = 6;
      const int CANT_ENTRADAS_MIN = 1;
      const int CANTIDAD_FILAS = 5;
      const int CANTIDAD_COLUMNAS = 6;
      const double PRECIO_ENTRADA = 735;
      string MSJE_INGRESO_ENTRADAS_ERROR = string.Format(
"Maximo {0} entradas. La cantidad de entradas disponibles son: {1}", TOTAL_ENTRADAS, CANT_ENTRADAS_MIN);
      int entradasDisponibles = TOTAL_ENTRADAS, maxPosicionAsientos = 56;
      int[] entradasPorVenta = new int[TOTAL_ENTRADAS];
      double[] precioPorVenta = new double[TOTAL_ENTRADAS];
      int[] dniPorEntrada = new int[TOTAL_ENTRADAS];
      int[] posicionPorEntrada = new int[CANT_ENTRADAS_MAX];
      int[] codigoReserva = new int[TOTAL_ENTRADAS];
      int[,] sala = new int[CANTIDAD_FILAS, CANTIDAD_COLUMNAS];
      int cantEntradas, numeroAsiento;
      char metodoAsignarAsientos;
      const char METODO_AUTOMATICO = 'A', METODO_MANUAL = 'M';
      string msjeIngresoMetodo = string.Format("Elegir meotod de asignacion de entradas Automatico: {0}, Manual: {1}",
       METODO_AUTOMATICO, METODO_MANUAL);
      string msjeIngresoMetodoError = string.Format("Metodo invalido, podes elegir Automatico: {0}, Manual: {1}",
      METODO_AUTOMATICO, METODO_MANUAL);
      string msjeIngresoPosicionErrorValidez = string.Format("Debe ser un numero entre 1 y {0}", maxPosicionAsientos);

      sala = LlenarSalaDefault(sala);




      cantEntradas = IngresarInt(MSJE_INGRESO_ENTRADAS, MSJE_INGRESO_ENTRADAS_ERROR, CANT_ENTRADAS_MIN, CANT_ENTRADAS_MAX);
      //pedir numeros de DNI


      while (entradasDisponibles >= 0)
      {

         entradasDisponibles -= cantEntradas;
         for (int i = 0; i < cantEntradas; i++)
         {
            dniPorEntrada[i] = IngresarInt(MSJE_INGRESO_DNI, MSJE_INGRESO_DNI_ERROR, 0, 999);
         }
         metodoAsignarAsientos = IngresarChar(msjeIngresoMetodo, msjeIngresoMetodoError, METODO_AUTOMATICO, METODO_MANUAL);
         if (metodoAsignarAsientos == METODO_MANUAL)
         {

            //pedir numeros de asiento
            for (int i = 0; i < cantEntradas; i++)
            {
               int ingresarPosicionAsiento = IngresarInt(MSJE_INGRESO_POSICION, msjeIngresoPosicionErrorValidez, 11, maxPosicionAsientos);
               int posiFila = GetFila(ingresarPosicionAsiento);
               int posiColumna = GetColumna(ingresarPosicionAsiento);

               while (!VerificarPosicionAsiento(posiFila, posiColumna, sala) || HayValorEnArray(ingresarPosicionAsiento, posicionPorEntrada))
               {
                  MostrarSala(sala);
                  MostrarArray(posicionPorEntrada);

                  Console.WriteLine(MSJE_INGRESO_POSICION_ERROR);
                  ingresarPosicionAsiento = IngresarInt(MSJE_INGRESO_POSICION, msjeIngresoPosicionErrorValidez, 11, maxPosicionAsientos);
                  posiFila = GetFila(ingresarPosicionAsiento);
                  posiColumna = GetColumna(ingresarPosicionAsiento);
               }
               posicionPorEntrada[i] = ingresarPosicionAsiento;


               //sala[posiFila, posiColumna] = dniPorEntrada[i];
            }
            //ingresar en sala los dni
            for (int i = 0; i < cantEntradas; i++)
            {
               int asientoActual = posicionPorEntrada[i];
               int posiFila = GetFila(asientoActual);
               int posiColumna = GetColumna(asientoActual);
               sala[posiFila, posiColumna] = dniPorEntrada[i];

            }

         }
         else if (metodoAsignarAsientos == METODO_AUTOMATICO)
         {
            if (AsientosSeguidosLibres(cantEntradas, sala))
            {
               Console.WriteLine("Hay asientos disponibles seguidos");
               int comenzarAsignar = PosicionAsientosSeguidosLibres(cantEntradas, sala);
               sala = AsignarAsientosAutomatico(cantEntradas, dniPorEntrada, sala, GetFila(comenzarAsignar) + 1, GetColumna(comenzarAsignar) + 1);

            }
            else
            {
               Console.WriteLine("No hay asientos disponibles");
               sala = AsignarAsientosAutomatico(cantEntradas, dniPorEntrada, sala);


            }

         }
         else
         {
            Console.WriteLine("ERROR IF ASIGNAR ASIENTOS");
         }

         /*   foreach (int num in dniPorEntrada)
            {
               Console.Write(num);
            }

            foreach (int num in posicionPorEntrada)
            {
               Console.WriteLine(num);
            }
      */

         MostrarSala(sala);
         cantEntradas = IngresarInt(MSJE_INGRESO_ENTRADAS, MSJE_INGRESO_ENTRADAS_ERROR, CANT_ENTRADAS_MIN, CANT_ENTRADAS_MAX);

      }
      Console.WriteLine("No hay mas entradas");


   }



   static int[,] AsignarAsientosAutomatico(int cantEntradas, int[] dniPorEntrada, int[,] matriz, int posiFila = 0, int posiColumna = 0)
   {
      int contador = 0;


      for (int i = posiFila; i < matriz.GetLength(0); i++)
      {
         for (int j = posiColumna; j < matriz.GetLength(1); j++)
         {
            if (matriz[i, j] == 0)
            {
               matriz[i, j] = dniPorEntrada[contador];
               contador++;
            }
         }
      }
      MostrarSala(matriz);
      return matriz;
   }
   static int PosicionAsientosSeguidosLibres(int cantEntradas, int[,] matriz)
   {
      int contador = 0;
      int posicionComienzoAsignar = 0;
      for (int i = 0; i < matriz.GetLength(0); i++)
      {
         for (int j = 0; j < matriz.GetLength(1); j++)
         {

            if (matriz[i, j] == 0)
            {
               if (contador == 0)
               {
                  posicionComienzoAsignar = i * 10 + j;
               }
               contador++;

            }
            else
            {
               contador = 0;
            }
         }
      }
      return posicionComienzoAsignar;
   }
   /*
      static int AsignarAsientosSeguidosLibres (int cantEntradas, int[,] matriz){
           for (int i = 0; i < matriz.GetLength(0); i++)
         {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {

               if (matriz[i, j] == 0)
               {
                  contador++;

               }
               else
               {
                  contador = 0;
               }
            }
         }
         return matriz;
      }*/

   static bool AsientosSeguidosLibres(int cantEntradas, int[,] matriz)
   {
      int contador = 0;
      for (int i = 0; i < matriz.GetLength(0); i++)
      {
         for (int j = 0; j < matriz.GetLength(1); j++)
         {

            if (matriz[i, j] == 0)
            {
               contador++;

            }
            else
            {
               contador = 0;
            }
         }
      }
      return contador >= cantEntradas;
   }
   static bool HayValorEnArray(int numero, int[] array)
   {
      return array.Contains(numero);
   }
   static bool VerificarPosicionAsiento(int posiFila, int posiColumna, int[,] matriz)
   {
      bool asientoDisponible = false;
      int posicionMatriz = matriz[posiFila, posiColumna];
      asientoDisponible = posicionMatriz == 0 ? true : false;
      return asientoDisponible;
   }
   static int GetFila(int numero)
   {

      return numero / 10 - 1;
   }
   static int GetColumna(int numero)
   {
      return numero % 10 - 1;
   }
   static char IngresarChar(string msje, string msjeError, char opcionUno, char opcionDos)
   {
      Console.WriteLine(msje);
      char letra = char.Parse(Console.ReadLine());
      letra = char.ToUpper(letra);
      while (letra != opcionUno && letra != opcionDos)
      {
         Console.WriteLine(msjeError);
         letra = char.Parse(Console.ReadLine());
         letra = char.ToUpper(letra);
      }
      return letra;
   }
   static int IngresarInt(string msje, string msjeError, int min = int.MinValue, int max = int.MaxValue)
   {
      Console.WriteLine(msje);
      int numero = int.Parse(Console.ReadLine());

      while (numero < min || numero > max)
      {
         Console.WriteLine(msjeError);
         numero = int.Parse(Console.ReadLine());
      }
      return numero;
   }
   static int[,] LlenarSalaDefault(int[,] matriz)
   {

      for (int i = 0; i < matriz.GetLength(0); i++)
      {
         for (int j = 0; j < matriz.GetLength(1); j++)
         {
            matriz[i, j] = 0;

         }
      }

      return matriz;

   }
   static void MostrarArray(int[] matriz)
   {
      Console.WriteLine("Posiciones reservadas actualemte: ");

      for (int i = 0; i < matriz.GetLength(0); i++)
      {
         Console.Write($"   {matriz[i]}    ");

      }
      Console.WriteLine(" ");

   }
   static void MostrarSala(int[,] matriz)
   {
      for (int i = 0; i < matriz.GetLength(0); i++)
      {
         Console.Write($"Fila {i + 1} ->   ");
         for (int j = 0; j < matriz.GetLength(1); j++)
         {
            Console.Write(matriz[i, j]);
            Console.Write("   ");

         }
         Console.WriteLine("");
      }



   }
}


/*
        ingresar venta
            - ingresar cantidad de entradas a comprar
            - validar que haya espacio disponible
            - pedir dni por cada entrada (guardar en array)

            - elegir metodo automatico o manual
                - automaitoc -> otorgar primeras 6 lineas consecutivas
                                si no hay consecutivas avisar al usuario y asignar como se pueda
                - manual -> mostrar sala con posicion LIBRE o RESERVADO   
                            ingresar posicion
                            validar posicion
            - informar codigo de reserva
                - es numero consecutivo a la reserva anterior 
                - informar importe a abonar, entrada: 735

        al finalizar ventas
            - mostrar promedio de recaudacion por venta
            - mostrar codigo de reserva de la venta mas cara 
  */