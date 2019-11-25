using System;

namespace PBHouse_CLI
{
  class NPCMaker
  {
    // --- static properties
    private static string[] TypeCodeList = {"Staff", "Warrior", "Spell-Caster", "Noble", "Merchant"};
    private static string[] GenderCodeList = {"Male", "Female", "Androgenous"};
    private static string[] SexualOrrientationCodeList = {"Hetro", "Bi", "Gay", "Asex"};

    // --- other class includes
    private DiceBagEngine diceBag = new DiceBagEngine();

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
    } // end method NPCMaker

    // --- other class methods
    public void RandomDetails()
    {
      // do some new do with the here do
      HeightDesc  = getRandomHeightDesc();
      // BuildDesc
      GenderCode = getRandomGenderCode();
      // Race

      // EyeColor
      // HairColor
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
        + $" {getGenderCodeText()} ${Race}.  They are a {EyeColor}-eyed, {HairStyle}-coifed {HairColor}-hair.";
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

  } // end class NPCMaker
}  // end namespace PBHouse_CLI
