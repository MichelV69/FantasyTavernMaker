using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

/*
 * First created Mon, Sep 16, 2019 10:22 PM by m.vaillancourt
 *  Last updated Wed, Sep 18, 2019  8:49 PM by m.vaillancourt
*/

namespace PBHouse_CLI
{
    class PBHouse
    {
        // -----
        public string PickFromList(List<string> pick_list)
        {
            // given a list of strings, determine the size of the list and
            // ... random roll to choose one to return
            Random random = new Random();

            int min = 0;
            int max = pick_list.Count - 1;
            int index = random.Next(min, max);

            string picked_word = pick_list[index];
            return picked_word;

        } // end public int PickFromList

        // -----
        public string Name()
        {
            // using a pair of Lists, generate  "Verb Noun" name for our PBHouse

            // ... create the lists
            List<string> name_verb = new List<string> { };
            List<string> name_noun = new List<string> { };

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

            // ... return the result
            return $"the {PickFromList(name_verb)} {PickFromList(name_noun)}";
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

            // ... return the result
            return PickFromList(adjectives_list);
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
            string adjectives_string = PickFromList(adjectives_list);
            string light_sources_string = PickFromList(light_sources_list);

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
            List<string> data_col2 = new List<string> { };

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

            data_col2.Add("fresh pastries");
            data_col2.Add("foods cooking");
            data_col2.Add("the outside surroundings");
            data_col2.Add("the ocean");
            data_col2.Add("the forests");
            data_col2.Add("fermenting wine");
            data_col2.Add("hops");
            data_col2.Add("fermenting rye");
            data_col2.Add("hot spiced cider");
            data_col2.Add("baking sweets");

            // ... now slot the 'data list' into the 'holding list'
            holding_2col_list.Add(data_col1);
            holding_2col_list.Add(data_col2);

            // ... grab one desc from each column
            string first_word = PickFromList(holding_2col_list[0]);
            string second_word = PickFromList(holding_2col_list[1]);

            // ... now return some output
            return $"{first_word} and {second_word}";
        } // end public string Smells()

        // -----
        public string Size()
        {
            // use a weighted case/switch ladder to determine size info for the PBHouse

            // instanciate our external class
            DiceBagEngine diceBag = new DiceBagEngine();

            // init the blank holder variables
            string size_description = "";
            int table_count = 0;
            string common_bed_word = "";
            int common_bed_count = 0;
            int private_room_count = 0;

            // non-linear chance for size
            int dice_roll = diceBag.RollDice("1d12");

            switch (dice_roll)
            {
                case 1:
                    size_description = "tiny";
                    table_count = diceBag.RollDice("2d4");
                    common_bed_word = "hammocks";
                    common_bed_count = diceBag.RollDice("1d4");
                    private_room_count = 0;
                    break;

                case 2:
                case 3:
                case 4:
                    size_description = "small";
                    table_count = diceBag.RollDice("3d4");
                    common_bed_word = "bunk-beds";
                    common_bed_count = diceBag.RollDice("2d4");
                    private_room_count = diceBag.RollDice("1d4");
                    break;

                case 5:
                case 6:
                case 7:
                case 8:
                    size_description = "modest";
                    table_count = diceBag.RollDice("4d6");
                    common_bed_word = "single beds";
                    common_bed_count = diceBag.RollDice("3d6");
                    private_room_count = diceBag.RollDice("2d6");
                    break;

                case 9:
                case 10:
                case 11:
                    size_description = "large";
                    table_count = diceBag.RollDice("5d6");
                    common_bed_word = "tent-beds";
                    common_bed_count = diceBag.RollDice("4d6");
                    private_room_count = diceBag.RollDice("3d6");
                    break;

                case 12:
                    size_description = "massive";
                    table_count = diceBag.RollDice("7d8");
                    common_bed_word = "tent-beds";
                    common_bed_count = diceBag.RollDice("6d8");
                    private_room_count = diceBag.RollDice("4d8");
                    break;

            } // end-switch

            string blurb = $"{size_description}, with {table_count} tables. It has {common_bed_count} {common_bed_word} in the common room and {private_room_count} private rooms";

            return blurb;
        } //public string Size()

        // -----
        public string PostedSign()
        {
            // random select from list of messages and sign locations 
            string sign_description = "";

            // ... create list
            List<string> posted_message = new List<string> { };
            List<string> sign_location = new List<string> { };

            // ... new and shiny advanced file-reading techniqification
            string fileToLoad = Path.Combine(Environment.CurrentDirectory, "table_data/posted_sign.message.data");
            List<string> fileContent = File.ReadAllLines(fileToLoad).ToList();
            posted_message.AddRange(fileContent);

            fileToLoad = Path.Combine(Environment.CurrentDirectory, "table_data/posted_sign.location.data");
            fileContent = File.ReadAllLines(fileToLoad).ToList();
            sign_location.AddRange(fileContent);

            // ... build and return the sign_description
            sign_description = $"a sign {PickFromList(sign_location)} says '{PickFromList(posted_message)}'.";
            return sign_description;
        } // end public string PostedSign()

        // -----
        public string SpecialtyDrink()
        {
            //  Using ale, cider, whiskey, wine and other drink descriptions saved
            //      as indivdual list files, build a description of the PBHouse SpecialtyDrink

            //  init empty vars and create lists
            DiceBagEngine diceBag = new DiceBagEngine();
            string specialty_drink_description = "";
            string coin_type = "";
            string where_made = "";
            string fileToLoad = "";
            List<string> drink_categories = new List<string> { "ales", "ciders", "whiskeys", "rums", "wines", "other_stock" };
            List<string> fileContent = new List<string> { };
            List<string> drink_list = new List<string> { };

            //--  loop the drink_categories list
            foreach (var drink in drink_categories)
            {
                fileToLoad = Path.Combine(Environment.CurrentDirectory, $"table_data/drink_specialty.{drink}.data");
                fileContent = File.ReadAllLines(fileToLoad).ToList();

                //  loop the list, adding it to the drink_list properly postfixed
                for (int loop = 0; loop < fileContent.Count; loop++)
                {
                    string drink_name = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(drink.TrimEnd('s'));
                    if (drink == "other_stock")
                    {
                        drink_name = "";
                    }
                    drink_list.Add($"{fileContent[loop]} {drink_name}".TrimEnd(' '));
                } // end-for
            } // end-foreach


            //--  build the content
            coin_type = "copper";  // TODO:  something clever here where 'wealthy' inns pay silver instead.

            switch (diceBag.RollDice("1d6"))
            {
                case 1:
                    where_made = "an imported";
                    break;
                case 2:
                case 3:
                    where_made = "a locally made";
                    break;
                default:
                    where_made = "the House's own";
                    break;
            } // end-switch

            specialty_drink_description = $"{where_made} {PickFromList(drink_list)}, for {diceBag.RollDice("2d4+3")} {coin_type}";

            //  return some content
            return specialty_drink_description;
        } // public string SpecialtyDrink()

        // -----
        public string SpecialtyFood()
        {
            //  init empty vars and create lists
            DiceBagEngine diceBag = new DiceBagEngine();
            string specialty_food_description = "";
            string coin_type = "";
            string data_slot = "";
            string fileToLoad = "";

            List<string> what_food = new List<string> { };
            List<string> how_cooked = new List<string> { };
            List<string> served_with = new List<string> { };

            data_slot = "what_cooked";
            fileToLoad = Path.Combine(Environment.CurrentDirectory, $"table_data/food_specialty.{data_slot}.data");
            what_food = File.ReadAllLines(fileToLoad).ToList();

            data_slot = "how_cooked";
            fileToLoad = Path.Combine(Environment.CurrentDirectory, $"table_data/food_specialty.{data_slot}.data");
            how_cooked = File.ReadAllLines(fileToLoad).ToList();

            data_slot = "side_dish";
            fileToLoad = Path.Combine(Environment.CurrentDirectory, $"table_data/food_specialty.{data_slot}.data");
            served_with = File.ReadAllLines(fileToLoad).ToList();

            //--  build the content
            coin_type = "copper";  // TODO:  something clever here where 'wealthy' inns pay silver instead.

            specialty_food_description = $"{PickFromList(what_food)} {PickFromList(how_cooked)} served with {PickFromList(served_with)}, for {diceBag.RollDice("2d4+3")} {coin_type}";

            //  return some content
            return specialty_food_description;
        }
        // public string SpecialtyFood()

        // -----
        public string EstablishmentHistory()
        {
            //  init empty vars and create lists
            DiceBagEngine diceBag = new DiceBagEngine();
            string establishment_history_notes = "The establishment is ";
            string fileToLoad = "";

            // going to do weighted picks
            List<string> categories = new List<string> {};

            categories.Add("age");
            categories.Add("building_condition");
            categories.Add("events_features");

            // now loop rolls_list and use a switch / case
            foreach (var item in categories)
            {
                var option_index = 0;
                switch (diceBag.RollDice("1d8"))
                {
                    case 1:
                        option_index = 1;
                        break;
                    case 2:
                    case 3:
                        option_index = 2;
                        break;
                    case 4:
                    case 5:
                    case 6:
                        option_index = 3;
                        break;
                    case 7:
                    case 8:
                        option_index = 4;
                        break;
                }
                fileToLoad = Path.Combine(Environment.CurrentDirectory, $"table_data/establishment_history.{item}.data");
                List<string> data_set = File.ReadAllLines(fileToLoad).ToList();

                string text_blurb = data_set[option_index - 1];
                establishment_history_notes += $"{text_blurb}. ";
            }

            return establishment_history_notes;
        }

    } // class PBHouse
}
