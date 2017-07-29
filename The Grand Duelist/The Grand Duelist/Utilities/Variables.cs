using Aimtec;
using Aimtec.SDK.TargetSelector;
using System.Collections.Generic;
using Aimtec.SDK.Orbwalking;

namespace The_Grand_Duelist
{
    internal partial class Fiora
    {
        public static Obj_AI_Hero MyHero => ObjectManager.GetLocalPlayer();
        public Obj_AI_Hero target;
        public List<GameObject> VitalSpots = new List<GameObject>();
        public string[] VitalSpotArray =new string [8] {"Fiora_Base_Passive_SE.troy", "Fiora_Base_Passive_NE.troy", "Fiora_Base_Passive_SW.troy", "Fiora_Base_Passive_NW.troy"
            , "Fiora_Base_R_Mark_SE_FioraOnly.troy", "Fiora_Base_R_Mark_NE_FioraOnly.troy", "Fiora_Base_R_Mark_SW_FioraOnly.troy",
            "Fiora_Base_R_Mark_NW_FioraOnly.troy"};
        public int DrawCRTick = 130;
        public int DrawCR2Tick = 50;
        public int DrawCTick = 0;
        public float DrawC2Tick = 0;
        public bool walljump = false;
        public string Thydra = "ItemTitanicHydraCleave";
        public string Tiamat = "ItemTiamatCleave";


        public static Orbwalker Orbwalker = new Orbwalker();
        //other variables
    }
}
