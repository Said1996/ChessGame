using System;
using System.Collections.Generic;
using System.Text;
using Chess.Models.Pieces;
using Chess;
using System.Linq;

namespace Chess.Models.Game
{
    class Move
    {
        public static string Turn = "White";
        static List<Piece> allPieces = Board.board.allPiecesObjects;
        
        public static List<int[]> Select(int[]from)
        {
            var obj = allPieces.Find(x => x.Position.SequenceEqual(from));
            if (Turn == obj.Side)
            {
                return obj.AvailableMoves();
            }
            else
            {
                return new List<int[]>();
            }
            
        }
        


        public static void DoMove(int[] moveFrom, int[] moveTo)
        {
            

            allPieces.RemoveAll(x => x.Position.SequenceEqual(moveTo));
            var piece = allPieces.Find(x => x.Position.SequenceEqual(moveFrom));
            piece.IsfirstMove = false;
            piece.Position = moveTo;

            if(Turn == "Black")
            {
                Turn = "White";
            }
            else
            {
                Turn = "Black";
            }

            Data.GettingData();
        }
    }
}  