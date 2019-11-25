using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
/*
 * First created Tue 27-Aug-2019 @ 09h42 ADT by m.vaillancourt
 *  Last updated Sun, Sep 22, 2019 12:20 AM by m.vaillancourt
*/

namespace PBHouse_CLI
{
    public class DiceBagEngine
    {
        // public static Random rndGen = new Random((int)DateTime.Now.Ticks);
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        // -----
        private static int getRandomNumber(int minimumValue, int maximumValue)
        {
            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            // We are using Math.Max, and substracting 0.00000000001,
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = maximumValue - minimumValue + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(minimumValue + randomValueInRange);
        }

        // -----
        public int RollDice(string dice_string)
        {
            int number_of_rolls;
            int type_of_dice;
            int roll_mod;
            int total_roll;

            // decompose the dice string
            // first check for a 'd' notation;  ahead is number_of_rolls, behind is type_of_dice

            total_roll = -1;
            if (dice_string.Contains("d"))
            {
                string[] blocks = dice_string.Split('d');
                number_of_rolls = Convert.ToInt32(blocks[0]);

                // next check type_of_dice for a + or - ;  ahead is type_of_dice, behind is roll_mod
                if (blocks[1].Contains("+") || blocks[1].Contains("-"))
                {
                    char[] plus_minus = { '+', '-' };
                    string[] small_blocks = blocks[1].Split(plus_minus);

                    type_of_dice = Convert.ToInt32(small_blocks[0]);
                    roll_mod = Convert.ToInt32(small_blocks[1]);

                    if(blocks[1].Contains("-"))
                    {
                        roll_mod = roll_mod * -1;
                    }
                }
                else
                {
                    type_of_dice = Convert.ToInt32(blocks[1]);
                    roll_mod = 0;
                } // end-if-else

                // now loop from 1 to number_of_rolls, adding to total_roll
                total_roll = 0;
                for (int loop = 1; loop <= number_of_rolls; loop++)
                {
                    total_roll = total_roll + getRandomNumber(1, type_of_dice);
                } // end-for

                // add roll_mod to total_roll
                total_roll = total_roll + roll_mod;

            } // end-if

            // return total_roll
            return total_roll;

        } // end-public RollDice

        // -----
        public string SearchStringForRolls(string to_search)
        {
            var pattern = @"\[(.*?)\]";
            var matches = Regex.Matches(to_search, pattern);
            var fixed_string = to_search;
            foreach (Match m in matches)
            {
                string dice_string = $"{m.Groups[1]}";
                int replacement_roll = this.RollDice(dice_string);
                fixed_string = fixed_string.Replace(dice_string, $"{replacement_roll}");
            }

            return fixed_string.Replace("[","").Replace("]","");
        }

        // -----
        public int RawRoll1To(int MaxRoll)
        {
          return getRandomNumber(1, MaxRoll);
        }
    } // end-class DiceBagEngine
}
