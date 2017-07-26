

using System;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Menu.Config;
using Aimtec.SDK.TargetSelector;

namespace Ice_Ice_Baby
{
    internal partial class Liss
    {
        public Liss()
        {
            LoadMenu();
            LoadSpells();
            LoadEvents();
                
        }

        private void OnTick()
        {
            if (MyHero.IsDead)
            {
                return;
            }
            target = TargetSelector.GetTarget(925);
            if (GlobalKeys.ComboKey.Active)
            {
                DoCombo();
            }
            if (GlobalKeys.MixedKey.Active)
            {
                DoHarass();
            }
            if (GlobalKeys.WaveClearKey.Active)
            {
                DoLaneClear();
            }
            if (GlobalKeys.LastHitKey.Active || RootM["farm"]["lasthit"]["autolasthit"].As<MenuBool>().Enabled)
            {
                DoLastHit();
            }
            if (RootM["keys"]["escape"].As<MenuKeyBind>().Enabled)
            {
                DoEscape();
            }
            AutoQHarass();
            DoKillSteal();
            DoAutoR();
            DoAutoW();
        }
        private void OnDraw()
        {
            if (MyHero.IsDead)
            {
                return;
            }
            DoDraws();
        }
    }
}
