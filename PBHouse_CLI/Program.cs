using System;

namespace PBHouse_CLI
{
    /*
     *   DOTNET learning project.  Use existing FantasyGrounds table-data
     *      to 'randomly roll' a 'P&B House' from my Scattered Isles
     *      DnD5e Campaign.
     * 
     *   First created : Thu 22-Aug-2019 @ 15:23 ADT by m.vaillancourt
     *   Last updated  : Mon, Sep 16, 2019 10:52 PM by m.vaillancourt
     *   
     */
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n ------ ");
            Console.WriteLine("demo PBHouse");
            PBHouse pbh = new PBHouse();
            int loop_max = 3;
            for (int loop = 1; loop <= loop_max; loop++)
            {
                Console.WriteLine($"\n --[{loop}]-- ");
                Console.WriteLine($"Name:  {pbh.Name()}");
                Console.WriteLine($"Current Mood: {pbh.Mood()}");
                Console.WriteLine($"Lighting Environment: {pbh.Lighting()}");
                Console.WriteLine($"Smells of: {pbh.Smells()}");
                Console.WriteLine($"Size: {pbh.Size()}");
                Console.WriteLine($"Posted Sign: {pbh.PostedSign()}");
                Console.WriteLine($"Specialty Drink: {pbh.SpecialtyDrink()}");
                Console.WriteLine($"Specialty Food: {pbh.SpecialtyFood()}");
                Console.WriteLine($"Specialty Food: {pbh.EstablishmentHistory()}");

            } // end-for

            Console.WriteLine("\n ------ ");
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
} // namespace PBHouse_CLI
// ----- end of file -----
