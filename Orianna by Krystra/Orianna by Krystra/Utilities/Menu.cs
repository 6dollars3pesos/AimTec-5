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
namespace Orianna_by_Krystra
{
    internal partial class Ori
    {
        #region Static Operations
        public static Menu RootM, Combo, Auto, ComboBack, Blockr, ComboLogics, ComboBlacklist, Harass, AutoHarass, Farm, LastHit, LaneClear, JungleClear, OneShot,
            KillSteal, Escape, Draw, WShadow, RShadow, DrawOptions, Misc, TurretDive, SkinHack, AutoLevel, AntiAfk, Key;
        #endregion
        public void LoadMenu()
        {
            RootM = new Menu("orianna", "Big Fat Ball- [Orianna]", true);
            Orbwalker.Implementation.Attach(RootM);
            {
                #region combo
                {
                    Combo = new Menu("combo", "Combo Settings");
                    Combo.Add(new MenuBool("useQ", "Use Q in Combo", true));
                    Combo.Add(new MenuBool("useW", "Use W in Combo", true));
                    Combo.Add(new MenuList("useE", "E logic for combo", new[] { "If my hp below", "Always", " Never" }, 0));
                    Combo.Add(new MenuSeperator("blank1", " R Settings"));
                    Combo.Add(new MenuBool("useR", "Use R  For Single Target", true));
                    Combo.Add(new MenuList("rlogic", "R logic (Single Target)", new[] { "Smart", "If Target Killable", "Always" }, 0));
                    Combo.Add(new MenuBool("UseRM", "Use R for Multiple Target", true));
                    Combo.Add(new MenuSlider("rcount", "Use R Min Count", 3, 2, 5));
                    if (IsIgnite)
                    {
                        Combo.Add(new MenuBool("useI", "Use Ignite in Combo", true));
                    }
                    Combo.Add(new MenuSlider("Mana", "Mana Manager %", 15, 10, 99));

                    ComboBlacklist = new Menu("blacklist", "Blacklist For Ulti");
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
                        Harass.Add(new MenuBool("useW", "Use W in Harass", true));
                        Harass.Add(new MenuSlider("Mana", "Mana Manager %", 15, 10, 99));
                    }
                }
                RootM.Add(Harass);
                #endregion

                #region farm
                Farm = new Menu("farm", "Farm Settings");
                {
                    LaneClear = new Menu("laneclear", "LaneClear Settings");
                    {
                        LaneClear.Add(new MenuBool("useQ", "Use Q in LaneClear", true));
                        LaneClear.Add(new MenuSlider("qcount", "Minimum minion to Q",  2, 1, 10));
                        LaneClear.Add(new MenuBool("useW", "Use W in LaneClear", true));
                        LaneClear.Add(new MenuSlider("wcount", "Minimum minion to W",  2, 1, 10));

                        LaneClear.Add(new MenuSeperator("blank1"));
                        LaneClear.Add(new MenuSeperator("energylane", "Mana Manager"));
                        LaneClear.Add(new MenuSlider("QMana", "Q Skill Mana Manager  %",  30, 10, 99));
                        LaneClear.Add(new MenuSlider("WMana", "W Skill Mana Manager  %",  30, 10, 99));

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
                        LastHit.Add(new MenuSeperator("blank1"));
                        LastHit.Add(new MenuSeperator("energylane", "Mana Manager"));
                        LastHit.Add(new MenuSliderBool("QMana", "Q Skill Mana Manager  %", true, 30, 10, 99));

                    }
                    Farm.Add(LastHit);
                }
                RootM.Add(Farm);
                #endregion
                #region Escape Menu
                {
                    Escape = new Menu("escape", "Escape Settings");
                    Escape.Add(new MenuBool("useE", "Use E While Escape", true));
                }
                RootM.Add(Escape);
                #endregion
                #region Killsteal
                {
                    KillSteal = new Menu("killsteal", "KillSteal Settings");
                    {

                    }
                    KillSteal.Add(new MenuBool("ks", "Use KillSteal", true));
                    KillSteal.Add(new MenuBool("useQ", "Use Q in Killsteal", true));
                    KillSteal.Add(new MenuBool("useW", "Use W in Killsteal", true));
                    KillSteal.Add(new MenuBool("useR", "UseR in Killsteal", true));
                    if (IsIgnite)
                    {
                        KillSteal.Add(new MenuBool("useI", "Use Ignite Killsteal", true));
                    }
            }

                RootM.Add(KillSteal);
                #endregion

                #region Misc Menu
                {
                      Misc = new Menu("misc", "Misc Settings");
                       {
                        {
                            Auto = new Menu("auto", "Auto Settings");
                            Auto.Add(new MenuBool("useW", "Use W (Multiple Target)", false));
                            Auto.Add(new MenuSlider("wcount", "Use W Minimum Count",  3, 1, 5));
                            Auto.Add(new MenuBool("useR", "Use R (Multiple Target)", true));
                            Auto.Add(new MenuSlider("rcount", "Use R Minimum Count",  3, 1, 5));

                        }
                        Misc.Add(Auto);
                        {
                            Blockr = new Menu("blockr", "Block R Settings");
                            Blockr.Add(new MenuBool("use", "Block R if hit <= enemy", true));
                            Blockr.Add(new MenuSlider("rcount", "Minimum enemy", 0, 0, 5));

                        }
                        Misc.Add(Blockr);
                        /*
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
                          Misc.Add(AntiAfk);*/
                    }
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
                    Draw.Add(DrawOptions);//ball drawings!
                    // Draw.Add(new MenuBool("damage", "Draw Damage Indicator", false));
                    // Draw.Add(new MenuBool("targetcal", "Target Calculation", false));
                    Draw.Add(new MenuBool("disable", "Disable All Drawings", false));

                }
                RootM.Add(Draw);
                #endregion

                #region Key Menu
                {
                    Key = new Menu("keys", "Key Settings");
                    Key.Add(new MenuSeperator("harass1", "Harass Key Settings"));
                    Key.Add(new MenuKeyBind("harass", "Smart Auto Q Harass", KeyCode.T, KeybindType.Toggle));
                    Key.Add(new MenuSeperator("other", "Other Key Settings"));
                    Key.Add(new MenuKeyBind("escape", "Escape Key", KeyCode.Y, KeybindType.Press));

                }
                RootM.Add(Key);
                #endregion

                RootM.Add(new MenuSeperator("1", "Big Fat Ball"));
                RootM.Add(new MenuSeperator("2", "Script Version : Beta Release"));
                RootM.Add(new MenuSeperator("3", "Script was made by Krystra"));
                RootM.Add(new MenuSeperator("4", "Leauge Of Legends Version: 7.15"));
                RootM.Attach();
            }

        }
}
}
