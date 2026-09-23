using System;
using System.Collections.Generic;
using System.Text;

namespace EM_16.Helpers
{
    class ContactSaver
    {
        Dictionary<string, string> contacts = new Dictionary<string, string>();

        public bool Create(string name, string phone)
        {
            if (name.Length < 2)
                throw new Exception("Ім'я повинно містити не менше 2 символів!");

            for (int i = 0; i < phone.Length; i++)
            {
                if (!char.IsDigit(phone[i]))
                    throw new Exception("Номер телефону повинен містити тільки цифри!");
            }

            if (phone.Length < 10 || phone.Length > 12)
                throw new Exception("Номер телефону повинен містити від 10 до 12 символів!");

            if (contacts.ContainsKey(name))
                throw new Exception("Контакт з таким ім'ям вже існує!");

            contacts.Add(name, phone);

            return true;
        }

        public bool Update(string oldName, string newName, string newPhone)
        {
            if (!contacts.ContainsKey(oldName))
                throw new Exception("Контакт з таким ім'ям не знайдено!");

            if (newName.Length > 0 && newName.Length < 2)
                throw new Exception("Ім'я повинно містити не менше 2 символів!");

            if (newPhone.Length > 0 && (newPhone.Length < 10 || newPhone.Length > 12))
                throw new Exception("Номер телефону повинен містити від 10 до 12 символів!");

            if (newName.Length > 0 && newPhone.Length > 0)
            {
                if (contacts.ContainsKey(newName))
                    throw new Exception("Контакт з таким ім'ям вже існує!");

                contacts.Remove(oldName);
                contacts.Add(newName, newPhone);
            }
            else if (newName.Length > 0)
            {
                if (contacts.ContainsKey(newName))
                    throw new Exception("Контакт з таким ім'ям вже існує!");

                string phone = contacts[oldName];

                contacts.Remove(oldName);
                contacts.Add(newName, phone);
            }
            else
            {
                contacts[oldName] = newPhone;
            }

            return true;
        }

        public bool Delete(string name)
        {
            return contacts.Remove(name);
        }

        public string GetOne(string name)
        {
            if (!contacts.ContainsKey(name))
                throw new Exception("Контакт з таким ім'ям не знайдено!");

            return contacts[name];
        }

        public List<string> Search(string searchText)
        {
            List<string> result = new List<string>();

            foreach (var contact in contacts)
            {
                if (contact.Key.ToLower().Contains(searchText.ToLower()))
                {
                    result.Add(contact.Key);
                }
            }

            return result;
        }

        public Dictionary<string, string> GetAll()
        {
            return contacts;
        }
    }
}
