﻿using System;

/*
 * First created Tue 27-Aug-2019 @ 09h42 ADT by m.vaillancourt
 *  Last updated Tue 27-Aug-2019 @ 10h55 ADT by m.vaillancourt
 */

namespace PBHouse_CLI
{
    public class DiceBagEngine
    {
        public static Random rndGen = new Random((int)DateTime.Now.Ticks);

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
                    total_roll = total_roll + rndGen.Next(1, type_of_dice);
                } // end-for

                // add roll_mod to total_roll
                total_roll = total_roll + roll_mod;

            } // end-if

            // return total_roll
            return total_roll;

        } // end-public RollDice
    } // end-class DiceBagEngine
}
