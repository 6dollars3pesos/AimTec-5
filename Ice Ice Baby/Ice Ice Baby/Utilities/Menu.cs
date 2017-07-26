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

namespace Ice_Ice_Baby
{
    internal partial class Liss
    {
        #region Static Operations
        public static Menu RootM, AutoW, SK, Rloc, Eloc, Combo, ComboBack, ComboLogics, ComboBlacklist, Harass, AutoHarass, Farm, LastHit, LaneClear, JungleClear, OneShot,
            KillSteal, Escape, Draw, AutoR, DrawOptions, Misc, TurretDive, SkinHack, AutoLevel, AntiAfk, Key;
        #endregion
        public void LoadMenu()
        {
            RootM = new Menu("champname", "Ice Ice Baby - [Lissandra]", true);
            Orbwalker.Implementation.Attach(RootM);
            {
                #region combo
                {
                    Combo = new Menu("combo", "Combo Settings");
                    Combo.Add(new MenuBool("useQ", "Use Q in Combo", true));
                    Combo.Add(new MenuBool("useW", "Use W in Combo", true));
                    Combo.Add(new MenuBool("useE", "Use E in Combo", true));
                    Combo.Add(new MenuBool("useR", "Use R in Combo", true));
                    if (IsIgnite)
                    {
                        Combo.Add(new MenuBool("useI", "Use Ignite in Combo", true));
                    }
                    Combo.Add(new MenuSliderBool("Mana", "Mana Manager %", true, 15, 10, 99));

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
                        Harass.Add(new MenuBool("useW", "Use W in Harass", true));
                        Harass.Add(new MenuBool("useE", "Use E in Harass", true));
                        Harass.Add(new MenuBool("autoq", "Use Auto Q Harass", false));
                        Harass.Add(new MenuSliderBool("Mana", "Mana Manager %", true, 15, 10, 99));
                    }
                }
                RootM.Add(Harass);
                #endregion

                #region skilllogic
                {
                    SK = new Menu("skill", "Skill Settings");
                    {
                        Eloc = new Menu("Elogic", "E Skill Settings");
                        Eloc.Add(new MenuList("combo", "E Logic for combo mode", new[] { "Engage with second E", "Do not use Second E ( Recomended)" }, 1));
                        Eloc.Add(new MenuList("harass", "E Logic for harass mode", new[] { "Engage with second E", "Do not use Second E ( Recomended)" }, 1));
                    }
                    SK.Add(Eloc);
                    {
                        Rloc = new Menu("Rlogic", "R Skill Settings");
                        Rloc.Add(new MenuList("rlogic", "R Unit Selection for combo mode", new[] { "Smart", "save for yourself Only", " Always use for enemy" }, 0));
                        Rloc.Add(new MenuList("rlogic2", "R logic combo mode", new[] { "Burst", "Only Secure Kill" }, 0));
                        Rloc.Add(new MenuBool("enableautoR", "Enable Auto R yourself", true));
                        Rloc.Add(new MenuSlider("autorhp", "Auto R for yourself if hp under -> %", 15, 10, 100));

                        SK.Add(Rloc);
                    }
                }
                RootM.Add(SK);
                #endregion

                #region farm
                Farm = new Menu("farm", "Farm Settings");
                    {
                        LaneClear = new Menu("laneclear", "LaneClear Settings");
                        {
                            LaneClear.Add(new MenuBool("useQ", "Use Q in LaneClear", true));
                            LaneClear.Add(new MenuSlider("qcount", "Minimum minion to Q", 2, 1, 10));
                            LaneClear.Add(new MenuBool("useW", "Use W in LaneClear", true));
                            LaneClear.Add(new MenuSlider("wcount", "Minimum minion to W",  2, 1, 10));
                            LaneClear.Add(new MenuBool("useE", "Use E in LaneClear", false));
                            LaneClear.Add(new MenuSlider("ecount", "Minimum minion to E", 2, 1, 10));

                            LaneClear.Add(new MenuSeperator("blank1"));
                            LaneClear.Add(new MenuSeperator("energylane", "Mana Manager"));
                            LaneClear.Add(new MenuSlider("QMana", "Q Skill Mana Manager  %",  30, 10, 99));
                            LaneClear.Add(new MenuSlider("WMana", "W Skill Mana Manager  %",  30, 10, 99));
                            LaneClear.Add(new MenuSlider("Emana", "E Skill Mana Manager  %",  30, 10, 99));
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
                            LastHit.Add(new MenuBool("useW", "Use W in LastHit", false));
                            LastHit.Add(new MenuBool("useE", "Use E in LastHit", false));
                            LastHit.Add(new MenuSeperator("blank1"));
                            LastHit.Add(new MenuSeperator("energylane", "Mana Manager"));
                            LastHit.Add(new MenuSlider("QMana", "Q Skill Mana Manager  %",  30, 10, 99));
                            LastHit.Add(new MenuSlider("WMana", "W Skill Mana Manager  %",  30, 10, 99));
                            LastHit.Add(new MenuSlider("Emana", "E Skill Mana Manager  %", 30, 10, 99));
                        }
                        Farm.Add(LastHit);
                    }
                    RootM.Add(Farm);
                    #endregion

                    #region Killsteal
                    {
                        KillSteal = new Menu("killsteal", "KillSteal Settings");
                        {

                        }
                        KillSteal.Add(new MenuBool("ks", "Use KillSteal", true));
                        KillSteal.Add(new MenuBool("useQ", "Use Q in Killsteal", true));
                        KillSteal.Add(new MenuBool("useW", "Use W in Killsteal", true));
                        KillSteal.Add(new MenuBool("useE", "Use E in Killsteal", true));
                        KillSteal.Add(new MenuBool("useR", "UseR in Killsteal", true));
                        if (IsIgnite)
                        {
                            KillSteal.Add(new MenuBool("useI", "Use Ignite Killsteal", true));
                        }
                    }

                    RootM.Add(KillSteal);
                    #endregion

                    #region Escape Menu
                    {
                        Escape = new Menu("escape", "Escape Settings");
                        Escape.Add(new MenuBool("useW", "Use W While Escape", true));
                        Escape.Add(new MenuBool("useE", "Use E While Escape", true));
                    }
                    RootM.Add(Escape);
                    #endregion

                    #region Misc Menu
                    {
                        Misc = new Menu("misc", "Misc Settings");
                        {
                            AutoW = new Menu("autow", "Auto W Settings");
                            AutoW.Add(new MenuBool("use", "Use Auto W", false));
                            AutoW.Add(new MenuSlider("enemycount", "Minimum Enemy to W", 2, 1, 5));
                        /*    TurretDive = new Menu("turretdive", "Turret Dive Settings");
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
                        Misc.Add(AutoW);

                        AutoR = new Menu("autor", "Auto R Settings");
                        AutoR.Add(new MenuBool("use", "Use Auto R", false));
                        AutoR.Add(new MenuSlider("enemycount", "Minimum Enemy to R", 2, 1, 5));
                        Misc.Add(AutoR);
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
                            Key.Add(new MenuKeyBind("harasskey", "Smart Harass Toggle Key", KeyCode.C, KeybindType.Toggle));
                            Key.Add(new MenuKeyBind("escape", "Escape Key", KeyCode.Y, KeybindType.Press));
                            Key.Add(new MenuSeperator("Combo,Harass,Clear keys are the same with orbwalker"));

                        }
                        RootM.Add(Key);
                        #endregion

                        RootM.Add(new MenuSeperator("1", "Ice Ice Baby"));
                        RootM.Add(new MenuSeperator("2", "Script Version : Beta Release"));
                        RootM.Add(new MenuSeperator("3", "Ice Ice Baby was made by Krystra"));
                        RootM.Add(new MenuSeperator("4", "Leauge Of Legends Version: 7.15"));
                        RootM.Attach();
                    }

                }
            }
        }
    }
