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

namespace Annie_by_Krystra
{
    internal partial class Annie
    {
        #region Static Operations
        public static Menu RootM, AutoR, Combo, SK, AutoStack, Eloc,Pas, Rloc,Qloc,Wloc, AutoS, ComboBack, ComboLogics, ComboBlacklist, Harass, AutoHarass, Farm, LastHit, LaneClear, JungleClear, OneShot,
            KillSteal, Escape, Draw, WShadow, RShadow, DrawOptions, Misc, AutoE, AutoT, TurretDive, SkinHack, AutoLevel, AntiAfk, Key;
        #endregion
        public void LoadMenu()
        {
            RootM = new Menu("annie", "Twerk For Tibbers - [Annie]", true);
            Orbwalker.Implementation.Attach(RootM);
            {
                #region combo
                {
                    Combo = new Menu("combo", "Combo Settings");
                    Combo.Add(new MenuBool("useQ", "Use Q in Combo", true));
                    Combo.Add(new MenuBool("useW", "Use W in Combo", true));
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
                        Harass.Add(new MenuBool("donot", "Do not harass if passive is ready", false));
                        Harass.Add(new MenuSliderBool("Mana", "Mana Manager %", true, 15, 10, 99));
                    }
                }
                RootM.Add(Harass);
                #endregion

                #region skilllogic
                {
                    SK = new Menu("skill", "Skill Settings");
                    {
                        Rloc = new Menu("Rlogic", "R Skill Settings");
                        Rloc.Add(new MenuList("rlogic2", "R Damage Selection", new[] { "Burst", "Only Secure Kill" }, 0));
                        Rloc.Add(new MenuList("rlogic", "R Passive Usage", new[] { "Smart", "Only Stun", " Direct" }, 0));
                        Rloc.Add(new MenuBool("blockR", "Block R Cast if Enemy Number <= ", true));
                        Rloc.Add(new MenuSlider("Rnumber", "Enemy Number", 0, 0, 5));

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
                        LaneClear.Add(new MenuList("qmode", "Select Q Mode", new[] { "Only Last Hit", "Always" }, 0));
                        LaneClear.Add(new MenuBool("useW", "Use W in LaneClear", true));
                        LaneClear.Add(new MenuSlider("wcount", "Minimum minion to W", 2, 1, 10));

                        LaneClear.Add(new MenuSeperator("blank1"));
                        LaneClear.Add(new MenuSeperator("energylane", "Mana Manager"));
                        LaneClear.Add(new MenuSlider("QMana", "Q Skill Energy Manager  %", 30, 10, 99));
                        LaneClear.Add(new MenuSlider("WMana", "W Skill Energy Manager  %",  30, 10, 99));
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
                        LastHit.Add(new MenuSliderBool("QMana", "Q Skill Energy Manager  %", true, 30, 10, 99));
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
                    Escape.Add(new MenuBool("useST", "Use Stan if possible", true));
                    RootM.Add(Escape);
                }
                #endregion


                #region Misc Menu
                {
                    Misc = new Menu("misc", "Misc Settings");
                       {
                        AutoR = new Menu("autor", "Automatic Ulti Usage");
                        {
                            AutoR.Add(new MenuBool("use", "Use Automatic Ulti Usage", true));
                            AutoR.Add(new MenuBool("autor", "Cast R if Enemy Number > ", true));
                            AutoR.Add(new MenuSlider("Enumber", "Enemy Number", 3, 1, 5));
                        }
                           Misc.Add(AutoR);
                        AutoStack = new Menu("autostack", "Automatic Passive Stacking");
                        {
                            AutoStack.Add(new MenuBool("use", "Use Automatic Passive Stacking", true));
                            AutoStack.Add(new MenuSeperator("q","Q Options"));
                            AutoStack.Add(new MenuBool("useQ", "Use Q to Stack Passive ", true));
                            AutoStack.Add(new MenuList("qmode", "Target for Q stack", new[] { "Smart","Only Minions", "Only Enemy (harass)" }, 0));
                            AutoStack.Add(new MenuSeperator("w", "W Options"));
                            AutoStack.Add(new MenuBool("useW", "Use W to Stack Passive ", false));
                            AutoStack.Add(new MenuList("wmode", "Target for W stack", new[] { "Smart", "Only Minions", "Only Enemy (harass)" }, 0));
                            AutoStack.Add(new MenuBool("wbase", "Use W while in base", true));
                            AutoStack.Add(new MenuBool("wrun", "Use W while flee", false));
                            AutoStack.Add(new MenuSeperator("E", "E Options"));
                            AutoStack.Add(new MenuBool("ebase", "Use E while in base", true));
                            AutoStack.Add(new MenuBool("erun", "Use E while flee", true));
                        }
                           Misc.Add(AutoStack);
                        AutoE =new Menu("autoe", "Automatic E Usage");
                        {
                            AutoE.Add(new MenuBool("use", "Use Automatic E Usage", true));
                            AutoE.Add(new MenuSeperator("1", "Use E if incoming attack from ;"));
                            AutoE.Add(new MenuBool("enemyattack", "Enemy Attack", false));
                            AutoE.Add(new MenuBool("turret", "Turret Attack", true));
                            AutoE.Add(new MenuBool("monster", "Monster Attack", false));
                            AutoE.Add(new MenuBool("enemyspell", "Enemy Spell", true));

                        }
                           Misc.Add(AutoE);
                        AutoT = new Menu("autotib", "Automatic Tibbers Plot");
                        {
                            AutoT.Add(new MenuBool("use", "Use Automatic Tibbers Plot", true));
                            AutoT.Add(new MenuList("mode", "Select Mode", new[] { "Follow Target", "Follow Me", "Around Minions" }, 0));

                        }
                           Misc.Add(AutoT);
                        AutoS = new Menu("autostun", "Automatic Stun Usage");
                        {
                            AutoS.Add(new MenuBool("use", "Use Automatic Stun Usage", true));
                            AutoS.Add(new MenuSeperator("R", "R Options"));
                            AutoS.Add(new MenuBool("useR", "Use R for auto stun if enemy =>", true));
                            AutoS.Add(new MenuSlider("Rnumber", "Enemy Number", 3, 1, 5));
                        }
                           Misc.Add(AutoS);
                           /* TurretDive = new Menu("turretdive", "Turret Dive Settings");
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
                    Draw.Add(DrawOptions);
                    //Draw.Add(new MenuBool("tibbers", "Draw Tibbers Timer", true));
                    // Draw.Add(new MenuBool("damage", "Draw Damage Indicator", false));
                    // Draw.Add(new MenuBool("targetcal", "Target Calculation", false));
                    Draw.Add(new MenuBool("disable", "Disable All Drawings", false));

                }
                RootM.Add(Draw);
                #endregion

                #region Key Menu
                {
                    Key = new Menu("keys", "Key Settings");
                    Key.Add(new MenuSeperator("combo1", "Combo Key Settings"));
                    Key.Add(new MenuKeyBind("combomode", "Combo Mode Key", KeyCode.G, KeybindType.Press));
                    Key.Add(new MenuSeperator("harass1", "Harass Key Settings"));
                    Key.Add(new MenuKeyBind("harass", "Smart Auto Q Key", KeyCode.H, KeybindType.Toggle));
                    Key.Add(new MenuSeperator("other", "Other Key Settings"));
                    Key.Add(new MenuKeyBind("escape", "Escape Key", KeyCode.Y, KeybindType.Press));

                }
                RootM.Add(Key);
                #endregion

                RootM.Add(new MenuSeperator("1", "Twerk for Tibbers"));
                RootM.Add(new MenuSeperator("2", "Script Version : Beta Release"));
                RootM.Add(new MenuSeperator("3", "Script was made by Krystra"));
                RootM.Add(new MenuSeperator("4", "Leauge Of Legends Version: 7.15"));
                RootM.Attach();
            }

        }
}
}
