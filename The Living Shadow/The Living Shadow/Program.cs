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
                Console.WriteLine("The Living Shadow by Krystra has been loaded.");
                var Zed = new Zed();
            }

        }
    }
}
