using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annie_by_Krystra
{
    internal partial class Annie
    {
        public void DoLaneClear()
        {
            int qmode = RootM["farm"]["laneclear"]["qmode"].As<MenuList>().Value;
            foreach (var minion in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(1400)))
            {
                if (minion != null)
                {
                    if (RootM["farm"]["laneclear"]["useW"].As<MenuBool>().Enabled)
                    {
                        if (GameObjects.EnemyMinions.Count(t => t.IsValidTarget(200, false, false,
                                minion.ServerPosition)) >=
                            RootM["farm"]["laneclear"]["wcount"].As<MenuSlider>().Value)
                        {
                            CastW(minion);
                        }
                    }

                    if (RootM["farm"]["laneclear"]["useQ"].As<MenuBool>().Enabled )
                    {
                        if(qmode == 0)
                        {
                            if(MyHero.GetSpellDamage(minion, SpellSlot.Q)>minion.Health)
                            {
                                CastQ(minion);
                            }
                        }
                        else
                        {
                            CastQ(minion);
                        }
                    }

                }

            }
        }
    }
}
