using System;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());

            int cakeSize = height * width;

            int takenPieces = 0;


            while (takenPieces < cakeSize)
            {
                string input = Console.ReadLine();

                if (input == "STOP")
                {
                    break;
                }

                int piece = int.Parse(input);

                takenPieces += piece;
            }

            if (takenPieces<=cakeSize)
            {
                int piecesLeft = cakeSize - takenPieces;

                Console.WriteLine($"{piecesLeft} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {takenPieces - cakeSize} pieces more.");
            }
        }
    }
}
