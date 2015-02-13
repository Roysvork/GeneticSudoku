using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSudoku
{
    class Program
    {
        public const int MutationRate = 20;

        static void Main(string[] args)
        {
            var candidates = Enumerable.Range(0, 9).Select(o => BoardGenerator.Random()).ToList();
            var first = candidates.First();
            var second = candidates.Skip(1).First();

            var generation = 0;
            var violations = 27;
            while (violations > 0)
            {
                first = candidates.OrderBy(o => o.Violations()).First();
                //second = candidates.OrderBy(o => o.Violations()).Skip(1).First();

                violations = first.Violations();

                var newCandidates = new List<Board> { first };
                newCandidates.AddRange(Enumerable.Range(0, 9).Select(o => first.ChildBoard(MutationRate)));

                candidates = newCandidates;
                generation++;

                if (generation % 1000 == 0)
                    Console.WriteLine("Generation {0}, violations {1}", generation, violations);
            }

            Console.WriteLine("We have a winner!");
            Console.ReadKey();
        }
    }
}
