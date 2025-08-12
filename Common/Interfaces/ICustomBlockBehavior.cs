using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TerrafirmaCombat.Common.Interfaces
{
    public interface ICustomBlockBehavior
    {
        void OnBlocked(Player player, float Power);
    }
}
