using System;
using System.Collections.Generic;

namespace YabsProblemC
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] kingdomSize = new int[]();
            //int[] sizeInputs = Array.ConvertAll(Console.ReadLine().Split(' '), (item) => Convert.ToInt32(item));
            //kingdomSize.Add(sizeInputs[0], sizeInputs[1]);

            int[] kingdomSize = Array.ConvertAll(Console.ReadLine().Split(' '), (item) => Convert.ToInt32(item));

            //int[] knightPosition = new int[]();
            //int[] knightPosInputs = Array.ConvertAll(Console.ReadLine().Split(' '), (item) => Convert.ToInt32(item));
            //knightPosition.Add(knightPosInputs[0], knightPosInputs[1]);

            int[] knightPosition = Array.ConvertAll(Console.ReadLine().Split(' '), (item) => Convert.ToInt32(item));

            //int[] capitalPosition = new int[]();
            //int[] capitalPosInputs = Array.ConvertAll(Console.ReadLine().Split(' '), (item) => Convert.ToInt32(item));
            //capitalPosition.Add(capitalPosInputs[0], capitalPosInputs[1]);

            int[] capitalPosition = Array.ConvertAll(Console.ReadLine().Split(' '), (item) => Convert.ToInt32(item));

            int amountOfMoves = 0;
            bool isRunning = true;

            while (isRunning)
            {
                if (knightPosition[0] == capitalPosition[0] && knightPosition[1] == capitalPosition[1])
                {
                    Console.WriteLine(amountOfMoves);
                    isRunning = false;
                    return;
                }
                bool knightFurtherLeft = false;
                bool knightFurtherRight = false;

                bool knightFurtherUp = false;
                bool knightFurtherDown = false;

                int pathLength_X;
                int pathLength_Y;

                // if knight is further left than capital (HORIZONTAL)
                if (knightPosition[0] < capitalPosition[0])
                {
                    pathLength_X = capitalPosition[0] - knightPosition[0];
                    knightFurtherLeft = true;
                }
                else
                {
                    pathLength_X = knightPosition[0] - capitalPosition[0];
                    knightFurtherRight = true;
                }

                // if knight is further up than capital (VERTICAL)
                if (knightPosition[1] < capitalPosition[1])
                {
                    pathLength_Y = capitalPosition[1] - knightPosition[1];
                    knightFurtherUp = true;
                }
                else
                {
                    pathLength_Y = knightPosition[1] - capitalPosition[1];
                    knightFurtherDown = true;
                }

                // MOVES METHODCALLINGS STARTING

                // IF POSITION IS CLOSE BUT WILL NOT MAKE IT WITH REGULAR ALGORITHM
                if (pathLength_X == 4 && pathLength_Y == 4)
                {
                    knightPosition = KnightMoveDownRight(knightPosition);
                    amountOfMoves++;
                    knightPosition = KnightMoveDownRight(knightPosition);
                    amountOfMoves++;
                    knightPosition = KnightMoveUpRight(knightPosition);
                    amountOfMoves++;
                    knightPosition = KnightMoveDownRight(knightPosition);
                    amountOfMoves++;
                }

                // LEFT UP
                else if (knightFurtherLeft && knightFurtherUp && pathLength_X >= pathLength_Y)
                {
                    knightPosition = KnightMoveRightDown(knightPosition);
                    amountOfMoves++;
                }

                else if (knightFurtherLeft && knightFurtherUp && pathLength_X <= pathLength_Y)
                {
                    knightPosition = KnightMoveDownRight(knightPosition);
                    amountOfMoves++;
                }

                // LEFT DOWN
                else if (knightFurtherLeft && knightFurtherDown && pathLength_X <= pathLength_Y)
                {
                    knightPosition = KnightMoveUpRight(knightPosition);
                    amountOfMoves++;
                }

                else if (knightFurtherLeft && knightFurtherDown && pathLength_X >= pathLength_Y)
                {
                    knightPosition = KnightMoveRightUp(knightPosition);
                    amountOfMoves++;
                }

                // RIGHT UP
                else if (knightFurtherRight && knightFurtherUp && pathLength_X <= pathLength_Y)
                {
                    knightPosition = KnightMoveDownLeft(knightPosition);
                    amountOfMoves++;
                }

                else if (knightFurtherRight && knightFurtherUp && pathLength_X >= pathLength_Y)
                {
                    knightPosition = KnightMoveLeftDown(knightPosition);
                    amountOfMoves++;
                }

                // RIGHT DOWN
                else if (knightFurtherRight && knightFurtherDown && pathLength_X <= pathLength_Y)
                {
                    knightPosition = KnightMoveUpLeft(knightPosition);
                    amountOfMoves++;
                }

                else if (knightFurtherRight && knightFurtherDown && pathLength_X >= pathLength_Y)
                {
                    knightPosition = KnightMoveLeftUp(knightPosition);
                    amountOfMoves++;
                }

                // MOVES METHODCALLING ENDS
            }
        }

        static int[] KnightMoveUpLeft(int[] knightPos)
        {
            knightPos[1] -= 2;
            knightPos[0] -= 1;

            return knightPos;
        }

        static int[] KnightMoveUpRight(int[] knightPos)
        {
            knightPos[1] -= 2;
            knightPos[0] += 1;

            return knightPos;
        }

        static int[] KnightMoveRightUp(int[] knightPos)
        {
            knightPos[0] += 2;
            knightPos[1] -= 1;

            return knightPos;
        }

        static int[] KnightMoveRightDown(int[] knightPos)
        {
            knightPos[0] += 2;
            knightPos[1] += 1;

            return knightPos;
        }

        static int[] KnightMoveDownRight(int[] knightPos)
        {
            knightPos[1] += 2;
            knightPos[0] += 1;

            return knightPos;
        }

        static int[] KnightMoveDownLeft(int[] knightPos)
        {
            knightPos[1] += 2;
            knightPos[0] -= 1;

            return knightPos;
        }

        static int[] KnightMoveLeftDown(int[] knightPos)
        {
            knightPos[0] -= 2;
            knightPos[1] += 1;

            return knightPos;
        }

        static int[] KnightMoveLeftUp(int[] knightPos)
        {
            knightPos[0] -= 2;
            knightPos[1] -= 1;

            return knightPos;
        }
    }
}
