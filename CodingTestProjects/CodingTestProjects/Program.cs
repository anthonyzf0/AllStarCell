using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTestProjects
{
    class Program
    {
        static int num = 0;

        //Draws the board given a long
        static void drawBoard(long l)
        {
            String vals = Convert.ToString(l, 2).PadLeft(64,'0').Replace("1","X ").Replace("0","- ");

            for (int x = 0; x < 8; x++)
                Console.WriteLine(vals.Substring(x * 16, 16));

            Console.WriteLine();

        }
        
        static long checkPosition(long map, int row, int col)
        {
            String val = "";
            String point = "";

            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                {

                    if (x == row || y == col || (x - row == y - col) || (x - row == col - y))
                        val += "1";
                    else
                        val += "0";

                    point += (x == row && y == col) ? "1" : "0";
                }

            long value = Convert.ToInt64(val, 2);
            long newMap = Convert.ToInt64(point, 2) | map;

            return ((value & map) == 0)?newMap: 0;
            
        }

        static void recursion(long map, int col)
        {
            if (col == 8)
            {
                drawBoard(map);
                num++;
                return;
            }

            for (int i = 0; i < 8; i++)
            {
                long newMap = checkPosition(map, i, col);
                if (newMap != 0)
                    recursion(newMap, col + 1);
            }

        }

        static void Main(string[] args)
        {
            recursion(0, 0);
            Console.WriteLine(num);
            Console.ReadLine();
        }
    }
}
