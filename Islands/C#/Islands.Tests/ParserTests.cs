using Islands.Core;
using Islands.Core.Models;
using System.Collections.Generic;
using Xunit;

namespace Islands.Tests
{
    public class ParserTests
    {
        public static IEnumerable<object[]> Lines
        {
            get
            {
                yield return new object[]
                {
                    "3000 5000 50 100 1000 2000 50 20 30",
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
                    }
                };

                yield return new object[]
                {
                    "2000 6000 100 400 500 1000 40 70 131",
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
                    }
                };

                yield return new object[]
                {
                    "5000 2000 900 100 400 5000 1 10 56",
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
                    }
                };

                yield return new object[]
                {
                    "500 1000 100 200 500 10000 42 99 1000",
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
                    }
                };

                yield return new object[]
                {
                    "500 2000 1500 10 500 9000 100 200 400",
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
                    }
                };

                yield return new object[]
                {
                    "1000 1000 2000 10 500 100 100 200 4000",
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
                };
            }
        }

        [Theory]
        [MemberData(nameof(Lines))]
        public void TestLines(string input, Resource[] expected)
        {
            Assert.Equal(expected, Parser.Parse(input));
        }
    }
}
