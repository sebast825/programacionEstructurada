namespace SimulacroParcialDos;
class Program
{
   static void Main(string[] args)
   {
      const string MSJ_CODIGO_RESERVA = "Ingresar el PNR de 6 caracteres";
      const string MSJ_CODIGO_RESERVA_ERROR = "El codigo debe tener 6 caracteres";
      const string MSJ_CANTIDAD_PASAJEROS = "Ingresar la cantidad de pasajeros, debe ser entre 1 y 9";
      const string MJS_INGRESAR_IMPORTE_ABONADO = "Ingresar importe abonado";
      const string MJS_INGRESAR_IMPORTE_ABONADO_ERROR = "El importe abonado debe ser mayor a 0";
      const string MSJ_INGRESAR_CANTIDAD_TICKETS = "Ingresar la cantidad de tickets, debe ser entre 1 y 5";
      const string MSJ_INGRESAR_CANTIDAD_TICKETS_ERROR = "La cantidad de tickets debe ser entre 1 y 5";
      const string MSJ_INGRESAR_ORIGEN = "Ingresar origen, pede ser: {0}, {1} o {2}";
      const string MSJ_INGRESAR_DESTINO = "Ingresar destino, pede ser: {0}, {1} o {2}";
      const string MSJ_INGRESAR_ORIGEN_ERROR = "El origen debe ser: {0}, {1} 0 {2}";
      const string MSJ_INGRESAR_DESTINO_ERROR = "El destino puede ser: {0}, {1} o {2}";
      const string MSJ_DESTINO_USADO = "El destino mas usado fue {0}, {1} veces";
      const string MSJ_CANTIDAD_PASAJEROS_ERROR = "La cantidad de pasajeros debe ser entre 1 y 9";
      string origenSeleccionado = "";
      string destinoSeleccionado = "";
      string pnr;
      const string origenUno = "AEP";
      const string origenDos = "FTE";
      const string origenTres = "USH";
      const string destinoUno = "COR";
      const string destinoDos = "SLA";
      const string destinoTres = "MDZ";
      int destinoUnoSeleccionado = 0, destinoDosSeleccionado = 0, destinoTresSeleccionado = 0, ticketAepToMdz = 0, cantidadPasajeros, totalCantidadPasajeros = 0, cantiadTickets = 1, cantidadReserva = 0;
      double importeAbonado, totalImporteAbonado = 0;

      pnr = IngresarString(MSJ_CODIGO_RESERVA);

      cantidadReserva++;
      while (pnr != "Z")
      {
         while (!stringLength(pnr, 6))
         {
            Console.WriteLine(MSJ_CODIGO_RESERVA_ERROR);
            pnr = IngresarString(MSJ_CODIGO_RESERVA);
         }

         cantidadPasajeros = IngresarInt(MSJ_CANTIDAD_PASAJEROS, MSJ_CANTIDAD_PASAJEROS_ERROR);
         totalCantidadPasajeros += cantidadPasajeros;
         importeAbonado = IngresarDouble(MJS_INGRESAR_IMPORTE_ABONADO, MJS_INGRESAR_IMPORTE_ABONADO_ERROR, 0);
         totalImporteAbonado += importeAbonado;



         cantiadTickets = IngresarInt(MSJ_INGRESAR_CANTIDAD_TICKETS, MSJ_INGRESAR_CANTIDAD_TICKETS_ERROR, 1, 5);

         for (int i = 1; i <= cantiadTickets; i++)
         {
            Console.WriteLine("Ingrese informacion ticket numero {0}", i);
            origenSeleccionado = ValidateString(MSJ_INGRESAR_ORIGEN, MSJ_INGRESAR_ORIGEN_ERROR, origenUno, origenDos, origenTres);
            destinoSeleccionado = ValidateString(MSJ_INGRESAR_DESTINO, MSJ_INGRESAR_DESTINO_ERROR, destinoUno, destinoDos, destinoTres);

            AumentarContadorDestino(destinoSeleccionado, ref destinoUnoSeleccionado, ref destinoDosSeleccionado, ref destinoTresSeleccionado);
            bool origenEspecifico = CompararDosStrings(origenSeleccionado, origenUno);
            bool destinoEspecifico = CompararDosStrings(destinoSeleccionado, destinoTres);

            bool origenDestinoExpected = CompararDosBool(origenEspecifico, destinoEspecifico);
            if (origenEspecifico)
            {
               ticketAepToMdz++;

            }
         }

         pnr = IngresarString(MSJ_CODIGO_RESERVA);

      }

      Console.WriteLine("Importe de todas las reservas: {0}", totalImporteAbonado);
      Console.WriteLine("Promedio de pasajeros por reserva: {0}", Promedio(totalCantidadPasajeros, cantidadReserva));

      ComaprarTresInt(MSJ_DESTINO_USADO, destinoUnoSeleccionado, destinoDosSeleccionado, destinoTresSeleccionado, destinoUno, destinoDos, destinoTres);
      Console.WriteLine("Ticket con tramo AEP a MDZ: {0} ", ticketAepToMdz);
   }

   static string IngresarString(string mensaje)
   {
      Console.WriteLine(mensaje);
      return Console.ReadLine();
   }

   static bool stringLength(string mensaje, int stringLength)
   {
      int cantCaracteres = mensaje.Length;
      return cantCaracteres == stringLength;
   }
   static int IngresarInt(string mensaje, string mje_error, int min = int.MinValue, int max = int.MaxValue)
   {
      Console.WriteLine(mensaje);
      int personas = int.Parse(Console.ReadLine());


      while (personas < min || personas > max)
      {
         Console.WriteLine(mje_error);
         personas = int.Parse(Console.ReadLine());
      }
      return personas;
   }

   static double IngresarDouble(string mensaje, string mje_error, int min = int.MinValue)
   {
      Console.WriteLine(mensaje);
      double personas = double.Parse(Console.ReadLine());


      while (personas < min)
      {
         Console.WriteLine(mje_error);
         personas = double.Parse(Console.ReadLine());
      }
      return personas;
   }

   static string ValidateString(string mensaje, string mensajeError, string validacionUno, string validacionDos, string validacionTres)
   {

      string funcString = IngresarString(string.Format(mensaje, validacionUno, validacionDos, validacionTres));
      while (funcString != validacionUno && funcString != validacionDos && funcString != validacionTres)
      {
         funcString = IngresarString(string.Format(mensajeError, validacionUno, validacionDos, validacionTres));
      }
      return funcString;
   }

   static int Promedio(int dividendo, int divisor)
   {
      double resultado = (double)dividendo / divisor;
      int cuenta = (int)Math.Round(resultado);
      return cuenta;
   }

   static void AumentarContadorOrigen(string valor, ref int contadorUno, ref int contadorDos, ref int contadorTres)
   {

      switch (valor)
      {
         case "AEP":
            contadorUno++;
            break;
         case "FTE":
            contadorDos++;
            break;
         case "USH":
            contadorTres++;
            break;
      }
   }

   static void AumentarContadorDestino(string valor, ref int contadorUno, ref int contadorDos, ref int contadorTres)
   {

      switch (valor)
      {
         case "COR":
            contadorUno++;
            break;
         case "SLA":
            contadorDos++;
            break;
         case "MDZ":
            contadorTres++;
            break;
      }
   }

   static bool CompararDosStrings(string valorUno, string valordDos)
   {
      if (valorUno == valordDos)
      {
         return true;
      }
      else
      {
         return false;
      }
   }
   static bool CompararDosBool(bool valorUno, bool valordDos)
   {
      if (valorUno == valordDos)
      {
         return true;
      }
      else
      {
         return false;
      }
   }

   static void ComaprarTresInt(string customText, int num1, int num2, int num3, string variableUno, string variableDos, string variableTres)
   {

      if (num1 >= num2 && num1 >= num3)
      {
         Console.WriteLine(customText, variableUno, num1);
      }
      else if (num2 >= num1 && num2 >= num3)
      {
         Console.WriteLine(customText, variableDos, num2);
      }
      else
      {
         Console.WriteLine(customText, variableTres, num3);
      }
   }
}

