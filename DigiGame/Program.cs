using System;
using ELibCode;


namespace DigiGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ELib.Init(false);
            ELib.NewTitle("DigiGame");
            Console.WriteLine("This is a game. Take 1-3 matchsticks and try to be the last one to be able to get one");
            int inputNum = 0;
            int currentWood = 0;
            string currentPlayer = null;
            
            do
            {
                run(inputNum, currentWood, currentPlayer);
            } while (ELib.AskUserIfYesOrNo("Play another game?"));
        }

        public static void run(int inputNum, int currentWood, string currentPlayer)
        {
            currentWood = 21; 
            if (getRndmNum(1, 10) >= 10)
            {
                currentPlayer = "AI";
            }
            else
            {
                currentPlayer = "Player";
            }
            bool firstRound = true;
            while (currentWood > 0)
            {
                Console.Clear();
                Console.WriteLine($"The current Player is {currentPlayer}");
                switch (currentPlayer)
                {
                    case "Player":
                        while (true)
                        {
                            inputNum = ELib.getInt("Input a number between 1 and 3");
                            if (inputNum == 1 || inputNum == 2 || inputNum == 3)
                            {
                                break;
                            }
                        }
                        currentPlayer = "AI";
                        break;
                    case "AI":
                        inputNum = currentWood % 4;
                        if (inputNum == 0 || firstRound)
                        {
                            inputNum = getRndmNum(1, 3);
                        }

                        currentPlayer = "Player";
                        break;
                    default:
                        Console.WriteLine("Error in code, exiting...");
                        return;
                        //break;
                }

                firstRound = false;
                currentWood -= inputNum;
                Console.WriteLine($"Current amount matchsticks: {currentWood}/21");
                string wooddisp = "";
                if (currentWood != 0)
                {
                    for (int i = 0; i < currentWood; i++)
                    {
                        wooddisp = wooddisp + "|";
                    }
                }
                Console.WriteLine(wooddisp + $"         Taken matchsticks: {inputNum}"); 
                inputNum = 0;
                if (currentWood == 0)
                {
                    Console.WriteLine(currentPlayer + " has lost!");
                }
            }
        }

        public static int getRndmNum(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max); //min, max
        }
    }
}