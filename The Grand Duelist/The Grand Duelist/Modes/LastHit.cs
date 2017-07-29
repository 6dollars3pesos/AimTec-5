

using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;
using System.Linq;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Orbwalking;

namespace The_Grand_Duelist
{
    internal partial class Fiora
    {
        public void DoLastHit()
        {

            foreach (var mt in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(900)))
            {
                bool checkMenuManaQ = MyHero.ManaPercent() > RootM["farm"]["lasthit"]["QMana"].As<MenuSlider>().Value;
                bool checkMenuManaE = MyHero.ManaPercent() > RootM["farm"]["lasthit"]["EMana"].As<MenuSlider>().Value;
                double Qdamage = MyHero.GetSpellDamage(mt, SpellSlot.Q);
                double AAdmg = MyHero.CalculateDamage(mt, DamageType.Physical, MyHero.TotalAttackDamage);
                double Edamage = MyHero.GetSpellDamage(mt, SpellSlot.E);
                if (RootM["farm"]["lasthit"]["useQ"].As<MenuBool>().Enabled && Qdamage > mt.Health && Q.Ready && checkMenuManaQ &&
                    MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost)
                {
                    Q.Cast(mt);
                }
                if (RootM["farm"]["lasthit"]["useE"].As<MenuBool>().Enabled && Edamage > mt.Health && E.Ready &&
                    mt.IsValidTarget(MyHero.BoundingRadius) && checkMenuManaE)
                {
                    if(AAdmg < mt.Health && AAdmg+Edamage > mt.Health && !Orbwalker.Implementation.CanAttack())
                    {
                        CastE();
                    }
                }
            }
        }
    }
}
