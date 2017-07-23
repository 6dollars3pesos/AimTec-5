
using Aimtec;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.TargetSelector;

namespace Classic_Misdirection
{
    internal partial class LB
    {

        public LB()
        {
            this.LoadMenu();
            this.LoadSpells();
            this.LoadEvents();
        }

        private void OnTick()
        {
            if (MyHero.IsDead)
            {
                return;
            }
            target = TargetSelector.GetTarget(1600);
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
            if (RootM["keys"]["escape"].As<MenuKeyBind>().Enabled)
            {
                this.DoEscape();
            }
            DoKillSteal();
            if ((lastp + 7500) < Game.TickCount && combostart)
            {
                ComboName = GetComboName();
                lastp = Game.TickCount;
                combostart = false;
            }
            else if (!combostart)
            {
                ComboName = GetComboName();
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

        private void ClickEvent(WndProcEventArgs e)
        {
            if (RootM["keys"]["combomode"].As<MenuKeyBind>().Enabled)
            {
                RootM["combo"]["combologics"]["mCombo"].As<MenuList>().Value += 1;
                RootM["keys"]["combomode"].As<MenuKeyBind>().Value =
                    !RootM["keys"]["combomode"].As<MenuKeyBind>().Enabled;
                if (RootM["combo"]["combologics"]["mCombo"].As<MenuList>().Value > 7)
                {
                    RootM["combo"]["combologics"]["mCombo"].As<MenuList>().Value = 0;
                }
            }
        }


    }
}
