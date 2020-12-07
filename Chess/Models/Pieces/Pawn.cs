using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows.Automation.Peers;

namespace Chess.Models.Pieces
{
    class Pawn
    {


        static List<int[]> NaturalMoves(int[] position)
        {
            List<int[]> naturalMoves = new List<int[]>();
            if (Array.Exists(position, elemet => elemet != 8 || elemet != 1))
            {
                if (position[3] == 1)
                {
                    naturalMoves.Add(new int[] { position[0], position[1] + 1 });
                    naturalMoves.Add(new int[] { position[0] + 1, position[1] + 1 });
                    naturalMoves.Add(new int[] { position[0] - 1, position[1] + 1 });
                }
                else
                {
                    naturalMoves.Add(new int[] { position[0], position[1] - 1 });
                    naturalMoves.Add(new int[] { position[0] + 1, position[1] - 1 });
                    naturalMoves.Add(new int[] { position[0] - 1, position[1] - 1 });
                }
            }

            return naturalMoves;
        }

        //int[][] avaliableMoves()
        //{

        //}

    }
}

