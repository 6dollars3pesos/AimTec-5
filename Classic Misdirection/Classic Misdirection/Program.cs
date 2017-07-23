
using System;


namespace Classic_Misdirection
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
            if (ObjectManager.GetLocalPlayer().ChampionName == "Leblanc")
            {
                Console.WriteLine("The Classic Misdirection by Krystra has been loaded.");
                var LB = new LB();

            }

        }
    }
}
