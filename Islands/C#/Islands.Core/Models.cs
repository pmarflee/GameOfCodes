using System;
using System.Collections.Generic;

namespace Islands.Core.Models
{
    public enum ResourceType
    {
        Water = 1,
        Wood = 2,
        Coal = 3,
        Iron = 4,
        Stone = 5,
        Obsidian = 6,
        Copper = 7,
        Gold = 8,
        Silver = 9
    }

    public class Resource
    {
        public Resource(ResourceType type, Double quantity)
        {
            Type = type;
            Quantity = quantity;
        }

        public ResourceType Type { get; }

        public Double Quantity { get; }

        public static IEnumerable<(ResourceType, Double)> Priorities
            = new[] 
            {
                (ResourceType.Water, 0.3),
                (ResourceType.Wood, 0.15),
                (ResourceType.Coal, 0.1),
                (ResourceType.Iron, 0.05),
                (ResourceType.Stone, 0.1),
                (ResourceType.Obsidian, 0.15),
                (ResourceType.Copper, 0.05),
                (ResourceType.Gold, 0.03),
                (ResourceType.Silver, 0.07)
            };

        public override bool Equals(object obj)
        {
            var other = obj as Resource;

            if (other == null) return false;

            return Type == other.Type && Quantity == other.Quantity;
        }

        public override int GetHashCode()
        {
            unchecked // disable overflow, for the unlikely possibility that you
            {         // are compiling with overflow-checking enabled
                int hash = 27;
                hash = (13 * hash) + Type.GetHashCode();
                hash = (13 * hash) + Quantity.GetHashCode();
                return hash;
            }
        }
    }
}
