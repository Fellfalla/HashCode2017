using System.Collections.Generic;

namespace HashCode2017.Practice
{
    public class SlicePattern
    {
        public SlicePattern()
        {
            
        }

        public SlicePattern(int right, int down)
        {
            Right = right;
            Down = down;
        }

        public int Right;
        public int Down;

        public int CellCount()
        {
            return (Right + 1)* (Down + 1);
        }

        public static IEnumerable<SlicePattern> GetAllPossible(Pizza pizza)
        {
            return GetAllPossible(pizza.MinIngredientsPerSlice, pizza.MaxCellsPerSlice);
        }

        public static IEnumerable<SlicePattern> GetAllPossible(int minCells, int maxCells)
        {
            for (int rows = 0; rows <= maxCells; rows++)
            {
                for (int columns = 0; columns <= maxCells; columns++)
                {
                    var pattern = new SlicePattern();
                    pattern.Right = columns;
                    pattern.Down = rows;

                    var cellCount = pattern.CellCount();
                    if (minCells <= cellCount  && cellCount <= maxCells)
                    {
                        yield return pattern;
                        //if (pattern.Right != pattern.Down)
                        //{
                        //    // Create flipped pattern
                        //    var flippedPattern = new SlicePattern();
                        //    flippedPattern.Down = pattern.Right;
                        //    flippedPattern.Right = pattern.Down;
                        //    yield return flippedPattern;
                        //}
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is SlicePattern)
            {
                return Equals((SlicePattern) obj);
            }

            return base.Equals(obj);
        }

        protected bool Equals(SlicePattern other)
        {
            return Right == other.Right && Down == other.Down;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Right*397) ^ Down;
            }
        }

        public override string ToString()
        {
            return Right + " " + Down;
        }
    }
}