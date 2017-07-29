using Aimtec;
using Aimtec.SDK.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krystra_s_Orianna
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEvents.GameStart += OnLoad;
        }
        private static void OnLoad()
        {
            if (ObjectManager.GetLocalPlayer().ChampionName == "Orianna")
            {
                Console.WriteLine("Script Name by Krystra has been loaded.");
                var Template = new Ori();

            }

        }
    }
}
