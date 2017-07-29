﻿

using Aimtec;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Menu.Config;
using Aimtec.SDK.TargetSelector;
using System.Linq;

namespace Krystra_s_Orianna
{
    internal partial class Ori
    {
        public Ori()
        {
            LoadMenu();
            LoadSpells();
            LoadEvents();
                
        }

        private void OnTick()
        {
            if (MyHero.IsDead)
            {
                if(Ball != MyHero.ServerPosition)
                {
                    Ball = MyHero.ServerPosition;
                }
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
            else
            {
                Escaping = false;
            }
            DoAutoQHarass();
            AutoCasting();
            DoKillSteal();
        }
        private void OnDraw()
        {
            if (MyHero.IsDead)
            {
                return;
            }
        }
        private void UpdateBuff(Obj_AI_Base sender, Buff buff)
        {
            if(!sender.IsValid || sender.IsAlly ||sender.Type == MyHero.Type)
            {
                if (buff.Name.ToLower() == "orianaghostself")
                {
                    Ball = MyHero.ServerPosition;
                }
            }
        }
        private void OnCastSpell(Obj_AI_Base sender, SpellBookCastSpellEventArgs e)
        {
            if (!sender.IsMe || !RootM["misc"]["blockr"]["use"].As<MenuBool>().Enabled)
            {
                return;
            }
            if (e.Slot == SpellSlot.R)
            {
                if (Aimtec.SDK.Extensions.UnitExtensions.CountEnemyHeroesInRange(e.Target, R.Range) <= RootM["misc"]["blockr"]["rcount"].As<MenuSlider>().Value)
                {
                    e.Process = false;
                }
            }
        }
        private void ProcessSpell(Obj_AI_Base sender, Obj_AI_BaseMissileClientDataEventArgs e)
        {
           if(sender.IsMe && sender.IsValid)
            {
                if (e.SpellData.Name == "OrianaIzunaCommand")
                {
                    Ball = e.End;
                }
                else if (e.SpellData.Name == "OrianaRedactCommand")
                {
                    Ball = e.Target.ServerPosition;
                }
            }
           if (sender.IsEnemy && sender.IsValid)
            {
                if (Escaping)
                {
                    if(e.Target.IsMe || TargettedSpelCollection.Contains(e.SpellData.Name))
                    {
                        E.Cast();
                    }
                }
            }
        }
    }
}
