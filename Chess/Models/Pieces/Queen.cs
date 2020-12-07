using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation.Peers;
using Chess.Models.Game;

namespace Chess.Models.Pieces
{
    class Queen
    {

        static List<List<int[]>> NaturalMoves(int[] position)
        {
            List<List<int[]>> naturalMoves = new List<List<int[]>>();

            List<int[]> verticalMovement = new List<int[]>();
            List<int[]> horizontalMovement = new List<int[]>();
            for (int i = 1; i < 9; i++)
            {
                verticalMovement.Add(new int[] { position[0], i });
                horizontalMovement.Add(new int[] { i, position[1] });
            }

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
            {
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

            naturalMoves.Add(verticalMovement);
            naturalMoves.Add(horizontalMovement);
            naturalMoves.Add(RightDiagonal(position));
            naturalMoves.Add(leftDiagonal());

            return naturalMoves;
        }



        


        //static int[][] avaliablemoves( int[] position)
        //{
        //    List<List<int[]>> naturalmoves = NaturalMoves(position);

        //    foreach (int[] item in board.AllPieces)
        //    {
        //        int[] boardposition = new int[] { item[0], item[1] };
        //        for (int i = 0; i < 4; i++)
        //        {
        //            if (naturalmoves[i].Contains(boardposition))
        //            {
        //                int boardpositionindex = naturalmoves[i].IndexOf(boardposition);
        //                int positionindex = naturalmoves[i].IndexOf(position);
        //                if (boardpositionindex < positionindex)
        //                {
        //                    naturalmoves[i] = naturalmoves[i].GetRange(boardpositionindex-1, naturalmoves[i]);
        //                }
        //                else if (boardpositionindex > positionindex)
        //                {

        //                }
        //            }
        //        }
        //    }
        //}
        //public static void Main()
        //{
        //    NaturalMoves(new int[] { 5, 3 });
        //}

    }

}

