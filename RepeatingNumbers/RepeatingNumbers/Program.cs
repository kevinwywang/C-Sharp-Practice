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

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a numbers:");
            while (!IsInputValid())
            {
                //Checks to see if the user has entered an input
            }

            string inputToCheck;
            string repeatingInput;
            int timesRepeated;
            int noRepeating = 0;
            List<string> alreadyCheckedInputs = new List<string>();

            for (int i = 0; i < userInput.Length; i++)
            {
                for (int j = 2; j < userInput.Length + 1 - i; j++)
                {
                    timesRepeated = 1;
                    inputToCheck = userInput.Substring(i, j);

                    if (alreadyCheckedInputs.Contains(inputToCheck))
                    {
                        break;
                    }

                    alreadyCheckedInputs.Add(inputToCheck);
                    
                    for (int k = 2 + i; k < userInput.Length; k++)
                    {
                        for (int l = 2; l < userInput.Length + 1 - k; l++)
                        {
                            repeatingInput = userInput.Substring(k, l);
                            if (inputToCheck == repeatingInput)
                            {
                                timesRepeated++;
                                noRepeating++;
                            }
                        }
                    }

                    PrintRepeatingInput(inputToCheck, timesRepeated);
                }
            }

            if (noRepeating == 0)
            {
                Console.WriteLine(noRepeating);
            }

        }

        private static void PrintRepeatingInput(string inputToCheck, int timesRepeated)
        {
            switch (timesRepeated)
            {
                case 0:
                    break;
                case 1:
                    break;
                default:
                    Console.WriteLine("{0}:{1}", inputToCheck, timesRepeated);
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
