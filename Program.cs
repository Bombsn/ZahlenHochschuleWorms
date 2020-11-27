using System;

namespace ZahlenHochschuleWorms
{
    class Program
    {
        public static string userInput;
        static void Main(string[] args)
        {
            int roundCounter = 0;
            int userMaxValue = 0;
            
            do
            {
                Console.WriteLine("Sie können das Programm jederzeit über die Eingabe \"exit\" verlassen.");
                if (userMaxValue != 0)
                {
                    Console.WriteLine("Wollen Sie eine neue Maximalzahl angeben? ('j' oder 'n')");
                    userInput = Console.ReadLine();
                    if (userInput == "j")
                    {
                        Console.WriteLine("Geben Sie eine Maximalzahl (positive Ganzzahl) ein:");
                        userInput = Console.ReadLine();
                        userMaxValue = UserInsertMaxNumber();
                    }
                }
                else
                {
                    Console.WriteLine("Geben Sie eine Maximalzahl (positive Ganzzahl) ein:");
                    userInput = Console.ReadLine();
                    userMaxValue = UserInsertMaxNumber();
                }

                if (userInput == "exit") break;
               
                int randomValue = GenerateRandomNumber(userMaxValue);

                Console.WriteLine("Erraten Sie die Zufallszahl:");

                do 
                {
                    userInput = Console.ReadLine();
                    roundCounter++;
                } while (!UserGuessNumber(randomValue));

            } while (userInput != "exit");

            Console.WriteLine($"Das Spiel wurde beendet. Sie haben insgesamt {roundCounter} mal geraten.");
        }


        static bool UserGuessNumber(int randNumb)
        {
            if (userInput == "exit") return true;

            int.TryParse(userInput, out int userGuess);

            if (userGuess == 0) UserGuessNumber(randNumb);

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
                if (userInput == "exit") return result;

                int.TryParse(userInput, out result);

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
