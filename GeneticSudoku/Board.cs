namespace GeneticSudoku
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class Board
    {
        private readonly int[,] data = { };

        private static readonly IEnumerable<int> Correct = Enumerable.Range(1, 9);

        public Board(int[,] data)
        {
            this.data = data;
        }

        public int Violations()
        {
            var violations = 0;

            // rows
            for (var y = 0; y < 9; y++)
            {
                var sequence = data.Row(y);
                if (!sequence.SequenceEqual(Correct))
                {
                    violations++;
                }
            }

            // columns
            for (var x = 0; x < 9; x++)
            {
                var sequence = data.Column(x);
                if (!sequence.SequenceEqual(Correct))
                {
                    violations++;
                }
            }

            // sqaures
            for (var x = 0; x < 9; x = x + 3)
            {
                for (var y = 0; y < 9; y = y + 3)
                {
                    var sequence = data.Square(x, y);
                    if (!sequence.SequenceEqual(Correct))
                    {
                        violations++;
                    }
                }
            }

            return violations;
        }

        public static implicit operator int[,](Board board)
        {
            int[,] data = new int[9, 9];
            for (var x = 0; x < 9; x++)
            {
                for (var y = 0; y < 9; y++)
                {
                    data[x,y] = board.data[x,y];
                }
            }

            return data;
        }
    }
}
