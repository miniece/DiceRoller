using System.Diagnostics.CodeAnalysis;

namespace DiceRoller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool rollAgain = true;

            Console.WriteLine("Welcome to Minnie's Casino.");


            while (rollAgain == true)
            {
                Console.Write("How many sides should each die have? ");
                int num = 0;
                try
                {
                    string dieSides = Console.ReadLine();
                    num = int.Parse(dieSides);
                    
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter a numeric value.");
                    continue;
                }


                int dieRoll = RandomNums(num);
               int dieRoll2 = RandomNums(num);
                string sixSided = "";


                Console.WriteLine(dieRoll);
               Console.WriteLine(dieRoll2);
                int totalPoints = dieRoll + dieRoll2;
                Console.WriteLine("You rolled a " + dieRoll + " and a " + dieRoll2 + ". Your total is: " + totalPoints);

                if (num == 6)
                {
                    sixSided = SixSides(dieRoll, dieRoll2, totalPoints);
                }
                Console.WriteLine(sixSided);
               rollAgain = AskToContinue();
            }
        }
        public static int RandomNums(int dieSides)
        {
            Random rnd = new Random();
            return rnd.Next(1, dieSides+ 1);
        }

        public static string SixSides(int dieRoll, int dieRoll2, int totalPoints)
        {
            return "";
            if (dieRoll == 1 && dieRoll2 == 1)
            {
                return "Snake Eyes";
            }
            else if (dieRoll == 1 || dieRoll2 == 2 && dieRoll2 == 1 || dieRoll2 ==2)
            {
                return "Ace Deuce";
            }
            else if (dieRoll == 6 || dieRoll2 == 6)
            {
                return "Box Cars";
            }
            else if (totalPoints == 7 || totalPoints == 11)
            {
                return "Win";
            }
            else if (totalPoints == 2 || totalPoints == 3 || totalPoints == 12)
            {
                return "Craps";
            }
        }

        public static bool AskToContinue()
        {
            Console.WriteLine("Would you like to roll again? Y/N.");
            string answer = Console.ReadLine().ToLower();

            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                Console.WriteLine("Thanks for playing!");
                return false;
            }
            else
            {
                Console.WriteLine("Sorry, that was an invalid response, please input a valid response.");
                return AskToContinue();
            }
        }
    }
}