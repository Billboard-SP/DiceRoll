﻿using System;
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

            public int RollDamage()
            {
                Random rnd = new Random();
                damageByType.Clear();
                int total = 0;

                // roll base damage
                int baseTotal = 0;
                for (int i = 0; i < diceCount; i++)
                    baseTotal += rnd.Next(1, diceSides + 1);
                baseTotal += modifier;
                damageByType[damageType] = baseTotal;
                total += baseTotal;

                // misc sources
                foreach (var (count, sides, type) in miscSources)
                {
                    int miscTotal = 0;
                    for (int i = 0; i < count; i++)
                        miscTotal += rnd.Next(1, sides + 1);
                    if (damageByType.ContainsKey(type))
                        damageByType[type] += miscTotal;
                    else
                        damageByType[type] = miscTotal;

                    total += miscTotal;
                }

                lastTotalDamage += total;
                return total;
            }

            public int GetLastTotalDamage() => lastTotalDamage;

            public string GetRollSummary()
            {
                string summary = "Damage Breakdown: \n";
                foreach (var kvp in damageByType)
                {
                    summary += $"- {kvp.Key}: {kvp.Value}\n";
                }
                summary += $"Total Damage: {lastTotalDamage}";
                return summary;
            }
        }
    }
}
