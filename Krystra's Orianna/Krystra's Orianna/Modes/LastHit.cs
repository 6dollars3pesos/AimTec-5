

using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;
using System.Linq;

namespace Krystra_s_Orianna
{
    internal partial class Ori
    {
        public void DoLastHit()
        {

            foreach (var mt in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(900)))
            {
                if(mt==null || !mt.IsValid)
                {
                    return;
                }
                double Qdamage = MyHero.GetSpellDamage(mt, SpellSlot.Q);
                if (RootM["farm"]["lasthit"]["useQ"].As<MenuBool>().Enabled && Qdamage > mt.Health  )
                {
                    CastQ(mt);
                }
            }
        }
    }
}
