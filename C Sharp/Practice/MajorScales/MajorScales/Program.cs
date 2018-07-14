using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorScales
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> scale = new List<string>{ "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            List<string> solfege = new List<string> { "Do", "Re", "Mi", "Fa", "So", "La", "Ti"};

            Console.WriteLine("Please enter a major scale: ");
            string userScaleInput = Console.ReadLine().ToUpper();

            while (!scale.Contains(userScaleInput))
            {
                Console.WriteLine("Enter a valid scale");
                userScaleInput = Console.ReadLine().ToUpper();
            }

            Console.WriteLine("Please enter a solfege name: ");
            string userSolfegeInput = Console.ReadLine();

            while (!solfege.Contains(userSolfegeInput))
            {
                Console.WriteLine("Enter a valid solfege");
                userSolfegeInput = Console.ReadLine();
            }

            int indexScale = scale.IndexOf(userScaleInput);
            int semitones = NumberSemitone(userSolfegeInput);

            indexScale = (indexScale + semitones) % 12;
            Console.WriteLine(scale[indexScale]);
        }

        private static int NumberSemitone(string userSolfegeInput)
        {
            switch (userSolfegeInput)
            {
                case "Do":
                    return 0;
                case "Re":
                    return 2;
                case "Mi":
                    return 4;
                case "Fa":
                    return 5;
                case "So":
                    return 7;
                case "La":
                    return 9;
                case "Ti":
                    return 11;
                default:
                    Console.WriteLine("The solfege does not exist.");
                    return 0;
            }
        }
    }
}
