using System;
using System.Collections.Generic;
using System.Text;

namespace EM_16.Helpers
{
    public class Validation
    {
        public static bool IsPositive(int value)
        {
            return value > 0;
        }

        public static bool IsPositive(double value)
        {
            return value > 0;
        }

        public static bool IsPositiveOrZero(int value)
        {
            return value >= 0;
        }

        public static bool IsZero(int value)
        {
            return value == 0;
        }

        public static bool IsZero(double value)
        {
            return value == 0;
        }
        public static bool IsNull(object value)
        {
            return value == null;
        }
    }
}
