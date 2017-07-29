using Aimtec;
using Aimtec.SDK.TargetSelector;

namespace Annie_by_Krystra
{
    internal partial class Annie
    {
        public static Obj_AI_Hero MyHero => ObjectManager.GetLocalPlayer();

        public Obj_AI_Hero target;
        public Obj_AI_Minion Tibbers;
        public static readonly string[] TargetedSpells =
        {
            "MonkeyKingQAttack", "FizzPiercingStrike", "IreliaEquilibriumStrike",
            "RengarQ", "GarenQAttack", "GarenRPreCast",
            "PoppyPassiveAttack", "viktorqbuff", "FioraEAttack",
            "TeemoQ"
        };
        public string R1Name ="ınfernalguardian";
        //other variables
    }
}
