using Islands.Core;
using Islands.Core.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Islands.Tests
{
    public class WPMTests
    {
        public static IEnumerable<object[]> TestCalculateData
        {
            get
            {
                var priorities = new[]
                {
                    (ResourceType.Water, 0.2),
                    (ResourceType.Wood, 0.15),
                    (ResourceType.Coal, 0.4),
                    (ResourceType.Iron, 0.25)
                };
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

                yield return new object[] { priorities, islands[0], islands[1], 1.007 };
                yield return new object[] { priorities, islands[0], islands[2], 1.067 };
                yield return new object[] { priorities, islands[1], islands[2], 1.059 };
            }
        }

        public static IEnumerable<object[]> TestRankData
        {
            get
            {
                yield return new object[]
                {
                    Resource.Priorities,
                    new[]
                    {
                        new[]
                        {
                            new Resource(ResourceType.Water, 3000),
                            new Resource(ResourceType.Wood,  5000),
                            new Resource(ResourceType.Coal, 50),
                            new Resource(ResourceType.Iron, 100),
                            new Resource(ResourceType.Stone, 1000),
                            new Resource(ResourceType.Obsidian, 2000),
                            new Resource(ResourceType.Copper, 50),
                            new Resource(ResourceType.Gold, 20),
                            new Resource(ResourceType.Silver, 30)
                        },
                        new[]
                        {
                            new Resource(ResourceType.Water, 2000),
                            new Resource(ResourceType.Wood,  6000),
                            new Resource(ResourceType.Coal, 100),
                            new Resource(ResourceType.Iron, 400),
                            new Resource(ResourceType.Stone, 500),
                            new Resource(ResourceType.Obsidian, 1000),
                            new Resource(ResourceType.Copper, 40),
                            new Resource(ResourceType.Gold, 70),
                            new Resource(ResourceType.Silver, 131)
                        },
                        new[]
                        {
                            new Resource(ResourceType.Water, 5000),
                            new Resource(ResourceType.Wood,  2000),
                            new Resource(ResourceType.Coal, 900),
                            new Resource(ResourceType.Iron, 100),
                            new Resource(ResourceType.Stone, 400),
                            new Resource(ResourceType.Obsidian, 5000),
                            new Resource(ResourceType.Copper, 1),
                            new Resource(ResourceType.Gold, 10),
                            new Resource(ResourceType.Silver, 56)
                        },
                        new[]
                        {
                            new Resource(ResourceType.Water, 500),
                            new Resource(ResourceType.Wood,  1000),
                            new Resource(ResourceType.Coal, 100),
                            new Resource(ResourceType.Iron, 200),
                            new Resource(ResourceType.Stone, 500),
                            new Resource(ResourceType.Obsidian, 10000),
                            new Resource(ResourceType.Copper, 42),
                            new Resource(ResourceType.Gold, 99),
                            new Resource(ResourceType.Silver, 1000)
                        },
                        new[]
                        {
                            new Resource(ResourceType.Water, 500),
                            new Resource(ResourceType.Wood,  2000),
                            new Resource(ResourceType.Coal, 1500),
                            new Resource(ResourceType.Iron, 10),
                            new Resource(ResourceType.Stone, 500),
                            new Resource(ResourceType.Obsidian, 9000),
                            new Resource(ResourceType.Copper, 100),
                            new Resource(ResourceType.Gold, 200),
                            new Resource(ResourceType.Silver, 400)
                        },
                        new[]
                        {
                            new Resource(ResourceType.Water, 1000),
                            new Resource(ResourceType.Wood,  1000),
                            new Resource(ResourceType.Coal, 2000),
                            new Resource(ResourceType.Iron, 10),
                            new Resource(ResourceType.Stone, 500),
                            new Resource(ResourceType.Obsidian, 100),
                            new Resource(ResourceType.Copper, 100),
                            new Resource(ResourceType.Gold, 200),
                            new Resource(ResourceType.Silver, 4000)
                        }
                    },
                    new[] { 2, 1, 0, 4, 3, 5 }
                };
            }
        }

        [Theory]
        [MemberData(nameof(TestCalculateData))]
        public void TestCalculate(
            IEnumerable<(ResourceType, Double)> priorities, 
            IEnumerable<Resource> island1, 
            IEnumerable<Resource> island2, 
            Double expected)
        {
            var wpm = new WPM(priorities);
            var actual = wpm.Calculate(island1, island2);

            Assert.Equal(expected, Math.Round(actual, 3));
        }

        [Theory]
        [MemberData(nameof(TestRankData))]
        public void TestRank(
            IEnumerable<(ResourceType, Double)> priorities, 
            IEnumerable<IEnumerable<Resource>> islands,
            IEnumerable<int> expected)
        {
            var wpm = new WPM(priorities);

            Assert.Equal(expected, wpm.Rank(islands));
        }
    }
}
