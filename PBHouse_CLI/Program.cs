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
     *   Last updated  : Thu 22-Aug-2019 @ 23h00 ADT by m.vaillancourt
     *   
     */
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            PBHouse pbh = new PBHouse();

            for (int loop = 0; loop < 5; loop++)
            {
                Console.WriteLine($"Name:  {pbh.Name()}");
                Console.WriteLine($"Current Mood: {pbh.Mood()}");
                Console.WriteLine("  ");
            } // end-for

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    class PBHouse
    {
        // -----
        public int RandomNumber(int min, int max)
        {
            // Generate a random number between two numbers
            Random random = new Random();
            return random.Next(min, max);
        } // end public int RandomNumber

        // -----
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

            // ... check how long the Lists are
            int name_verb_count = name_verb.Count;
            int name_noun_count = name_noun.Count;

            // ... roll some dice
            int name_verb_roll = RandomNumber(0, name_verb_count -1);
            int name_noun_roll = RandomNumber(0, name_noun_count -1);

            // ... return the result
            return $"the {name_verb[name_verb_roll]} {name_noun[name_noun_roll]}";
        } // end public string Name()

        // -----
        public string Mood()
        {
            // using a list of adjectives, descript the mood of our PBHouse

            // ... create the lists=
            List<string> adjectives_list = new List<string> { };

            // ... load the list
            adjectives_list.Add("jovial");
            adjectives_list.Add("relaxing");
            adjectives_list.Add("smoky");
            adjectives_list.Add("erudite");
            adjectives_list.Add("loud");
            adjectives_list.Add("subdued");
            adjectives_list.Add("rowdy");
            adjectives_list.Add("seedy");
            adjectives_list.Add("shady");
            adjectives_list.Add("busy");
            adjectives_list.Add("lower-class");
            adjectives_list.Add("middle-class");
            adjectives_list.Add("upper-class");
            adjectives_list.Add("merchant-friendly");
            adjectives_list.Add("dour");
            adjectives_list.Add("flirty");

            // ... use a crunchy-format load string
            string mood_description = $"{adjectives_list[RandomNumber(0, adjectives_list.Count -1)]}";

            // ... return the result
            return mood_description;
        } // end public string Mood()

        // -----
        public string Lighting()
        {

        } // end public string Lighting()
    } // class PBHouse

} // namespace PBHouse_CLI
