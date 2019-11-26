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

                Console.WriteLine($"\n                 --[{loop}]-- ");
                Console.WriteLine(" ------          DM Notes           ------ ");
                Console.WriteLine($"Name:  {name}");
                Console.WriteLine(ww.doWordWrap($"Establishment Quality: {quality_list.Item1};  Room {quality_list.Item2} & Board {quality_list.Item3}", MaxTextWidthCols));
                Console.WriteLine(ww.doWordWrap($"Size: {size}", MaxTextWidthCols));
                Console.WriteLine(ww.doWordWrap($"Current Mood: {mood}", MaxTextWidthCols));
                Console.WriteLine(ww.doWordWrap($"Lighting Environment: {lights}", MaxTextWidthCols));
                Console.WriteLine(ww.doWordWrap($"Smells of: {smells}", MaxTextWidthCols));
                Console.WriteLine(ww.doWordWrap($"Posted Sign: {posted_sign}", MaxTextWidthCols));
                Console.WriteLine(ww.doWordWrap($"Specialty Drink: {drinks}", MaxTextWidthCols));
                Console.WriteLine(ww.doWordWrap($"Specialty Food: {foods}", MaxTextWidthCols));
                Console.WriteLine(ww.doWordWrap($"Establishment History: {history}", MaxTextWidthCols));
                Console.WriteLine(ww.doWordWrap($"Red Light Services: {naughty}", MaxTextWidthCols));
                Console.WriteLine(" ------                            ------ ");

                // --- new feature;  staff and patron NPCs
                NPCMaker NPC_Owner = new NPCMaker("Staff", "Owner") ;
                NPC_Owner.RandomDetails();

                Console.WriteLine("Notable Staff & Patrons");
                Console.WriteLine(ww.doWordWrap( NPC_Owner.toString(), MaxTextWidthCols));

                if (size.Contains("modest") || size.Contains("large") || size.Contains("massive"))
                {
                  NPCMaker NPC_Cook = new NPCMaker("Staff", "Cook") ;
                  NPC_Cook.RandomDetails();
                  Console.WriteLine(ww.doWordWrap( NPC_Cook.toString(), MaxTextWidthCols));
                }

                // "modest", "large", "massive"
                if (size.Contains("large") || size.Contains("massive"))
                {
                  NPCMaker NPC_HeadServer = new NPCMaker("Staff", "Head Server") ;
                  NPC_HeadServer.RandomDetails();
                  Console.WriteLine(ww.doWordWrap( NPC_HeadServer.toString(), MaxTextWidthCols));
                }

                if (size.Contains("massive"))
                {
                  NPCMaker NPC_Bouncer = new NPCMaker("Staff", "Bouncer") ;
                  NPC_Bouncer.RandomDetails();
                  Console.WriteLine(ww.doWordWrap( NPC_Bouncer.toString(), MaxTextWidthCols));
                }

                // --- summary blurb output

                Console.WriteLine("\n ------       Player Blurb        ------ ");

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

            // prompt user about doing more or quiting
            Console.WriteLine("\n ------ ");
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
