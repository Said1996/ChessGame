using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Automation.Peers;




namespace Chess.Models.Pieces
{
    class Knight
    {


        static List<int[]> NaturalMoves(int[] position)
        {
            List<int[]> naturalMoves = new List<int[]>();

            List<int[]> matrix = new List<int[]>();
            matrix.Add(new int[] { 2, 1 });
            matrix.Add(new int[] { 2, -1 });
            matrix.Add(new int[] { -2, 1 });
            matrix.Add(new int[] { -2, -1 });
            matrix.Add(new int[] { 1, 2 });
            matrix.Add(new int[] { 1, -2 });
            matrix.Add(new int[] { -1, 2 });
            matrix.Add(new int[] { -1, -2 });

            foreach (int[] item in matrix)
            {
                int[] zip = position.Zip(item, (x, y) => x + y).ToArray();
                if (Array.Exists(zip, element => element > 8 || element < 1))
                {
                    continue;
                }
                else
                {
                    naturalMoves.Add(zip);
                }
            }
            
            return naturalMoves;
        }

        //int[][] avaliableMoves()
        //{

        //}

        //public static void Main()
        //{
        //    NaturalMoves(new int[] { 5, 3 });
        //}


    }
}

