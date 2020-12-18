using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int _minValue;
        private readonly int _maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            ValidateRange(minValue, maxValue);
            _minValue = minValue;
            _maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            if (obj is Int32)
            {
                int value = (int)obj;
                if (value < _minValue || value >  _maxValue)
                {
                    return false;
                }
                return true;
            }
            else
            {
                throw new ArgumentException("Cannot validate input data!");
            }
        }

        private void ValidateRange(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("Invalid range!");
            }
        }
    }
}
