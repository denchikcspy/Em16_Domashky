using System;
using System.Collections.Generic;
using System.Text;

namespace EM_16.Entities
{
    internal class Weapon
    {
        private static int autoInc = 1;

        public int Id { get; }
        public string Name { get; }
        public Caliber Caliber { get; }

        public Magazine? Magazine { get; private set; }

        public Weapon(string name, Caliber caliber)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва зброї не може бути порожньою.");

            Id = autoInc++;
            Name = name;
            Caliber = caliber;
        }

        public Magazine? ChangeMagazine(Magazine magazine)
        {
            if (magazine == null)
                throw new ArgumentNullException(nameof(magazine),
                    "Магазин не може бути порожнім.");

            if (magazine.Caliber != Caliber)
                throw new ArgumentException("Калібр магазину не відповідає калібру зброї.");

            Magazine? previousMagazine = Magazine;
            Magazine = magazine;

            return previousMagazine;
        }

        public bool Shoot()
        {
            if (Magazine == null)
                return false;

            return Magazine.UseAmmo();
        }

    }
}
