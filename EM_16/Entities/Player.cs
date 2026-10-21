using System;
using System.Collections.Generic;
using System.Text;

namespace EM_16.Entities
{
    internal class Player
    {
        private const int MaxWeapons = 4;
        private const int MaxMagazines = 6;

        private List<Weapon> weapons = new List<Weapon>();
        private List<Magazine> magazines = new List<Magazine>();

        public string Name { get; }
        public Weapon? ActiveWeapon { get; private set; }

        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ім'я гравця не може бути порожнім.");

            Name = name;
        }

        public void AddWeapon(Weapon weapon)
        {
            if (weapon == null)
                throw new ArgumentNullException(nameof(weapon),
                    "Зброя не може бути порожньою.");

            if (weapons.Count >= MaxWeapons)
                throw new InvalidOperationException("Досягнуто максимальної кількості зброї (4).");

            if (weapons.Contains(weapon))
                throw new ArgumentException("Така зброя вже є у гравця.");

            weapons.Add(weapon);

            if (ActiveWeapon == null)
                ActiveWeapon = weapon;
        }
        public void SelectWeapon(int id)
        {
            Weapon? weapon = weapons.Find(w => w.Id == id);

            if (weapon == null)
                throw new Exception("Зброю з таким ID не знайдено.");

            ActiveWeapon = weapon;
        }
        public void Reload()
        {
            if (ActiveWeapon == null)
                throw new InvalidOperationException("У гравця немає активної зброї.");

            Magazine? magazine = magazines.Find(
                m => m.Caliber == ActiveWeapon.Caliber);

            if (magazine == null)
                throw new Exception("Відповідного магазину з набоями не знайдено.");

            Magazine? oldMagazine = ActiveWeapon.ChangeMagazine(magazine);

            magazines.Remove(magazine);

            if (oldMagazine != null && oldMagazine.AmmoCount > 0)
            {
                magazines.Add(oldMagazine);
            }
        }
        public bool Shoot()
        {
            if (ActiveWeapon == null)
                return false;

            return ActiveWeapon.Shoot();
        }

        public void AddMagazine(Magazine magazine)
        {
            if (magazine == null)
                throw new ArgumentNullException(nameof(magazine),
                    "Магазин не може бути порожнім.");

            if (magazines.Count >= MaxMagazines)
                throw new InvalidOperationException("Досягнуто максимальної кількості магазинів (6).");

            if (magazines.Contains(magazine))
                throw new ArgumentException("Такий магазин уже є у гравця.");

            magazines.Add(magazine);
        }

        public IReadOnlyList<Weapon> GetWeapons()
        {
            return weapons.AsReadOnly();
        }

        public IReadOnlyList<Magazine> GetMagazines()
        {
            return magazines.AsReadOnly();
        }
    }
}

