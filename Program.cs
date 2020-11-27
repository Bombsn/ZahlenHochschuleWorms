using System;

namespace ZahlenHochschuleWorms
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Sie können das Programm jederzeit über die Escape-Taste verlassen.");
                
                int userMaxValue = UserInsertMaxNumber();

                int randomValue = GenerateRandomNumber(userMaxValue);



            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }


        static int UserInsertMaxNumber()
        {
            int result = 0;

            do
            {
                Console.WriteLine("Geben Sie eine Maximalzahl ein:");
                
                var eingabeUser = Console.ReadLine();

                int.TryParse(eingabeUser, out result);

                if (result == 0)
                {
                    Console.WriteLine("Ihre Eingabe war keine Ganzzahl.");
                }

            } while (result == 0);

            return result;
        }

        static int GenerateRandomNumber(int maxVal)
        {
            var rando = new Random();
            return rando.Next(0, maxVal);
        }


    }
}
