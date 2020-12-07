using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Models.Pieces
{
    static class Rook
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
            naturalMoves.Add(verticalMovement);
            naturalMoves.Add(horizontalMovement);

            return naturalMoves;
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

