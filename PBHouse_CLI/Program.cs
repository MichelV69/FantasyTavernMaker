using System;
using System.Collections;
using System.Collections.Generic;

namespace PBHouse_CLI
{
    /*
     *   DOTNET learning project.  Use existing FantasyGrounds table-data
     *      to 'randomly roll' a 'P&B House' from my Scattered Isles
     *      DnD5e Campaign.
     * 
     *   First created : Thu 22-Aug-2019 @ 15:23 ADT by m.vaillancourt
     *   Last updated  : Thu 22-Aug-2019 @ 16h11 ADT by m.vaillancourt
     *   
     */
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            PBHouse pbh = new PBHouse();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{pbh.Name()}");
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    class PBHouse
    {
        public int RandomNumber(int min, int max)
        {
            // Generate a random number between two numbers
            Random random = new Random();
            return random.Next(min, max);
        }

        public string Name()
        {
            // using a pair of Lists, generate  "Verb Noun" name for our PBHouse
            // ... create the lists

            List<string> name_verb = new List<string> {};
            List<string> name_noun = new List<string> {};

            // ... load the pairs
            name_verb.Add("Waltzing");
            name_noun.Add("Werebear");

            name_verb.Add("Checkered");
            name_noun.Add("Cockrel");

            name_verb.Add("Lazy");
            name_noun.Add("Hen");

            name_verb.Add("Silver");
            name_noun.Add("Dragon");

            name_verb.Add("Saucy");
            name_noun.Add("Wench");

            name_verb.Add("Flirting");
            name_noun.Add("Dryad");

            name_verb.Add("Blue");
            name_noun.Add("Sky");

            name_verb.Add("Red");
            name_noun.Add("Tide");

            name_verb.Add("Green");
            name_noun.Add("Meadow");

            name_verb.Add("Yellow");
            name_noun.Add("Sun");

            name_verb.Add("Fickle");
            name_noun.Add("Fortune");

            name_verb.Add("Roaring");
            name_noun.Add("Waters");

            name_verb.Add("Carousing");
            name_noun.Add("Bard");

            name_verb.Add("Melting");
            name_noun.Add("Crystal");

            name_verb.Add("Drifting");
            name_noun.Add("Ice");

            name_verb.Add("Spring");
            name_noun.Add("Tempest");

            name_verb.Add("Winter");
            name_noun.Add("Snows");

            name_verb.Add("Summer");
            name_noun.Add("Draft");

            name_verb.Add("Autumn");
            name_noun.Add("Harvest");

            name_verb.Add("Pouring");
            name_noun.Add("Chalice");

            name_verb.Add("Heaving");
            name_noun.Add("Waves");

            int name_verb_count = name_verb.Count;
            int name_noun_count = name_noun.Count;

            int name_verb_roll = RandomNumber(0, name_verb_count -1);
            int name_noun_roll = RandomNumber(0, name_noun_count -1);

            return $"the {name_verb[name_verb_roll]} {name_noun[name_noun_roll]}";
        } // end public string Name()
    } // class PBHouse

} // namespace PBHouse_CLI
