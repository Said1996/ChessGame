using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Chess.Models.Game;
using System.Runtime.CompilerServices;

namespace Chess.Models.Pieces
{
    public abstract class Piece
    {
        public int[] Position { get; set; }
        public string Side { get; set; }
        public bool IsfirstMove = true;
        public List<List<int[]>> _naturalMoves { get; set; }
        public List<List<int[]>> _piecesIntersectTheWay { get; set; }
        public List<List<int[]>> _lineOfFire { get; set; }
        
        

        public Piece(int positionX, int positionY, string side)
        {
            Position = new int[] { positionX, positionY };
            Side = side;
        }

        public abstract List<int[]> Matrix(bool IsfirstMove);
        
        public virtual List<List<int[]>> NaturalMoves()
        {
            _naturalMoves = new List<List<int[]>>();
            var matrix = Matrix(IsfirstMove);           
            for (int i = 0; i < matrix.Count; i++)
            {
                _naturalMoves.Add(new List<int[]>());
                var tempPos = Position;
                do
                {
                    int[] zip = Enumerable.Zip(matrix[i], tempPos, (x, y) => x + y).ToArray();
                    if (Array.Exists(zip, element => element < 1 || element > 8))
                    {
                        break;
                    }
                    else
                    {
                        _naturalMoves[i].Add(zip);
                        if (this is Bishop|| this is Rook || this is Queen)
                        {
                            tempPos = zip;
                        }
                    }
                } while (this is Bishop || this is Rook || this is Queen);
            }
            return _naturalMoves;
        }
        
        public List<List<int[]>> PiecesIntersectTheWay()
        {
            NaturalMoves();
            _piecesIntersectTheWay = new List<List<int[]>>();
            for (int i = 0; i < _naturalMoves.Count; i++)
            {
                _piecesIntersectTheWay.Add(new List<int[]>());
                for (int j = 0; j < _naturalMoves[i].Count; j++)
                {

                    if (Board.board.allPiecesObjects.Exists(x => x.Position.SequenceEqual(_naturalMoves[i][j])))
                    {
                        _piecesIntersectTheWay[i].Add(_naturalMoves[i][j]);
                    }
                  
                }
            }
            return _piecesIntersectTheWay;
        }

        public virtual List<List<int[]>> LineOfFire()
        {
            var piecesOnTheWay = PiecesIntersectTheWay();
            _lineOfFire = _naturalMoves;
            

            for (int i = 0; i < _lineOfFire.Count; i++)
            {
                
                    if(piecesOnTheWay[i].Count != 0) 
                    {
                    var index = _lineOfFire[i].IndexOf(piecesOnTheWay[i][0]);
                    _lineOfFire[i] = _lineOfFire[i].GetRange(0, index + 1);
                    }
                
            }
            return _lineOfFire;
        }

    
        public virtual List<int[]> AvailableMoves()
        {
            var _availableMoves = new List<int[]>();
            

            foreach (List<int[]> item in LineOfFire())
            {
                if(item.Count != 0)
                {
                    if (Board.board.allPiecesObjects.Exists(x => x.Position.SequenceEqual(item.Last()) && x.Side == Side))
                    {
                        item.RemoveAt(item.Count - 1);
                    }
                }
                _availableMoves.AddRange(item);
            }
            

            foreach(var item in Data._pinnedPieces)
            {
                if(item.Key == this && Data._positionsToBlockCheck.Count == 1 || Data._positionsToBlockCheck.Count > 1)
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
            
            
           
            if(Data._positionsToBlockCheck.Count == 1)
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
