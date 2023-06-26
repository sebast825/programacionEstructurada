namespace dParcial;
class Program
{
   static void Main(string[] args)
   {
      string MSJ_INGRESO_CANTIDAD_SANGUCHE = "Cuantos sanguches {0} se compraron: ";
      const string MSJ_INGRESO_ERROR_CANTIDAD_SANGUCHE = "La cantidad minima es 1 ";
      const string MSJE_INGRESO_GUSTO = "Ingrese el nombre del sandwich a consultar: ";
      const string MSJE_ERROR_INGRESO_GUSTO = "Nombre invalido, intente nuevamente:";

      const int MIN_SANGUCHES = 1;
      const int FILAS_MATRIZ = 4;
      const int COLUMNAS_MATRIZ = 3;

      int[,] matrizSanguches = new int[FILAS_MATRIZ, COLUMNAS_MATRIZ];
      string[] sanguchegusto = new string[] { "JAMON-QUESO", "ACEITUNA", "SALAME", "ATUN" };
      string[] sangucheVariedad = new string[] { "SIMPLE", "DOBLE", "TRIPLE" };
      int[] sangucheTotalGusto = new int[FILAS_MATRIZ];
      string consultarSanguche;
      int consultarIndice, totalSanguches, minVentas, minVentasIndice;





      //ingreso de datos
      for (int i = 0; i < matrizSanguches.GetLength(0); i++)
      {
         Console.Write("Ventas de Sandwiches de ");
         Console.WriteLine(sanguchegusto[i]);
         for (int j = 0; j < matrizSanguches.GetLength(1); j++)
         {
            string mensaje = string.Format(MSJ_INGRESO_CANTIDAD_SANGUCHE, sangucheVariedad[j]);
            matrizSanguches[i, j] = IngresarInt(mensaje, MSJ_INGRESO_ERROR_CANTIDAD_SANGUCHE, MIN_SANGUCHES);
         }
         MostrarMatriz(matrizSanguches, sanguchegusto, sangucheVariedad);
      }

      //hacer calculos
      SumarGustoSanguche(matrizSanguches, sangucheTotalGusto);
      MostrarMatriz(matrizSanguches, sanguchegusto, sangucheVariedad);

      for (int j = 0; j < sangucheTotalGusto.Length; j++)
      {
         Console.WriteLine($"{sanguchegusto[j]}: {sangucheTotalGusto[j]}");
      }
      
      consultarSanguche = IngresarString(MSJE_INGRESO_GUSTO);

      consultarIndice = IndexArray(consultarSanguche, sanguchegusto);
      while (consultarIndice == -1)
      {
         consultarSanguche = IngresarString(MSJE_ERROR_INGRESO_GUSTO);

         consultarIndice = IndexArray(consultarSanguche, sanguchegusto);
      }

      totalSanguches = SumarArray(sangucheTotalGusto);
      minVentas = MinValueArray(sangucheTotalGusto);

      minVentasIndice = IndexArray(minVentas, sangucheTotalGusto);

         //mostrar datos
      Console.WriteLine($"El total de sanguche de {sanguchegusto[consultarIndice]} fue: {sangucheTotalGusto[consultarIndice]}");
      Console.WriteLine($"El sanguche menos vendido fue {sanguchegusto[minVentasIndice]} con {minVentas} ventas");
      Console.WriteLine($"Se vendieron {totalSanguches} sanguches en total");
   }

   static int MinValueArray(int[] arreglo)
   {
      return arreglo.Min();
   }
   static int SumarArray(int[] arreglo)
   {
      int total = 0;
      for (int i = 0; i < arreglo.Length; i++)
      {
         total += arreglo[i];
      }
      return total;

   }

   static int IndexArray(int valor, int[] arrgelo)
   {
      return Array.IndexOf(arrgelo, valor);
   }
   static int IndexArray(string valor, string[] arrgelo)
   {
      return Array.IndexOf(arrgelo, valor);
   }
   static string IngresarString(string mensaje)
   {

      Console.WriteLine(mensaje);
      string input = Console.ReadLine();
      return input.ToUpper();
   }
   static void SumarGustoSanguche(int[,] matriz, int[] sangucheTotalGusto)
   {

      int total = 0;
      for (int i = 0; i < matriz.GetLength(0); i++)
      {
         for (int j = 0; j < matriz.GetLength(1); j++)
         {
            total += matriz[i, j];

         }
         sangucheTotalGusto[i] = total;
         total = 0;
      }

   }
   static int IngresarInt(string msje, string msjeError, int min = int.MinValue, int max = int.MaxValue)
   {

      Console.WriteLine(msje);
      int numero = int.Parse(Console.ReadLine());

      while (numero < min || numero >= max)
      {
         Console.WriteLine(msjeError);
         numero = int.Parse(Console.ReadLine());
      }
      return numero;
   }

   static void MostrarMatriz(int[,] matriz, string[] sanguchegusto, string[] sangucheVariedad)
   {
      Console.Write("             ");
      foreach (string variedad in sangucheVariedad)
      {
         Console.Write($"{variedad}   ");

      }
      Console.WriteLine("        ");

      for (int i = 0; i < matriz.GetLength(0); i++)
      {
         Console.Write($"{sanguchegusto[i]} ");
         for (int j = 0; j < matriz.GetLength(1); j++)
         {
            Console.Write($"     {matriz[i, j]}");
            Console.Write("   ");

         }
         Console.WriteLine("");
      }

   }
}

/*
    crear array con 4 gustos
    crear array para sumar el total de c/ gusto

    - ingresar cantidad de cada variedad

    - sumar el total de cada gusto
    - sandwich menos vendido
    - cantiad total de sandwiches vendidos



*/