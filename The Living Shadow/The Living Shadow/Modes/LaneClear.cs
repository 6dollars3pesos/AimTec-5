using System.Linq;
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;

namespace The_Living_Shadow
{
    internal partial class Zed
    {
        public void DoLaneClear()
        {
            bool Qmana = MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.Q).Cost;
            bool Wmana = MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.W).Cost;
            bool Emana = MyHero.Mana > MyHero.SpellBook.GetSpell(SpellSlot.E).Cost;
            var poscheck = !Wpos.Equals(new Vector3()) ? Wpos : MyHero.ServerPosition;
            foreach (var minion in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(900)))
            {
                if (minion != null)
                {
                    if (RootM["farm"]["laneclear"]["useW"].As<MenuBool>().Enabled && W.Ready && Wmana)
                    {
                        if (GameObjects.EnemyMinions.Count(t => t.IsValidTarget(E.Range, false, false, minion.ServerPosition)) > 2)
                        {
                            this.CastW(minion.ServerPosition);
                        }
                    }
                    if (RootM["farm"]["laneclear"]["useE"].As<MenuBool>().Enabled && E.Ready && Emana)
                    {
                        if (GameObjects.EnemyMinions.Count(t => t.IsValidTarget(E.Range, false, false, poscheck)) >= RootM["farm"]["laneclear"]["ecount"].As<MenuSliderBool>().Value)
                        {
                            E.Cast();
                        }
                    }

                    if (RootM["farm"]["laneclear"]["useQ"].As<MenuBool>().Enabled && Q.Ready && Qmana)
                    {
                        this.CastQ(minion);
                    }
                }

            }
        }
    }
}
