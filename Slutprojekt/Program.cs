using System;
using Raylib_cs;

namespace array_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle mouse;
            Rectangle r1;
            int rpoint = 0;
            int ypoint = 0;
            int recHeight = 100;
            int recWidth = 100;
            int windowHeight = 600;
            int windowWidth = 900;
            int gridHeight = 6;
            int gridWidth = 7;
            int radiusCirc = (int)47.5;
            int red = 1;
            int yellow = 2;
            bool leftClick;
            int playerTurn = 1;
            bool click = true;
            int lowest = gridHeight - 1;
            int[,] grid = new int[gridWidth, gridHeight];
            bool[,] trueGrid = new bool[gridWidth, gridHeight];

            Raylib.InitWindow(windowWidth, windowHeight, "Four in a row");

            while (!Raylib.WindowShouldClose())
            {
                leftClick = Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON);

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BEIGE);

                for (int x = 1; x < gridWidth + 1; x++)
                {
                    for (int y = 0; y < gridHeight; y++)
                    {
                        mouse = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 1, 1);
                        r1 = new Rectangle(x * recWidth, y * recHeight, recWidth, recHeight);

                        Raylib.DrawRectangleRec(r1, Color.BLACK);

                        Raylib.DrawCircle(x * recWidth + radiusCirc + (int)2.5, y * recHeight + radiusCirc - (int)1.5, radiusCirc, Color.DARKGRAY);
                    }
                }
                for (int x = 1; x < gridWidth + 1; x++)
                {
                    for (int y = 0; y < gridHeight; y++)
                    {
                        mouse = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 1, 1);
                        r1 = new Rectangle(x * recWidth, y * recHeight, recWidth, recHeight);
                        if (Raylib.CheckCollisionRecs(mouse, r1))
                        {
                            x--;
                            if (!trueGrid[x, y])
                            {

                                y = gridWidth - 1;
                                for (int i = 0; i < gridWidth; i++)
                                {
                                    if (y > 5)
                                    {
                                        y = 5;
                                    }

                                    if (trueGrid[x, y])
                                    {
                                        y--;
                                    }
                                }
                                if (playerTurn == red)
                                {

                                    Raylib.DrawCircle((x + 1) * recWidth + radiusCirc + (int)2.5, y * recHeight + radiusCirc - (int)1.5, radiusCirc, Color.MAROON);
                                    if (leftClick)
                                    {


                                        grid[x, y] = 1;
                                        trueGrid[x, y] = true;
                                    }
                                }
                                else if (playerTurn == yellow)
                                {
                                    Raylib.DrawCircle((x + 1) * recWidth + radiusCirc + (int)2.5, y * recHeight + radiusCirc - (int)1.5, radiusCirc, Color.ORANGE);
                                    if (leftClick)
                                    {

                                        grid[x, y] = 2;
                                        trueGrid[x, y] = true;
                                    }
                                }
                            }
                            x++;
                        }


                    }
                }



                for (int x = 0; x < gridWidth; x++)
                {
                    for (int y = 0; y < gridHeight; y++)
                    {

                        if (red == grid[x, y])
                        {
                            x++;
                            Raylib.DrawCircle(x * recWidth + radiusCirc + (int)2.5, y * recHeight + radiusCirc - (int)1.5, radiusCirc, Color.RED);
                            x--;
                        }
                        if (grid[x, y] == yellow)
                        {
                            x++;
                            Raylib.DrawCircle(x * recWidth + radiusCirc + (int)2.5, y * recHeight + radiusCirc - (int)1.5, radiusCirc, Color.YELLOW);
                            x--;
                        }

                    }
                }


                if (playerTurn == red && click && leftClick)
                {
                    playerTurn = yellow;
                    click = false;
                }
                else if (playerTurn == yellow && leftClick && click)
                {
                    playerTurn = red;
                    click = false;
                }
                if (Raylib.IsMouseButtonUp(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    click = true;
                }
                if (leftClick)
                {
                    for (int x = 0; x < gridWidth; x++)
                    {
                        for (int y = 0; y < gridHeight; y++)
                        {
                            System.Console.Write(grid[x,y] + ", ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                for (int x = 0; x < gridWidth; x++)
                {
                    rpoint = 0;
                    ypoint = 0;
                    for (int y = 0; y < gridHeight; y++)
                    {
                        if (grid[x, y] == 1)
                        {
                            rpoint++;
                            ypoint = 0;
                        }
                        else if (grid[x, y] == 2)
                        {
                            ypoint++;
                            rpoint = 0;
                        }
                        if (rpoint == 4)
                        {
                            Environment.Exit(0);
                        }
                        else if (ypoint == 4)
                        {
                            Environment.Exit(0);
                        }
                    }
                }
                for (int y = 0; y < gridHeight; y++)
                {
                    rpoint = 0;
                    ypoint = 0;
                    for (int x = 0; x < gridWidth; x++)
                    {
                        if (grid[x, y] == 1)
                        {
                            rpoint++;
                            ypoint = 0;
                        
                        }
                        else if (grid[x, y] == 2)
                        {
                            ypoint++;
                            rpoint = 0;
                        }
                        if (rpoint == 4)
                        {
                            Environment.Exit(0);
                        }
                        else if (ypoint == 4)
                        {
                            Environment.Exit(0);
                        }

                    }
                }


                Raylib.EndDrawing();
            }
        }
    }
}


// credit to Elias for removing gray
