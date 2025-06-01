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

                DamageCalculator roll = new DamageCalculator(diceCount, diceSides, modifier, damageType);

            }
        }
    }
}
