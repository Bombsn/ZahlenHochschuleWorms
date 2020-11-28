using System;

namespace ZahlenHochschuleWorms
{
    class Program
    {
        public static string userInput;
        public static int userMaxValue;

        static void Main(string[] args)
        {
            int roundCounter = 0;
            
            do
            {
                AskForMaxVal();

                if (userInput == "exit") break;
               
                int randomValue = GenerateRandomNumber(userMaxValue);

                Console.WriteLine("Erraten Sie die Zufallszahl:");

                do 
                {
                    userInput = Console.ReadLine();
                    if (userInput == "exit") break;
                    roundCounter++;
                } while (!UserGuessNumber(randomValue));

            } while (userInput != "exit");

            Console.WriteLine($"Das Spiel wurde beendet. Sie haben insgesamt {roundCounter} mal geraten.");
            Console.ReadKey(true);
        }


        static void AskForMaxVal()
        {
            Console.WriteLine("Sie können das Programm jederzeit über die Eingabe \"exit\" verlassen.");

            if (userMaxValue != 0)
            {
                Console.WriteLine("Wollen Sie eine neue Maximalzahl angeben? ('j' oder 'n')");
                userInput = Console.ReadLine();
                if (userInput != "j")
                {
                    return;
                }
            }
            
            userMaxValue = UserInsertMaxNumber();
        }


        static bool UserGuessNumber(int randNumb)
        {
            if (userInput == "exit") return true;

            int.TryParse(userInput, out int userGuess);

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
                userInput = Console.ReadLine();

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
