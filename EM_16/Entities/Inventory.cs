using System;
using System.Collections.Generic;
using System.Text;

namespace EM_16.Entities
{
    internal class Inventory
    {
        private const int MaxSlots = 10;
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            if (item == null)
                throw new ArgumentException("Предмет не може бути null.");

            if (items.Count >= MaxSlots)
                throw new Exception("Інвентар заповнений.");

            if (items.Contains(item))
                throw new Exception("Предмет вже знаходиться в інвентарі.");

            items.Add(item);
        }

        public void RemoveItem(int id)
        {
            Item? item = items.Find(i => i.Id == id);

            if (item == null)
                throw new Exception("Предмет не знайдено.");

            items.Remove(item);
        }

        public IReadOnlyList<Item> GetItems()
        {
            return items.AsReadOnly();
        }

        public string UseItem(int id)
        {
            Item? item = items.Find(i => i.Id == id);

            if (item == null)
                throw new Exception("Предмет не знайдено.");

            return item.Use();
        }
    }
}
