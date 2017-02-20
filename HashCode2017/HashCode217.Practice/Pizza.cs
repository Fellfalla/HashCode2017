using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCode2017.Practice
{
    public class Pizza
    {
        public List<Ingredient[]> IngredientRows = new List<Ingredient[]>();

        public enum Ingredient
        {
            T,
            M
        }

        public int MinIngredientsPerSlice;
        public int MaxCellsPerSlice;


        public static Pizza ConsumePizzaData(string[] data)
        {
            var pizza = new Pizza();

            int[] specs = data[0].Split(' ').Select(int.Parse).ToArray();

            int rows = specs[0];
            int columns = specs[1];
            pizza.MinIngredientsPerSlice = specs[2];
            pizza.MaxCellsPerSlice = specs[3];

            pizza.IngredientRows = new List<Ingredient[]>();
            for (int i = 0; i < rows; i++)
            {
                pizza.IngredientRows.Add(new Ingredient[columns]);
            }

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
