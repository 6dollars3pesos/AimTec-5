using Aimtec.SDK.Menu;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Orbwalking;
using Aimtec.SDK.Util;
using Aimtec.SDK.Util.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aimtec;

namespace The_Grand_Duelist
{
    internal partial class Fiora
    {
        #region Static Operations
        public static Menu RootM, Combo, AutoParry, ComboBack, AutoParrySub, AutoParrySub2, ComboLogics, ComboBlacklist, Harass, AutoHarass, Farm, LastHit, LaneClear, JungleClear, OneShot,
            KillSteal, Escape, Draw, WShadow, RShadow, DrawOptions, Misc, TurretDive, SkinHack, AutoLevel, AntiAfk, Key;
        #endregion
        public void LoadMenu()
        {
            RootM = new Menu("champname", "The Grand Duelist - [Fiora]", true);
            Orbwalker.Implementation.Attach(RootM);
            {
                #region combo
                {
                    Combo = new Menu("combo", "Combo Settings");
                    Combo.Add(new MenuBool("useQ", "Use Q in Combo", true));
                    Combo.Add(new MenuBool("useE", "Use E in Combo", true));
                    Combo.Add(new MenuBool("useR", "Use R in Combo", true));
                    Combo.Add(new MenuList("rlogic", "R logic laning phase(1vs1)", new[] { "Smart", "If target killable", "Direcly" }, 0));
                    Combo.Add(new MenuBool("useRM", "Use R for multiple enemy", true));
                    Combo.Add(new MenuSlider("useRMC", "Use R for multiple enemy", 3,1,5));


                    if (IsIgnite)
                    {
                        Combo.Add(new MenuBool("useI", "Use Ignite in Combo", true));
                    }
                    Combo.Add(new MenuSeperator("blank"));
                    Combo.Add(new MenuBool("useER", "Use Skill Resets if Possible", true));
                    Combo.Add(new MenuBool("item", "Use Aggresive items for reset", true));
                    Combo.Add(new MenuSlider("Mana", "Mana Manager %", 15, 10, 99));

                    ComboBlacklist = new Menu("blacklist", "Blacklist For Combo");
                    foreach (var tar in GameObjects.EnemyHeroes)
                    {
                        ComboBlacklist.Add(new MenuBool("use" + tar.ChampionName.ToLower(), "Don't use on :" + tar.ChampionName, false));
                    }
                    Combo.Add(ComboBlacklist);
                    RootM.Add(Combo);
                }
                #endregion

                #region harass

                {
                    Harass = new Menu("harass", "Harass Settings");
                    {
                        Harass.Add(new MenuBool("useQ", "Use Q in Harass", true));
                        Harass.Add(new MenuBool("useE", "Use E in Harass", true));
                        Harass.Add(new MenuSeperator("blank"));
                        Harass.Add(new MenuBool("useER", "Use Skill Resets if Possible", true));
                        Harass.Add(new MenuSlider("Mana", "Mana Manager %",  15, 10, 99));
                    }
                }
                RootM.Add(Harass);
                #endregion

                AutoParry= new Menu("ap", "Auto Parry Settings");
                {
                    AutoParry.Add(new MenuList("use", "Use Auto parry", new[] { "Always", "Only Dangerous Spell", "Only In Combo Mode" }, 0));
                    AutoParry.Add(new MenuBool("dsd", "Disable All Drawings", true));
                    AutoParry.Add(new MenuBool("cdl", "Consider Danger Level", true));
                    AutoParry.Add(new MenuSlider("mindanger", "Minimum Danger to use", 2, 1, 5));
                    {
                        AutoParrySub = new Menu("ssk", "Skillshots");
                        for (int i = 0; i < GameObjects.EnemyHeroes.Count(); i++)
                        {
                            var hero = GameObjects.EnemyHeroes.ElementAt(i);
                            foreach (var sp in SpellDatabase.Spells.Where(enemy => (enemy.charName == hero.ChampionName)))
                            {
                                var danger = sp.dangerlevel > 3 ;
                                AutoParrySub2 = new Menu(hero.ChampionName+sp.spellName, sp.charName + " - "+sp.name);
                                AutoParrySub2.Add(new MenuBool("Enable", "Enabled", true));
                                AutoParrySub2.Add(new MenuBool("danger", "Is Dangerous", true));
                                AutoParrySub2.Add(new MenuBool("DrawSpell", "Draw Spells", true));
                                AutoParrySub2.Add(new MenuSlider("ignorehp", "Ignore Above Hp %", 100, 1, 100));
                                AutoParrySub2.Add(new MenuSlider("dangerlevel", "Danger Level", sp.dangerlevel, 1, 5));
                                AutoParrySub2.Add(new MenuSeperator("b", "Spell Type =  "+sp.spellType));
                           }
                            AutoParrySub.Add(AutoParrySub2);
                        }
                    }
                    AutoParry.Add(AutoParrySub);
                    AutoParry.Add(new MenuSeperator("2", "Auto Parry has not implemented yet"));
                    AutoParry.Add(new MenuSeperator("1", "Very Soon"));
                }
                RootM.Add(AutoParry);
                #region farm
                Farm = new Menu("farm", "Farm Settings");
                {
                    LaneClear = new Menu("laneclear", "LaneClear Settings");
                    {
                        LaneClear.Add(new MenuBool("useQ", "Use Q in LaneClear", true));
                        LaneClear.Add(new MenuList("qcount", "Q Clear Logic",  new[] { "Only if killable", "Always" }, 0));
                        LaneClear.Add(new MenuBool("useE", "Use E in LaneClear", true));

                        LaneClear.Add(new MenuSeperator("blank1"));
                        LaneClear.Add(new MenuSeperator("energylane", "Mana Manager"));
                        LaneClear.Add(new MenuSlider("QMana", "Q Skill Mana Manager  %",  30, 10, 99));
                        LaneClear.Add(new MenuSlider("EMana", "E Skill Mana Manager  %",  30, 10, 99));
                    }
                    Farm.Add(LaneClear);

                    /* JungleClear = new Menu("jungleclear", "JungleClear Settings");
                         {
                             JungleClear.Add(new MenuBool("useQ", "Use Q in JungleClear", true));
                             JungleClear.Add(new MenuBool("useW", "Use W in JungleClear", true));
                             JungleClear.Add(new MenuBool("useE", "Use E in JungleClear", true));
                             JungleClear.Add(new MenuSeperator("blank1"));
                             JungleClear.Add(new MenuSeperator("energylane", "Energy Manager"));
                             JungleClear.Add(new MenuSliderBool("QMana", "Q Skill Energy Manager  %", true, 30, 10, 99));
                             JungleClear.Add(new MenuSliderBool("WMana", "W Skill Energy Manager  %", true, 30, 10, 99));
                             JungleClear.Add(new MenuSliderBool("Emana", "E Skill Energy Manager  %", true, 30, 10, 99));
                         }
                         Farm.Add(JungleClear);*/

                    LastHit = new Menu("lasthit", "LastHit Settings");
                    {
                        LastHit.Add(new MenuBool("autolasthit", "Use Auto LastHit", false));
                        LastHit.Add(new MenuBool("useQ", "Use Q in LastHit", true));
                        LastHit.Add(new MenuBool("useE", "Use E in LastHit", true));
                        LastHit.Add(new MenuSeperator("blank1"));
                        LastHit.Add(new MenuSeperator("energylane", "Mana Manager"));
                        LastHit.Add(new MenuSlider("QMana", "Q Skill Energy Manager  %",  30, 10, 99));
                        LastHit.Add(new MenuSlider("EMana", "E Skill Energy Manager  %",  30, 10, 99));
                    }
                    Farm.Add(LastHit);
                }
                RootM.Add(Farm);
                #endregion

                #region Escape Menu
                {
                    Escape = new Menu("escape", "Escape Settings");
                    Escape.Add(new MenuBool("useQ", "Use Q While Escape", false));
                }
                RootM.Add(Escape);
                #endregion

                #region Killsteal
                {
                    KillSteal = new Menu("killsteal", "KillSteal Settings");
                    {

                    }
                    KillSteal.Add(new MenuBool("ks", "Use KillSteal", true));
                    KillSteal.Add(new MenuBool("useQ", "Steal with Q", true));
                    KillSteal.Add(new MenuBool("useW", "Steal with W", true));
                    if (IsIgnite)
                    {
                        KillSteal.Add(new MenuBool("useI", "Use Ignite Killsteal", true));
                    }
            }

                RootM.Add(KillSteal);
                #endregion

                #region Misc Menu
                {
                    /*   Misc = new Menu("misc", "Misc Settings");
                       {
                           TurretDive = new Menu("turretdive", "Turret Dive Settings");
                           {
                               TurretDive.Add(new MenuBool("use", "Use Turret Dive Settings", false));
                               TurretDive.Add(new MenuList("turretdivelogic", "Turret Dive Mode", new[] { "Normal Mode", "Krystra Mode" }, 0));
                               TurretDive.Add(new MenuBool("Drawturret", "Draw Turret Range", false));
                               TurretDive.Add(new MenuSeperator("blank1"));
                               TurretDive.Add(new MenuSeperator("nmb", "Normal Mode Settings >"));
                               TurretDive.Add(new MenuSliderBool("normalmode", "Minimum Number of Ally Minions", true, 3, 1, 8));
                               TurretDive.Add(new MenuSliderBool("health", "Do not dive if my health > % ", true, 30, 10, 99));
                               TurretDive.Add(new MenuSeperator("blank2"));
                               TurretDive.Add(new MenuSeperator("knmb", "Krystra  Mode Settings >"));
                               TurretDive.Add(new MenuSliderBool("krystramode", "Minimum Number of Ally Minions", true, 3, 1, 8));
                               TurretDive.Add(new MenuSliderBool("krystramode2", "Minimum Number of Ally Champions", true, 2, 1, 4));
                               TurretDive.Add(new MenuSliderBool("health1", "Do not dive if my health > % ", true, 30, 10, 99));
                           }
                           Misc.Add(TurretDive);
                           SkinHack = new Menu("skinhack", "Skinhack Settings");
                           {
                               SkinHack.Add(new MenuBool("useskin", "Use Skin Hack", false));
                               SkinHack.Add(new MenuList("selectedskin", "Select Skin", new[] { "Classic", "Shockblade", "SKT T1", "PROJECT" }, 0));
                           }
                           Misc.Add(SkinHack);
                           AutoLevel = new Menu("autolevel", "AutoLevel Settings");
                           {
                               AutoLevel.Add(new MenuBool("uselevel", "Use Auto Level", false));
                               AutoLevel.Add(new MenuList("logic", "Select Skill Order", new[] { "Focus Q>W>E", "Focus Q>E>W", "Focus W>Q>E", "Focus W>E>Q", "Focus E>W>Q", "Focus E>Q>W", "Smart" }, 6));
                           }
                           Misc.Add(AutoLevel);
                           AntiAfk = new Menu("antiafk", "AntiAfk Settings");
                           {
                               AntiAfk.Add(new MenuBool("antiafk", "Use Anti Afk", false));
                           }
                           Misc.Add(AntiAfk);
                       }*/
                }
                RootM.Add(Misc);
                #endregion

                #region Drawing Menu
                {
                    Draw = new Menu("draw", "Drawing Settings");
                    {
                        DrawOptions = new Menu("drawS", "Skill Drawing Settings");
                        DrawOptions.Add(new MenuBool("qdraw", "Draw Q Range", true));
                        DrawOptions.Add(new MenuBool("wdraw", "Draw W Range", false));
                        DrawOptions.Add(new MenuBool("edraw", "Draw E Range", false));
                        DrawOptions.Add(new MenuBool("rdraw", "Draw R Range", false));
                    }
                    Draw.Add(DrawOptions);
                    Draw.Add(new MenuBool("vital", "Draw Vital Spots", false));
                    // Draw.Add(new MenuBool("damage", "Draw Damage Indicator", false));
                    // Draw.Add(new MenuBool("targetcal", "Target Calculation", false));
                    Draw.Add(new MenuBool("disable", "Disable All Drawings", false));

                }
                RootM.Add(Draw);
                #endregion

                #region Key Menu
                {
                    Key = new Menu("keys", "Key Settings");
                    Key.Add(new MenuSeperator("other", "Other Key Settings"));
                    Key.Add(new MenuKeyBind("escape", "Escape Key", KeyCode.Y, KeybindType.Press));
                    Key.Add(new MenuKeyBind("walljump", "Wall Jump Key", KeyCode.H, KeybindType.Press));
                    Key.Add(new MenuSeperator("Combo,Harass,Clear keys are the same with orbwalker"));

                }
                RootM.Add(Key);
                #endregion
                
                RootM.Add(new MenuSeperator("1", "The Grand Duelist"));
                RootM.Add(new MenuSeperator("2", "Script Version : Beta Release"));
                RootM.Add(new MenuSeperator("3", "The Grand Duelist was made by Krystra"));
                RootM.Add(new MenuSeperator("4", "Leauge Of Legends Version: 7.14"));
                RootM.Attach();
            }

        }
}
}
