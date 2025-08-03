using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TerrafirmaCombat.Common
{
    public class NPCStats : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool Parried = false;
        public override void ResetEffects(NPC npc)
        {
            Parried = false;
        }
    }
}
