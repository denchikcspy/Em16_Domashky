using System;
using System.Collections.Generic;
using System.Text;

namespace EM_16.Entities
{
    internal class Stats
    {
        public int Current { get; private set; }
        public int Maximum { get; private set; }

        public Stats(int maximum)
        {
            if (maximum <= 0)
                throw new ArgumentException("Максимум повинен бути додатним.");

            Maximum = maximum;
            Current = maximum;
        }

        public void ChangeCurrent(int amount)
        {
            Current = Math.Clamp(Current + amount, 0, Maximum);
        }

        public void ChangeMaximum(int amount)
        {
            if (Maximum + amount <= 0)
                throw new ArgumentException("Максимум повинен бути додатним.");

            Maximum += amount;
            Current = Math.Min(Current, Maximum);
        }
    }   
}



