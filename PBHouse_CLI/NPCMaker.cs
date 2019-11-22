namespace PBHouse_CLI
{
  class NPCMaker
  {

      private static string[] TypeCodeList = {"Staff", "Warrior", "Spell-Caster", "Noble", "Merchant"};
      private static string[] GenderCodeList = {"Male", "Female", "Androgenous"};
      private static string[] SexualOrrientationCodeList = {"Hetro", "Bi", "Gay", "Asex"};
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
  }
}
