using System;

namespace PBHouse_CLI
{
    /*
     *   DOTNET learning project.  Use existing FantasyGrounds table-data
     *      to 'randomly roll' a 'P&B House' from my Scattered Isles
     *      DnD5e Campaign.
     * 
     *   First created : Thu 22-Aug-2019 @ 15:23 ADT by m.vaillancourt
     *   Last updated  : Sun, Sep 22, 2019 9:29 PM by m.vaillancourt
     *   
     */
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n ------ ");
            Console.WriteLine("demo PBHouse");
            PBHouse pbh = new PBHouse();
            DiceBagEngine diceBag = new DiceBagEngine();
            int loop_max = 3;
            for (int loop = 1; loop <= loop_max; loop++)
            {
                // ---- create an example PBHouse
                var name = pbh.Name();
                var quality_list = pbh.EstablishmentQuality(); // quality, rooms_cost, meals_cost
                var mood = pbh.Mood();
                var lights = pbh.Lighting();
                var smells = pbh.Smells();
                var size = pbh.Size();
                var posted_sign = diceBag.SearchStringForRolls(pbh.PostedSign());
                var drinks = diceBag.SearchStringForRolls(pbh.SpecialtyDrink(quality_list.Item1));
                var foods = pbh.SpecialtyFood(quality_list.Item1);
                var history = diceBag.SearchStringForRolls(pbh.EstablishmentHistory());
                var naughty = diceBag.SearchStringForRolls(pbh.RedLightServices());

                Console.WriteLine($"\n --[{loop}]-- ");
                Console.WriteLine($"Name:  {name}");
                Console.WriteLine($"Establishment Quality: {quality_list.Item1};  Room {quality_list.Item2} & Board {quality_list.Item3}");
                Console.WriteLine($"Size: {size}");
                Console.WriteLine($"Current Mood: {mood}");
                Console.WriteLine($"Lighting Environment: {lights}");
                Console.WriteLine($"Smells of: {smells}");
                Console.WriteLine($"Posted Sign: {posted_sign}");
                Console.WriteLine($"Specialty Drink: {drinks}");
                Console.WriteLine($"Specialty Food: {foods}");
                Console.WriteLine($"Establishment History: {history}");
                Console.WriteLine($"Red Light Services: {naughty}");

                var desc_line1 = $"\n  The local Pub and Bed House for travellers is the {name}." +
                    $" The {quality_list.Item1}-quality establishment would be considered {size}." +
                    $" Rooms are {quality_list.Item2} per day, and meals are {quality_list.Item3} per day.";

                var desc_line2 = $"\n  As you enter, you smell {smells}. It seems to be a {mood} place, {lights}." +
                    $" A sign {posted_sign}.";

                var desc_line3 = "\n  The menu has the usual standard fare posted. " +
                    $"The House Specialty Drink is {drinks}, while the House Specialty Meal is {foods}.";

                Console.WriteLine(" ");
                Console.WriteLine(desc_line1);
                Console.WriteLine(desc_line2);
                Console.WriteLine(desc_line3);
                Console.WriteLine(" ");

            } // end-for

            Console.WriteLine("\n ------ ");
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
} // namespace PBHouse_CLI
// ----- end of file -----
