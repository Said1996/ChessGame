using Chess.Models.Game;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Automation.Peers;

namespace Chess.Models.Pieces
{
    class Pawn : Piece
    {
        
        public Pawn(int x, int y, string side) : base(x, y, side)
        {

        }
        public override List<int[]> Matrix(bool IsFirstMove)
        {
            var matrix = new List<int[]>();


            if (this.Side == "Black")
            {
                matrix.Add(new int[] { 1, -1 });
                matrix.Add(new int[] { 1, 1 });
            }
            else
            {
                matrix.Add(new int[] { -1, 1 });
                matrix.Add(new int[] { -1, -1 });
            }
            
            
            return matrix;
        }
        
        public List<int[]> PawnEspecial()
        {
            var matrix = new List<int[]>();

            if (Side == "Black")
            {
                if (Board.board.allPiecesObjects.Exists(x => x.Position[0] == (Position[0] + 1) && x.Position[1] == (Position[1] + 1) && x.Side == "White"))
                {
                    matrix.Add(new int[] { 1, 1 });

                }
                if (Board.board.allPiecesObjects.Exists(x => x.Position[0] == (Position[0] + 1) && x.Position[1] == (Position[1] - 1) && x.Side == "White"))
                {

                    matrix.Add(new int[] { 1, -1 });
                }


                if (!Board.board.allPiecesObjects.Exists(x => x.Position[0] == (Position[0] + 1) && x.Position[1] == Position[1]))
                {
                    matrix.Add(new int[] { 1, 0 });

                    if (IsfirstMove && !Board.board.allPiecesObjects.Exists(x => x.Position[0] == (Position[0] + 2) && x.Position[1] == Position[1]))
                    {
                        matrix.Add(new int[] { 2, 0 });
                    }
                }
            }
            else if (Side == "White")
            {
                if (Board.board.allPiecesObjects.Exists(x => x.Position[0] == (Position[0] - 1) && x.Position[1] == (Position[1] + 1) && x.Side == "Black"))
                {
                    matrix.Add(new int[] { -1, 1 });

                }
                if (Board.board.allPiecesObjects.Exists(x => x.Position[0] == (Position[0] - 1) && x.Position[1] == (Position[1] - 1) && x.Side == "Black"))
                {

                    matrix.Add(new int[] { -1, -1 });
                }

                if (!Board.board.allPiecesObjects.Exists(x => x.Position[0] == (Position[0] - 1) && x.Position[1] == Position[1]))
                {
                    matrix.Add(new int[] { -1, 0 });

                    if (IsfirstMove && !Board.board.allPiecesObjects.Exists(x => x.Position[0] == (Position[0] - 2) && x.Position[1] == Position[1]))
                    {
                        matrix.Add(new int[] { -2, 0 });
                    }
                }
            }
            var pawnEspecial = new List<int[]>();
            for (int i = 0; i < matrix.Count; i++)
            {
                var zip = Enumerable.Zip(matrix[i], Position, (x, y) => x + y).ToArray();
                pawnEspecial.Add(zip);
            }
            return pawnEspecial;
        }

        public override List<int[]> AvailableMoves()
        {
            var _availableMoves = PawnEspecial();
            LineOfFire();

            foreach (var item in Data._pinnedPieces)
            {
                if (item.Key == this && Data._positionsToBlockCheck.Count == 1 || Data._positionsToBlockCheck.Count > 1)
                {
                    _availableMoves.Clear();
                }
                else if (item.Key == this)
                {
                    var list = new List<int[]>();
                    foreach (var pos in _availableMoves)
                    {
                        foreach (var pos2 in item.Value)
                        {
                            if (pos.SequenceEqual(pos2))
                            {
                                list.Add(pos);
                            }
                        }
                    }
                    _availableMoves = list;
                }
            }



            if (Data._positionsToBlockCheck.Count == 1)
            {
                var list = new List<int[]>();

                foreach (var item in _availableMoves)
                {
                    foreach (var item2 in Data._positionsToBlockCheck[0])
                    {
                        if (item.SequenceEqual(item2))
                        {
                            list.Add(item);
                        }
                    }
                }
                _availableMoves = list;
            }

            return _availableMoves;
        }
    }



    
}

