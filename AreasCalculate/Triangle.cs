using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreasCalculate
{
    public class Triangle : AreaFigureBase
    {
        private double _a;
        public double A
        {
            get { return _a; }
            set
            {
                SetProp(ref _a, Math.Abs(value));
            }
        }
        private double _b;
        public double B
        {
            get { return _b; }
            set
            {
                SetProp(ref _b, Math.Abs(value));
            }
        }
        private double _c;
        public double C
        {
            get { return _c; }
            set
            {
                SetProp(ref _c, Math.Abs(value));
            }
        }
        public double Err { get; private set; } = 0.00001;

        public bool IsRight { get; private set; } = false;
        public double? Hypothenuse { get; private set; }

        public Triangle(double a, double b, double c, double err = 0.00001)
        {
            var newErr = Math.Min(Math.Abs(Err), Err);
            if (newErr < Err)
            {
                Err = err;
            }

            A = a;
            B = b;
            C = c;

            AfterCreate();
            CheckRight();
        }

        protected override double GetArea()
        {
            if (IsRight)
            {
                Func<double, double, double> rightEreaFunc = (a, b) => a * b * 0.5;

                if (Hypothenuse == A)
                {
                    return rightEreaFunc(B, C);
                }
                else if (Hypothenuse == B)
                {
                    return rightEreaFunc(A, C);
                }
                return rightEreaFunc(A, B);
            }
            double semiPerimiter = (A + B + C) / 2;
            return Math.Sqrt(semiPerimiter * (semiPerimiter - A) * (semiPerimiter - B) * (semiPerimiter - C));
        }

        protected override bool GetExistance()
        {
            return checkExistanceProperty(A, B, C) && checkExistanceProperty(B, C, A) && checkExistanceProperty(C, B, A);
        }

        private bool CheckRight()
        {
            double max = Math.Max(Math.Max(A, B), C);
            
            if(max == A)
            {
                IsRight = PythogoreanCheck(B, C, A);
            }
            else if(max == B)
            {
                IsRight = PythogoreanCheck( A, C, B);
            }
            else if(max == C)
            {
                IsRight = PythogoreanCheck( A, B, C);
            }

            if (IsRight)
            {
                Hypothenuse = max;
            }
            else
            {
                Hypothenuse = null;
            }

            return IsRight;
        }

        private bool PythogoreanCheck(double a, double b, double c)
        {
            double actualErr = a * a + b * b - c * c;
            return Err > Math.Abs(actualErr);
        }

        private bool checkExistanceProperty(double a, double b, double c)
        {
            return a < b + c;
        }

        protected override void ProcessPropChange()
        {
            CheckRight();
        }
    }
}
