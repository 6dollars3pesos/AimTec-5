
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;
using System.Linq;

namespace Annie_by_Krystra
{
    internal partial class Annie
    {
        public void DoAutoR()
        {
            if (MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.R).Cost || target == null || !target.IsValid)
            {
                return;
            }
            if (RootM["misc"]["autor"]["use"].As<MenuBool>().Enabled)
            {
                if(RootM["misc"]["autor"]["autor"].As<MenuBool>().Enabled && R.GetPrediction(target).AoeTargetsHitCount> RootM["misc"]["autor"]["Enumber"].As<MenuSlider>().Value)
                {
                    CastR(target);
                }
            }
        }
        public void DoAutoStack()
        {
            int qmode = RootM["misc"]["autostack"]["qmode"].As<MenuList>().Value;
            int wmode = RootM["misc"]["autostack"]["wmode"].As<MenuList>().Value;
            if (MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.E).Cost || target == null || !target.IsValid || !RootM["misc"]["autostack"]["use"].As<MenuBool>().Enabled
                && IsPassiveReady())
            {
                return;
            }
            var minion = GameObjects.EnemyMinions.FirstOrDefault(m => m.IsValidTarget(1400));
            if (RootM["misc"]["autostack"]["useQ"].As<MenuBool>().Enabled)
            {
                switch (qmode)
                {
                    case 0:
                        if(MyHero.Distance(target)< Q.Range)
                        {
                            CastQ(target);
                        }
                        else
                        {
                            CastQ(minion);
                        }
                        break;
                    case 1:
                        if (MyHero.Distance(target) < Q.Range)
                          {
                             CastQ(minion);
                          }
                        break;
                    case 2:
                        if(MyHero.Distance(target) < Q.Range)
                        {
                            CastQ(target);
                        }
                        break;
                }
            }
            if (RootM["misc"]["autostack"]["useW"].As<MenuBool>().Enabled)
            {
                switch (wmode)
                {
                    case 0:
                        if (MyHero.Distance(target) < Q.Range)
                        {
                            CastW(target);
                        }
                        else
                        {
                            CastW(minion);
                        }
                        break;
                    case 1:
                        if (MyHero.Distance(target) < Q.Range)
                        {
                            CastW(minion);
                        }
                        break;
                    case 2:
                        if (MyHero.Distance(target) <  Q.Range)
                        {
                            CastW(target);
                        }
                        break;
                }
                //wbase gelecek
                // w yürü gelecek
            }
            if (RootM["misc"]["autostack"]["ebase"].As<MenuBool>().Enabled)
            {
                // ebase gelecek
                // w yürü gelecek
            }
            if (RootM["misc"]["autostack"]["erun"].As<MenuBool>().Enabled)
            {
                // ebase gelecek
                // w yürü gelecek
            }


        }
        public void AutoTibbers()
        {
            Tibbers = GameObjects.Minions.FirstOrDefault(it => !it.IsDead && it.IsValidTarget(2000) && it.Name.ToLower().Contains("tibbers") || it.Name.ToLower().Contains("infernal") || it.Name.ToLower().Contains("guardian"));
            int mode = RootM["misc"]["autotib"]["mode"].As<MenuList>().Value;
            if ( target == null || !target.IsValid)
            {
                return;
            }
            if (RootM["misc"]["autotib"]["use"].As<MenuBool>().Enabled && !IsR1())
            {
                if(Tibbers ==null || !Tibbers.IsValid)
                {
                    return;
                }
                if(mode == 0)
                {
                    MyHero.IssueOrder(OrderType.AutoAttackPet, target);
                }
                else if (mode == 1)
                {
                    MyHero.IssueOrder(OrderType.MovePet, MyHero);
                }
                else if (mode == 2)
                {
                    foreach (var minion in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(1400)))
                    {
                        MyHero.IssueOrder(OrderType.AutoAttackPet, minion);
                    }
                }
            }
        }
        public void DoAutoStun()
        {
            if (MyHero.Mana < MyHero.SpellBook.GetSpell(SpellSlot.R).Cost || target == null || !target.IsValid)
            {
                return;
            }
            if (RootM["misc"]["autostun"]["use"].As<MenuBool>().Enabled && IsPassiveReady())
            {
                if (RootM["misc"]["autostun"]["useR"].As<MenuBool>().Enabled && R.GetPrediction(target).AoeTargetsHitCount > RootM["misc"]["autostun"]["Rnumber"].As<MenuSlider>().Value)
                {
                    CastR(target);
                }
            }
        }
    }
}
