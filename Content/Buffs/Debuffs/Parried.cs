using TerrafirmaCombat.Common.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace TerrafirmaCombat.Content.Buffs.Debuffs
{
    public class Parried : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.NPCStats().Parried = true;
            if(Main.rand.NextBool(3))
            Dust.NewDustPerfect(npc.position + new Vector2(Main.rand.NextFloat(npc.width),0),DustID.GoldCoin,new Vector2(0f,-Main.rand.NextFloat()));
        }
    }
}
