using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HashCode2017.Practice
{
    public class Pizza
    {
        public Pizza(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

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


        public static Pizza ConsumePizzaData(string[] data)
        {
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
                    pizza.IngredientRows[i][j] = (Ingredient) Enum.Parse(typeof(Ingredient), data[i + 1][j].ToString());
                }
            }
            return pizza;
        }
    }

}
