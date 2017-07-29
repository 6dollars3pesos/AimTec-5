

using System;
using System.Linq;
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Menu.Config;
using Aimtec.SDK.Orbwalking;
using Aimtec.SDK.TargetSelector;
using Aimtec.SDK.Util.Cache;

namespace The_Grand_Duelist
{
    internal partial class Fiora
    {
        public Fiora()
        {
         
            LoadSpells();
            LoadMenu();
            LoadEvents();

        }

        private void OnTick()
        {
            if (MyHero.IsDead)
            {
                return;
            }
            target = TargetSelector.GetTarget(1500);
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
            DoKillSteal();

        }

        private void OnDraw()
        {
            if (MyHero.IsDead)
            {
                return;
            }
            DoDraws();
        }

        private void OnCreate(GameObject obj)
        {
            if (!obj.IsValid || obj == null)
            {
                return;
            }
            for (int i = 0; i < VitalSpotArray.Length; i++)
            {
                if (obj.Name == VitalSpotArray[i])
                {
                    VitalSpots.Add(obj);
                }
            }
        }

        private void OnProcessSpell(Obj_AI_Base unit, Obj_AI_BaseMissileClientDataEventArgs e)
        {
          
     

        }

        private void OnDestroy(GameObject obj)
        {
            if (!obj.IsValid)
            {
                return;
            }
            for (int i = 0; i < VitalSpotArray.Length; i++)
            {
                if (obj.Name.Contains(VitalSpotArray[i]))
                {
                    VitalSpots.Remove(obj);
                }

            }
        }

        private void PostAttack(object unit, PostAttackEventArgs e)
        {

            if (GlobalKeys.MixedKey.Active &&
                RootM["harass"]["useER"].As<MenuBool>().Enabled)
            {
                CastE();
                ResetAA();

            }
            if (GlobalKeys.MixedKey.Active && MyHero.CanUseItem(Thydra) && !E.Ready)
            {
                MyHero.UseItem(Thydra);
                ResetAA();
             
            }
            if (GlobalKeys.MixedKey.Active && MyHero.CanUseItem(Tiamat) && !E.Ready)
            {
                MyHero.UseItem(Tiamat);
                ResetAA();
            }
            if (RootM["combo"]["useE"].As<MenuBool>().Enabled && RootM["combo"]["useER"].As<MenuBool>().Enabled &&
                GlobalKeys.ComboKey.Active )
            {
                CastE();
                // ResetAA();
            }
            if (GlobalKeys.ComboKey.Active && RootM["combo"]["item"].As<MenuBool>().Enabled &&
                MyHero.CanUseItem(Thydra) && !E.Ready )
            {
                MyHero.UseItem(Thydra);
                // ResetAA();
            }
            if (GlobalKeys.ComboKey.Active && RootM["combo"]["item"].As<MenuBool>().Enabled &&
                MyHero.CanUseItem(Tiamat)&& !E.Ready )
            {
                MyHero.UseItem(Tiamat);
               // ResetAA();
            }


        }
    }
}
