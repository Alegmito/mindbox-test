using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreasCalculate
{
    public class Circle: AreaFigureBase
    {
        private double _radius;
        public double Radius
        {
            get { return _radius; }
            set
            {
                SetProp(ref _radius, Math.Abs(value));
            }
        }
        public Circle(double radius = 1)
        {
            Radius = Math.Abs(radius);
            AfterCreate();
        }

        protected override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        protected override bool GetExistance()
        {
            return Radius != 0;
        }
    }
}
