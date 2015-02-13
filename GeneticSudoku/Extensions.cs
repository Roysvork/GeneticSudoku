using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSudoku
{
    public static class Extensions
    {
        public static IEnumerable<int> Row(this int[,] data, int y)
        {
            return Enumerable.Range(0, 9).Select(x => data[x, y]).OrderBy(o => o);
        }

        public static IEnumerable<int> Column(this int[,] data, int x)
        {
            return Enumerable.Range(0, 9).Select(y => data[x, y]).OrderBy(o => o);
        }

        public static IEnumerable<int> Square(this int[,] data, int x, int y)
        {
            return new List<int>
                               {
                                   data[x, y],
                                   data[x + 1, y],
                                   data[x + 2, y],
                                   data[x, y + 1],
                                   data[x + 1, y + 1],
                                   data[x + 2, y + 1],
                                   data[x, y + 2],
                                   data[x + 1, y + 2],
                                   data[x + 2, y + 2]
                               }.OrderBy(o => o);
        }
    }
}
