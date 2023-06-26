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
      int[] dniPorEntrada = new int[CANT_ENTRADAS_MAX];
      int[] posicionPorEntrada = new int[CANT_ENTRADAS_MAX];
      int[] codigoReserva = new int[TOTAL_ENTRADAS];
      int[,] sala = new int[CANTIDAD_FILAS, CANTIDAD_COLUMNAS];
      int cantEntradas=0,cantVentas=0;
      char metodoAsignarAsientos;
      const char METODO_AUTOMATICO = 'A', METODO_MANUAL = 'M';
      string msjeIngresoMetodo = string.Format("Elegir meotod de asignacion de entradas Automatico: {0}, Manual: {1}",
       METODO_AUTOMATICO, METODO_MANUAL);
      string msjeIngresoMetodoError = string.Format("Metodo invalido, podes elegir Automatico: {0}, Manual: {1}",
      METODO_AUTOMATICO, METODO_MANUAL);
      string msjeIngresoPosicionErrorValidez = string.Format("Asiento ingresado invalido");

      sala = LlenarSalaDefault(sala);




   


      while (HayEntradas(sala, 1))
      {
         cantEntradas = IngresarInt(MSJE_INGRESO_ENTRADAS, MSJE_INGRESO_ENTRADAS_ERROR, CANT_ENTRADAS_MIN, CANT_ENTRADAS_MAX);
         while(!HayEntradas(sala, cantEntradas)){
            Console.WriteLine("No hay suficientes entradas disponibles");
            cantEntradas = IngresarInt(MSJE_INGRESO_ENTRADAS, MSJE_INGRESO_ENTRADAS_ERROR, CANT_ENTRADAS_MIN, CANT_ENTRADAS_MAX);

         }
         metodoAsignarAsientos = IngresarChar(msjeIngresoMetodo, msjeIngresoMetodoError, METODO_AUTOMATICO, METODO_MANUAL);
         IngresarDni(MSJE_INGRESO_DNI, MSJE_INGRESO_DNI_ERROR, dniPorEntrada, cantEntradas);

         if (metodoAsignarAsientos == METODO_MANUAL)
         {
            AsignarAsientoManual(cantEntradas, posicionPorEntrada, sala, MSJE_INGRESO_POSICION, msjeIngresoPosicionErrorValidez, dniPorEntrada);

         }
         else if (metodoAsignarAsientos == METODO_AUTOMATICO)
         {
            // GetFila(comenzarAsignar), GetColumna(comenzarAsignar)
            //asientos seguidosDisponibles

            AsientosSeguidosLibres(cantEntradas, sala, dniPorEntrada);
         }
         else
         {
            Console.WriteLine("ERROR IF ASIENTOS");
         }

         MostrarSala(sala);
      }


      precioPorVenta[cantVentas] = cantEntradas * PRECIO_ENTRADA;
      codigoReserva[cantVentas] = cantVentas;
      cantVentas++;
      Console.WriteLine("No hay mas entradas");

   }

   static void AsignarAsiento(int[,] matriz, int posiFila, int posiColumna, int dni)
   {
      matriz[posiFila, posiColumna] = dni;
   }
   static void AsignarAsientoManual(int cantEntradas, int[] posicionPorEntrada, int[,] sala, string mensaje, string msjeError, int[] dniPorEntrada)
   {
      int maxValue = sala.GetLength(0) * sala.GetLength(1);
      for (int i = 0; i < cantEntradas; i++)
      {
         MostrarSala(sala);

         int ingresarPosicionAsiento = IngresarInt(mensaje, msjeError, 0);
         int posiFila = GetFila(ingresarPosicionAsiento);
         int posiColumna = GetColumna(ingresarPosicionAsiento);
         Console.WriteLine($"{posiFila},{posiColumna}");
         while (!VerificarPosicionAsiento(posiFila, posiColumna, sala))
         {
            MostrarSala(sala);

            Console.WriteLine("Lugar ocupado");
            ingresarPosicionAsiento = IngresarInt(mensaje, msjeError, 0);
            posiFila = GetFila(ingresarPosicionAsiento);
            posiColumna = GetColumna(ingresarPosicionAsiento);
         }
         AsignarAsiento(sala, posiFila, posiColumna, dniPorEntrada[i]);
      }
   }


   static void IngresarDni(string mensaje, string msjeError, int[] dniPorEntrada, int cantEntradas)
   {

      for (int i = 0; i < cantEntradas; i++)
      {
         dniPorEntrada[i] = IngresarInt(mensaje, msjeError, 0, 999);

      }

   }
   static bool HayEntradas(int[,] matriz, int entradas)
   {
      bool hayEntradasDisponibles = false;
      int i = 0, j, contador = 0;
      while (i < matriz.GetLength(0) && !hayEntradasDisponibles)
      {
         j = 0;
         while (j < matriz.GetLength(1) && !hayEntradasDisponibles)
         {
            if (matriz[i, j] == 0)
            {
               contador++;
               if (entradas == contador)
               {
                  hayEntradasDisponibles = true;
               }
            }
            j++;
         }
         i++;
      }
      return hayEntradasDisponibles;
   }
   static void AsignarAsientosAutomatico(int cantEntradas, int[] dniPorEntrada, int[,] matriz, int posiFila = 0, int posiColumna = 0)
   {
      int contador = 0, i = posiFila, j = posiColumna;


      while (i < matriz.GetLength(0) && contador < cantEntradas)
      {
         while (j < matriz.GetLength(1) && contador < cantEntradas)
         {
            Console.WriteLine($"automatico {i},{j}");
            if (matriz[i, j] == 0)
            {
               matriz[i, j] = dniPorEntrada[contador];
               contador++;
            }
            j++;
         }
         j = 0;
         i++;

      }
   }
 

   static void  AsientosSeguidosLibres(int cantEntradas, int[,] matriz, int []dniPorEntrada)
   {
      int contador = 0, i = 0, j, fila = 0, columna = 0;


      while (i < matriz.GetLength(0) && contador < cantEntradas)
      {
         j = 0;
         while (j < matriz.GetLength(1) && contador < cantEntradas)
         {

            if (matriz[i, j] == 0)
            {
               fila = i;
               columna = j;
               contador++;

            }
            else
            {
               contador = 0;
            }
            j++;
         }
         i++;

      }
      Console.WriteLine($"libres: {fila}, {columna}");

      if(contador >= cantEntradas){
            AsignarAsientosAutomatico(cantEntradas, dniPorEntrada, matriz, fila, columna-1);

      }else{
            AsignarAsientosAutomatico(cantEntradas, dniPorEntrada, matriz, 0, 0);
            Console.WriteLine("No se pudieron asignar asientos juntos");
      }
    
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

      return numero / 10;
   }
   static int GetColumna(int numero)
   {
      return numero % 10;
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
            Console.Write($"Pos {i}{j}: {matriz[i, j]}");
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