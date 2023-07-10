﻿namespace FinalJulio23;
class Program
{
   static void Main(string[] args)
   {
      const string MJE_INGRESO_CANT_DPTOS = "Ingrese la cantidad de departamentos que tiene el edificio (max. 5): ";
      const string MJE_ERROR_CANT_DPTOS = "Debe ingresar entre 2 y 5 dptos. Vuelva a ingresar: ";
      const string MJE_ERROR_EXPENSAS = "El importe de las expensas debe ser >= 0. Vuelva a ingresar: ";
      const string MJE_INGRESO_MES = "Ingrese un mes para consultar sus expensas: ";
      const string MJE_ERROR_MES = "El mes ingresado no se encuentra.";
      const string MJE_FINAL_1 = "\nEn el mes de {0} se recaudaron ${1} entre todos los departamentos.";
      const string MJE_FINAL_2 = "El Departamento #{0} fue el que menos expensas pago.";
      const string MJE_FINAL_3 = "Se recaudo ${0} entre todos los departamentos.";
      const int MIN_DPTOS = 2;
      const int MAX_DPTOS = 5;
      const int CANT_MESES = 4;
      int cantDepartametos = 0;

      int[,] consorcioExpensas = new int[cantDepartametos, CANT_MESES];

      cantDepartametos = IngresarEntero(MJE_INGRESO_CANT_DPTOS, MJE_ERROR_CANT_DPTOS, MIN_DPTOS, MAX_DPTOS);
      //TODO: Realizar el programa principal.

      /*
          NOTA: Para reemplazar el nro. entre llaves de las constantes, por ejemplo {0}: 
          Console.WriteLine(CONSTANTE, variable);
          Si tiene más de un número --> Console.WriteLine(CONSTANTE, variable1, variable2);
          */
   }
   static int IngresarEntero(string mensaje, string mjeError = "", int min = int.MinValue, int max = int.MaxValue)
   {
      Console.Write(mensaje);
      int ingreso = int.Parse(Console.ReadLine());
      while (ingreso < min || ingreso > max)
      {
         Console.Write(mjeError);
         ingreso = int.Parse(Console.ReadLine());
      }
      return ingreso;
   }
   static string IngresarString(string mensaje)
   {
      Console.Write(mensaje);
      return Console.ReadLine();
   }

   /* /// <summary>
    /// Solicita al usuario que ingrese un mes por ejemplo "Enero". Se debe validar que exista dentro del array de meses. 
    En caso de no existir, se debe mostrar <paramref name="mjeError"/> y volver a pedir al usuario que ingrese un mes válido.
    /// </summary>
    /// <param name="mensaje">Mensaje de ingreso del mes que se mostrará al usuario</param>
    /// <param name="mjeError">Mensaje a visualizar en caso de no existir el mes ingresado</param>
    /// <param name="meses">Array con los meses existentes</param>
    /// <returns>Posición del mes encontrado en el array meses</returns>*/
   static int IngresarMes(string mensaje, string mjeError, string[] meses)
   {
      //TODO: Desarollar función. [BORRAR LINEA DE ABAJO]
      throw new NotImplementedException();
   }
   /*  /// <summary>
     /// <para>Debe solicitar al usuario el ingreso del importe de las expensas mes a mes por departamento y almacenarlo en 
     la estructura <paramref name="expensas"/>.</para><para>El importe deberá ser >= 0. En caso de no cumplirse esto, se
      deberá volver a solicitar al usuario hasta que el ingreso sea válido.</para>
     /// </summary>
     /// <param name="expensas">Estructura donde se cargarán los importes de las expensas. Las filas corresponden a los departamentos y las columnas a los meses.</param>
     /// <param name="meses">Array de meses. Se debe utilizar para indicar al usuario el mes a cargar.</param>
     /// <param name="mjeError">Mensaje a visualizar en caso de que el importe de las expensas sea menor a 0</param>*/
   static void CargarExpensas(int[,] expensas, string[] meses, string mjeError)
   {
      //TODO: Desarollar función.
   }
   /*  /// <summary>
     /// Permite obtener las expensas de todos los departamentos de un mes en particular 
     /// </summary>
     /// <param name="expensas">Estructura donde se almacenan los importes de las expensas</param>
     /// <param name="posiMes">Posición del mes a obtener sus expensas</param>
     /// <returns>Sumatoria de las expensas del mes pasado como parámetro</returns>*/
   static int ObtenerExpensasXMes(int[,] expensas, int posiMes)
   {
      //TODO: Desarollar función. [BORRAR LINEA DE ABAJO]
      throw new NotImplementedException();
   }
   /*   /// <summary>
      /// Permite obtener el importe total de expensas de todos los departamentos entre todos los meses
      /// </summary>
      /// <param name="expensas">Estructura donde se almacena el importe de las expensas</param>
      /// <returns>Importe total de expensas entre todos los departamentos y meses</returns>*/
   static int ObtenerTotalExpensas(int[,] expensas)
   {
      //TODO: Desarollar función. [BORRAR LINEA DE ABAJO]
      throw new NotImplementedException();
   }
   /*
   /// <summary>
   /// Permite obtener el número de departamento que menos expensas pagó entre todos los meses. Tener en cuenta que 
   los números de departamento empiezan en 1.
   /// </summary>
   /// <param name="expensas">Estructura donde se almacenan las expensas</param>
   /// <returns>Número de departamento que menos expensas pagó</returns>*/
   static int ObtenerDptoMenosPago(int[,] expensas)
   {
      //TODO: Desarollar función. [BORRAR LINEA DE ABAJO]
      throw new NotImplementedException();
   }
}
