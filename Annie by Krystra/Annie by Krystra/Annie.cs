
using System;
using Aimtec;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Menu.Config;
using Aimtec.SDK.TargetSelector;
using System.Linq;

namespace Annie_by_Krystra
{
    internal partial class Annie
    {
        public Annie()
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
            if (RootM["keys"]["harass"].As<MenuKeyBind>().Enabled)
            {
                AutoQHarass();
            }
            AutoTibbers();
            DoAutoStun();
            DoAutoR();
            DoAutoStack();
            DoKillSteal();
        }
        private void OnDraw()
        {
            if (MyHero.IsDead)
            {
                return;
            }
            DoDraws();
            Console.WriteLine(IsR1());
        }
        private void OnCastSpell(Obj_AI_Base sender, SpellBookCastSpellEventArgs e)
        {
            if (sender == null ||!sender.IsMe || !RootM["skill"]["Rlogic"]["blockR"].As<MenuBool>().Enabled  || target ==null)
            {
                return;
            }
            if (e.Slot == SpellSlot.R)
            {
                if(Aimtec.SDK.Extensions.UnitExtensions.CountEnemyHeroesInRange(target,R.Range) <= RootM["skill"]["Rlogic"]["Rnumber"].As<MenuSlider>().Value)
                {
                    e.Process = false;
                }
            }
        }
        private void OnProcessSpell(Obj_AI_Base sender, Obj_AI_BaseMissileClientDataEventArgs e)
        {

            if (sender.IsMe || !RootM["misc"]["autoe"]["use"].As<MenuBool>().Enabled || !E.Ready)
            {
                return;
            }
            if (e.SpellData.Name.ToLower().Contains("attack"))
            {
               if(sender.IsEnemy && RootM["misc"]["autoe"]["enemyattack"].As<MenuBool>().Enabled && e.Target.IsMe)
                {
                    CastE();
                }
                if (sender.IsTurret && RootM["misc"]["autoe"]["turret"].As<MenuBool>().Enabled && e.Target.IsMe)
                {
                    CastE();
                }
                if (sender.IsMinion && RootM["misc"]["autoe"]["monster"].As<MenuBool>().Enabled && e.Target.IsMe)
                {
                    CastE();
                }
            }
            if(sender.IsEnemy && TargetedSpells.Contains(e.SpellData.Name) && e.Target.IsMe)
            {
                CastE();
            }
        }

    }
}
