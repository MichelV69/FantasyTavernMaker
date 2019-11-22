using System;

namespace PBHouse_CLI
{
  class NPCMaker
  {
    // --- static properties
    private static string[] TypeCodeList = {"Staff", "Warrior", "Spell-Caster", "Noble", "Merchant"};
    private static string[] GenderCodeList = {"Male", "Female", "Androgenous"};
    private static string[] SexualOrrientationCodeList = {"Hetro", "Bi", "Gay", "Asex"};

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
      string nothing = "goes nowhere";
    }

    public string toString()
    {
      // do some new do with the here do
      string desc_line1 = $"{getTypeCodeText()} : {PublicName} is the {TaskDesc}";
      return desc_line1;
    }

    public string getTypeCodeText()
    {
      return TypeCodeList[TypeCode];
    }

  } // end class NPCMaker
}  // end namespace PBHouse_CLI
