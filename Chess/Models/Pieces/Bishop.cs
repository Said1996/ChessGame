using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chess.Models.Pieces
{
    static class Bishop
    {


        static List<List<int[]>> NaturalMoves(int[] position)
        {
            List<List<int[]>> naturalMoves = new List<List<int[]>>();


            int[] DiagonalStartupPosition(int[] position)
            {
                int minimum = Math.Min(position[0], position[1]);
                if (minimum != 1)
                {
                    int decrement = minimum - 1;
                    int[] startupPosition = new int[] { position[0] - decrement, position[1] - decrement };
                    return startupPosition;
                }
                else
                {
                    return position;
                }
            }

            List<int[]> RightDiagonal(int[] position)
            {
                int[] appendedPosition = DiagonalStartupPosition(position);
                List<int[]> rightDiagonal = new List<int[]>();
                while (true)
                {
                    rightDiagonal.Add(new int[] { appendedPosition[0], appendedPosition[1] });
                    appendedPosition[0] += 1;
                    appendedPosition[1] += 1;
                    if (Array.Exists(appendedPosition, element => element == 9))
                    {
                        break;
                    }
                }
                return rightDiagonal;
            }


            List<int[]> leftDiagonal()
            {                       // 1  2  3  4  5  6  7  8
                int[] swapArray = { 0, 8, 7, 6, 5, 4, 3, 2, 1 };

                int[] mirrorPosition = new int[] { swapArray[position[0]], position[1] };
                int[] startupMirroredPosition = DiagonalStartupPosition(mirrorPosition);
                List<int[]> mirroredLeftDiagonalPositions = RightDiagonal(startupMirroredPosition);
                List<int[]> leftDiagonalPositions = new List<int[]>();

                for (int i = 0; i < mirroredLeftDiagonalPositions.Count; i++)
                {
                    int swapX = mirroredLeftDiagonalPositions[i][0];
                    leftDiagonalPositions.Add(new int[] { Array.IndexOf(swapArray, swapX), mirroredLeftDiagonalPositions[i][1] });
                }
                return leftDiagonalPositions;
            }

            naturalMoves.Add(RightDiagonal(position));
            naturalMoves.Add(leftDiagonal());

            return naturalMoves;
        }

        //int[][] avaliableMoves()
        //{

        //}

    }
}

