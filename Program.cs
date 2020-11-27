using System;

namespace ZahlenHochschuleWorms
{
    class Program
    {
        static void Main(string[] args)
        {
            int roundCounter = 0;
            int userMaxValue = 0;

            do
            {
                Console.WriteLine("Sie können das Programm jederzeit über die Escape-Taste verlassen.");
                if (userMaxValue != 0)
                {
                    Console.WriteLine("Wollen Sie eine neue Maximalzahl angeben? ('j' oder 'n')");
                    if (Console.ReadKey(true).Key == ConsoleKey.J)
                    {
                        userMaxValue = UserInsertMaxNumber();
                    }
                }
                else
                {
                    userMaxValue = UserInsertMaxNumber();
                }
               
                int randomValue = GenerateRandomNumber(userMaxValue);

                while (!UserGuessNumber(randomValue))
                {
                    roundCounter++;
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine($"Das Spiel wurde beendet. Sie haben insgesamt {roundCounter} mal geraten.");
            Console.ReadKey();
        }


        static bool UserGuessNumber(int randNumb)
        {
            Console.WriteLine("Erraten Sie die Zufallszahl:");
            int.TryParse(Console.ReadLine(), out int userGuess);

            if (userGuess == 0) return false;

            if (userGuess == randNumb)
            {
                Console.WriteLine("Wow, voll getroffen, Ihre Eingabe war korrekt!");
                return true;
            }
            else
            {
                if (userGuess < randNumb)
                {
                    Console.WriteLine("No way dude, Ihre Eingabe war zu tief.");
                    return false;
                }
                else
                {
                    Console.WriteLine("lol viel zu hoch.");
                    return false;
                }
            }
        }


        static int UserInsertMaxNumber()
        {
            int result = 0;

            do
            {
                Console.WriteLine("Geben Sie eine Maximalzahl (positive Ganzzahl) ein:");
                
                var eingabeUser = Console.ReadLine();

                int.TryParse(eingabeUser, out result);

                if (result <= 0)
                {
                    Console.WriteLine("Ihre Eingabe war keine positive Ganzzahl.");
                }

            } while (result <= 0);

            return result;
        }

        static int GenerateRandomNumber(int maxVal)
        {
            var rando = new Random();
            return rando.Next(1, maxVal);
        }


    }
}
