using AreasCalculate;
using Xunit;

namespace AreasCalculateTest
{
    public class TriangleTest
    {
        [Theory]
        [InlineData(0, 1, 1, -1)]
        [InlineData(1, 0, 1, -1)]
        [InlineData(1, 1, 0, -1)]
        public void TestNonValidTriangleWithZeroSide(double a, double b, double c, double res)
        {
            AreaFigureBase triangle = new Triangle(a, b, c);
            var area = triangle.CalculateArea();
            Assert.Equal(area, res);
        }

        [Theory]
        [InlineData(-3, -4, -5, 6)]
        [InlineData(-3, 4, 5, 6)]
        public void TestTriangleWithNegValues(double a, double b, double c, double res)
        {
            AreaFigureBase triangle = new Triangle(a, b, c);
            var area = triangle.CalculateArea();
            Assert.Equal(area, res);
        }

        [Theory]
        [InlineData(3, 4, 5, 6, 0)]
        [InlineData(3, 5, 4, 6, 0)]
        [InlineData(4, 3, 5, 6, 0)]
        [InlineData(4, 5, 3, 6, 0)]
        [InlineData(5, 3, 4, 6, 0)]
        [InlineData(5, 4, 3, 6, 0)]
        [InlineData(2, 3, 3.60555, 3)]
        public void TestRightTrianglePermutations(double a, double b, double c, double res, double err = 0.0001)
        {
            AreaFigureBase triangle = new Triangle(a, b, c, err);
            var area = triangle.CalculateArea();
            Assert.Equal(area, res);
            Assert.True(((Triangle)triangle).IsRight);
        }

        [Theory]
        [InlineData(3, 4, 5.1, 5.9947)]
        [InlineData(3, 5.1, 4, 5.9947)]
        [InlineData(4, 3, 5.1, 5.9947)]
        [InlineData(4, 5.1, 3, 5.9947)]
        [InlineData(5.1, 3, 4, 5.9947)]
        [InlineData(5.1, 4, 3, 5.9947)]
        public void TestNonRightTrianglePermutations(double a, double b, double c, double res, double err = 0.0001)
        {
            AreaFigureBase triangle = new Triangle(a, b, c, err);
            var area = triangle.CalculateArea();
            Assert.InRange(area, res - err, res + err);
            Assert.False(((Triangle)triangle).IsRight);
        }

        [Fact]
        public void TestFromValidToNonValid()
        {
            AreaFigureBase triangle = new Triangle(3, 4, 5);
            var areaValid = triangle.CalculateArea();

            ((Triangle)triangle).C = 7;
            var areaNotValid = triangle.CalculateArea();
            Assert.True(areaNotValid == -1 && areaValid == 6);
        }

        [Fact]
        public void TestFromNonValidToValid()
        {
            AreaFigureBase triangle = new Triangle(3, 4, 7);
            var areaNotValid = triangle.CalculateArea();

            ((Triangle)triangle).C = 5;
            var areaValid = triangle.CalculateArea();
            Assert.True(areaNotValid == -1 && areaValid == 6);
        }
    }
}