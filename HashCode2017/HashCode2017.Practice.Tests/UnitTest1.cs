using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashCode2017.Practice.Tests
{
    [TestClass]
    public class PizzaTests
    {
        public static string[] GetSmallPizzaData()
        {
            return new[]
            {
                "6 7 1 5\n",
                "TMMMTTT\n",
                "MMMMTMM\n",
                "TTMTTMT\n",
                "TMMTMMM\n",
                "TTTTTTM\n",
                "TTTTTTM\n"
            };
        }

        [TestMethod]
        public void PizzaConstructorTest()
        {
            var data = GetSmallPizzaData();

            var pizza = Pizza.ConsumePizzaData(data);

            Assert.AreEqual(Pizza.Ingredient.M, pizza.IngredientRows[3][2]);
            Assert.AreEqual(Pizza.Ingredient.T, pizza.IngredientRows[2][4]);
        }
    }

    [TestClass]
    public class SLiceTest
    {

        [TestMethod]
        public void SliceTest()
        {
            Assert.AreEqual(1, new Slice(2,2,2,2).Cells());
            Assert.AreEqual(6, new Slice(0,0,2,1).Cells());
            Assert.AreEqual(3, new Slice(0,2,2,2).Cells());
            Assert.AreEqual(6, new Slice(0,3,2,4).Cells());
        }

        [TestMethod]
        public void SlicePizzeTest()
        {
            var data = PizzaTests.GetSmallPizzaData();
            var pizza = Pizza.ConsumePizzaData(data);

            var slices = PizzaSlicer.SlicePizze(pizza);

            Trace.WriteLine("Slice count: " + slices.Count);

            foreach (var slice in slices)
            {
                Trace.WriteLine(slice.ToString());
            }
        }
    }
}
