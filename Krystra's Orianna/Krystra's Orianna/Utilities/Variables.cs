using Aimtec;
using Aimtec.SDK.TargetSelector;


namespace Krystra_s_Orianna
{
    internal partial class Ori
    {
        public static Obj_AI_Hero MyHero => ObjectManager.GetLocalPlayer();
        public Obj_AI_Hero target;
        public Vector3 Ball;
        public bool Escaping = false;
        public static readonly string[] TargettedSpelCollection =
        {
            "MonkeyKingQAttack", "FizzPiercingStrike", "IreliaEquilibriumStrike",
            "RengarQ", "GarenQAttack", "GarenRPreCast",
            "PoppyPassiveAttack", "viktorqbuff", "FioraEAttack",
            "TeemoQ"
        };
        //other variables
    }
}
