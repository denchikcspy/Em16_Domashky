using System;
using System.Collections.Generic;
using System.Text;

namespace EM_16.Entities
{
    internal class Item
    {
        private static int autoInc = 1;

        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }

        public Item(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ім'я предмета не може бути порожнім");

            if (price < 0)
                throw new ArgumentException("Ціна не може бути від'ємною");

            Id = autoInc++;
            Name = name;
            Price = price;
        }

        public virtual string Use()
        {
            return $"Предмет {Name} був використаний.";
        }
    }
}
