using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Automation.Peers;

namespace Chess.Models.Pieces
{
    class Knight : Piece
    {
        public Knight(int x, int y, string side) : base(x, y, side)
        {

        }
        public override List<int[]> Matrix(bool IsFirstMove)
        {
            List<int[]> matrix = new List<int[]>();
            matrix.Add(new int[] { 2, 1 });
            matrix.Add(new int[] { 2, -1 });
            matrix.Add(new int[] { -2, 1 });
            matrix.Add(new int[] { -2, -1 });
            matrix.Add(new int[] { 1, 2 });
            matrix.Add(new int[] { 1, -2 });
            matrix.Add(new int[] { -1, 2 });
            matrix.Add(new int[] { -1, -2 });
            return matrix;
        }
    }
}

