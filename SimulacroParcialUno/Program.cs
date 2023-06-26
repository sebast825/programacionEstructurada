namespace SimulacroParcialUno;
class Program
{
   static void Main(string[] args)
   {
      Console.WriteLine("Hello, World!");

      const string MJE_FIN = "TERMO VACIO";
      const string MJE_INGRESO_nombreRonda = "Como se llama la ronda?";
      const string MJE_INGRESO_CANT_PARTICIPANTES = "Cuatas personas participaron de la ronda?";
      const string MJE_ERROR_CANT_PARTICIPANTES = "La cantidad de participantes debe ser mayor a 1";
      const string MJE_INGRESO_nombreParticipante = "Como se llama el participante?";
      const string MJE_INGRESO_TIPO_MATE = "Ingresar una 'A' si es mate amargo o la letra 'D' si es dulce";
      const string MJE_INGRESO_TIEMPO_MATE = "Ingresar tiempo que tardo en tomar el mate en segundos";
  const string MJE_ERROR_TIEMPO_MATE = "Por lo menos debe durar 1 segundo"; 
    const string MJE_ERROR_TIPO_MATE = "Valor invalido, debe ingresar una 'A' si es mate amargo o la letra 'D' si es dulce";
    const string MJE_PARTICIPANTE_MAS_TARDO = "{0} fue el participante que mas tardó, con un tiempo de {1:F2} minutos";
const string MSJ_PROMEDIO_MATES_RONDA = "Hubo un promedio de {0} mates por ronda";
const string MSJ_RONDA_TIEMPO_MAX = "La ronda que mas duro es {0}";
const string MSJ_CANTIDAD_MATES_DULCES = "Hubo {0} de mates dulces";

      const int PARTICIPANTES_MINIMOS_RONDA = 1;
      const int SEGUNDOS_POR_MINUTO = 60;
      const char CONDICION_MATE_UNO = 'A';
      const char CONDICION_MATE_DOS = 'D';
            const int TIMEPO_MIN_MATE = 1;

      int duracionMate = 0;
      int duracionMateMax = 0;
      double duracionMateMaxMinutos;
      int participantesRonda = 0;
      int cantidadMatesDulces = 0;
      int matesTotales = 0;
      int cantidadRondas = 0;
      int participantesRondaMax = 0;
      string nombreRondaMax = "";
      double promedioMatesPorRonda = 0;
      string nombreRonda, nombreParticipante, nombreParticipanteMasTardo = "";
      char tipoMate;

      nombreRonda = IngresarString(MJE_INGRESO_nombreRonda);
      while (nombreRonda != MJE_FIN)
      {
         duracionMateMax=0;
         cantidadRondas++;
         participantesRonda = IngresarInt(MJE_INGRESO_CANT_PARTICIPANTES, MJE_ERROR_CANT_PARTICIPANTES, PARTICIPANTES_MINIMOS_RONDA);
         matesTotales += participantesRonda;
         for (int i = 0; i < participantesRonda; i++)
         {
            nombreParticipante = IngresarString(MJE_INGRESO_nombreParticipante);

            tipoMate = ingresarChar(MJE_INGRESO_TIPO_MATE,MJE_ERROR_TIPO_MATE,CONDICION_MATE_UNO,CONDICION_MATE_DOS);

            duracionMate = IngresarInt(MJE_INGRESO_TIEMPO_MATE, MJE_ERROR_TIEMPO_MATE,TIMEPO_MIN_MATE);

            if (duracionMate > duracionMateMax)
            {
               duracionMateMax = duracionMate;
               nombreParticipanteMasTardo = nombreParticipante;
            }
            if (tipoMate == CONDICION_MATE_DOS)
            {
               cantidadMatesDulces++;
            }
         }

         if (participantesRonda > participantesRondaMax)
         {
            participantesRondaMax = participantesRonda;
            nombreRondaMax = nombreRonda;
         }

         duracionMateMaxMinutos = dividir(duracionMateMax, SEGUNDOS_POR_MINUTO);
         Console.WriteLine(MJE_PARTICIPANTE_MAS_TARDO,nombreParticipanteMasTardo,duracionMateMaxMinutos);
         nombreRonda = IngresarString(MJE_INGRESO_nombreRonda);

      }
      promedioMatesPorRonda = dividir(matesTotales, cantidadRondas);
      Console.WriteLine(MSJ_PROMEDIO_MATES_RONDA,promedioMatesPorRonda);
      Console.WriteLine(MSJ_RONDA_TIEMPO_MAX,nombreRondaMax);
      Console.WriteLine(MSJ_CANTIDAD_MATES_DULCES,cantidadMatesDulces);
   }
   static string IngresarString(string mensaje,string param = "")
   {
      Console.WriteLine(mensaje);
      return Console.ReadLine();
   }

   static int IngresarInt(string mensaje, string mje_error, int min_participantes)
   {
      Console.WriteLine(mensaje);
      int personas = int.Parse(Console.ReadLine());

      while (personas < min_participantes)
      {
         Console.WriteLine(mje_error);
         personas = int.Parse(Console.ReadLine());
      }
      return personas;
   }

    static char ingresarChar(string mensaje, string mje_error, char valor1, char valor2)
    {
        Console.WriteLine(mensaje);
        char value = char.Parse(Console.ReadLine());

        while(value != valor1 && value != valor2)
        {
            Console.WriteLine(mje_error);
           value = char.Parse(Console.ReadLine());
        }
        return value;
    }
    static double dividir(int num1, int num2)
   {
      return (double)num1 / num2;
   }


}
