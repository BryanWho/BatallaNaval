namespace BatallaNaval
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int N = 10;
            int x, y, eje, longitud;
            string coordenada;
            Console.WriteLine("Juego BATALLA NAVAL");
            ImprimirTablero(N);
            Console.WriteLine("Por favor de una coordenada (X,Y) en donde va a estar ubicado su barco");
            coordenada = Console.ReadLine();
            x = SepararCoordenadas(coordenada, 0);
            y = SepararCoordenadas(coordenada, 1);
            Console.WriteLine("El barco va a estar ubicado de forma horizontal o de forma vertical. (0: horizontal, 1: vertical)");
            eje = Int32.Parse(Console.ReadLine());
            Console.WriteLine("¿Cuál es la longitud del barco?");
            longitud = Int32.Parse(Console.ReadLine());

            PosBarco(x, y, eje, longitud, N);



        }



        public static void ImprimirTablero(int n)
        {
            string[,] campo = new string[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    campo[j, i] = "~";
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(campo[j, i] + " ");
                }
                Console.WriteLine(" ");
            }
        }

        public static int SepararCoordenadas(string cadena, int i)
        {
            int cooX, cooY;
            int[] cooXY = new int[2];
            string[] arrCoordenada = cadena.Split(",");
            cooX = Int32.Parse(arrCoordenada[0]);
            cooY = Int32.Parse(arrCoordenada[1]);
            cooXY[0] = cooX;
            cooXY[1] = cooY;
            return cooXY[i];
        }

        public static void PosBarco(int x, int y, int eje, int longitud, int n)
        {
            string[,] campo = new string[n, n];
            string[,] newCampo = new string[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    campo[j, i] = "~";
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    newCampo[j, i] = "~";
                }
            }



            newCampo[x, y] = "O";
            if (eje == 1)
            {
                for (int i = 0; i < longitud; i++)
                {
                    newCampo[x, y + i] = "O";
                }
            }
            if (eje == 0)
            {
                for (int i = 0; i < longitud; i++)
                {
                    newCampo[x + i, y] = "O";
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(newCampo[j, i] + " ");
                }
                Console.WriteLine(" ");
            }

            Console.WriteLine("¡¡¡INICIA EL JUEGO!!!");
            string coordenada;
            int aciertos = 0, intentos = 0;
            int gameOver = 0;
            int x0, y0;
            ImprimirTablero(n);
            while (gameOver == 0)
            {
                intentos++;
                Console.WriteLine("Por favor ingrese una coordenada");
                coordenada = Console.ReadLine();
                x0 = SepararCoordenadas(coordenada, 0);
                y0 = SepararCoordenadas(coordenada, 1);
                if (newCampo[x0, y0] == "O")
                {
                    campo[x0, y0] = "0";
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write(campo[j, i] + " ");
                        }
                        Console.WriteLine(" ");
                    }

                    Console.WriteLine("ACERTÓ");
                    aciertos++;
                    gameOver = 0;
                    if(aciertos == longitud)
                    {   
                        Console.WriteLine("GANASTEEEEEEE");
                        gameOver = 1;
                    }

                }
                else
                {
                    campo[x0, y0] = "X";
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write(campo[j, i] + " ");
                        }
                        Console.WriteLine(" ");
                    }

                    Console.WriteLine("Fallaste. Intenta de nuevo");

                }
            }

        }
    }
}
