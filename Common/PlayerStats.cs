using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace TerrafirmaCombat.Common
{
    public class PlayerStats : ModPlayer
    {
        public int ParryDamage = 0;

        // Tension
        public int Tension = 50;
        public int TensionMax = 50;
        public int TensionMax2 = 0;
        public float TensionGainMultiplier = 1f;
        public float TensionCostMultiplier = 1f;
        public int FlatTensionGain = 0;
        public int FlatTensionCost = 0;
        public override void ResetEffects()
        {
            TensionMax2 = TensionMax;
            Tension = Math.Clamp(Tension, 0, TensionMax2);
            TensionGainMultiplier = 1f;
            TensionCostMultiplier = 1f;
            FlatTensionGain = 0;
            FlatTensionCost = 0;
            ParryDamage = 8;
        }
    }
}
