using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Chess.Models.Game
{
    class Board
    {
        public List<int[]> allPieces = new List<int[]>();

        public Board()
        {
            Console.WriteLine("boardIntiated");
            allPieces.Add(new int[]{ 1, 1, 4, 1, 1});
            allPieces.Add(new int[]{ 2, 1, 3, 1, 2});
            allPieces.Add(new int[]{ 3, 1, 2, 1, 3});
            allPieces.Add(new int[]{ 4, 1, 5, 1, 4});
            allPieces.Add(new int[]{ 5, 1, 0, 1, 5});
            allPieces.Add(new int[]{ 6, 1, 2, 1, 6});
            allPieces.Add(new int[]{ 7, 1, 3, 1, 7});
            allPieces.Add(new int[]{ 8, 1, 4, 1, 8});
            allPieces.Add(new int[]{ 1, 2, 1, 1, 9});
            allPieces.Add(new int[]{ 2, 2, 1, 1, 10});
            allPieces.Add(new int[]{ 3, 2, 1, 1, 11});
            allPieces.Add(new int[]{ 4, 2, 1, 1, 12});
            allPieces.Add(new int[]{ 5, 2, 1, 1, 13});
            allPieces.Add(new int[]{ 6, 2, 1, 1, 14});
            allPieces.Add(new int[]{ 7, 2, 1, 1, 15});
            allPieces.Add(new int[]{ 8, 2, 1, 1, 16});
            allPieces.Add(new int[]{ 1, 7, 1, 0, 17});
            allPieces.Add(new int[]{ 2, 7, 1, 0, 18});
            allPieces.Add(new int[]{ 3, 7, 1, 0, 19});
            allPieces.Add(new int[]{ 4, 7, 1, 0, 20});
            allPieces.Add(new int[]{ 5, 7, 1, 0, 21});
            allPieces.Add(new int[]{ 6, 7, 1, 0, 22});
            allPieces.Add(new int[]{ 7, 7, 1, 0, 23});
            allPieces.Add(new int[]{ 8, 7, 1, 0, 24});
            allPieces.Add(new int[]{ 1, 8, 4, 0, 25});
            allPieces.Add(new int[]{ 2, 8, 3, 0, 26});
            allPieces.Add(new int[]{ 3, 8, 2, 0, 27});
            allPieces.Add(new int[]{ 4, 8, 5, 0, 28});
            allPieces.Add(new int[]{ 5, 8, 0, 0, 29});
            allPieces.Add(new int[]{ 6, 8, 2, 0, 30});
            allPieces.Add(new int[]{ 7, 8, 3, 0, 31});
            allPieces.Add(new int[]{ 8, 8, 4, 0, 32});

        }

    }
    //ToDo: list of { position, type, side}
    //ToDo: Delete from List when die
    //ToDo: Move Item
    
}
