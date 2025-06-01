using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoll
{
    internal class DamageCalculator
    {
        public class DamageRoll
        {
            // Base damage (from the weapon itself)
            private int diceCount;
            private int diceSides;
            private int modifier;
            private string damageType;

            // Misc sources (from boons, smites, or any extra sources)
            private List<(int count, int sides, string type)> miscSources;

            // Damage breakdown (the total damage seperated)
            private Dictionary<string, int> damageByType;

            private int lastTotalDamage;

            //Contructor
            public DamageRoll(int diceCount, int diceSides, int modifier, string damageType)
            {
                this.diceCount = diceCount;
                this.diceSides = diceSides;
                this.modifier = modifier;
                this.damageType = damageType;
                miscSources = new List<(int, int, string)>();
                damageByType = new Dictionary<string, int>();
                lastTotalDamage = 0;
            }

            public void AddMiscDamage(int count, int sides, string type)
            {
                miscSources.Add((count, sides, type));
            }
        }
    }
}
