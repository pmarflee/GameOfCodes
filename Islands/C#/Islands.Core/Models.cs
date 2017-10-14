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
        public Resource(ResourceType type, Single quantity)
        {
            Type = type;
            Quantity = quantity;
        }

        public ResourceType Type { get; }

        public Single Quantity { get; }

        public static IReadOnlyCollection<ValueTuple<ResourceType, Single>> Priorities
            = new List<ValueTuple<ResourceType, Single>>
            {
                (ResourceType.Water, 0.3f),
                (ResourceType.Wood, 0.15f),
                (ResourceType.Coal, 0.1f),
                (ResourceType.Iron, 0.05f),
                (ResourceType.Stone, 0.1f),
                (ResourceType.Obsidian, 0.15f),
                (ResourceType.Copper, 0.05f),
                (ResourceType.Gold, 0.03f),
                (ResourceType.Silver, 0.07f)
            }.AsReadOnly();

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
