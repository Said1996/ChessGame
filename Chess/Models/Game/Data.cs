using System;
using System.Collections.Generic;
using System.Text;
using Chess.Models.Pieces;
using System.Linq;
using System.ComponentModel;

namespace Chess.Models.Game
{

    class Data
    {
        static public List<List<int[]>> _positionsToBlockCheck = new List<List<int[]>>();
        static public Dictionary<Piece, List<int[]>> _pinnedPieces = new Dictionary<Piece, List<int[]>>();

        static public void GettingData()
        {
            PinnedPieces();
            PositionsToBlockCheck();
        }
        public static void PinnedPieces()
        {
            _pinnedPieces.Clear();
            foreach (var piece in Board.board.allPiecesObjects)
            {
                int i = 0;
                foreach (var list in piece.PiecesIntersectTheWay())
                {
                    
                    if(list.Count >= 2)
                    {
                        var pinnedOne = Board.board.allPiecesObjects.Find(x => x.Position.SequenceEqual(list[0]));
                        var king = Board.board.allPiecesObjects.Find(x => x.Position.SequenceEqual(list[1]));
                        if (pinnedOne.Side != piece.Side && king.Side != piece.Side && king is King )
                        {   
                            
                            _pinnedPieces.Add(pinnedOne, piece._naturalMoves[i].Prepend(piece.Position).ToList());
                        }
                    }
                    i++;
                }
            }
        }

        public static List<List<int[]>> PositionsToBlockCheck()
        {
            _positionsToBlockCheck.Clear();
            var king = Board.board.allPiecesObjects.Find(x => x.Side == Move.Turn && x is King);
            
            foreach (var piece in Board.board.allPiecesObjects)
            {
                if(piece.Side != Move.Turn)
                {
                    foreach (var list in piece.LineOfFire())
                    {
                        foreach (var position in list)
                        {
                            if (position.SequenceEqual(king.Position))
                            {
                                var listCopy = list.Prepend(piece.Position).ToList();
                                _positionsToBlockCheck.Add(listCopy);
                            }
                        }
                    }
                }
            }
            return _positionsToBlockCheck;
        }
    }
}
