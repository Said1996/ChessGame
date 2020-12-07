using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Chess.Models.Game;

namespace Chess.Models.Pieces
{
    class Bishop : Piece
    {
        public Bishop(int x, int y, string side) : base(x, y, side)
        { 

        }
        public override List<int[]> Matrix(bool IsFirstMove)
        {
            List<int[]> matrix = new List<int[]>();
            matrix.Add(new int[] { 1, 1 });
            matrix.Add(new int[] { 1, -1 });
            matrix.Add(new int[] { -1, -1 });
            matrix.Add(new int[] { -1, 1 });
            return matrix;
        }


    }
}

