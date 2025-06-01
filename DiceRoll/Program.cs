using static DiceRoll.DamageCalculator;

namespace DiceRoll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {
                Console.Write("Enter number of dice: ");
                int diceCount = int.Parse(Console.ReadLine());

                Console.Write("Enter number of sides per die: ");
                int diceSides = int.Parse(Console.ReadLine());

                Console.Write("Enter Modifier: ");
                int modifier = int.Parse(Console.ReadLine());

                Console.Write("Enter base damage type: ");
                string damageType = Console.ReadLine();

                DamageRoll roll = new DamageRoll(diceCount, diceSides, modifier, damageType);

                // add multiple misc damage sources
                string addMore;
                do
                {
                    Console.Write("Add extra damage source? (y/n): ");
                    addMore = Console.ReadLine().ToLower();

                    if (addMore == "y" || addMore == "yes")
                    {
                        Console.Write("Enter number of extra dice: ");
                        int miscCount = int.Parse(Console.ReadLine());

                        Console.Write("Enter sides per extra die: ");
                        int miscSides = int.Parse(Console.ReadLine());

                        Console.Write("Enter extra damage type: ");
                        string miscType = Console.ReadLine();

                        roll.AddMiscDamage(miscCount, miscSides, miscType);
                    }
                }
            }
        }
    }
}
