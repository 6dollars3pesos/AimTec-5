

using Aimtec;
using Aimtec.SDK.Events;
using System;

namespace Moon_Moon
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEvents.GameStart += OnLoad;
        }
        private static void OnLoad()
        {
            if (ObjectManager.GetLocalPlayer().ChampionName == "Diana")
            {
                Console.WriteLine("Moon Moon Diana by Krystra has been loaded.");
                var Diana = new Diana();

            }

        }
    }
}
