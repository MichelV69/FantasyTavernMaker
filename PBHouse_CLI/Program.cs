using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PBHouse_CLI
{
  /*
  *   DOTNET learning project.  Use existing FantasyGrounds table-data
  *      to 'randomly roll' a 'P&B House' from my Scattered Isles
  *      DnD5e Campaign.
  *
  *   First created : Thu 22-Aug-2019 @ 15:23 ADT by m.vaillancourt
  *   Last updated  : Fri 11/29/2019 07h21 AST by m.vaillancourt
  *
  */
  class MainClass
  {
    public static int MaxTextWidthCols = 80;
    public static string MyAppName = "Fantasy Tavern Maker";
    public static string StockDashedLine = "------   ------   ------";

    // -----
    public static void Main(string[] args)
    {
      Console.WriteLine("\n" + DashLineText(StockDashedLine));
      string versionText = Assembly.GetExecutingAssembly().GetName().Version.ToString();
      var titleText = $"{MyAppName} - version {versionText}";
      Console.WriteLine(DashLineText(titleText));

      bool JustNPCList = false;
      int MaxNumberToMake = 1;

      Console.WriteLine($"\n How many per batch? [1 - 9, Default:{MaxNumberToMake}]");
      string batch_size = Console.ReadLine();
      if (!String.IsNullOrEmpty(batch_size))
        MaxNumberToMake = int.Parse(batch_size);
      Console.WriteLine($"\n Just build an NPC List? [true / false, Default:{JustNPCList}]");
      string npc_only = Console.ReadLine();
      if (!String.IsNullOrEmpty(npc_only))
        JustNPCList = Boolean.Parse(npc_only);

      var do_again = true;
      int AbsoLooply = 0;
        while (do_again)
        {
          PrepConsole();
          Console.WriteLine(DashLineText(titleText));

          WordWrap ww = new WordWrap();
          DiceBagEngine diceBag = new DiceBagEngine();
          for (int loop = 1; loop <= MaxNumberToMake; loop++)
          {
            AbsoLooply++;
            if (JustNPCList)
            {
              NPCMaker RandomNPC = new NPCMaker("Story Character", "Random");
              RandomNPC.RandomDetails();
              RandomNPC.TaskDesc = RandomNPC.getRandomTaskDesc();
              Console.WriteLine( "\n " + ww.doWordWrap(  String.Format("[#{0,2:d2}] ", AbsoLooply) + RandomNPC.toString(), MaxTextWidthCols));
            }
            else
            {
              CreateOneRandomPBHouse(diceBag, ww, AbsoLooply);
            }

          } // end-for

          // prompt user about doing more or quiting
          Console.WriteLine("\n" + DashLineText(StockDashedLine));
          var wait_on_valid_input = true;
          while (wait_on_valid_input)
          {
            Console.WriteLine($"Press [ESC] to exit, or [SPACE] to generate {MaxNumberToMake} more.");
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

    // -----
    private static void PrepConsole()
    {
      if (Console.BackgroundColor == ConsoleColor.Black)
      {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
      }
        Console.Clear();

    } // end method PrepConsole

    // -----
    private static string DashLineText(string TextToDisplay)
    {
      string Dashes = "-----";
      string LeadingGap = "   ";
      double Scalar = 1.0;
      int LineSpace = (int)(MaxTextWidthCols * Scalar) - 4;
      int EmtpySpace = LineSpace - TextToDisplay.Length - (2 * Dashes.Length) - (2 * LeadingGap.Length);
      int Offset = EmtpySpace / 2;
      string OffsetString = "";
      for (int i = 0; i < Offset; i++)
      {
        OffsetString += " ";
      }
      return $"{LeadingGap}{Dashes}{OffsetString}{TextToDisplay}{OffsetString}{Dashes}";
    } // end method DashLineText

    // -----
    private static void CreateOneRandomPBHouse(DiceBagEngine diceBag, WordWrap ww, int AbsoLooply)
    {
      // ---- create an example P3BHouse
      PBHouse pbh = new PBHouse();

      var name = pbh.Name();
      var quality_list = pbh.EstablishmentQuality(); // quality, rooms_cost, meals_cost
      var mood = pbh.Mood();
      var lights = pbh.Lighting();
      var smells = pbh.Smells();
      var size = pbh.Size();
      var posted_sign = diceBag.SearchStringForRolls(pbh.PostedSign());
      var drinks = diceBag.SearchStringForRolls(pbh.SpecialtyDrink(quality_list.Item1));
      var foods = diceBag.SearchStringForRolls(pbh.SpecialtyFood(quality_list.Item1));
      var history = diceBag.SearchStringForRolls(pbh.EstablishmentHistory());
      var naughty = diceBag.SearchStringForRolls(pbh.RedLightServices());

      // --- summary blurb output
      string FormatedAbsoLooply = String.Format("{0,2:d2}", AbsoLooply);
      Console.WriteLine(DashLineText( $"--[{FormatedAbsoLooply}]--" ));
      Console.WriteLine("\n" + DashLineText("Player Blurb"));

      var desc_line1 = $"  The local Pub and Bed House for travellers is the {name}." +
                        $" The {quality_list.Item1}-quality establishment would be considered {size}." +
                        $" Rooms are {quality_list.Item2} per day, and meals are {quality_list.Item3} per day.";

      var desc_line2 = $"\n  As you enter, you smell {smells}. It seems to be a {mood} place, {lights}." +
                        $" A sign {posted_sign}.";

      var desc_line3 = "\n  The menu has the usual standard fare posted. " +
                        $"The House Specialty Drink is {drinks}, while the House Specialty Meal is {foods}.";

      Console.WriteLine(ww.doWordWrap(desc_line1, MaxTextWidthCols));
      Console.WriteLine(ww.doWordWrap(desc_line2, MaxTextWidthCols));
      Console.WriteLine(ww.doWordWrap(desc_line3, MaxTextWidthCols));

      // --- new feature;  staff and patron NPCs
      NPCMaker NPC_Owner = new NPCMaker("Staff", "Owner") ;
      NPC_Owner.RandomDetails();

      int patronHeadCount = diceBag.RollDice("2d4-6");

      Console.WriteLine("\n " + DashLineText("Notable Staff & Patrons"));
      Console.WriteLine(ww.doWordWrap( NPC_Owner.toString(), MaxTextWidthCols));

      if (size.Contains("modest") || size.Contains("large") || size.Contains("massive"))
      {
        patronHeadCount++;
        NPCMaker NPC_Cook = new NPCMaker("Staff", "Cook") ;
        NPC_Cook.RandomDetails();
        Console.WriteLine( "\n " + ww.doWordWrap( NPC_Cook.toString(), MaxTextWidthCols));
      }

      // "modest", "large", "massive"
      if (size.Contains("large") || size.Contains("massive"))
      {
        patronHeadCount++;
        NPCMaker NPC_HeadServer = new NPCMaker("Staff", "Head Server") ;
        NPC_HeadServer.RandomDetails();
        Console.WriteLine( "\n " + ww.doWordWrap( NPC_HeadServer.toString(), MaxTextWidthCols));
      }

      if (size.Contains("massive"))
      {
        patronHeadCount++;
        NPCMaker NPC_Bouncer = new NPCMaker("Staff", "Bouncer") ;
        NPC_Bouncer.RandomDetails();
        Console.WriteLine( "\n " + ww.doWordWrap( NPC_Bouncer.toString(), MaxTextWidthCols));
      }

      for (int patronLoop = 0; patronLoop < patronHeadCount; patronLoop++)
      {
        NPCMaker NPC_Patron = new NPCMaker("Patron", "Random");
        NPC_Patron.RandomDetails();
        NPC_Patron.TaskDesc = NPC_Patron.getRandomTaskDesc();
        Console.WriteLine( "\n " + ww.doWordWrap( NPC_Patron.toString(), MaxTextWidthCols));
      }

      Console.WriteLine("\n" + DashLineText("DM Notes") );
      Console.WriteLine(ww.doWordWrap($"Establishment History: {history}", MaxTextWidthCols));
      Console.WriteLine(ww.doWordWrap($"Red Light Services: {naughty}", MaxTextWidthCols));

    } // end CreateOneRandomPBHouse

  }  // end class MainClass
} // namespace PBHouse_CLI
// ----- end of file -----
