using System.Collections.Generic;

namespace HashCode2017.Practice
{
    public class Slice
    {
        public Slice(int row1, int column1, int row2, int column2)
        {
            Row1 = row1;
            Row2 = row2;
            Column1 = column1;
            Column2 = column2;
        }

        public int Row1;
        public int Row2;
        public int Column1;
        public int Column2;

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Row1, Column1, Row2, Column2);
        }

        public int Cells()
        {
            return (Row2 - Row1+1) * (Column2 - Column1+1);
        }

        public bool IsSufficient(Pizza pizza)
        {
            if (Cells() > pizza.MaxCellsPerSlice)
            {
                return false;
            }

            uint hasT = 0;

            uint hasM = 0;

            for (int i = Row1; i <= Row2; i++)
            {
                for (int j = Column1; j <= Column2; j++)
                {
                    var ingredient = pizza.IngredientRows[i][j];

                    if (ingredient == Pizza.Ingredient.M)
                    {
                        hasM++;
                    }
                    else if (ingredient == Pizza.Ingredient.T)
                    {
                        hasT++;
                    }

                    if (hasM >= pizza.MinIngredientsPerSlice && hasT >= pizza.MinIngredientsPerSlice)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }

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
    }
}