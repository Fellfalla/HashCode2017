using System;
using System.Collections;
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

        public static IEnumerable<Slice> SliceWithAnalysis(Pizza pizza, IProgress<float> progress)
        {
            progress?.Report(0);

            // Analyse
            var fieldsToAssign = pizza.Fields.ToList();

            // sort all Possible Slices
            foreach (var field in fieldsToAssign)
            {
                field.PossibleSlices.Sort(new BiggestSliceSorter());
            }
            // clean and sort fields 
            fieldsToAssign.RemoveAll(field => field.PossibleSlices.Count < 1);
            fieldsToAssign.Sort(new FieldPossibilityComparison());


            int initialCount = fieldsToAssign.Count;

            while (fieldsToAssign.Count > 0)
            {
                var choosenSlice = fieldsToAssign.First().PossibleSlices.First();

                // remove possibilities from cutted fields
                foreach (var field in choosenSlice.AffectedFields)
                {
                    foreach (var foreclosedSlice in field.PossibleSlices.ToArray())
                    {
                        // Remove all destroyed possibilities
                        foreach (var neighbouredField in foreclosedSlice.AffectedFields)
                        {
                            neighbouredField.PossibleSlices.Remove(foreclosedSlice);
                        }
                    }

                    // remove from fields to assign
                    fieldsToAssign.Remove(field);
                    field.PossibleSlices.Clear();
                }

                yield return choosenSlice;
                progress?.Report( (initialCount-fieldsToAssign.Count) / (float)initialCount);

                // Remove all unmanageableFields
                fieldsToAssign.RemoveAll(field => field.PossibleSlices.Count < 1);

                // refresh sorting
                fieldsToAssign.Sort(new FieldPossibilityComparison());
            }

            progress?.Report(1);
        }

        public class BiggestSliceSorter : IComparer<Slice>
        {
            public int Compare(Slice x, Slice y)
            {
                var sizeX = x.Cells();
                var sizeY = y.Cells();

                return sizeX - sizeY;
            }
        }

        public class FieldPossibilityComparison : IComparer<Field>
        {
            public int Compare(Field x, Field y)
            {
                return x.PossibleSlices.Count - y.PossibleSlices.Count;
            }
        }
    }
}