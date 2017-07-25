


using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;
using System.Linq;

namespace Moon_Moon
{
    internal partial class Diana
    {
        public void DoLastHit()
        {
            {
                bool Qmana = MyHero.ManaPercent() > MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost;
                foreach (var mt in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(Q.Range)))
                {
                    double Qdamage = MyHero.GetSpellDamage(mt, SpellSlot.Q);
                    if (RootM["farm"]["lasthit"]["useQ"].As<MenuBool>().Enabled && Qdamage > mt.Health && Q.Ready &&
                        Qmana)
                    {
                        CastQ(mt);
                    }

                }
            }
        }
    }
}
