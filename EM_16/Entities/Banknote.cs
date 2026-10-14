using System;
using System.Collections.Generic;
using System.Text;

namespace EM_16.Entities
{
    public class Banknote
    {
        private int value;
        private int count;

        public Banknote(int value, int count)
        {
            if (value <= 0)
                throw new ArgumentException("Banknote value must be positive.");

            if (count < 0)
                throw new ArgumentException("Banknote count cannot be negative.");

            this.value = value;
            this.count = count;
        }

        public int GetValue()
        {
            return value;
        }

        public int GetCount()
        {
            return count;
        }

        public void Remove(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Cannot remove a negative number of banknotes.");

            if (amount > count)
                throw new Exception("Not enough banknotes.");

            count -= amount;
        }
    }
}
