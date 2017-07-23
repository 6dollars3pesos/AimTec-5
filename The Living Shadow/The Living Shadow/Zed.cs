
using System;
using System.Drawing;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
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
            if (RootM["keys"]["combokey"].As<MenuKeyBind>().Enabled)
            {
                this.DoCombo();
            }
            if (RootM["keys"]["harasskey"].As<MenuKeyBind>().Enabled)
            {
                this.DoHarass();
            }
            if (RootM["keys"]["escape"].As<MenuKeyBind>().Enabled)
            {
                this.DoEscape();
            }
            if (RootM["keys"]["lasthitkey"].As<MenuKeyBind>().Enabled || RootM["farm"]["lasthit"]["autolasthit"].As<MenuBool>().Enabled)
            {
                this.DoLastHit();
            }
            if (RootM["keys"]["laneclearkey"].As<MenuKeyBind>().Enabled)
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

        private void OnDamage(AttackableUnit sender, AttackableUnitDamageEventArgs e)
        {
            if (!e.Source.IsMe)
            {
                return;
            }
            var tar = e.Target as Obj_AI_Hero;
            if (tar != null && tar.HasBuff("zedrtargetmark"))
            {
                TotalRDamage += e.Damage;
            }
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
                TotalRDamage = 0;
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
                    DelayAction.Queue((int)Rtimer*1000, () =>
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
                    DelayAction.Queue((int)Wtimer*1000, () =>
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
    }
}
