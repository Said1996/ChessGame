using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation.Peers;
using Chess.Models.Game;

namespace Chess.Models.Pieces
{
    class Queen : Piece
    {
        public Queen(int x, int y, string side) : base(x, y, side)
        {

        }
        public override List<int[]> Matrix(bool IsfirstMove)
        {
            List<int[]> matrix = new List<int[]>();
            matrix.Add(new int[] { 0, 1 });
            matrix.Add(new int[] { 1, 0 });
            matrix.Add(new int[] { 0, -1 });
            matrix.Add(new int[] { -1, 0 });
            matrix.Add(new int[] { 1, 1 });
            matrix.Add(new int[] { 1, -1 });
            matrix.Add(new int[] { -1, -1 });
            matrix.Add(new int[] { -1, 1 });
            return matrix;
        }

    }

}

