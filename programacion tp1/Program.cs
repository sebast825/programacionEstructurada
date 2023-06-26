namespace programacion;
class Program
{
   static void Main(string[] args)
   {
      /*
      CLASE 1
      EJERCICIO 4

        Realizá un programa que permita ingresar 3 notas pertenecientes a tres trimestres distintos
        para cierto alumno de nivel secundario. Debe calcularse y mostrarse la nota promedio.
*/
      /*
            double notaA;
            double notaB;
            double notaC;
            double suma;


            notaA = DoubleWithMessage("Ingrese nota 1er cuaasdtri: ");
            notaB = DoubleWithMessage("Ingrese nota 1er cuatri: ");
            notaC = DoubleWithMessage("Ingrese nota 1er cuatri: ");
            suma = (notaA + notaB + notaC) / 3;

            Console.WriteLine("Promedio: " + suma);
      */

      /*
      EJERCICIO 5 

      Se ingresa valor monetario de una hora de trabajo y la cantidad de horas trabajadas por día
      por un trabajador. Debés mostrar el valor del salario semanal, sabiendo que trabaja todos
      los días hábiles y la mitad de las horas del día hábil los sábados. (Todas las horas valen lo
      mismo.)
*/
      /*
                  int horasDiaTrabajadas;
                  double salario;
                  double salarioSemana;

                  horasDiaTrabajadas = IntWithMessage("Ingresar horas trbajadas por dia: ");

                  salario = DoubleWithMessage("Cuanto cobras por hora?: ");

                  int sabado = horasDiaTrabajadas / 2;
                  salarioSemana = horasDiaTrabajadas * salario * 5 + salario * sabado;
                  showResult("Salario semanal: " + salarioSemana);
            */
      /*
      EJERCICIO 6
      Dado valor numérico entero que se ingresa por teclado, se pide informar:
            ● La quinta parte de dicho valor,
            ● el resto de la división por 5 y
            ● la séptima parte de la quinta parte.
      */
      /*
            int valor;

             valor = IntWithMessage("Ingresar valor: ");

            double quintaParte = valor / 5;
            double restoDivision = quintaParte * 5;
            double septimaParte = quintaParte / 7;

          Console.WriteLine("Valor: " + valor);
          Console.WriteLine("quintaParte: " + quintaParte);
          Console.WriteLine("restoDivision: " + restoDivision);
          Console.WriteLine("septimaParte de la quintaparte: " + septimaParte);
      */
      /*
      EJERCICIO 7

      Dados dos valores numéricos diferentes entre sí, informar cual es el mayor.

      EJERCICIO 8

    Dados dos valores numéricos, informar cual es el mayor y cual es el menor o, si ambos
    valores son iguales emitir un mensaje.
*/
      /*
            double valorUno;
            double valorDos;


            valorUno = DoubleWithMessage("Ingresar 1er valor: ");

            valorDos = DoubleWithMessage("Ingresar 2do valor: ");

            if (valorUno > valorDos){
                Console.WriteLine(valorUno + " es mayor que " + valorDos);
            }else if(valorUno < valorDos){
                    Console.WriteLine(valorUno + " es menor que " + valorDos);

            }else{
                    Console.WriteLine("Los numeros ingresados son iguales");

            }

      */
      /*
      EJERCICIO 9

      Realizá un programa que permita ingresar valores del mismo tipo para las variables num1 y
      num2. Una vez cargadas, mostrar ambas variables por pantalla, intercambiá sus valores
      (que lo cargado en num1 quede en num2 , y viceversa) y volvé a mostrarlas actualizadas.

      

      int valorUno;
      int valorDos;
      int variableIntermedia;
      Console.Write("Ingresar valor uno: ");
      valorUno = Convert.ToInt16(Console.ReadLine());
      Console.Write("Ingresar valor dos:");
      valorDos = Convert.ToInt16(Console.ReadLine());

      Console.WriteLine("Este es el 1er valor: " + valorUno + " y este es el 2do valor: " + valorDos);

      variableIntermedia = valorUno;

      valorUno = valorDos;
      valorDos = variableIntermedia;

      Console.WriteLine("Pero tambien este es el 1er valor: " + valorUno + " y este es el 2do valor: " + valorDos);

*/
      /*
      Ejercicio 10
      Dada una terna de números naturales que representan el día, el mes y el año de una
      determinada fecha informarla como un solo número natural de 8 dígitos (aaaammdd).


      string dia;
      string mes;
      string año;

      Console.Write("ingresar dia: ");
      dia = Console.ReadLine();

      Console.Write("ingresar dia: ");
      mes = Console.ReadLine();

      Console.Write("ingresar dia: ");
      año = Console.ReadLine();

      string fecha = dia + mes + año;
      Console.WriteLine(fecha);

      */
      /*
      Ejercicio 11
Dado un número de 8 dígitos que representa una fecha con formato aaaammdd, se pide
mostrar por separado el día, el mes y el año de la ingresada.
     
      int fecha = 01021957;
            //d8 permite que toString tome 0 adelante

    string fechatSr = fecha.ToString("D8");
      string dia = fechatSr.Substring(0,2);
      string mes = fechatSr.Substring(2,2);
      string año = fechatSr.Substring(4,4);

      Console.WriteLine("{0}/{1}/{2}",dia,mes,año);


 */
      /*
      Ejercicio 15
      Realizá un programa que permita ingresar la cantidad de inscriptos a una conferencia y la
      cantidad de asientos disponibles en el auditorio. Debes indicar si alcanzan los asientos, Si
      los asientos no alcanzaran indicar cuántos faltan para que todos los inscriptos puedan
      sentarse.


      int inscriptos = 50;
      int asientosDisponibles = 70;
      int sillasImaginarias;
      if (inscriptos > asientosDisponibles){
          Console.WriteLine("traete unos pares mas ameoo");
      }else{
          sillasImaginarias = asientosDisponibles - inscriptos;
          Console.WriteLine("nos falta espacio para: " + sillasImaginarias + " teletubies");
      }

      */
      /*
      Ejercicio 16
      Realizá un programa que permita al usuario ingresar dos números enteros. La computadora
      debe indicar si el mayor es divisible por el menor. (Un número entero a es divisible por un
      número entero b cuando el resto de la división entre a y b es 0).


      int numUno = 5;
      int numDos = 2;

      if(numUno % numDos == 0){
          Console.WriteLine("es divisible");
      }else{
          Console.WriteLine("no es divisible");
      }

      */
      /*
      Ejercicio 17
      Existen dos reglas que identifican dos conjuntos de valores:
      A. El número es de un solo dígito.
      B. El número es impar.
      A partir de estas reglas, realizá un programa que permita ingresar un número entero. Debe
      asignar el valor que corresponda a las variables booleanas esDeUnSoloDigito, esImpar,
      estaEnAmbos y noEstaEnNinguno el valor Verdadero o Falso, según corresponda, para
      indicar si el valor número ingresado pertenece o no a cada conjunto.
      */
      /*
      int numero = 2;
      bool esDeUnSoloDigito;
      bool esImpar;

      string numeroSr = numero.ToString();

      //length
      if (numeroSr.Length == 1){
          esDeUnSoloDigito = true;
      }else if (numeroSr.Length > 1){
          esDeUnSoloDigito = false;
      }else{
          Console.WriteLine(numeroSr.Length);
              esDeUnSoloDigito = false;

      }

      //impar
      if (numero == 0){
          esImpar = false; // valor predeterminado si el número es 0
      }else if (numero % 2 == 0){
          esImpar = false;
      }else{
          esImpar = true;
      }

      if(esImpar && esDeUnSoloDigito){
          Console.WriteLine("El número es impar y de un solo dígito.");
      }else if (esImpar || esDeUnSoloDigito){
          Console.WriteLine("El número es par o de un solo dígito.");
      }else{
          Console.WriteLine("El número es 0.");
      }
      */
      /*
      Ejercicio 18
      Realizá un programa que permita al usuario ingresar un número entero entre 1 y 7. Debe
      mostrarse por pantalla el nombre del día de la semana que representa tal número tomando
      como el primer día de la semana el Domingo. De ingresar un número fuera de rango debe
      mostrar error.


      string[] dias = {"lunes","martes","miercoles","jueves","viernes","sabado","domingo"};

      int numero = 7;

      Console.WriteLine("el numero " + numero + " representa el dia " + dias[numero-1]);

      */
      /* const int FIN_DATOS = -1;
             double nota, promedio, acumNotas = 0;
             int cantEstudiantes = 0;

             nota = IngresarDouble("Ingrese su nota: ");
             while(nota != FIN_DATOS)
             {
                 //Acá dentro va a ir lo que quiero que se repita
                 acumNotas = acumNotas + nota; //acumNotas += nota
                 cantEstudiantes++;
                 nota = IngresarDouble("Ingrese su nota: ");
             }
     */

      int num = 5;
      do
      {
        /*
        string letra = Console.ReadLine();
        
            int.TryParse(letra, out num);*/
        Console.WriteLine(num);

            num = numero();
      } while (num < 10);
   }

static int numero(){
     string letra = Console.ReadLine();
    int num = int.Parse(letra);
    return num;
}
   static double DoubleWithMessage(string message)
   {

      Console.Write(message);
      string nota = Console.ReadLine();
      return double.Parse(nota);
   }
   static int IntWithMessage(string message)
   {

      Console.Write(message);
      string nota = Console.ReadLine();
      return Int16.Parse(nota);
   }

   static void showResult(string message)
   {
      Console.WriteLine(message);
   }

   static double IngresarDouble(string mensaje)
   {
      Console.WriteLine(mensaje);
      return double.Parse(Console.ReadLine());
   }
}
