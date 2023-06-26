namespace BarcosSimulacroSegundoParcial;
class Program
{
   static void Main(string[] args)
   {
      const string MSJE_INGRESO_FILAS = "Ingresar cantidad de filas: ";
      const string MSJE_INGRESO_COLUMNAS = "Ingresar cantidad de columnas: ";
      const string MSJE_ERROR_INGRESO_MATRIZ = "La cantidad minima es 1";
      const string MSJE_INGRESO_BARCOS = "Ingresar la cantidad de barcos:";
      const string MSJE_ERROR_INGRESO_BARCOS = "Cantidad no disponible:";
      const string MSJE_INGRESO_POSICION = "En que posicion esta el barco?";
      const string MSJE__ERROR_INGRESO_POSICION = "Numero Invalido";

      const int MIN_COLUMNAS = 2;
      const int MIN_FILAS = 2;
      const int MIN_BARCOS = 1;
      const int BARCO = 1;
      const int BARCO_HUNDIDO = -1;
      const int AGUA_TOCADA = 2;

      int filasMatriz = 2, columnasMatriz = 2, cantBarcos, numeroIntentos = 0;
      /*
      filasMatriz = IngresarInt(MSJE_INGRESO_FILAS, MSJE_ERROR_INGRESO_MATRIZ, MIN_FILAS);
      columnasMatriz = IngresarInt(MSJE_INGRESO_COLUMNAS, MSJE_ERROR_INGRESO_MATRIZ, MIN_COLUMNAS);
*/
      int[,] tablero = new int[filasMatriz, columnasMatriz];
      int[] posicionesSeleccionadasAntes = new int[tablero.Length];
      cantBarcos = IngresarInt(MSJE_INGRESO_BARCOS, MSJE_ERROR_INGRESO_BARCOS, MIN_BARCOS, tablero.Length);
      int posicionMaxima = tablero.GetLength(0) * 10 + tablero.GetLength(1);
      //      LlenarMatrizDefault(tablero);
      CargarBarcos(tablero, cantBarcos, BARCO);
      MostrarMatriz(tablero);

      while (NoHayMasBarcos(tablero))
      {
        MostrarMatrizJuego(tablero);
         IngresarPosicion(MSJE_INGRESO_POSICION, MSJE__ERROR_INGRESO_POSICION, 0, posicionMaxima, tablero, posicionesSeleccionadasAntes, BARCO_HUNDIDO, AGUA_TOCADA);

         numeroIntentos++;

      }
            MostrarMatriz(tablero);
MostrarMatrizJuego(tablero);
      Console.WriteLine($"intentos: {numeroIntentos}");
   }


   static void IngresarPosicion(string mensaje, string msjeError, int min, int max, int[,] matriz, int[] posicionesSeleccionadasAntes, int barcoHundido, int aguaTocada)
   {

   


      int maxValue = matriz.GetLength(0) * matriz.GetLength(1);


      int ingresarPosicion = IngresarInt(mensaje, msjeError, 0);
      //bool asd = ValorEnArray(ingresarPosicion, posicionesSeleccionadasAntes);

      int posiFila = GetFila(ingresarPosicion);
      int posiColumna = GetColumna(ingresarPosicion);
      //Console.WriteLine($"{posiFila},{posiColumna}");
      bool asd = posicionUsada(matriz, posiFila, posiColumna, barcoHundido, aguaTocada);
      MostrarMatriz(matriz);
      while (asd)
      {

         //Console.WriteLine($"{posiFila},{posiColumna}, {asd}");

         Console.WriteLine("Ya tocaste este lugar");
         ingresarPosicion = IngresarInt(mensaje, msjeError, 0);
         posiFila = GetFila(ingresarPosicion);
         posiColumna = GetColumna(ingresarPosicion);
         asd = posicionUsada(matriz, posiFila, posiColumna, barcoHundido, aguaTocada);

      }


      AsignarAsiento(matriz, posiFila, posiColumna, barcoHundido, aguaTocada);
      /*      Console.WriteLine("Sale while");
            ValorPosicionMatriz(matriz, posiFila, posiColumna);*/
   }
   static bool posicionUsada(int[,] matriz, int posiFila, int posiColumna, int barcoHundido, int aguaTocada)
   {
      int posMatriz = matriz[posiFila, posiColumna];
      if (posMatriz == barcoHundido || posMatriz == aguaTocada)
      {
         Console.WriteLine($"posiusada: {posMatriz},{barcoHundido},{aguaTocada}");
         return true;
      }
      else
      {
         return false;
      }



   }
   static void AsignarAsiento(int[,] matriz, int posiFila, int posiColumna, int barcoHundido, int aguaTocada)
   {
      switch (matriz[posiFila, posiColumna])
      {
         case 0:
            matriz[posiFila, posiColumna] = aguaTocada;
            break;
         case 1:
            matriz[posiFila, posiColumna] = barcoHundido;
            break;
         default:
            Console.WriteLine($"ERROR SWICH {matriz[posiFila, posiColumna]}");
            break;
      }

      //  matriz[posiFila, posiColumna] = dni;
   }
   static bool ValorEnArray(int valor, int[] array)
   {
      Console.WriteLine(valor);
      foreach (int elem in array)
      {
         Console.Write($" {elem}");
      }
      return array.Contains(valor);
   }
   static bool NoHayMasBarcos(int[,] matriz)
   {
      bool hayBarcos = false;
      for (int i = 0; i < matriz.GetLength(0); i++)
      {

         for (int j = 0; j < matriz.GetLength(1); j++)
         {
            if (matriz[i, j] == 1)
            {
               hayBarcos = true;
            }
         }
      }
      return hayBarcos;

   }
   static void CargarBarcos(int[,] tablero, int cantBarcos, int barco)
   {
      Random rnd = new Random();
      int i = 0, fila, columna;

      while (i < cantBarcos)
      {
         fila = rnd.Next(tablero.GetLength(0));
         columna = rnd.Next(tablero.GetLength(1));
         if (!TieneBarco(tablero, fila, columna, barco))
         {
            tablero[fila, columna] = barco;
            i++;
         }
      }
   }
   static int IngresarInt(string msje, string msjeError, int min = int.MinValue, int max = int.MaxValue)
   {

      //Console.WriteLine($"int {min},{max}");
      Console.WriteLine(msje);
      int numero = int.Parse(Console.ReadLine());

      while (numero < min || numero > max)
      {
         Console.WriteLine(msjeError);
         numero = int.Parse(Console.ReadLine());
      }
      return numero;
   }
   static int[,] LlenarMatrizDefault(int[,] matriz)
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

   static void MostrarMatrizJuego(int[,] matriz)
   {
      for (int i = 0; i < matriz.GetLength(0); i++)
      {
         Console.Write($"Fila {i + 1} ->   ");
         for (int j = 0; j < matriz.GetLength(1); j++)
         {
            switch (matriz[i, j])
            {
               case 0:
                  Console.Write($"pos {i},{j}:  - ");
                                    Console.Write($" dato {matriz[i, j]}");

                  break;
               case 1:
                  Console.Write($"pos {i},{j}: - ");
                                                      Console.Write($" dato {matriz[i, j]}");

                  break;
               case (-1):
                  Console.Write($"pos {i},{j}: Q ");
                                                      Console.Write($" dato {matriz[i, j]}");

                  break;

               case (2):
                  Console.Write($"pos {i},{j}: A ");
                                                      Console.Write($" dato {matriz[i, j]}");

                  break;
               default:
                                 Console.Write($"pos {i},{j}: error");

                  Console.WriteLine($"pos {i},{j}: {matriz[i, j]}");
                  break;

            }


         }
         Console.WriteLine("");
      }

   }
   static void MostrarMatriz(int[,] matriz)
   {
      for (int i = 0; i < matriz.GetLength(0); i++)
      {
         Console.Write($"Fila {i + 1} ->   ");
         for (int j = 0; j < matriz.GetLength(1); j++)
         {
            Console.Write($"pos {i},{j}: {matriz[i, j]}");
            Console.Write("   ");

         }
         Console.WriteLine("");
      }

   }
   static int ValorPosicionMatriz(int[,] tablero, int fila, int columna)
   {
      return tablero[fila, columna];
   }
   static bool TieneBarco(int[,] tablero, int fila, int columna, int barco)
   {
      return tablero[fila, columna] == barco;
   }
   static int GetFila(int numero)
   {

      return numero / 10;
   }
   static int GetColumna(int numero)
   {
      return numero % 10;
   }
}


/*
 static void IngresarPosicion(string mensaje, string msjeError, int min, int max, int[,] matriz, int[] posicionesSeleccionadasAntes)
   {

      int posicionTablero, fila, columna, i = 0;
      bool datoIngresado = false;

      posicionTablero = IngresarInt(mensaje, msjeError, min, max);
      fila = GetFila(posicionTablero);
      columna = GetColumna(posicionTablero);
        bool asd = ValorEnArray(posicionTablero, posicionesSeleccionadasAntes);
      while (asd)
      {
            ValorPosicionMatriz(matriz, fila, columna);
         Console.WriteLine("Ya habias seleccionado esta posicion");
         posicionTablero = IngresarInt(mensaje, msjeError, min, max);
         fila = GetFila(posicionTablero);
         columna = GetColumna(posicionTablero);
         asd = ValorEnArray(posicionTablero, posicionesSeleccionadasAntes);
      }
*/