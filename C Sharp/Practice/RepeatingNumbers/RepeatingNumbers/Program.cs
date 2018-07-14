using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatingNumbers
{
    class Program
    {
        public static string userInput;
        public static int noRepeating;

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a numbers:");
            while (!IsInputValid())
            {
                //Checks to see if the user has entered an input
            }

            int timesRepeated;
            noRepeating = 0;
            List<string> inputsToCheck = new List<string>();
            List<string> alreadyCheckedInputs = new List<string>();

            for (int i = 0; i < userInput.Length; i++)
            {
                for (int j = 2; j < userInput.Length + 1 - i; j++)
                {
                    inputsToCheck.Add(userInput.Substring(i,j));
                    if (!alreadyCheckedInputs.Contains(userInput.Substring(i, j)))
                    {
                        alreadyCheckedInputs.Add(userInput.Substring(i, j));
                    }
                }
            }

            foreach (string item in alreadyCheckedInputs)
            {
                timesRepeated = 0;
                foreach (string list in inputsToCheck)
                {
                    if (item == list)
                    {
                        timesRepeated++;
                    }
                }
                PrintRepeatingInput(item, timesRepeated);
            }
            if (noRepeating == 0)
            {
                Console.WriteLine(noRepeating);
            }
        }

        public static void PrintRepeatingInput(string inputToCheck, int timesRepeated)
        {
            switch (timesRepeated)
            {
                case 0:
                    break;
                case 1:
                    break;
                default:
                    Console.WriteLine("{0}:{1}", inputToCheck, timesRepeated);
                    noRepeating++;
                    break;
            }
        }

        public static bool IsInputValid()
        {
            userInput = Console.ReadLine();

            if (userInput.Trim().Length == 0)
            {
                Console.WriteLine("Please enter a valid input.");
                return false;
            }
            return true;
        }
    }
}
