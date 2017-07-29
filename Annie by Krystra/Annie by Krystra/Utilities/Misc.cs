
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Util.Cache;
using System.Collections.Generic;
using System.Linq;

namespace Annie_by_Krystra
{
    internal partial class Annie
    {

        public bool IsPassiveReady()
        {
            return MyHero.HasBuff("pyromania_particle");
        }
        public bool IsR1()
        {
            return MyHero.SpellBook.GetSpell(SpellSlot.R).Name.ToLower() == R1Name;
        }
        public static Vector3 BestCircularFarmLocation(int radius, int range, int minMinions = 3)
        {
            var minions = GameObjects.EnemyMinions.Where(it => !it.IsDead && it.IsValidTarget(range));
            if (minions.Any() && minions.Count() == 1) return default(Vector3);

            var hitsperminion = new List<int>();
            int hits = new int();

            for (int i = 0; i < minions.Count(); i++)
            {
                hits = 1;

                for (int j = 0; j < minions.Count(); j++)
                {
                    if (j == i) continue;

                    if (minions.ElementAt(i).Distance(minions.ElementAt(j)) <= radius) hits++;
                }

                hitsperminion.Add(hits);
            }

            if (hitsperminion.Any() && hitsperminion.Max() > minMinions)
            {
                var pos = minions.ElementAt(hitsperminion.IndexOf(hitsperminion.Max())).ServerPosition;

                return pos;
            }

            return default(Vector3);
        }
    }
}
