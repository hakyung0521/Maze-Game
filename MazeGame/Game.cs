﻿using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ExplorableWorld
{
    class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        public void Start()
        {
            Title = "Welcome to the Maze!";
            CursorVisible = false;

            string[,] grid = {
            {"=", "=", "=", "=", "=", "=", "="},
            {"|", " ", "|", " ", " ", " ", "X"},
            {" ", " ", "|", " ", "|", " ", "|"},
            {"|", " ", "|", " ", "|", " ", "|"},
            {"|", " ", " ", " ", "|", " ", "|"},
            {"=", "=", "=", "=", "=", "=", "="},
         };

            MyWorld = new World(grid);

            CurrentPlayer = new Player(0, 2);

            RunGameLoop();
        }

        private void DisplayIntro()
        {
            WriteLine("Welcome to the maze!");
            WriteLine("\nInstructions");
            WriteLine("> Use the arrow keys to move");
            Write("> Try to reach the goal, which looks like this: ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("X");
            ResetColor();
            WriteLine("> press any key to start");
            ReadKey(true);
        }

        private void DisplayOutro()
        {
            Clear();
            WriteLine("You escaped!");
            WriteLine("Thanks for playing.");
            WriteLine("Press any key to exit...");
            ReadKey(true);
        }
        private void DrawFrame()
        {
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();

        }
        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                default:
                    break;

            }
        }
        private void RunGameLoop()
        {
            DisplayIntro();
            while (true)
            {
                //Draw everything.
                DrawFrame();
                // check for player input from keyboard and move the player
                HandlePlayerInput();

                // check if the player has reached the exit and end the game if so 
                string elementAtPlayerPos = MyWorld.GetElenmentAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPos == "X")
                {
                    break;
                }

                // Give the console a chance to render.
                System.Threading.Thread.Sleep(20);
            }
            DisplayOutro();
        }
    }
}


