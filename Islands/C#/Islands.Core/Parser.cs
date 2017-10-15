using Islands.Core.Models;
using System;
using System.Linq;

namespace Islands.Core
{
    public static class Parser
    {
        public static Resource[] Parse(string input)
        {
            var types = Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>();
            var values = input.Split(' ');

            return types.Zip(values, (type, value) => new Resource(type, Double.Parse(value))).ToArray();
        }
    }
}
