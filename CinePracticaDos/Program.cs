namespace CinePracticaDos;
class Program
{
   static void Main(string[] args)
   {
      const string MSJE_INGRESO_DNI = "Ingresar DNI: ";
      const string MSJE_ERROR_INGRESO_DNI = "DNI invalido, ingresar nuevamente: ";
      const string MSJE_INGRESO_ENTRADAS = "Cuantas entradas queres llevar? ";
      const string MSJE_ERROR_INGRESO_ENTRADAS = "Numero no valido, intente nuevamente: ";
      const string MSJE_METODO_ASIENTOS = "Seleccionar metodo para elegir asientos:";
      const string MSJE_ERROR_METODO_ASIENTOS = "Metodo invalido:";

      const string MSJE_INGRESO_MANUAL = "Ingresar la posicion de sala: ";
      const string MSJE_ERROR_INGRESO_MANUAL = "Posicion no valida: ";
      const int CANT_FILAS = 5;
      const int CANT_COLUMNAS = 6;
      const int DNI_MIN = 100;
      const int DNI_MAX = 999;
      const int MAX_ENTRADAS = 6;
      const int MIN_ENTRADAS = 1;
      const char METODO_MANUAL = 'M';
      const char METODO_AUTOMATICO = 'A';
      char metodoAsientos;
      int[] dniIngresado = new int[MAX_ENTRADAS];
      int cantEntradas = 0;
      int[,] sala = new int[CANT_FILAS, CANT_COLUMNAS];
      int posicionAsientoActual;
      bool cargaExitosa = false;

      Console.WriteLine("Hello, World!");
      //dniIngresado = IngresarInt(MSJE_INGRESO_DNI, MSJE_ERROR_INGRESO_DNI, DNI_MIN, DNI_MAX);
      int num = 45;
      /*
            Console.WriteLine(AsientosDisponibles(sala));

             cargaExitosa = CargarDniManual(sala, NumFila(num), NumColumna(num), 100);
            MostrarMatriz(sala);
            Console.WriteLine(AsientosDisponibles(sala));
          bool asd =  CargarDniManual(sala, NumFila(num), NumColumna(num), 100);
          */
      cantEntradas = IngresarInt(MSJE_INGRESO_ENTRADAS, MSJE_ERROR_INGRESO_ENTRADAS, MIN_ENTRADAS, MAX_ENTRADAS);

      for (int i = 0; i < cantEntradas; i++)
      {
         dniIngresado[i] = IngresarInt(MSJE_INGRESO_DNI, MSJE_ERROR_INGRESO_DNI, DNI_MIN, DNI_MAX);
      }
      metodoAsientos = IngresarChar(MSJE_METODO_ASIENTOS, MSJE_ERROR_METODO_ASIENTOS, METODO_MANUAL, METODO_AUTOMATICO);
      if (metodoAsientos == METODO_MANUAL)
      {
         for (int i = 0; i < cantEntradas; i++)
         {
            posicionAsientoActual = IngresarInt(MSJE_INGRESO_MANUAL, MSJE_ERROR_INGRESO_MANUAL, 0, 45);
            cargaExitosa = IsPosicionLibre(sala, NumFila(posicionAsientoActual), NumColumna(posicionAsientoActual));

            while (!cargaExitosa)
            {
               Console.WriteLine("Posicion no valida, intente nuevamente: ");
               posicionAsientoActual = IngresarInt(MSJE_INGRESO_MANUAL, MSJE_ERROR_INGRESO_MANUAL, 0, 45);

               cargaExitosa = IsPosicionLibre(sala, NumFila(posicionAsientoActual), NumColumna(posicionAsientoActual));
            }
            CargarDniManual(sala, NumFila(posicionAsientoActual), NumColumna(posicionAsientoActual), dniIngresado[i]);

            cargaExitosa = false;
         }
      }
      else if (metodoAsientos == METODO_AUTOMATICO)
      {
         Console.WriteLine("automatico");
      }
      else
      {
         Console.WriteLine("error metodo asignacion asientos");
      }
      /*  foreach (int elem in dniIngresado)
        {
           Console.WriteLine(elem);
        }
  */

      MostrarMatriz(sala);

   }


   static bool IsPosicionLibre(int[,] array, int posFila, int posColumna)
   {
      return array[posFila, posColumna] == 0 ? true : false;

   }
   static void CargarDniManual(int[,] array, int posFila, int posColumna, int dni)
   {

      array[posFila, posColumna] = dni;

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

      Console.Write(msje);
      int numero = int.Parse(Console.ReadLine());

      while (numero < min || numero > max)
      {
         Console.Write(msjeError);
         numero = int.Parse(Console.ReadLine());
      }
      return numero;
   }

   static int AsientosDisponibles(int[,] matriz)
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

         }
      }
      return contador;
   }

   static void MostrarMatriz(int[,] matriz)
   {
      Console.Write("             ");

      Console.WriteLine("        ");

      for (int i = 0; i < matriz.GetLength(0); i++)
      {
         for (int j = 0; j < matriz.GetLength(1); j++)
         {
            Console.Write($"     {matriz[i, j]}");
            Console.Write("   ");

         }
         Console.WriteLine("");
      }

   }

   static int NumFila(int numero)
   {
      return numero / 10;
   }
   static int NumColumna(int numero)
   {
      return numero % 10;
   }

}
