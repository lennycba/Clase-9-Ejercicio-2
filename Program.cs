int filas = 3;
int columnas = 9;
int posicionFila = 0;
int posicionColumna = 0;
int decena = 0;
int[,] cartonBingo = new int[filas, columnas];
int[,] espaciosEnBlanco = new int[filas, columnas];
Random numero = new Random();
int numeroCarton = 1;
int deuda = 0;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("=============================================");
Console.WriteLine("|BIENVENIDO AL GRAN BINGO DEL PROFE JOAQUÍN |");
Console.WriteLine("=============================================");
Console.WriteLine();
Console.WriteLine("¿DESEA COMPRAR UN CARTON?");
Console.WriteLine("S/N");
Console.ForegroundColor = ConsoleColor.Green;
string respuesta = Console.ReadLine();



while (respuesta.ToUpper() == "S")
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    while (posicionColumna <= 7)
    //llena los cartones con numeros sin repetir de la columna 1 a la 8
    {

        int posicionAnterior = 0;
        while (posicionFila <= 2)
        {

            cartonBingo[posicionFila, posicionColumna] = decena + (numero.Next(1, 10));

            while (cartonBingo[posicionFila, posicionColumna] == posicionAnterior)
            {
                cartonBingo[posicionFila, posicionColumna] = decena + (numero.Next(1, 10));
            }
            posicionAnterior = cartonBingo[posicionFila, posicionColumna];
            posicionFila++;
        }
        posicionColumna++;
        posicionFila = 0;
        decena = decena + 10;
    }
    decena = 0;

    if (posicionColumna == 8)
    //ecxepcion de la ultima columna
    {
        int posicionAnterior = 0;
        while (posicionFila <= 2)
        {

            cartonBingo[posicionFila, posicionColumna] = (numero.Next(80, 91));

            while (cartonBingo[posicionFila, posicionColumna] == posicionAnterior)
            {
                cartonBingo[posicionFila, posicionColumna] = (numero.Next(80, 91));
            }
            posicionAnterior = cartonBingo[posicionFila, posicionColumna];
            posicionFila++;
        }
    }

    //reseteo posicion de fila y columna
    posicionFila = 0;
    int contadorCeros = 0;

    //genero los espacios en blanco

    while (posicionFila <= 1)
    {
        while (contadorCeros != 4)
        {
            contadorCeros = 0;
            posicionColumna = 0;

            while (posicionColumna <= 8)
            {
                espaciosEnBlanco[posicionFila, posicionColumna] = numero.Next(0, 2);
                if (espaciosEnBlanco[posicionFila, posicionColumna] == 0)
                {
                    contadorCeros++;
                }
                posicionColumna++;

            }


        }

        contadorCeros = 0;
        posicionFila++;

    }
    posicionFila = 0;
    posicionColumna = 0;
    contadorCeros = 0;
    int[] suma = new int[9];

    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < 9; j++)
        {
            suma[j] = suma[j] + espaciosEnBlanco[i, j]; 
        }
    }


    while (contadorCeros != 4)
        {
            contadorCeros = 0;
            posicionFila = 2;
            posicionColumna = 0;

            while (posicionColumna <= 8)
            {
                if (suma[posicionColumna] == 0)
                {

                espaciosEnBlanco[posicionFila, posicionColumna] = 1;
                    posicionColumna++;
                }
                else if (suma[posicionColumna] == 2)
                {
                espaciosEnBlanco[posicionFila, posicionColumna] = 0;
                contadorCeros++;
                posicionColumna++;
                }
                else
                {
                espaciosEnBlanco[posicionFila, posicionColumna] = numero.Next(0,2);
                    if(espaciosEnBlanco[posicionFila, posicionColumna] == 0)
                {
                    contadorCeros++;
                }
                    posicionColumna++;
                }

            }


        }
    contadorCeros = 0;
    posicionFila = 0;
    posicionColumna = 0;

    //asigno los espacios en blanco al carton de bingo

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 9; j++)
        {
            if (espaciosEnBlanco[i, j] == 0)
            {
                cartonBingo[i, j] = 0;
            }

        }

    }

    //lo que se va a imprimir en pantalla

    Console.WriteLine("======================================================");
    Console.WriteLine("|             El bingo del profe Joaquín             |");
    Console.WriteLine("======================================================");
    Console.WriteLine("|" + "carton Nº: " + numeroCarton + "                                        |");
    Console.WriteLine("======================================================");

    for (int i = 0; i < 3; i++)
    {

        for (int j = 0; j < 9; j++)
        {
            if (cartonBingo[i, j] == 0)
            {
                Console.Write("|    |");
            }
            else if (cartonBingo[i, j] < 10)
            {
                Console.Write("| 0" + cartonBingo[i, j] + " |");
            }
            else
            {
                Console.Write("| " + cartonBingo[i, j] + " |");
            }


        }
        Console.WriteLine();
        Console.WriteLine("======================================================");
    }

    numeroCarton++;
    deuda += 1500;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine();
    Console.WriteLine("Se ha cobrado $1500 de su tarjeta de débito");
    Console.WriteLine("hasta el momento ha gastado $" + deuda);
    Console.WriteLine("¿DESEA COMPRAR OTRO CARTON? S/N");
    Console.ForegroundColor = ConsoleColor.Green;
    respuesta = Console.ReadLine();
}

if (respuesta.ToUpper() == "N")
{

    Console.WriteLine("====================================================================");
    Console.WriteLine("| MUCHAS GRACIAS POR PARTICIPAR EN EL GRAN BINGO DEL PROFE JOAQUÍN |");
    Console.WriteLine("====================================================================");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Todo lo recaudado en el gran bingo del profe joaquín será invertido");
    Console.WriteLine("en bitcoin en beneficio de los estudiantes del curso .net ");
    Console.WriteLine("y por supuesto del profe joaquín que tuvo la fantástica idea de hacernos renegar con este bingo");
}
Console.ResetColor();
Console.WriteLine();
Console.WriteLine();