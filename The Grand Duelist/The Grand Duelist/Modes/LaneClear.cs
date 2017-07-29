

using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;
using System.Linq;
using Aimtec.SDK.Orbwalking;

namespace The_Grand_Duelist
{
    internal partial class Fiora
    {
        public void DoLaneClear()
        {
            foreach (var minion in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(1400)))
            {
                if (minion != null)
                {
                    int qlogic = RootM["farm"]["laneclear"]["qcount"].As<MenuList>().Value;
                    bool checkMenuManaQ = MyHero.ManaPercent() > RootM["farm"]["laneclear"]["QMana"].As<MenuSlider>().Value;
                    bool checkMenuManaE = MyHero.ManaPercent() > RootM["farm"]["laneclear"]["EMana"].As<MenuSlider>().Value;
                    double AAdmg = MyHero.CalculateDamage(minion, DamageType.Physical, MyHero.TotalAttackDamage);
                    double Edamage = MyHero.GetSpellDamage(minion, SpellSlot.E);
                    double QDmg = MyHero.GetSpellDamage(minion, SpellSlot.Q);
                    if (RootM["farm"]["laneclear"]["useE"].As<MenuBool>().Enabled && checkMenuManaE && AAdmg < minion.Health && AAdmg + Edamage > minion.Health &&
                        !Orbwalker.Implementation.CanAttack())
                    {
                        CastE();
                    }

                    if (RootM["farm"]["laneclear"]["useQ"].As<MenuBool>().Enabled && checkMenuManaQ &&Q.Ready &&
                        MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost)
                    {
                        switch (qlogic)
                        {
                            case 0:
                                if (QDmg > minion.Health)
                                {
                                    Q.Cast(minion);
                                }
                                break;
                            case 1:
                                Q.Cast(minion);
                                break;
                        }
                    }

                }

            }
        }
    }
}
