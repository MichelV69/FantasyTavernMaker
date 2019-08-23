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
     *   Last updated  : Fri 23-Aug-2019 @ 11h47 ADT by m.vaillancourt
     *   
     */
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            PBHouse pbh = new PBHouse();

            int loop_max = 9;

            for (int loop = 0; loop <= loop_max; loop++)
            {
                Console.WriteLine($"Name:  {pbh.Name()}");
                Console.WriteLine($"Current Mood: {pbh.Mood()}");
                Console.WriteLine($"Lighting Environment: {pbh.Lighting()}");
                Console.WriteLine($"Smells of: {pbh.Smells()}");
                Console.WriteLine("  ");
            } // end-for

            // Keep the console window open in debug mode.
            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
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
            // Load a pair of lists with light sources and adjectives, then
            //   pick one for the PBHouse lighting

            // ... create list
            List<string> light_sources_list = new List<string> { };
            List<string> adjectives_list = new List<string> { };

            // ... load lists
            adjectives_list.Add("brightly");
            adjectives_list.Add("clearly");
            adjectives_list.Add("evenly");
            adjectives_list.Add("dimly");
            adjectives_list.Add("shadowly");

            light_sources_list.Add("candles");
            light_sources_list.Add("a fireplace");
            light_sources_list.Add("oil lamps");
            light_sources_list.Add("magic orbs and crystals");

            // ... grab the right words
            string adjectives_string = adjectives_list[RandomNumber(0, adjectives_list.Count - 1)];
            string light_sources_string = light_sources_list[RandomNumber(0, light_sources_list.Count - 1)];

            // ... build the output string
            string lighting_description = $"{adjectives_string} lit by {light_sources_string}";

            // ... return some output
            return lighting_description;
        } // end public string Lighting()

        // -----
        public string Smells()
        {
            // load a pair of lists with a set of adjectives then return one from
            // ... each list for the PBHouse olfactory environment

            // ... create fancy two-column list
            List<List<string>> holding_2col_list = new List<List<string>>();
            List<string> data_col1 = new List<string> { };

            // ... so yes, this is make-work; it's proof-of-understanding
            data_col1.Add("wood smoke");
            data_col1.Add("spices");
            data_col1.Add("perfumes");
            data_col1.Add("weary travellers");
            data_col1.Add("strong drink");
            data_col1.Add("tobacco");
            data_col1.Add("spiced tobacco");
            data_col1.Add("shisha");
            data_col1.Add("fresh linen");
            data_col1.Add("hot bread");
            data_col1.Add("fresh pastries");

            // ... now slot the 'data list' into the 'holding list'
            holding_2col_list.Add(data_col1);

            // ... grab one desc from each column
            string first_word = holding_2col_list[0][RandomNumber(0, holding_2col_list[0].Count - 1)];
            string second_word = holding_2col_list[0][RandomNumber(0, holding_2col_list[0].Count - 1)];

            // ... now return some output
            return $"{first_word} and {second_word}";
        } // end public string Smells()

    } // class PBHouse

} // namespace PBHouse_CLI
