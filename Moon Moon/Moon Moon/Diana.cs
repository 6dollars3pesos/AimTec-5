


using System;
using Aimtec;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.TargetSelector;

namespace Moon_Moon
{
    internal partial class Diana
    {
        public Diana()
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
            if (RootM["keys"]["combokey"].As<MenuKeyBind>().Enabled)
            {
                DoCombo();
            }
            if (RootM["keys"]["harasskey"].As<MenuKeyBind>().Enabled)
            {
                DoHarass();
            }
            if (RootM["keys"]["laneclearkey"].As<MenuKeyBind>().Enabled)
            {
                DoLaneClear();
            }
            if (RootM["keys"]["lasthitkey"].As<MenuKeyBind>().Enabled)
            {
                DoLastHit();
            }
            DoKillSteal();
        }

        private void ClickEvent(WndProcEventArgs e)
        {
            if (RootM["keys"]["combomode"].As<MenuKeyBind>().Enabled)
            {
                RootM["combo"]["rlogic"].As<MenuList>().Value += 1;
                RootM["keys"]["combomode"].As<MenuKeyBind>().Value =
                    !RootM["keys"]["combomode"].As<MenuKeyBind>().Enabled;
                if (RootM["combo"]["rlogic"].As<MenuList>().Value > 2)
                {
                    RootM["combo"]["rlogic"].As<MenuList>().Value = 0;
                }
            }
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
