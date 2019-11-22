using System;
using System.Collections.Generic;

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
    public static int MaxTextWidthCols = 80;
    public static string MyAppName = "Fantasy Tavern Maker";
    public static int NPC_Owner = 0;
    public static int NPC_ChiefServer = 1;
    public static int NPC_Cook = 2;

    public static void Main(string[] args)
    {
        var do_again = true;
        int loop_max = 3;

        if (args.Length != 0)
        {
            loop_max = int.Parse(args[0]);
        }

        while (do_again)
        {
            PrepConsole();
            Console.WriteLine("\n ------  ------  ------  ------  ------ ");
            Console.WriteLine(MyAppName);

            PBHouse pbh = new PBHouse();
            WordWrap ww = new WordWrap();
            DiceBagEngine diceBag = new DiceBagEngine();

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

                Dictionary<int, NPCMaker> NPCListing = new Dictionary <int, NPCMaker>();

                Console.WriteLine("\n ------                           ------ ");
                Console.WriteLine($"\n            --[{loop}]-- ");
                Console.WriteLine($"Name:  {name}");
                Console.WriteLine(ww.doWordWrap($"Establishment Quality: {quality_list.Item1};  Room {quality_list.Item2} & Board {quality_list.Item3}", MaxTextWidthCols));
                Console.WriteLine($"Size: {size}");
                Console.WriteLine($"Current Mood: {mood}");
                Console.WriteLine($"Lighting Environment: {lights}");
                Console.WriteLine($"Smells of: {smells}");
                Console.WriteLine($"Posted Sign: {posted_sign}");
                Console.WriteLine($"Specialty Drink: {drinks}");
                Console.WriteLine($"Specialty Food: {foods}");
                Console.WriteLine(ww.doWordWrap($"Establishment History: {history}", MaxTextWidthCols));
                Console.WriteLine(ww.doWordWrap($"Red Light Services: {naughty}", MaxTextWidthCols));
                Console.WriteLine("\n ------                           ------ ");

                // --- new feature;  staff and patron NPCs
                NPCListing.Add( NPC_Owner, new NPCMaker("Staff", "Owner") );
                NPCListing[ NPC_Owner].RandomDetails();

                // "modest", "large", "massive"
                //if (size.Contains("modest"))
                //{
                //  Person[NPC_Cook] = new NPCMaker("Staff", "Cook");
                //  Person[NPC_Cook].RandomDetails();
                //}

                Console.WriteLine("Notable Staff & Patrons");
                Console.WriteLine(NPCListing[ NPC_Owner].toString());

                Console.WriteLine("\n ------                           ------ ");

                var desc_line1 = $"\n  The local Pub and Bed House for travellers is the {name}." +
                    $" The {quality_list.Item1}-quality establishment would be considered {size}." +
                    $" Rooms are {quality_list.Item2} per day, and meals are {quality_list.Item3} per day.";

                var desc_line2 = $"\n  As you enter, you smell {smells}. It seems to be a {mood} place, {lights}." +
                    $" A sign {posted_sign}.";

                var desc_line3 = "\n  The menu has the usual standard fare posted. " +
                    $"The House Specialty Drink is {drinks}, while the House Specialty Meal is {foods}.";

                Console.WriteLine(" ");
                Console.WriteLine(ww.doWordWrap(desc_line1, MaxTextWidthCols));
                Console.WriteLine(ww.doWordWrap(desc_line2, MaxTextWidthCols));
                Console.WriteLine(ww.doWordWrap(desc_line3, MaxTextWidthCols));
                Console.WriteLine(" ");

            } // end-for

            Console.WriteLine("\n ------ ");
            // Keep the console window open in debug mode.
            var wait_on_valid_input = true;
            while (wait_on_valid_input)
            {
                Console.WriteLine($"Press [ESC] to exit, or [SPACE] to generate {loop_max} more.");
                var user_keypress = Console.ReadKey();
                if (user_keypress.Key == ConsoleKey.Escape)
                {
                    do_again = false;
                    wait_on_valid_input = false;
                }

                if (user_keypress.Key == ConsoleKey.Spacebar)
                {
                    do_again = true;
                    wait_on_valid_input = false;
                }

            } // while (wait_on_valid_input)
        } // end while do_again
    } // end method main

    private static void PrepConsole()
    {
      if (Console.BackgroundColor == ConsoleColor.Black)
        {
          Console.BackgroundColor = ConsoleColor.Gray;
          Console.ForegroundColor = ConsoleColor.DarkBlue;

        }
        Console.Clear();

    } // end method PrepConsole
  }  // end class MainClass
} // namespace PBHouse_CLI
// ----- end of file -----
