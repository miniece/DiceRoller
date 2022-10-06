using System.Reflection.Metadata.Ecma335;
​
namespace Dice_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool goOn = true;
            while (goOn == true)
            {
                int input;
                try
                {
                    Console.WriteLine("Hello, please enter a positive integer for the number of sides for your custom pair of dice.");
                    input = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("You must enter a positive integer");
                    continue;
                }
                if ((input >= 1 && input != 6))
                {
                    Console.WriteLine("Okay, let's roll your " + input + "-sided dice");
                    int roll1 = DieRoll(input);
                    int roll2 = DieRoll(input);
                    Console.WriteLine("You rolled a " + roll1 + " and a " + roll2 + " for a total of " + (roll1 + roll2));
                    goOn = goAgain();
                    break;
                }
                else
                {
                    Console.WriteLine("The tried and true, " + input + "-sided dice!");
                    int roll1 = DieRoll(input);
                    int roll2 = DieRoll(input);
                    Console.WriteLine("You rolled a " + roll1 + " and a " + roll2 + " for a total of " + (roll1 + roll2));
                    Console.WriteLine(SixDie(roll1, roll2));
                    goOn = goAgain();

                }
            }
        }
        public static string SixDie(int roll1, int roll2)
        {
            if (roll1 == 1 && roll1 == roll2)
            {
                return "Snake Eyes!\nCraps.....?";
            }
            else if (roll1 == 6 && roll1 == roll2)
            {
                return "Box Cars!\nCraps....?";
            }
            else if ((roll1 == 1 && roll2 == 2) || (roll1 == 2 && roll2 == 1))
            {
                return "Ace Deuce!\nCraps....?";
            }
            else if ((roll1 + roll2 == 7) || (roll1 + roll2 == 11))
            {
                return "You Win!!!";
            }


            else
            {
                return "I'm sorry, you lose!";
            }
        }
        public static int DieRoll(int sides)
        {
            Random r = new Random();
            int roll = r.Next(1, sides + 1);
            return roll;
        }
        public static bool goAgain()
        {
            Console.WriteLine("Would you like to play again? Y/N");
​
            string input = Console.ReadLine().Trim().ToLower();
​
            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                Console.WriteLine("Thanks for playing!");
                return false;
            }
            else
            {
                Console.WriteLine("Please enter Y or N");
                return goAgain();
            }
        }
    }
}