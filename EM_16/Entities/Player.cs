using System;
using System.Collections.Generic;
using System.Text;

namespace EM_16.Entities
{
    internal class Player
    {
        public string Name { get; }

        public Stats Health { get; }
        public Stats Mana { get; }
        public Stats Energy { get; }

        public Inventory Inventory { get; }

        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ім'я гравця не може бути порожнім");

            Name = name;

            Health = new Stats(100);
            Mana = new Stats(100);
            Energy = new Stats(100);

            Inventory = new Inventory();
        }
    }
}

