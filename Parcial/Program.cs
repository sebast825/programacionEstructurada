namespace Parcial;
class Program
{
   static void Main(string[] args)
   {
      const string MSJ_INGRESAR_NOMBRE_CLIENTE = "Ingresar el nombre del cliente:";
      const string MSJ_CANTIDAD_HELADOS = "Cuantos helados querés comprar?";
      const string MSJ_ERROR_CANTIDAD_HELADOS = "La cantidad de helados debe ser entre 1 y 5";
      const string MSJ_TAMAÑO_VASO = "Ingresar el tamaño del vaso: chico (C), grande (G)";
      const string MSJ_ERROR_TAMAÑO_VASO = "Error, ingresar el tamaño del vaso: chico (C), grande (G)";
      const string MSJ_ELEGIR_GUSTO = "El gusto puede ser: {0}, {1}, {2}";
      const string MSJ_ERROR_ELEGIR_GUSTO = "Error, El gusto puede ser: {0}, {1}, {2}";
      const string MSJ_GUSTO_MENOS_VENDIDO = "El gusto menos vendido fue {0} con {1} venta/s";
      const string FIN_PROGRAMA = "CERRAR CAJA";
      const char VASO_CHICO = 'C';
      const char VASO_GRANDE = 'G';
      const string GUSTO_1 = "americana";
      const string GUSTO_2 = "sambayon";
      const string GUSTO_3 = "chocolate";
      char tamanioVaso;
      const int CANTIDAD_HELADOS_MIN = 1, CANTIDAD_HELADOS_MAX = 5;
      string nombreCliente = "", gustoElegido;
      int heladosPorVenta = 0, contadorVasoChico = 0, contadorVasoGrande = 0, contadorGustoUno = 0, contadorGustoDos = 0, contadorGustoTres = 0, contadorTotalVasoChico = 0, contadorTotalVasoGrande = 0, totalVenta = 0, totalRecudado = 0, precioVasoChico = 750, precioVasoGrande = 900, totalHeladosVendidos = 0;

      nombreCliente = IngresarString(MSJ_INGRESAR_NOMBRE_CLIENTE);

      while (nombreCliente != FIN_PROGRAMA)
      {

         heladosPorVenta = IngresarInt(MSJ_CANTIDAD_HELADOS, MSJ_ERROR_CANTIDAD_HELADOS, CANTIDAD_HELADOS_MIN, CANTIDAD_HELADOS_MAX);

         for (int i = 0; i < heladosPorVenta; i++)
         {
            //tamaño del vaso
            tamanioVaso = IngresarChar(MSJ_TAMAÑO_VASO, MSJ_ERROR_TAMAÑO_VASO, VASO_CHICO, VASO_GRANDE);


            switch (tamanioVaso)
            {
               case VASO_CHICO:
                  contadorVasoChico++;
                  break;
               case VASO_GRANDE:
                  contadorVasoGrande++;
                  break;
            }

            gustoElegido = ValidarString(MSJ_ELEGIR_GUSTO, MSJ_ERROR_ELEGIR_GUSTO, GUSTO_1, GUSTO_2, GUSTO_3);

            switch (gustoElegido)
            {
               case GUSTO_1:
                  contadorGustoUno++;
                  break;

               case GUSTO_2:
                  contadorGustoDos++;
                  break;
               case GUSTO_3:
                  contadorGustoTres++;
                  break;
            }

         }

         contadorTotalVasoChico += contadorVasoChico;
         contadorTotalVasoGrande += contadorVasoGrande;
         totalHeladosVendidos += heladosPorVenta;

         totalVenta = Multiplicar(contadorVasoChico, precioVasoChico) + Multiplicar(contadorVasoGrande, precioVasoGrande);
         Console.WriteLine($"El total de la venta fue de: {totalVenta}");
         totalRecudado += totalVenta;
         contadorVasoChico = 0;
         contadorVasoGrande = 0;
         totalVenta = 0;

         nombreCliente = IngresarString(MSJ_INGRESAR_NOMBRE_CLIENTE);

      }
      Console.WriteLine($"Se vendieron {totalHeladosVendidos} helados");
      ComaprarTresInt(MSJ_GUSTO_MENOS_VENDIDO, contadorGustoUno, contadorGustoDos, contadorGustoTres, GUSTO_1, GUSTO_2, GUSTO_3);
      Console.WriteLine($"El total recaudado fue de: {totalRecudado}");


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

   static char IngresarChar(string mensaje, string mje_error, char valor1, char valor2)
   {
      Console.WriteLine(mensaje);
      char value = char.ToUpper(char.Parse(Console.ReadLine()));

      while (value != valor1 && value != valor2)
      {
         Console.WriteLine(mje_error);
         value = char.ToUpper(char.Parse(Console.ReadLine()));
      }
      return value;
   }
   static string ValidarString(string mensaje, string mensajeError, string validacionUno, string validacionDos, string validacionTres)
   {
      string newMesaje = string.Format(mensaje, validacionUno, validacionDos, validacionTres);
      string newErrorMesaje = string.Format(mensajeError, validacionUno, validacionDos, validacionTres);
      string funcString = IngresarString(newMesaje).ToLower();
      while (funcString != validacionUno && funcString != validacionDos && funcString != validacionTres)
      {
         funcString = IngresarString(newErrorMesaje).ToLower();
      }
      return funcString;
   }

   static int Multiplicar(int valorUno, int valordDos)
   {
      int total = valorUno * valordDos;
      return total;
   }
   static void ComaprarTresInt(string mensaje, int num1, int num2, int num3, string variableUno, string variableDos, string variableTres)
   {

      if (num1 <= num2 && num1 <= num3)
      {
         Console.WriteLine(mensaje, variableUno, num1);
      }
      else if (num2 <= num1 && num2 <= num3)
      {
         Console.WriteLine(mensaje, variableDos, num2);
      }
      else
      {
         Console.WriteLine(mensaje, variableTres, num3);
      }
   }
}
