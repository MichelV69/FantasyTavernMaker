using System;
using System.Collections.Generic;

namespace PBHouse_CLI
{
  class NPCMaker
  {
    // --- static properties
    private static string[] TypeCodeList = {"Staff", "Warrior", "Spell-Caster", "Noble", "Merchant"};
    private static string[] GenderCodeList = {"Male", "Female", "Androgenous"};
    private static string[] SexualOrrientationCodeList = {"Hetro", "Bi", "Gay", "Asex"};

    private Dictionary<string, int> RacialDistribution =
    new Dictionary<string, int>();

    private Dictionary<string, int> EyeColorTable =
    new Dictionary<string, int>();

    private Dictionary<string, int> HairColorTable =
    new Dictionary<string, int>();

    // --- other class includes
    private DiceBagEngine diceBag = new DiceBagEngine();
    private Random random = new Random((int)DateTime.Now.Ticks);
    // --- variable properties
    private int TypeCode { get; set; }
    private int SexualOrrientationCode { get; set; }
    private int GenderCode { get; set; }
    private string PublicName { get; set; }
    private string TaskDesc { get; set; }
    private string Race { get; set; }
    private string HeightDesc { get; set; }
    private string BuildDesc { get; set; }
    private string HairColor { get; set; }
    private string HairStyle { get; set; }
    private string EyeColor { get; set; }
    private string QuirkEmotional { get; set; }
    private string QuirkPhysical { get; set; }
    private string NotableAttributePositive { get; set; }
    private string NotableAttributeNegative { get; set; }
    private string SchtickAbilityDescription { get; set; }

    // --- constructor
    public NPCMaker(string TypeCodeText, string NewTaskDesc)
    {
        this.PublicName = "(Character)";
        this.TypeCode = Array.IndexOf(TypeCodeList, TypeCodeText);
        this.TaskDesc = NewTaskDesc;

        RacialDistribution.Add("dragonborn", 1);
        RacialDistribution.Add("dwarf", 5);
        RacialDistribution.Add("elf", 4);
        RacialDistribution.Add("gnome", 3);
        RacialDistribution.Add("half-elf", 2);
        RacialDistribution.Add("halfling", 4);
        RacialDistribution.Add("half-orc", 1);
        RacialDistribution.Add("human", 7);
        RacialDistribution.Add("tiefling", 1);

        EyeColorTable.Add("brown", 32);
        EyeColorTable.Add("hazel", 16);
        EyeColorTable.Add("blue", 8);
        EyeColorTable.Add("green", 4);
        EyeColorTable.Add("grey", 2);
        EyeColorTable.Add("amber", 1);

        HairColorTable.Add("raven", 70);
        HairColorTable.Add("brown", 12);
        HairColorTable.Add("blonde", 6);
        HairColorTable.Add("white", 6);
        HairColorTable.Add("silver-grey", 6);
        HairColorTable.Add("red", 3);
        HairColorTable.Add("green", 1);
        HairColorTable.Add("blue", 1);

    } // end method NPCMaker

    // --- other class methods
    public void RandomDetails()
    {
      // do some new do with the here do
      HeightDesc  = getRandomHeightDesc();
      BuildDesc   = getRandomBuildDesc();
      GenderCode  = getRandomGenderCode();
      Race  = RandomWeightedRoller("Human*", RacialDistribution);

      EyeColor   =  RandomWeightedRoller("Blue*", EyeColorTable);
      HairColor  =  RandomWeightedRoller("Chestnut*", HairColorTable);
      // HairStyle

      // QuirkEmotional
      // QuirkPhysical
      // NotableAttributePositive
      // NotableAttributeNegative
      // SexualOrrientationCode
      // SchtickAbilityDescription
    }

    public string toString()
    {
      // do some new do with the here do
      string desc_line1 = $"{getTypeCodeText()} : {PublicName} is the {TaskDesc}.  They are {HeightDesc} and {BuildDesc}"
        + $" {getGenderCodeText()} ${Race}.  They are {EyeColor}-eyed, with {HairStyle}-coifed {HairColor}-hair.";
      return desc_line1;
    }

    public string getTypeCodeText()
    {
      return TypeCodeList[TypeCode];
    }

    private int getRandomGenderCode()
    {
      int roll_1d8 = diceBag.RollDice("1d8");
      int localGenderCode = -1;
      if (1 <= roll_1d8 && roll_1d8 <= 5)
      {
          localGenderCode = getGenderCodeByText("male");
      }
      if (6 <= roll_1d8 && roll_1d8 <= 8)
      {
          localGenderCode = getGenderCodeByText("female");
      }
      if (9 <= roll_1d8 && roll_1d8 <= 10)
      {
          localGenderCode = getGenderCodeByText("Androgenous");
      }
      return localGenderCode;
    } // end method getRandomGenderCode

    public int getGenderCodeByText(string GenderCodeText)
    {
      return Array.FindIndex(GenderCodeList, data => data.ToLower() == GenderCodeText.ToLower() );
    } // end method getGenderCodeByText

    private string getRandomHeightDesc()
    {
      string localHeightDesc = "average*";
      int roll_2d6 = diceBag.RollDice("2d6");

      if ( roll_2d6 == 2)
      {
          localHeightDesc = diceBag.SearchStringForRolls("very short (-[3d8+6]%)");
      }
      if ( roll_2d6 == 3)
      {
          localHeightDesc = diceBag.SearchStringForRolls("short (-[2d8+3]%)");
      }
      if (4 <= roll_2d6 && roll_2d6 <= 5)
      {
          localHeightDesc = diceBag.SearchStringForRolls("short-ish (-[1d8+1]%)");
      }

      if (6 <= roll_2d6 && roll_2d6 <= 8)
      {
          localHeightDesc = diceBag.SearchStringForRolls("average height ([2d4-4]%)");
      }

      if (9 <= roll_2d6 && roll_2d6 <= 10)
      {
          localHeightDesc = diceBag.SearchStringForRolls("tall-ish (+[1d8+1]%)");
      }
      if ( roll_2d6 == 11)
      {
          localHeightDesc = diceBag.SearchStringForRolls("tall (+[2d8+3]%)");
      }
      if ( roll_2d6 == 12)
      {
          localHeightDesc = diceBag.SearchStringForRolls("very tall (+[3d8+6]%)");
      }

      return localHeightDesc;
    } // end method getRandomHeightDesc

    public string getGenderCodeText()
    {
      return GenderCodeList[GenderCode];
    } // end method getGenderCodeText

    private string getRandomBuildDesc()
    {
      string localBuildDesc = "average*";
      int roll_2d6 = diceBag.RollDice("2d6");

      if ( roll_2d6 == 2)
      {
          localBuildDesc = diceBag.SearchStringForRolls("gaunt (-[3d8+6]%)");
      }
      if ( roll_2d6 == 3)
      {
          localBuildDesc = diceBag.SearchStringForRolls("lean (-[2d8+3]%)");
      }
      if (4 <= roll_2d6 && roll_2d6 <= 5)
      {
          localBuildDesc = diceBag.SearchStringForRolls("slightly angular (-[1d8+1]%)");
      }

      if (6 <= roll_2d6 && roll_2d6 <= 8)
      {
          localBuildDesc = diceBag.SearchStringForRolls("medium build ([2d4-4]%)");
      }

      if (9 <= roll_2d6 && roll_2d6 <= 10)
      {
          localBuildDesc = diceBag.SearchStringForRolls("slightly husky (+[1d8+1]%)");
      }
      if ( roll_2d6 == 11)
      {
          localBuildDesc = diceBag.SearchStringForRolls("stout (+[2d8+3]%)");
      }
      if ( roll_2d6 == 12)
      {
          localBuildDesc = diceBag.SearchStringForRolls("portly (+[3d8+6]%)");
      }

      return localBuildDesc;
    } // end method getRandomBuildDesc

    private string RandomWeightedRoller(string DefaultResult, Dictionary<string, int> WeightedTable)
    {

      string ResultText = DefaultResult;

      // add up total_weight
      int total_weight = 0;
      foreach (var TableData in WeightedTable)
      {
        total_weight += TableData.Value;
      }

      // roll from 1 to total_weight
      int RollToCompare = random.Next(1, total_weight);

      // loop the race list
      int RangeLow  = 0;
      int RangeHigh = 0;
      foreach (var TableData in WeightedTable)
      {
        // move high to low, and add the weight of the next race to high
        RangeLow = RangeHigh + 1;
        RangeHigh += TableData.Value;

        // if we're between high and low, that's our race
        if (RangeLow <= RollToCompare && RollToCompare <= RangeHigh)
        {
          ResultText = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TableData.Key.ToLower());
        }
      } // end foreach

      return ResultText;

    } // end method RandomWeightedRoller

  } // end class NPCMaker
}  // end namespace PBHouse_CLI
