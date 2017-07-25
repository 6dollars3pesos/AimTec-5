
using Aimtec;
using Aimtec.SDK.Extensions;

namespace Moon_Moon
{
    internal partial class Diana
    {
        // misc stuff is here
        public bool IsMarked(Obj_AI_Base unit)
        {
            return unit.HasBuff("dianamoonlight");
        }

        public bool IsPassive()
        {
            return MyHero.HasBuff("dianaarcready");
        }
    }
}
