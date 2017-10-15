using Islands.Core;
using Islands.Core.Models;
using System;
using System.Collections.Generic;

namespace Islands
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input (enter a blank line to finish)");

            var islands = new List<Resource[]>();

            while (true)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) break;

                var island = Parser.Parse(input);

                islands.Add(island);
            }

            var wpm = new WPM(Resource.Priorities);

            var ranked = wpm.Rank(islands);

            Console.WriteLine(string.Join(' ', ranked));
        }
    }
}
