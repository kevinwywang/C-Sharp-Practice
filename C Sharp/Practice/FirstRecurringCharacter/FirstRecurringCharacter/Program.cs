using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstRecurringCharacter
{
    //Description:
    //Write a program that outputs the first recurring character in a string.

    //Formal Inputs & Outputs

    //Input Description

    //A string of alphabetical characters.Example:
    //ABCDEBC
    //Output description

    //The first recurring character from the input. From the above example:
    //B
    //Challenge Input

    //IKEUNFUVFV
    //PXLJOUDJVZGQHLBHGXIW
    //* l1J?)yn%R[}9~1"=k7]9;0[$

    //https://www.reddit.com/r/dailyprogrammer/comments/7cnqtw/20171113_challenge_340_easy_first_recurring/

    class Program
    {
        static void Main(string[] args)
        {
            string input = "ABCDEBC";
            string inputChallenge1 = "IKEUNFUVFV";
            string inputChallenge2 = "PXLJOUDJVZGQHLBHGXIW";
            string inputChallenge3 = "*l1J?)yn%R[}9~1\"=k7]9;0[$";

            Console.WriteLine(FindRecurring(input));
            Console.WriteLine(FindRecurring(inputChallenge1));
            Console.WriteLine(FindRecurring(inputChallenge2));
            Console.WriteLine(FindRecurring(inputChallenge3));
        }

        public static string FindRecurring(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                    {
                        return input[i].ToString();
                    }
                }
            }
            return "Could not find a recurring character.";
        }
    }
}
