using System;
using System.Diagnostics;
using System.Linq;
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
    public class SlciePatternTests
    {
        [TestMethod]
        public void GetAllPossibleSlicesTest()
        {
            {
                // 1-Celled
                var result = SlicePattern.GetAllPossible(1, 1);
                var expected = new[]
                {
                    new SlicePattern()
                    {
                        Right = 0,
                        Down = 0,
                    }
                };
                Assert.IsTrue(expected.SequenceEqual(result));
            }

            {
                // 2-Celled
                var result = SlicePattern.GetAllPossible(1, 2).ToArray();
                var expected = new[]
                {
                    new SlicePattern(0, 0),
                    new SlicePattern(1, 0),
                    new SlicePattern(0, 1),
                };

                Assert.IsTrue(expected.SequenceEqual(result));
            }


            {
                // 4-Celled
                var result = SlicePattern.GetAllPossible(1, 4).ToArray();
                var expected = new[]
                {
                    new SlicePattern(0, 0),
                    new SlicePattern(1, 0),
                    new SlicePattern(2, 0),
                    new SlicePattern(3, 0),

                    new SlicePattern(0, 1),
                    new SlicePattern(0, 2),
                    new SlicePattern(0, 3),

                    new SlicePattern(1, 1),
                };

                foreach (var slicePattern in result)
                {
                    Trace.WriteLine(slicePattern);
                }

                Assert.AreEqual(expected.Count(), result.Count());
                foreach (var expectedPattern in expected)
                {
                    Assert.IsTrue(result.Contains(expectedPattern));
                }

            }


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
