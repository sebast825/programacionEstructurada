namespace dParcial;
class Program
{
   static void Main(string[] args)
   {
       string MSJ_INGRESO_CANTIDAD_SANGUCHE = "Cuantos sanguches {0} se compraron: ";
      const string MSJ_INGRESO_ERROR_CANTIDAD_SANGUCHE = "La cantidad minima es 1 ";
      const int MIN_SANGUCHES = 1;
      const int FILAS_MATRIZ = 4;
      const int COLUMNAS_MATRIZ = 3;
      
      int[,] matrizSanguches = new int[FILAS_MATRIZ, COLUMNAS_MATRIZ];
      string[] sanguchegusto = new string[] { "Jamon-Queso", "Aceituna", "Salame", "Atun" };
      string[] sangucheVariedad = new string[] { "Simple", "Doble", "Triple" };


      for (int i = 0; i < matrizSanguches.GetLength(0); i++)
      {
       Console.Write("Ventas de Sandwiches de ");
            Console.WriteLine(sanguchegusto[i]);
         for (int j = 0; j < matrizSanguches.GetLength(1); j++)
         {
            string mensaje = string.Format(MSJ_INGRESO_CANTIDAD_SANGUCHE,sangucheVariedad[j]);
            matrizSanguches[i,j] = IngresarInt(mensaje,MSJ_INGRESO_ERROR_CANTIDAD_SANGUCHE,MIN_SANGUCHES);
         }
         MostrarMatriz(matrizSanguches,sanguchegusto,sangucheVariedad);

      }
MostrarMatriz(matrizSanguches,sanguchegusto,sangucheVariedad);

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

      static void MostrarMatriz(int[,] matriz, string [] sanguchegusto, string [] sangucheVariedad)
   {
      Console.Write("             ");
    foreach(string variedad in sangucheVariedad){
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