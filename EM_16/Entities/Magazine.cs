using System;
using System.Collections.Generic;
using System.Text;

namespace EM_16.Entities
{
    internal class Magazine
    {
        private static int autoInc = 1;

        public int Id { get; }
        public Caliber Caliber { get; }
        public int AmmoCount { get; private set; }
        public int Capacity { get; }

        public Magazine(Caliber caliber, int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Місткість магазину повинна бути більшою за нуль.");

            Id = autoInc++;
            Caliber = caliber;
            Capacity = capacity;
            AmmoCount = capacity;
        }

        public bool UseAmmo()
        {
            if (AmmoCount <= 0)
                return false;

            AmmoCount--;
            return true;
        }

    }
}
