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
    private string NameDesc { get; set; }
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
    public static void NPCMaker(BDPO builder)
    {
        this.TypeCode = builder.TypeCode;
        this.NameDesc = builder.NameDesc;
    } // end method NPCMaker

    // --- builder design pattern
    public static class BDPO
    {
      // - required parameters
      private int TypeCode;
      private string NameDesc;

      // - other optional parameters

      public BDPO (string TypeCodeText, string NewNameDesc)
      {
        this.TypeCode = Array.IndexOf(TypeCodeList, TypeCodeText);
        this.NameDesc = NewNameDesc;
      } // end class constructor BDPO
    } // end class BDPO

    // --- other class methods

  } // end class NPCMaker
} end // namespace PBHouse_CLI
