

using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;
using System.Linq;

namespace Annie_by_Krystra
{
    internal partial class Annie
    {
        public void DoLastHit()
        {
            bool Qmana = MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost;
            bool Wmana = MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.W).Cost;
            foreach (var mt in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(900)))
            {
                double Qdamage = MyHero.GetSpellDamage(mt, SpellSlot.Q);

                if (RootM["farm"]["lasthit"]["useQ"].As<MenuBool>().Enabled && Qdamage > mt.Health  &&
                    Qmana )
                {
                    CastQ(mt);
                }
            }
        }
    }
}
