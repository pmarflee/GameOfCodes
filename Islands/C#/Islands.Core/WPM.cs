using Islands.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Islands.Core
{
    public class WPM
    {
        private readonly IEnumerable<(ResourceType, Double)> _priorities;

        public WPM(IEnumerable<(ResourceType, Double)> priorities)
        {
            _priorities = priorities;
        }

        public Double Calculate(IEnumerable<Resource> island1, IEnumerable<Resource> island2)
        {
            return island1
                .Zip(island2, (i1, i2) => new { Island1 = i1, Island2 = i2 })
                .Zip(_priorities, (pair, p) => new { Island1 = pair.Island1, Island2 = pair.Island2, Priority = p })
                .Aggregate(1d, (acc, item) => acc * Calculate(item.Island1, item.Island2, item.Priority));
        }

        private Double Calculate(Resource island1, Resource island2, (ResourceType, Double) priority)
        {
            var (type, weighting) = priority;

            return Math.Pow((island1.Quantity / island2.Quantity), weighting);
        }
    }
}
