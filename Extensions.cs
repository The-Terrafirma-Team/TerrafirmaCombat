using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrafirmaCombat.Common;

namespace TerrafirmaCombat
{
    public static class Extensions
    {
        public static PlayerStats PlayerStats(this Player player)
        {
            return player.GetModPlayer<PlayerStats>();
        }
        public static NPCStats NPCStats(this NPC npc)
        {
            return npc.GetGlobalNPC<NPCStats>();
        }
        public static bool CheckTension(this Player player, int Tension, bool Consume = true)
        {
            PlayerStats pStats = player.PlayerStats();
            if (pStats.Tension >= Tension)
            {
                if (Consume)
                {
                    pStats.Tension -= player.ApplyTensionBonusScaling(Tension, true);
                }
                return true;
            }
            return false;
        }
        public static void GiveTension(this Player player, int Tension, bool Numbers = true)
        {
            PlayerStats pStats = player.PlayerStats();
            int gain = (int)(Tension * pStats.TensionGainMultiplier);
            pStats.Tension += gain;
            if (pStats.Tension > pStats.TensionMax2)
                pStats.Tension = pStats.TensionMax2;
            if (Numbers)
                CombatText.NewText(player.Hitbox, new Color(64,222,170), gain);
        }
        public static int ApplyTensionBonusScaling(this Player player, int number, bool drain = false)
        {
            PlayerStats stats = player.PlayerStats();
            if (!drain)
            {
                return (int)(number * stats.TensionGainMultiplier) + stats.FlatTensionGain;
            }
            else
            {
                return (int)(number * stats.TensionCostMultiplier) + stats.FlatTensionCost;
            }
        }
        public static Vector2 LengthClamp(this Vector2 vector, float max, float min = 0)
        {
            if (vector.Length() > max) return Vector2.Normalize(vector) * max;
            else if (vector.Length() < min) return Vector2.Normalize(vector) * min;
            else return vector;
        }
        public static void QuickDefaults(this Projectile proj, bool hostile = false, int size = 8, int aiStyle = -1)
        {
            proj.aiStyle = aiStyle;
            proj.hostile = hostile;
            proj.friendly = !hostile;
            proj.width = size;
            proj.height = size;
        }
        public static string NicenUpKeybindNameIfApplicable(string name)
        {
            switch (name)
            {
                case "Mouse1":
                    return Language.GetText("Mods.Terrafirma.KeybindReplacements.Mouse1").Value;
                case "Mouse2":
                    return Language.GetText("Mods.Terrafirma.KeybindReplacements.Mouse2").Value;
                case "Mouse3":
                    return Language.GetText("Mods.Terrafirma.KeybindReplacements.Mouse3").Value;
                case "OemOpenBrackets":
                    return "[";
                case "OemCloseBrackets":
                    return "]";
                case "OemSemiColon":
                    return ";";
                case "OemColon":
                    return ":";
                case "OemQuotes":
                    return "'";
                case "OemComma":
                    return ",";
                case "OemPeriod":
                    return ".";
                case "OemQuestion":
                    return "?";
                case "OemPipe":
                    return "/";
                case "OemPlus":
                    return "+";
                case "OemMinus":
                    return "-";
                default:
                    break;
            }
            return name;
        }
        /// <summary>
        /// Will likely need to be updated as cases arise. Fearful.
        /// </summary>
        public static int FindAppropriateLineForTooltip(this List<TooltipLine> tooltips)
        {
            int index = tooltips.Count;
            for (int i = 0; i < tooltips.Count; i++)
            {
                if (tooltips[i].Mod.Equals("Terraria"))
                {
                    if (tooltips[i].Name.Equals("Defense") || tooltips[i].Name.Equals("Material") || tooltips[i].Name.Equals("Tooltip0") || tooltips[i].Name.Equals("Tooltip1"))
                        index = i + 1;
                }
            }
            //new TooltipLine();
            return index;
        }
    }
}
