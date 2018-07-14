using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkInAMinefield
{
    // Dailyprogrammer challenge #340 Intermediate on Reddit

    class Program
    {
        private static string[] VALID_INPUTS = { "I", "-", "N", "E", "W", "S" };
        static string action = null;
        static string[,] minefield;
        static int robotRow;
        static int robotCol;
        static bool isRobotOn;
        static string instructions;
        static bool isRobotDead;

        static void Main(string[] args)
        {
            minefield = new string[8, 11]
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

            isRobotOn = false;            
            robotRow = 6;
            robotCol = 0;

            //get instructions;

            PrintMinefield();
            PrintInstruction();

            while (!ValidateInstructions())
            {
                Console.WriteLine("Please provide instructions for the robot.");
                instructions = Console.ReadLine();
            }

            for (int i = 0; i < instructions.Length; i++)
            {
                Console.Clear();
                action = instructions[i].ToString();
                HandleNextAction();
                PrintMinefield();
                if (isRobotDead)
                {
                    break;
                }
                System.Threading.Thread.Sleep(500);
            }

            if (isRobotDead)
            {
                Console.WriteLine("You're robot fell off a map or hit a mine.");
            }
            else if (IsRobotParkedAtFinish())
            {
                Console.WriteLine("YOU WON! The robot found its way out!");
            }
            else
            {
                Console.WriteLine("You're robot is not parked at the final location.");
            }         
        }

            //Prints out the minefield and gives instructions
            public static void PrintMinefield()
        {
            for (int i = 0; i < minefield.GetLength(0); i++)
            {
                for (int j = 0; j < minefield.GetLength(1); j++)
                {
                    string charToPrint = minefield[i, j];
                    ConsoleColor beforeColor = Console.ForegroundColor;
                    ConsoleColor beforeBgColor = Console.BackgroundColor;
                    ConsoleColor color;
                    ConsoleColor bgColor = beforeBgColor;
                    switch (charToPrint)
                    {
                        case "+":
                            color = ConsoleColor.White;
                            bgColor = ConsoleColor.White;
                            break;
                        case "*":
                            color = ConsoleColor.Green;
                            bgColor = ConsoleColor.DarkGreen;
                            break;
                        case "0":
                            color = ConsoleColor.DarkGreen;
                            bgColor = ConsoleColor.DarkGreen;
                            break;
                        case "R":
                            color = ConsoleColor.Yellow;
                            bgColor = ConsoleColor.DarkGreen;
                            break;
                        case "X":
                            color = ConsoleColor.Red;
                            bgColor = ConsoleColor.DarkGreen;
                            break;
                        default:
                            color = beforeColor;
                            bgColor = beforeBgColor;
                            break;
                    }

                    Console.ForegroundColor = color;
                    Console.BackgroundColor = bgColor;
                    Console.Write(charToPrint);
                    Console.ForegroundColor = beforeColor;
                    Console.BackgroundColor = beforeBgColor;
                }
                Console.WriteLine();
            }

        }   

        public static void PrintInstruction()
        {
            Console.WriteLine("Find your way through the maze!\n");
            Console.WriteLine("\nThe mines are represented by * and the robot by R");
            Console.WriteLine("N moves the robot one square to the north");
            Console.WriteLine("S moves the robot one square to the south");
            Console.WriteLine("E moves the robot one square to the east");
            Console.WriteLine("W moves the robot one square to the west");
            Console.WriteLine("I starts the robot's engine");
            Console.WriteLine("- turns off the robot's engine");
        }

        public static bool ValidateInstructions()
        {
            if (instructions == null || instructions.Trim().Length == 0)
            {
                return false;
            }

            instructions = instructions.ToUpper();
            
            //iterate through to get the next instruction
            for (int i = 0; i < instructions.Length; i++)
            {
                if (VALID_INPUTS.Contains(instructions[i].ToString()))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("{0} is not a valid input", instructions[i]);
                    return false;
                }
            }
            return true;
        }

        public static void HandleNextAction()
        {

            int rowOffset = 0;
            int colOffset = 0;

            switch (action)
            {
                case "N":
                    rowOffset = -1;
                    break;
                case "E":
                    colOffset = 1;
                    break;
                case "W":
                    colOffset = -1;
                    break;
                case "S":
                    rowOffset = 1;
                    break;
                case "I":
                    isRobotOn = true;
                    return;
                case "-":
                    isRobotOn = false;
                    return;
                    //return !DidIWin();
                default:
                    return;
            }

            if (isRobotOn)
            {
                int nextRow = robotRow + rowOffset;
                int nextCol = robotCol + colOffset;
                MoveRobot(nextRow, nextCol);
            }
            else
            {
                Console.WriteLine("Your robot engine is off.");
            }
        }

        private static bool IsRobotParkedAtFinish()
        {
            return (isRobotAtFinish() && !isRobotOn);
        }

        private static bool isRobotAtFinish()
        {
            return (robotCol == minefield.GetLength(1) - 1);
        }

        private static void MoveRobot(int nextRow, int nextCol)
        {
            if (nextCol > 10 || nextCol < 0)
            {
                Console.WriteLine("You are off the minefield!\n And you lose =(");
                isRobotDead = true;
                return;
            }
            switch (minefield[nextRow, nextCol])
            {
                case "*":
                    minefield[robotRow, robotCol] = "0";
                    minefield[nextRow, nextCol] = "X";
                    isRobotDead = true;
                    break;
                case "+":
                    break;
                default:
                    minefield[robotRow, robotCol] = "0";
                    minefield[nextRow, nextCol] = "R";
                    robotRow = nextRow;
                    robotCol = nextCol;
                    break;
            }
        }
    }
}
