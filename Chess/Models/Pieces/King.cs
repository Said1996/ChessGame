using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Chess.Models.Game;

namespace Chess.Models.Pieces
{
    class King
    {


        static List<int[]> NaturalMoves(int[] position)
        {
            List<int[]> naturalMoves = new List<int[]>();

            List<int[]> matrix = new List<int[]>();
            matrix.Add(new int[] { 1, 0 });
            matrix.Add(new int[] { -1, 0 });
            matrix.Add(new int[] { 0, 1 });
            matrix.Add(new int[] { 0, -1 });
            matrix.Add(new int[] { 1, 1 });
            matrix.Add(new int[] { 1, -1 });
            matrix.Add(new int[] { -1, 1 });
            matrix.Add(new int[] { -1, -1 });

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
            foreach (var res in naturalMoves)
            {
                Console.WriteLine(string.Join(",", res));
            }
            return naturalMoves;
        }

        static List<int[]> PrimaryMoves(int[] position)
        {
            List<int[]> naturalMoves = NaturalMoves(position);
            return naturalMoves;
        }

        static List<int[]> AvaliableMoves(int[] position)
        {
            List<int[]> avaliableMoves = NaturalMoves(position);

            foreach(int[] piecePosition in Move.X.allPieces)
            {
                List<int[]> unavailablePositions = Move.GetPrimaryMoves(position);
                avaliableMoves = avaliableMoves.Except(unavailablePositions).ToList();
            }
            return avaliableMoves;
        }

        //public static void Main()
        //{
        //    NaturalMoves(new int[] { 5, 3 });
        //}

    }
}

