using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HashCode2017.Practice
{
    public class Slice
    {
        public Slice(Pizza pizza, Field field, SlicePattern pattern) :
            this(field.Row, field.Column, pattern)
        {
            Pizza = pizza;
            foreach (var field1 in GetFields())
            {
                AffectedFields.Add(field1);
            }
        }



        public readonly Pizza Pizza;
        public bool IsOnPizza = true;
        public readonly List<Field> AffectedFields = new List<Field>(); 

        public Slice(int row, int column, SlicePattern pattern) : 
            this(row, column, row+pattern.Down, column+pattern.Right)
        {
        }

        public Slice(int row1, int column1, int row2, int column2)
        {
            Row1 = row1;
            Row2 = row2;
            Column1 = column1;
            Column2 = column2;
            Pattern = new SlicePattern()
            {
                Down = Row2 - Row1,
                Right = Column2 - Column1,
            };
        }

        public int Row1;
        public int Row2;
        public int Column1;
        public int Column2;

        public readonly SlicePattern Pattern;

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Row1, Column1, Row2, Column2);
        }

        public int Cells()
        {
            return Pattern.CellCount();
        }

        public bool OverlapsWith(Slice other)
        {
            foreach (var point in other.GetPoints())
            {
                if (IsPointInside(point.Item1, point.Item2))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Field> GetFields()
        {
            foreach (var point in GetPoints())
            {
                if (Pizza.IsIndexOnPizza(point.Item1, point.Item2))
                {
                    yield return Pizza.GetField(point.Item1, point.Item2);
                }
                else
                {
                    IsOnPizza = false;
                }
            }
        } 

        public IEnumerable<Tuple<int, int>> GetPoints()
        {
            for (int i = Row1; i <= Row2; i++)
            {
                for (int j = Column1; j <= Column2; j++)
                {
                    yield return new Tuple<int,int>(i, j);
                }
            }
        }

        public bool IsPointInside(int row, int column)
        {
            return row.IsInRange(Row1, Row2) && column.IsInRange(Column1, Column2);
        }

        public bool IsSufficient(Pizza pizza)
        {
            // Amount of Cells
            if (Cells() > pizza.MaxCellsPerSlice)
            {
                return false;
            }

            // Exceeds pizza
            if (Row2 >= pizza.Rows || Column2 >= pizza.Columns)
            {
                return false;
            }

            if (!IsOnPizza)
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
}