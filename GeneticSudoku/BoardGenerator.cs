namespace GeneticSudoku
{
    using System;
    using System.Linq;

    public static class BoardGenerator
    {
        public static Random random = new Random();

        public static Board Random()
        {
            int[,] data = new int[9,9];
            for (var x = 0; x < 9; x++)
            {
                for (var y = 0; y < 9; y++)
                {
                    data[x,y] = R();
                }
            }

            return new Board(data);
        }

        public static Board ChildBoard(this Board board, int mutationRate)
        {
            int[,] data = board;
            foreach (var change in Enumerable.Range(0, random.Next(0, mutationRate)).Select(o => new { x = R(), y = R(), z = R() }))
            {
                data[change.x,change.y] = change.z + 1;
            }

            return new Board(data);
        }

        public static Board MateWith(this Board board, Board otherBoard, int mutationRate)
        {
            var sources = new[] { board, otherBoard };
            int[,] data = board;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    var source = random.Next(0, 1);
                    data[x, y] = ((int[,])sources[source])[x, y];
                }
            }

            foreach (var change in Enumerable.Range(0, random.Next(0, mutationRate)).Select(o => new { x = R(), y = R(), z = R() }))
            {
                data[change.x, change.y] = change.z + 1;
            }

            return new Board(data);
        }

        private static int R()
        {
            return random.Next(0, 9);
        }
    }
}
