using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreasCalculateTest
{
    public class CircleTest
    {
        [Fact]
        public void TestNonValidCircle()
        {
            AreaFigureBase circle = new Circle(0);
            var area = circle.CalculateArea();
            double res = -1;
            Assert.Equal(area, res);
        }

        [Theory]
        [InlineData(2, Math.PI * 4)]
        [InlineData(-2, Math.PI * 4)]
        public void TestValidCircle(double radius, double res)
        {
            AreaFigureBase circle = new Circle(radius);
            var area = circle.CalculateArea();

            Assert.Equal(area, res);
        }

        [Fact]
        public void TestValidToNonValidCircle()
        {
            AreaFigureBase circle = new Circle(2);
            var areaValid = circle.CalculateArea();

            ((Circle)circle).Radius = 0;
            var areaNonValid = circle.CalculateArea();

            var areaActual = Math.PI * 4;

            Assert.True(areaValid == areaActual && areaNonValid == -1);
        }

        [Fact]
        public void TestNonValidToValidCircle()
        {
            AreaFigureBase circle = new Circle(0);
            var areaNonValid = circle.CalculateArea();

            ((Circle)circle).Radius = 2;
            var areaValid = circle.CalculateArea();

            var areaActual = Math.PI * 4;

            Assert.True(areaValid == areaActual && areaNonValid == -1);
        }
    }
}
