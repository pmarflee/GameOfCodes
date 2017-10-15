using Islands.Core;
using Islands.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Islands.Tests
{
    public class WPMTests
    {
        private static (ResourceType, Double)[] _priorities = new[]
        {
            (ResourceType.Water, 0.2),
            (ResourceType.Wood, 0.15),
            (ResourceType.Coal, 0.4),
            (ResourceType.Iron, 0.25)
        };

        public static IEnumerable<object[]> TestData
        {
            get
            {
                var islands = new Resource[][]
                    {
                        new[]
                        {
                            new Resource(ResourceType.Water, 25),
                            new Resource(ResourceType.Wood, 20),
                            new Resource(ResourceType.Coal, 15),
                            new Resource(ResourceType.Iron, 30)
                        },
                        new[]
                        {
                            new Resource(ResourceType.Water, 10),
                            new Resource(ResourceType.Wood, 30),
                            new Resource(ResourceType.Coal, 20),
                            new Resource(ResourceType.Iron, 30)
                        },
                        new[]
                        {
                            new Resource(ResourceType.Water, 30),
                            new Resource(ResourceType.Wood, 10),
                            new Resource(ResourceType.Coal, 30),
                            new Resource(ResourceType.Iron, 10)
                        }
                    };

                yield return new object[] { islands[0], islands[1], 1.007 };
                yield return new object[] { islands[0], islands[2], 1.067 };
                yield return new object[] { islands[1], islands[2], 1.059 };
            }
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void TestWPM(IEnumerable<Resource> island1, IEnumerable<Resource> island2, Double expected)
        {
            var wpm = new WPM(_priorities);
            var actual = wpm.Calculate(island1, island2);

            Assert.Equal(expected, Math.Round(actual, 3));
        }
    }
}
