using System.Collections.Generic;
using System.Linq;

namespace HashCode2017.Practice
{
    public static class PizzaSlicer
    {
        public static List<Slice> SlicePizze(Pizza pizza)
        {
            var slices = new List<Slice>();
            for (int i = 0; i < pizza.IngredientRows.Count; i++)
            {
                var slice = new Slice(i,0,i,pizza.MaxCellsPerSlice-1);
                if (slice.IsSufficient(pizza))
                {
                    slices.Add(slice);
                }

            }

            return slices;
        }

        public static List<Slice> SlicePizza2(Pizza pizza)
        {
            var slices = new List<Slice>();
            for (int i = 0; i < pizza.IngredientRows.Count; i++)
            {
                int curEnd = pizza.MaxCellsPerSlice - 1;
                int curStart = 0;
                // Search for 1-Line Slices
                while (curEnd < pizza.Columns)
                {
                    var slice = new Slice(i,curStart,i,curEnd);
                    if (slice.IsSufficient(pizza))
                    {
                        slices.Add(slice);
                        curEnd += pizza.MaxCellsPerSlice;
                        curStart += pizza.MaxCellsPerSlice;
                    }
                    else
                    {
                        curEnd += 1;
                        curStart += 1;
                    }

                }

            }

            return slices;
        }

        private static bool DoesNotOverlapWithSolution(List<Slice> slices, Slice sliceToTest)
        {
            foreach (var slice in slices)
            {
                if (slice.OverlapsWith(sliceToTest))
                {
                    return false;
                }
            }
            return true;
        }

        public static List<Slice> SlicePizzaWithDifferentPatterns(Pizza pizza)
        {
            var slices = new List<Slice>();
            var patterns = SlicePattern.GetAllPossible(pizza);

            foreach (var pattern in patterns.ToArray())
            {
                for (int row = 0; row < pizza.IngredientRows.Count; row++)
                {
                    for (int column = 0; column < pizza.Columns; column++)
                    {
                        var newSlice = new Slice(row, column, pattern);
                        if (newSlice.IsSufficient(pizza) &&
                            DoesNotOverlapWithSolution(slices, newSlice)
                            )
                        {
                            slices.Add(newSlice);
                            column += newSlice.Pattern.Right;
                        }
                    }

                }
 
            }

            return slices;
        }
    }
}