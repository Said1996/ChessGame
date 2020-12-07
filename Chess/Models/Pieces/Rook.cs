using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chess.Models.Pieces
{
    class Rook : Piece
    {
        public Rook(int x, int y, string side) : base(x, y, side)
        {

        }
        public override List<int[]> Matrix(bool IsfirstMove)
        {
            List<int[]> matrix = new List<int[]>();
            matrix.Add(new int[] { 0, 1 });
            matrix.Add(new int[] { 1, 0 });
            matrix.Add(new int[] { 0, -1 });
            matrix.Add(new int[] { -1, 0 });
            return matrix;
        }


 
        

        //Piece in the way 
        //Queen,Bishop,Rook,Pawn

        // Two ideas to solve this : Loop over every primary move 

        //King Check
        //King Checked
        //Remove position if its ally

        //int[][] avaliableMoves()
        //{

        //}


        //public static void Main()
        //{
        //    NaturalMoves(new int[] { 2,4 });
        //}
    }

}

