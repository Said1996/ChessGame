using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Chess.Models.Pieces
{
    class test
    {
        public static void Main()
        {
            Console.WriteLine("hey");
            Console.ReadLine();

            int[] aaa = {1,2,3};
            List<int[]> hey = new List<int[]>();
            List<int[]> cow = new List<int[]>();
            List<int[]> hi = new List<int[]>();
            hey.Add(aaa);
            hey.Add(aaa);
            hey.Add(aaa);
            
            hi.Add(aaa);
            hi.Add(new int[]{ 12,3,4,5});
            hi.Add(new int[]{ 12,3,4,5});
            
            cow = hey.AsQueryable().Intersect(hi);

            foreach(int[] item in cow)
            {
                foreach(int x in item)
                Console.WriteLine(x);
            }
        }
    }
 
}
