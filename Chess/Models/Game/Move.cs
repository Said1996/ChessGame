using System;
using System.Collections.Generic;
using System.Text;
using Chess.Models.Pieces;

namespace Chess.Models.Game
{
    class Move
    {
        public static Board X = new Board();
        public static void MovePiece(int[] piece, int[] target)
        {
            if (IsPieceExist(piece)
            {
                if IsValidMove(piece, target)
                {


                } 
                else 
                {
                    
                }

            }
            else { }

        }

        bool IsPieceExist(int[] piece)
        {
            bool isPieceExist = X.allPieces.Contains(piece);
            return isPieceExist;
        }


        public static List<int[]> GetPrimaryMoves(int[] piece)
        {
            switch (piece[2])
            {
                case 0:
                    return King.PrimaryMoves(piece);
                case 1:
                    return Pawn.PrimaryMoves(piece);
                case 2:
                    return Bishop.PrimaryMoves(piece);
                case 3:
                    return Knight.PrimaryMoves(piece);
                case 4:
                    return Rook.PrimaryMoves(piece);
                case 5:
                    return Queen.PrimaryMoves(piece);
            }
        List<int[]> GetAvailableMoves(int[] piece)
            {
                switch (piece[2])
                {
                    case 0:
                        return King.AvailableMoves(piece);
                    case 1:
                        return Pawn.AvailableMoves(piece);
                    case 2:
                        return Bishop.AvailableMoves(piece);
                    case 3:
                        return Knight.AvailableMoves(piece);
                    case 4:
                        return Rook.AvailableMoves(piece);
                    case 5:
                        return Queen.AvailableMoves(piece);
                }

                bool IsValidMove(int[] piece, int[] target)
                {
                    List<int[]> x = GetAvailableMoves(piece);
                    return x.Contains(target);
                }
            }








            void Main()
            {
                bool z = IsPieceExist(new int[] { 2, 3, 4, 5 });
                Console.WriteLine(z);
            }
        }
    }
}  