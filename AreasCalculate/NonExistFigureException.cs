using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreasCalculate
{
    internal class NonExistFigureException: Exception
    {
        public override string Message { get; } = "The figure with these parameters doesn't exist";
    }
}
