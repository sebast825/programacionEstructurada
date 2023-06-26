namespace SimulacroParcialTres;
class Program
{
   static void Main(string[] args)
   {
      const string MSJ_INGRESAR_CANTIDAD_ESTANTES = "Ingresar la cantidad de estantes que hay en este momento";
      const string MSJ_ERROR_CANTIDAD_ESTANTES = "La cantidad de estantes debe ser mayor a 0";
      const string MSJ_NUMERO_ESTANTE = "La siguiente información es para el estante numero {0}";
      const string MSJ_INGRESAR_NOMBRE_LIBRO = "Ingresar el nombre del libro";
      const string MSJ_INGRESAR_GENERO_LIBRO = "Ingresar el genero del libro: Infantil: I, Novela: N, Historia: H ";
      const string MSJ_INGRESAR_PAGINAS_LIBRO = "Ingresar la cantidad de paginas del libro";
      const string MSJ_ERROR_PAGINAS_LIBRO = "El numero ingresado debe ser mayor a 0";
      const string MSJ_ERROR_GENERO_LIBRO = "El genero ingresado es incorrecto";
      const string FIN_NOMBRE_LIBRO = "ZZZ";
      const string MSJ_LIBRO_MAX_PAGINAS = "El libro {0} es el que tiene mas paginas, son {1}";
      const string MSJ_LIBROS_POR_GENERO = "Hay {0} libros Infantiles, {1} Novelas y {2} libros de Historia";
      const int MIN_PAGINAS_LIBRO = 0;

      const char GENERO_INFANTIL = 'I', GENERO_NOVELA = 'N', GENERO_HISTORIA = 'H';

      int cantidadEstantes = 0, cantidadEstantesMin = 1, cantidadPaginasLibro, cantidadPaginasLibroMax = 0,
      contadorInfantil = 0, contadorNovela = 0, contadorHistoria = 0;
      string nombreLibro = "", nombreLibroMaxPag = "";

      char genero;
      //ingresar la cantidad de estantes
      cantidadEstantes = IngresarInt(MSJ_INGRESAR_CANTIDAD_ESTANTES, MSJ_ERROR_CANTIDAD_ESTANTES, cantidadEstantesMin);

      // por cada estante ingresar nombre, genero, cant paginas libro
      for (int i = 1; i <= cantidadEstantes; i++)
      {
        Console.WriteLine(MSJ_NUMERO_ESTANTE,i);
         string asd = (MSJ_INGRESAR_NOMBRE_LIBRO);
         nombreLibro = IngresarString(asd);
         while (nombreLibro != FIN_NOMBRE_LIBRO)
         {
            genero = ingresarChar(MSJ_INGRESAR_GENERO_LIBRO, MSJ_ERROR_GENERO_LIBRO, GENERO_INFANTIL, GENERO_NOVELA, GENERO_HISTORIA);

            switch (genero)
            {
               case GENERO_INFANTIL:
                  contadorInfantil++;
                  break;
               case GENERO_NOVELA:
                  contadorNovela++;
                  break;
               case GENERO_HISTORIA:
                  contadorHistoria++;
                  break;
            }
            cantidadPaginasLibro = IngresarInt(MSJ_INGRESAR_PAGINAS_LIBRO, MSJ_ERROR_PAGINAS_LIBRO, MIN_PAGINAS_LIBRO);
            if (cantidadPaginasLibro >= cantidadPaginasLibroMax)
            {
               cantidadPaginasLibroMax = cantidadPaginasLibro;
               nombreLibroMaxPag = nombreLibro;
            }
            nombreLibro = IngresarString(MSJ_INGRESAR_NOMBRE_LIBRO);
            if (nombreLibro == FIN_NOMBRE_LIBRO)
            {
               Console.WriteLine(MSJ_LIBRO_MAX_PAGINAS, nombreLibroMaxPag, cantidadPaginasLibroMax);
               cantidadPaginasLibroMax = 0;
            }
         }
      }
      Console.WriteLine(MSJ_LIBROS_POR_GENERO, contadorInfantil, contadorNovela, contadorHistoria);

   }
   static string IngresarString(string mensaje)
   {
      Console.WriteLine(mensaje);
      return Console.ReadLine();
   }
   static int IngresarInt(string mensaje, string mje_error, int min = int.MinValue, int max = int.MaxValue)
   {
      Console.WriteLine(mensaje);
      int numeroIngresado = int.Parse(Console.ReadLine());

      while (numeroIngresado < min || numeroIngresado > max)
      {
         Console.WriteLine(mje_error);
         numeroIngresado = int.Parse(Console.ReadLine());
      }
      return numeroIngresado;
   }
   static char ingresarChar(string mensaje, string mje_error, char valor1, char valor2, char valor3)
   {
      Console.WriteLine(mensaje);
      char value = char.Parse(Console.ReadLine());

      while (value != valor1 && value != valor2 && value != valor3)
      {
         Console.WriteLine(mje_error);
         value = char.Parse(Console.ReadLine());
      }
      return value;
   }
}
