using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Automation.Peers;
using Chess.Models.Game;

namespace Chess.Models.Pieces
{
    class King : Piece
    {
        public King(int x, int y, string side) : base(x, y, side)
        {

        }
        public override List<int[]> Matrix(bool IsFirstMove)
        {
            List<int[]> matrix = new List<int[]>();
            matrix.Add(new int[] { 1, 0 });
            matrix.Add(new int[] { -1, 0 });
            matrix.Add(new int[] { 0, 1 });
            matrix.Add(new int[] { 0, -1 });
            matrix.Add(new int[] { 1, 1 });
            matrix.Add(new int[] { 1, -1 });
            matrix.Add(new int[] { -1, 1 });
            matrix.Add(new int[] { -1, -1 });

            return matrix;
        }


        public override List<List<int[]>> LineOfFire()
        {
            var naturalMoves = NaturalMoves();
            return naturalMoves;
        }

        public override List<int[]> AvailableMoves()
        {
            var lineOfFire = LineOfFire();
            var availableMoves = new List<int[]>();
            
            foreach(var item in lineOfFire)
            {
                if(item.Count != 0)
                {
                    availableMoves.Add(item[0]);
                }
            }
            foreach (var piece in Board.board.allPiecesObjects)
            {
                if (piece.Side == this.Side &&  !(piece is King))        //Remove Ally Positions from king's available moves 
                {
                    availableMoves.RemoveAll(x => x.SequenceEqual(piece.Position));
                }
                else if (piece.Side != this.Side && !(piece is King))   
                {
                    if (piece.AvailableMoves().Exists(x => x.SequenceEqual(Position))) //Remove Enemy natural moves if check King (piece that checked only)
                    {   
                        foreach (var list in piece.NaturalMoves())
                        {
                            foreach (var pos in list)
                            {
                                availableMoves.RemoveAll(x => x.SequenceEqual(pos));
                            }
                        }
                    }
                    foreach (var list in piece.LineOfFire())               //Remove All positions of king of all Enemies lineOfFIre (Result: Positions where king can move)
                    {
                        foreach (var pos in list)
                        {
                            availableMoves.RemoveAll(x => x.SequenceEqual(pos));
                        }
                    }
                }
            }
            return availableMoves;
        }
    }
}

