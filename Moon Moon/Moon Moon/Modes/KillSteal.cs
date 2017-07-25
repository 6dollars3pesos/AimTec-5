
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
        #region Killstea part
        public void DoKillSteal()
        {

            
                if (!RootM["killsteal"]["ks"].As<MenuBool>().Enabled)
                {
                    return;
                }
                foreach (var hptarget in GameObjects.EnemyHeroes.Where(a => a.IsValidTarget(1200) && !a.IsDead))
                {
                    if (!hptarget.IsValid || hptarget.IsDead || hptarget == null)
                    {
                        return;
                    }
                    var Health = hptarget.Health;
                  
                    var dmgQ = MyHero.GetSpellDamage(hptarget, SpellSlot.Q);
                    if (MyHero.Distance(hptarget) < Q.Range && Health < dmgQ && !RootM["keys"]["combokey"].As<MenuKeyBind>().Enabled &&
                        RootM["killsteal"]["useQ"].As<MenuBool>().Enabled)
                    {
                        CastQ(hptarget);
                    }
                  
                    var dmgR = MyHero.GetSpellDamage(hptarget, SpellSlot.Q);
                    if (MyHero.Distance(hptarget) < Q.Range && Health < dmgR && !RootM["keys"]["combokey"].As<MenuKeyBind>().Enabled &&
                        RootM["killsteal"]["useR"].As<MenuBool>().Enabled)
                    {
                    CastR(hptarget);
                    }
                    if (!IsIgnite) continue;
                    var dmgI = (50 + ((MyHero.Level) * 20));
                    if (MyHero.Distance(hptarget) < Q.Range && Health < dmgQ && !RootM["keys"]["combokey"].As<MenuKeyBind>().Enabled &&
                        RootM["killsteal"]["useI"].As<MenuBool>().Enabled)
                    {
                        Ignite.CastOnUnit(hptarget);
                    }
              


            }
            #endregion
        }
    }
}
