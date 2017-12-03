using System.Collections.Generic; // for IEnumerable<T>
using System.Linq; // for LINQ extension methods
using static System.Console;

namespace LinqWithSets
{
    class Program
    {
        private static void Output(
         IEnumerable<string> cohort, string description = "")
        {
            if (!string.IsNullOrEmpty(description))
            {
                WriteLine(description);
            }
            Write(" ");
            WriteLine(string.Join(", ", cohort.ToArray()));
        }

        static void Main(string[] args)
        {
            var cohort1 = new string[]
         { "Rachel", "Gareth", "Jonathan", "George" };
            var cohort2 = new string[]
                { "Jack", "Stephen", "Daniel", "Jack", "Jared" };
            var cohort3 = new string[]
              { "Declan", "Jack", "Jack", "Jasmine", "Conor" };
            Output(cohort1, "Cohort 1");
            Output(cohort2, "Cohort 2");
            Output(cohort3, "Cohort 3");
            WriteLine();
            Output(cohort2.Distinct(),
              "cohort2.Distinct(): removes duplicates");
            Output(cohort2.Union(cohort3),
              "cohort2.Union(cohort3): combines and removes duplicates");
            Output(cohort2.Concat(cohort3),
              "cohort2.Concat(cohort3): combines but leaves duplicates");
            Output(cohort2.Intersect(cohort3),
              "cohort2.Intersect(cohort3): items that are in both sequences");
            Output(cohort2.Except(cohort3),
              "cohort2.Except(cohort3): removes items from the first sequence that are in the second sequence");

            Output(cohort1.Zip(cohort2,
              (c1, c2) => $"{c1} matched with {c2}"),
              "cohort1.Zip(cohort2, (c1, c2) => $\"{c1} matched with {c2}\")" +
              ": matches items based on position in the sequence");
        }
    }
}
