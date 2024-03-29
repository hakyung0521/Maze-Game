﻿using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ExplorableWorld
{
    class World
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = grid.GetLength(0);
            Cols = grid.GetLength(1);
        }

        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Grid[y, x];
                    SetCursorPosition(x, y);

                    if (element == "X")
                    {
                        ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.White;
                    }

                    Write(element);
                }
            }
        }

        public string GetElenmentAt(int x, int y)
        {
            return Grid[y, x];
        }
        public bool IsPositionWalkable(int x, int y)
        {
            // check bounds first.
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }
            // Check if the grid is a wolkable tile.
            return Grid[y, x] == " " || Grid[y, x] == "X";
        }
    }
}