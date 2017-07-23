using System;

namespace The_Living_Shadow
{
    using Aimtec;
    using Aimtec.SDK.Events;

    class Program
    {
        static void Main(string[] args)
        {
            GameEvents.GameStart += OnLoad;
        }
        private static void OnLoad()
        {
            if (ObjectManager.GetLocalPlayer().ChampionName == "Zed")
            {
                Console.WriteLine("yüklendi");
                var Zed = new Zed();
            }

        }
    }
}
