using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreasCalculate
{
    public abstract class AreaFigureBase : IArieable
    {
        public bool IsExists { get; set; } = false;
        private bool IsCreated = false;

        protected virtual void AfterCreate()
        {
            try
            {
                IsCreated = true;
                if (!Exists())
                {
                    throw new NonExistFigureException();
                }
            }
            catch (NonExistFigureException ex)
            {
                Console.WriteLine("Warning: Figure isn't valid. " + ex.Message);
            }
        }

        public double CalculateArea()
        {
            try
            {
                if (!IsExists)
                {
                    throw new NonExistFigureException();
                }

                return GetArea();
            }
            catch (NonExistFigureException ex)
            {
                Console.WriteLine("Can't calculate the area of the figure. " + ex.Message);
                return -1;
            }
        }

        protected abstract double GetArea();

        public virtual bool Exists()
        {
            IsExists = GetExistance() ;
            return IsExists;
        }

        protected abstract bool GetExistance();

        protected void SetProp<T>(ref T prop, T setValue)
        {
            prop = setValue;
            OnPropChange();
        }

        protected void OnPropChange()
        {
            if (!IsCreated)
            {
                return;
            }

            Exists();
            if (!IsExists)
            {
                return;
            }

            ProcessPropChange();

        }
        protected virtual void ProcessPropChange() { }


    }
}
