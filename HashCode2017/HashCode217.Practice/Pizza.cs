using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;

namespace HashCode2017.Practice
{
    public class Field
    {
        public Field(int row, int column, Pizza.Ingredient ingredient)
        {
            Row = row;
            Column = column;
            Ingredient = ingredient;
        }

        public Pizza.Ingredient Ingredient;
        public readonly int Row;
        public readonly int Column;

        public List<Slice> PossibleSlices = new List<Slice>(); 
    }

    public class Pizza
    {
        public Pizza(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            Fields = new Field[Rows*Columns];

            IngredientRows = new List<Ingredient[]>();
            for (int i = 0; i < rows; i++)
            {
                IngredientRows.Add(new Ingredient[columns]);
            }
        }

        public readonly List<Ingredient[]> IngredientRows;

        public enum Ingredient
        {
            T,
            M
        }

        public readonly int Rows;
        public readonly int Columns;
        public int MinIngredientsPerSlice;
        public int MaxCellsPerSlice;

        public readonly Field[] Fields;

        public Field GetField(int row, int column)
        {
            return Fields[row*Columns + column];
        }

        public bool IsIndexOnPizza(int row, int column)
        {
            return row >= 0 && row < Rows &&
                   column >= 0 && column < Columns;
        }

        public void AddField(int row, int column, Field field)
        {
            Fields[row*Columns + column] = field;
        }

        public static Pizza ConsumePizzaData(string[] data, IProgress<float> progress = null)
        {
            progress?.Report(0);

            int[] specs = data[0].Split(' ').Select(int.Parse).ToArray();

            int rows = specs[0];
            int columns = specs[1];

            var pizza = new Pizza(rows, columns);
            pizza.MinIngredientsPerSlice = specs[2];
            pizza.MaxCellsPerSlice = specs[3];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var ingredient = (Ingredient) Enum.Parse(typeof (Ingredient), data[i + 1][j].ToString());
                    pizza.IngredientRows[i][j] = ingredient;

                    var field = new Field(i, j, ingredient);
                    pizza.AddField(i, j, field);
                }

                progress?.Report(i/(float)rows);
            }

            if (progress != null) progress.Report(1);

            Console.WriteLine("\nAnalyzing Possibilities");
            pizza.InitiazeFieldPossibilities(progress);

            progress?.Report(1);

            return pizza;
        }

        private void InitiazeFieldPossibilities(IProgress<float> progress = null)
        {
            var slicePatterns = SlicePattern.GetAllPossible(this).ToArray();
            int fieldCount = Fields.Length;
            int current = 0;
            foreach (var field in Fields)
            {
                if (progress != null)
                {
                    current++;
                    progress.Report(current/ (float)fieldCount);   
                }

                foreach (var slicePattern in slicePatterns)
                {
                    var possibleSlice = new Slice(this, field, slicePattern);
                    if (possibleSlice.IsSufficient(this))
                    {
                        //field.PossibePatterns.Add(possibleSlice);
                        foreach (var affectedField in possibleSlice.AffectedFields)
                        {
                            affectedField.PossibleSlices.Add(possibleSlice);
                        }
                    }
                }
            }
        }
    }

}
