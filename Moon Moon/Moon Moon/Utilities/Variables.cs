using Aimtec;
using Aimtec.SDK.TargetSelector;



namespace Moon_Moon
{
    internal partial class Diana
    {
        public static Obj_AI_Hero MyHero => ObjectManager.GetLocalPlayer();
        public Obj_AI_Hero target = TargetSelector.GetTarget(925);
        //other variables
    }
}
