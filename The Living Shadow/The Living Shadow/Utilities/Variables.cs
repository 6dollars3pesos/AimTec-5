using Aimtec;
using Aimtec.SDK.TargetSelector;

namespace The_Living_Shadow
{
    internal partial class Zed

    {
        public Vector3 Wpos;
        public Vector3 Rpos;
        public int Wtimer;
        public int GR = 0;
        public int GW = 0;
        public double Rtimer;
        public int global_ticks = 0;
        public float StartTime = 0f;
        public int LastCastTime = 0;
        public float StartTimeR = 0f;
        public bool Wdmgp = false;
        public bool Rdmgcheck = false;
        public bool Rdmgp = false;
        public static Obj_AI_Hero MyHero => ObjectManager.GetLocalPlayer();
        public Obj_AI_Hero target = TargetSelector.GetTarget(925);
        public bool wgapclose = false;


    }

}

