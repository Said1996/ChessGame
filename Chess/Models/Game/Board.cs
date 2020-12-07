using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Chess.Models.Pieces;


namespace Chess.Models.Game
{
    public class Board
    {
        
        
        public List<Piece> allPiecesObjects = new List<Piece>();
        public static Board board = new Board();
        public Board()
        {

            allPiecesObjects.Add(new Rook ( 1, 1, "Black" ));
            allPiecesObjects.Add(new Knight ( 1, 2, "Black"));
            allPiecesObjects.Add(new Bishop ( 1, 3, "Black"));
            allPiecesObjects.Add(new Queen ( 1, 5, "Black"));
            allPiecesObjects.Add(new King ( 1, 4, "Black"));
            allPiecesObjects.Add(new Bishop ( 1, 6, "Black"));
            allPiecesObjects.Add(new Knight ( 1, 7, "Black"));
            allPiecesObjects.Add(new Rook ( 1, 8, "Black"));
            allPiecesObjects.Add(new Pawn ( 2, 1, "Black"));
            allPiecesObjects.Add(new Pawn ( 2, 2, "Black"));
            allPiecesObjects.Add(new Pawn ( 2, 3, "Black"));
            allPiecesObjects.Add(new Pawn ( 2, 4, "Black"));
            allPiecesObjects.Add(new Pawn ( 2, 5, "Black"));
            allPiecesObjects.Add(new Pawn ( 2, 6, "Black"));
            allPiecesObjects.Add(new Pawn ( 2, 7, "Black"));
            allPiecesObjects.Add(new Pawn ( 2, 8, "Black"));
            allPiecesObjects.Add(new Pawn ( 7, 1, "White" ));
            allPiecesObjects.Add(new Pawn ( 7, 2, "White"));
            allPiecesObjects.Add(new Pawn ( 7, 3, "White"));
            allPiecesObjects.Add(new Pawn ( 7, 4, "White"));
            allPiecesObjects.Add(new Pawn ( 7, 5, "White"));
            allPiecesObjects.Add(new Pawn ( 7, 6, "White"));
            allPiecesObjects.Add(new Pawn ( 7, 7, "White"));
            allPiecesObjects.Add(new Pawn ( 7, 8, "White"));
            allPiecesObjects.Add(new Rook ( 8, 1, "White"));
            allPiecesObjects.Add(new Knight ( 8, 2, "White"));
            allPiecesObjects.Add(new Bishop ( 8, 3, "White"));
            allPiecesObjects.Add(new Queen ( 8, 5, "White"));
            allPiecesObjects.Add(new King ( 8, 4, "White"));
            allPiecesObjects.Add(new Bishop ( 8, 6, "White"));
            allPiecesObjects.Add(new Knight ( 8, 7, "White"));
            allPiecesObjects.Add(new Rook ( 8, 8, "White"));

        }

    }
    //ToDo: list of { position, type, side}
    //ToDo: Delete from List when die
    //ToDo: Move Item
    
}
