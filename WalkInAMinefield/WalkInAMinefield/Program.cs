using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkInAMinefield
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] minefield = new string[8,11]
            {
                {"+","+","+","+","+","+","+","+","+","+","+"},
                {"+","0","0","0","0","0","0","0","0","0","0"},
                {"+","0","0","0","0","0","0","*","0","0","+"},
                {"+","0","0","0","0","0","0","0","0","0","+"},
                {"+","0","0","0","*","0","0","*","0","0","+"},
                {"+","0","0","0","0","0","0","0","0","0","+"},
                {"R","0","0","0","*","0","0","0","0","0","+"},
                {"+","+","+","+","+","+","+","+","+","+","+"}
            };

            PrintMinefield(minefield);

            //bool engineStatus = false;
            string robotLocation = minefield[7, 1];
            string userInput = Console.ReadLine();

            //RobotAction(userInput, minefield, robotLocation, engineStatus);
            
        }

        public static void PrintMinefield(string[,] matrix)
        {
            Console.WriteLine("Find your way through the maze!\n");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nThe mines are represented by * and the robot by R");
            Console.WriteLine("N moves the robot one square to the north");
            Console.WriteLine("S moves the robot one square to the south");
            Console.WriteLine("E moves the robot one square to the east");
            Console.WriteLine("W moves the robot one square to the west");
            Console.WriteLine("I starts the robot's engine");
            Console.WriteLine("- turns off the robot's engine");
            Console.WriteLine("\nWhat would you like to do with your robot?");
            ReadInput();
        }   

        public static string ReadInput()
        {
            string[] validInputs = { "I", "-", "N", "E", "W" };
            string input = Console.ReadLine();
            input = input.ToUpper();

            foreach (string x in validInputs)
            {
                if (input.Contains(x))
                {
                    return x;
                }
                else
                {
                    Console.WriteLine("Please give a valid input.");
                    ReadInput();
                }
            }
        }

        public void moveRobot()
        {
            
        }
        
        //public static void RobotAction(string input, string[,] matrix, string location, bool engineStatus)
        //{
            
        //    input = input.ToUpper();

        //    if (engineStatus == true)
        //    {
        //        if (input == "I")
        //        {
        //            Console.WriteLine("The robot's engine is already on.");
        //        }
        //        else if (input == "-")
        //        {

        //        }
        //        else if (input == "N")
        //        {

        //        }
        //        else if (input == "S")
        //        {

        //        }
        //        else if (input == "E")
        //        {

        //        }
        //        else if (input == "W")
        //        {

        //        }
        //        else
        //        {
        //            Console.WriteLine("That is not a valid command.");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("The robot's engine is not on. Please turn the engine on by entering I");
        //        string input2 = Console.ReadLine();
        //        if(input2 == "I")
        //        {
        //            engineStatus = true;
        //        }
        //        RobotAction(input2, matrix, location, engineStatus);
        //    }
        //}
    }
}
