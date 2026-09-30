using System;
using System.Collections.Generic;

namespace EM_16.Helpers
{
    class ContactSaver2
    {
        List<Contact> contacts = new List<Contact>();

        public bool Create(string name, string phone, string address = "")
        {
            ValidateNewData(name, phone);

            CheckNameAndPhoneDuplicate(name, phone, -1);

            Contact newContact = new Contact(name, phone, address);

            contacts.Add(newContact);


            return true;
        }

        public bool UpdateById(int id, string newName, string newPhone)
        {
            Contact contact = GetOne(id);

            ValidateNewData(newName, newPhone);

            if (newName.Length > 0)
            {
                CheckNameAndPhoneDuplicate(newName, newPhone, contact.getId());
                contact.setName(newName);
            }

            if (newPhone.Length > 0)
            {
                contact.setPhoneNumber(newPhone);
            }

            return true;
        }

        public bool UpdateByName(string name, string newName, string newPhone)
        {
            Contact contact = null;

            foreach (Contact item in contacts)
            {
                if (item.getName() == name)
                {
                    contact = item;
                    break;
                }
            }

            if (contact == null)
                throw new Exception("Контакт з таким ім'ям не знайдено!");

            ValidateNewData(newName, newPhone);

            if (newName.Length > 0)
            {
                CheckNameAndPhoneDuplicate(newName, newPhone, contact.getId());
                contact.setName(newName);
            }

            if (newPhone.Length > 0)
            {
                contact.setPhoneNumber(newPhone);
            }

            return true;
        }

        public List<Contact> GetAll()
        {
            return contacts;
        }

        public Contact GetOne(int id)
        {
            foreach (Contact contact in contacts)
            {
                if (contact.getId() == id)
                {
                    return contact;
                }
            }

            throw new Exception("Контакт з таким ID не знайдено!");
        }

        public bool Delete(int id)
        {
            Contact contact = GetOne(id);

            return contacts.Remove(contact);
        }

        public List<Contact> Search(string searchText)
        {
            List<Contact> result = new List<Contact>();

            foreach (Contact contact in contacts)
            {
                if (contact.getName().ToLower().Contains(searchText.ToLower()) ||
                    contact.getPhoneNumber().Contains(searchText))
                {
                    result.Add(contact);
                }
            }

            return result;
        }

        private void ValidateNewData(string name, string phone)
        {
            if (name.Length > 0 && name.Length < 2)
                throw new Exception("Ім'я повинно містити не менше 2 символів!");

            if (phone.Length > 0)
            {
                if (phone.Length < 10 || phone.Length > 12)
                    throw new Exception("Номер телефону повинен містити від 10 до 12 символів!");

                for (int i = 0; i < phone.Length; i++)
                {
                    if (!char.IsDigit(phone[i]))
                        throw new Exception("Номер телефону повинен містити тільки цифри!");
                }
            }
        }

        private void CheckNameAndPhoneDuplicate(string name, string phone, int currentId)
        {
            foreach (Contact contact in contacts)
            {
                if (contact.getName() == name && contact.getId() != currentId)
                
                    throw new Exception("Контакт з таким ім'ям вже існує!");
                

                if (contact.getPhoneNumber() == phone && contact.getId() != currentId)
                
                    throw new Exception("Контакт з таким номером телефону вже існує!");
                
            }
        }
    }
}
