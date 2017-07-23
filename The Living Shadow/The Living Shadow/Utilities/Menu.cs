using Aimtec.SDK.Menu;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Orbwalking;
using Aimtec.SDK.Util;
using Aimtec.SDK.Util.Cache;

namespace The_Living_Shadow
{

    internal partial class Zed
    {
        #region Static Operations
        public static Menu RootM, Combo, ComboBack, ComboBlacklist, Harass, AutoHarass, Farm, LastHit, LaneClear, JungleClear, OneShot,
            KillSteal, Escape, Draw, WShadow, RShadow, DrawOptions, Misc, TurretDive, SkinHack, AutoLevel, AntiAfk, Key;
        #endregion

        public void LoadMenu()
        {
            // Inıtialize the first menu
            RootM = new Menu("zed", "The Living Shadow - [Zed]", true);
            Orbwalker.Implementation.Attach(RootM);
            {
                #region  Combo Menu
                {
                    Combo = new Menu("combo", "Combo Settings");
                    {
                        ComboBack = new Menu("turnback", "W/R Turn back settings");
                        {
                            ComboBack.Add(new MenuBool("targetdied", "Turn Back if target died.", false));
                            ComboBack.Add(new MenuSliderBool("swaphp", "Swap W/R if my hp % <= ", true, 15, 10, 99));
                        }
                        Combo.Add(ComboBack);

                        Combo.Add(new MenuBool("useQ", "Use Q in Combo", true));
                        Combo.Add(new MenuBool("useW", "Use W in Combo", true));
                        Combo.Add(new MenuBool("useE", "Use E in Combo", true));
                        Combo.Add(new MenuBool("useR", "Use R in Combo", true));
                        Combo.Add(new MenuList("rlogic", "Combo Logic", new[] { "Use Line Mode", "Use Rectangle Mode", "Use Mouse Position" }, 0));
                        if (IsIgnite)
                        {
                            Combo.Add(new MenuBool("useI", "Use Ignite in Combo", true));
                        }
                        Combo.Add(new MenuSeperator("blank1"));
                        Combo.Add(new MenuSeperator("extra", "Extra Settings"));
                        Combo.Add(new MenuBool("forcer", "Force to start with Ulti"));
                        Combo.Add(new MenuBool("secondw", "Use second W to Chase", true));
                        // Combo.Add(new MenuBool("useitem", "Use Items After R", true));
                        Combo.Add(new MenuBool("wgap", "Use W to Gap Close", false));
                        Combo.Add(new MenuSliderBool("Mana", "Energy Manager %", true, 15, 10, 99));

                        ComboBlacklist = new Menu("blacklist", "Blacklist For Ulti");
                        foreach (var tar in GameObjects.EnemyHeroes)
                        {
                            ComboBlacklist.Add(new MenuBool("use" + tar.ChampionName.ToLower(), "Don't use on :" + tar.ChampionName, true));
                        }
                        Combo.Add(ComboBlacklist);

                    }

                }
                RootM.Add(Combo);
                #endregion

                #region Harass Menu
                {
                    Harass = new Menu("harass", "Harass Settings");
                    {
                        AutoHarass = new Menu("autoharass", "Auto Harass Settings");
                        {
                            AutoHarass.Add(new MenuBool("use", "Use Special Auto Harass", false));
                            AutoHarass.Add(new MenuList("harasslogic", "Special Harass Mode", new[] { "QW", "QWE", "WE" }, 0));
                            AutoHarass.Add(new MenuBool("useQ", "Use Auto Q Harass", false));
                            AutoHarass.Add(new MenuBool("useE", "Use Auto E Harass", false));
                        }
                        Harass.Add(AutoHarass);

                        Harass.Add(new MenuBool("useQ", "Use Q in Harass", true));
                        Harass.Add(new MenuBool("useW", "Use W in Harass", true));
                        Harass.Add(new MenuBool("useE", "Use E in Harass", true));
                        Harass.Add(new MenuSliderBool("Mana", "Energy Manager %", true, 15, 10, 99));
                    }
                }
                RootM.Add(Harass);
                #endregion

                #region Farm Menu
                {
                    Farm = new Menu("farm", "Farm Settings");
                    {
                        LaneClear = new Menu("laneclear", "LaneClear Settings");
                        {
                            LaneClear.Add(new MenuBool("useQ", "Use Q in LaneClear", true));
                            //  LaneClear.Add(new MenuSliderBool("qcount", "Minimum minion to Q", true, 2, 1, 10));
                            LaneClear.Add(new MenuBool("useW", "Use W in LaneClear", true));
                            LaneClear.Add(new MenuBool("useE", "Use E in LaneClear", true));
                            LaneClear.Add(new MenuSliderBool("ecount", "Minimum minion to E", true, 2, 1, 10));

                            LaneClear.Add(new MenuSeperator("blank1"));
                            LaneClear.Add(new MenuSeperator("energylane", "Energy Manager"));
                            LaneClear.Add(new MenuSliderBool("QMana", "Q Skill Energy Manager  %", true, 30, 10, 99));
                            LaneClear.Add(new MenuSliderBool("WMana", "W Skill Energy Manager  %", true, 30, 10, 99));
                            LaneClear.Add(new MenuSliderBool("Emana", "E Skill Energy Manager  %", true, 30, 10, 99));
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
                            LastHit.Add(new MenuBool("autolasthit", "Use Auto LastHit", true));
                            LastHit.Add(new MenuBool("useQ", "Use Q in LastHit", true));
                            LastHit.Add(new MenuBool("useE", "Use E in LastHit", true));
                            LastHit.Add(new MenuSeperator("blank1"));
                            LastHit.Add(new MenuSeperator("energylane", "Energy Manager"));
                            LastHit.Add(new MenuSliderBool("QMana", "Q Skill Energy Manager  %", true, 30, 10, 99));
                            LastHit.Add(new MenuSliderBool("Emana", "E Skill Energy Manager  %", true, 30, 10, 99));
                        }
                        Farm.Add(LastHit);

                    }
                }
                RootM.Add(Farm);
                #endregion

                #region Escape Menu
                {
                    Escape = new Menu("escape", "Escape Settings");
                    Escape.Add(new MenuBool("useW", "Use W While Escape", true));
                }
                #endregion
                RootM.Add(Escape);
                #region Killsteal Menu
                {
                    KillSteal = new Menu("killsteal", "KillSteal Settings");
                    {
                        OneShot = new Menu("oneshot", "OneShotCombo Settings");
                        OneShot.Add(new MenuBool("oto", "Use One Shot Combo", true));

                        foreach (var tar in GameObjects.EnemyHeroes)
                        {
                            OneShot.Add(new MenuBool(tar.ChampionName.ToLower(), "Use on :" + tar.ChampionName, true));
                        }
                    }
                    KillSteal.Add(OneShot);

                    KillSteal.Add(new MenuBool("ks", "Use KillSteal", true));
                    KillSteal.Add(new MenuBool("useQ", "Use Q in Killsteal", true));
                    KillSteal.Add(new MenuBool("useE", "Use E in Killsteal", true));
                    if (IsIgnite)
                    {
                        KillSteal.Add(new MenuBool("useI", "Use Ignite Killsteal", true));
                    }
                }

                #endregion
                RootM.Add(KillSteal);
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
                        WShadow = new Menu("drawshadowW", "Circle for W Shadow");
                        WShadow.Add(new MenuBool("enable", "Enable", true));
                        WShadow.Add(new MenuBool("timer", "Draw Shadow Time", true));
                    }
                    Draw.Add(WShadow);
                    {
                        RShadow = new Menu("drawshadowR", "Circle for R Shadow");
                        RShadow.Add(new MenuBool("enable", "Enable", true));
                        RShadow.Add(new MenuBool("timer", "Draw Shadow Time", true));
                    }
                    Draw.Add(RShadow);
                    {
                        DrawOptions = new Menu("drawS", "Skill Drawing Settings");
                        DrawOptions.Add(new MenuBool("qdraw", "Draw Q Range", true));
                        DrawOptions.Add(new MenuBool("wdraw", "Draw W Range", false));
                        DrawOptions.Add(new MenuBool("edraw", "Draw E Range", false));
                        DrawOptions.Add(new MenuBool("rdraw", "Draw R Range", false));
                    }
                    Draw.Add(DrawOptions);

                    Draw.Add(new MenuBool("combomode", "Draw Combo Mode", true));
                    // Draw.Add(new MenuBool("damage", "Draw Damage Indicator", false));
                    // Draw.Add(new MenuBool("targetcal", "Target Calculation", false));
                    Draw.Add(new MenuBool("disable", "Disable All Drawings", false));

                }
                #endregion
                RootM.Add(Draw);
                #region Key Menu
                {
                    Key = new Menu("keys", "Key Settings");
                    Key.Add(new MenuSeperator("combo1", "Combo Key Settings"));
                    Key.Add(new MenuKeyBind("combokey", "Combo Key", KeyCode.Space, KeybindType.Press));
                    // Key.Add(new MenuKeyBind("combomode", "Combo Mode Key", KeyCode.G, KeybindType.Press));
                    Key.Add(new MenuSeperator("harass1", "Harass Key Settings"));
                    Key.Add(new MenuKeyBind("harasskey", "Smart Harass Key", KeyCode.C, KeybindType.Press));
                    Key.Add(new MenuSeperator("lane1", "Clear Key Settings"));
                    Key.Add(new MenuKeyBind("lasthitkey", "LastHit Key", KeyCode.X, KeybindType.Press));
                    Key.Add(new MenuKeyBind("laneclearkey", "LaneClear Key", KeyCode.V, KeybindType.Press));
                    //  Key.Add(new MenuKeyBind("jungleclearkey", "JungleClear Key", KeyCode.V, KeybindType.Press));
                    Key.Add(new MenuSeperator("other", "Other Key Settings"));
                    Key.Add(new MenuKeyBind("escape", "Escape Key", KeyCode.Y, KeybindType.Press));

                }

                #endregion
                RootM.Add(Key);
            }
            RootM.Add(new MenuSeperator("1", "The Living Shadow"));
            RootM.Add(new MenuSeperator("2", "Script Version : Beta Release"));
            RootM.Add(new MenuSeperator("3", "Script was made by Krystra"));
            RootM.Add(new MenuSeperator("4", "Leauge Of Legends Version: 7.14"));
            RootM.Attach();
        }
    }
}