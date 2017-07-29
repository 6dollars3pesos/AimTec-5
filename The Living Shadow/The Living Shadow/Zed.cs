
using System;
using System.Drawing;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Menu.Config;
using Aimtec.SDK.TargetSelector;
using Aimtec.SDK.Util;

namespace The_Living_Shadow
{
    using Aimtec;

    internal partial class Zed
    {

        public Zed()
        {
            this.LoadSpells();
            this.LoadMenu();
            this.LoadEvents();


        }

        private void OnTick()
        {
            if (MyHero.IsDead)
            {
                return;
            }
            target = TargetSelector.GetTarget(1600);
            if (GlobalKeys.ComboKey.Active)
            {
                this.DoCombo();
            }
            if (GlobalKeys.MixedKey.Active)
            {
                this.DoHarass();
            }
            if (RootM["keys"]["escape"].As<MenuKeyBind>().Enabled)
            {
                this.DoEscape();
            }
            if (GlobalKeys.LastHitKey.Active || RootM["farm"]["lasthit"]["autolasthit"].As<MenuBool>().Enabled)
            {
                this.DoLastHit();
            }
            if (GlobalKeys.WaveClearKey.Active)
            {
                this.DoLaneClear();
            }
            this.DoKillSteal();
            this.LoadAutos();
            this.ReturnSettings();
        }

        private void OnDraw()
        {
            if (MyHero.IsDead)
            {
                return;
            }
            this.DrawSpells();

        }

        private void ProcessSpell(Obj_AI_Base sender, Obj_AI_BaseMissileClientDataEventArgs e)
        {
            if (!sender.IsMe)
            {
                return;
            }


            if (e.SpellData.Name == "ZedW")
            {
                Wpos = e.End;
                Wtimer = 5;
                Wdmgp = true;
                StartTime = Game.ClockTime + 5f;

            }
            else if (e.SpellData.Name == "ZedW2")
            {
                Wpos = e.Start;
            }
            if (e.SpellData.Name == "ZedR")
            {
                Rpos = e.Start;
                Rtimer = 7.5f;
                Rdmgp = true;
                Rdmgcheck = true;
                DelayAction.Queue(3750, () => Rdmgcheck = false);
                StartTimeR = Game.ClockTime + 7.5f;

            }
            else if (e.SpellData.Name == "ZedR2")
            {
                Rpos = MyHero.ServerPosition;
            }
            var asd = Game.TickCount;
            if ((GR + 10) < asd)
            {
                if (Rtimer == 7.5)
                {
                    DelayAction.Queue((int) Rtimer * 1000, () =>
                        {
                            Rtimer = 0f;
                            Rdmgcheck = false;
                            Rpos = new Vector3();
                            StartTimeR = 0;
                        }

                    );
                }
                GR = asd;
            }
            var W = Game.TickCount;
            if ((GW + 10) < W)
            {
                if (Wtimer == 5)
                {
                    DelayAction.Queue((int) Wtimer * 1000, () =>
                        {
                            Wtimer = 0;
                            Wdmgp = false;
                            Wpos = new Vector3();
                            StartTime = 0;
                        }

                    );
                }
                GW = W;
            }
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
    }
}
