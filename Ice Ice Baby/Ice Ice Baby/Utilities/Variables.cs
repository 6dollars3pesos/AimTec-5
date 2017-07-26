using Aimtec;
using Aimtec.SDK.TargetSelector;


namespace Ice_Ice_Baby
{
    internal partial class Liss
    {
        public static Obj_AI_Hero MyHero => ObjectManager.GetLocalPlayer();
        public Obj_AI_Hero target;
        public int globalticker = 0;
        //other variables
    }
}
