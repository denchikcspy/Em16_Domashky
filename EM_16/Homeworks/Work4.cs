using System;
using System.Collections.Generic;
using EM_16.Helpers;

namespace EM_16.Homeworks
{
    internal class Work4
    {
        public static void Run4()
        {
            ContactSaver2 contactSaver = new ContactSaver2();

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine(
                    "\nМеню контактів:" +
                    "\n1. Додати контакт" +
                    "\n2. Редагувати контакт по ID" +
                    "\n3. Редагувати контакт по імені" +
                    "\n4. Показати всі контакти" +
                    "\n5. Отримати контакт по ID" +
                    "\n6. Видалити контакт по ID" +
                    "\n7. Пошук контактів" +
                    "\n0. Вийти"
                );

                int choice = Getters.GetInt("Оберіть дію:");

                try
                {
                    switch (choice)
                    {
                        case 1:
                            CreateContact(contactSaver);
                            break;

                        case 2:
                            UpdateContactById(contactSaver);
                            break;

                        case 3:
                            UpdateContactByName(contactSaver);
                            break;

                        case 4:
                            ShowAllContacts(contactSaver);
                            break;

                        case 5:
                            ShowContactById(contactSaver);
                            break;

                        case 6:
                            DeleteContact(contactSaver);
                            break;

                        case 7:
                            SearchContacts(contactSaver);
                            break;

                        case 0:
                            isRunning = false;
                            Console.WriteLine("\nПрограму завершено.");
                            break;

                        default:
                            Console.WriteLine("\nНекоректний пункт меню.");
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"\nПомилка: {exception.Message}");
                }
            }
        }

        static void CreateContact(ContactSaver2 contactSaver)
        {
            string name = Getters.GetString("Введіть ім'я:");
            string phone = Getters.GetPhone("Введіть номер телефону:");
            string address = Getters.GetString("Введіть адресу:");

            contactSaver.Create(name, phone, address);

            Console.WriteLine("\nКонтакт успішно додано.");
        }

        static void UpdateContactById(ContactSaver2 contactSaver)
        {
            int id = Getters.GetInt("Введіть ID контакту:");

            Console.WriteLine(
                "\nЩо потрібно змінити?" +
                "\n1. Ім'я" +
                "\n2. Номер телефону"
            );

            int choice = Getters.GetInt("Оберіть дію:");

            if (choice == 1)
            {
                string newName = Getters.GetString("Введіть нове ім'я:");

                contactSaver.UpdateById(id, newName, "");
            }
            else if (choice == 2)
            {
                string newPhone = Getters.GetPhone("Введіть новий номер телефону:");

                contactSaver.UpdateById(id, "", newPhone);
            }
            else
            {
                Console.WriteLine("\nНекоректний пункт меню.");
                return;
            }

            Console.WriteLine("\nКонтакт успішно змінено.");
        }

        static void UpdateContactByName(ContactSaver2 contactSaver)
        {
            string name = Getters.GetString("Введіть ім'я контакту:");

            Console.WriteLine(
                "\nЩо потрібно змінити?" +
                "\n1. Ім'я" +
                "\n2. Номер телефону"
            );

            int choice = Getters.GetInt("Оберіть дію:");

            if (choice == 1)
            {
                string newName = Getters.GetString("Введіть нове ім'я:");

                contactSaver.UpdateByName(name, newName, "");
            }
            else if (choice == 2)
            {
                string newPhone = Getters.GetPhone("Введіть новий номер телефону:");

                contactSaver.UpdateByName(name, "", newPhone);
            }
            else
            {
                Console.WriteLine("\nНекоректний пункт меню.");
                return;
            }

            Console.WriteLine("\nКонтакт успішно змінено.");
        }

        static void ShowAllContacts(ContactSaver2 contactSaver)
        {
            List<Contact> contacts = contactSaver.GetAll();

            if (Validation.IsZero(contacts.Count))
            {
                Console.WriteLine("\nСписок контактів порожній.");
                return;
            }

            foreach (Contact contact in contacts)
            {
                PrintContact(contact);
            }
        }

        static void ShowContactById(ContactSaver2 contactSaver)
        {
            int id = Getters.GetInt("Введіть ID контакту:");

            Contact contact = contactSaver.GetOne(id);

            PrintContact(contact);
        }

        static void DeleteContact(ContactSaver2 contactSaver)
        {
            int id = Getters.GetInt("Введіть ID контакту:");

            contactSaver.Delete(id);

            Console.WriteLine("\nКонтакт успішно видалено.");
        }

        static void SearchContacts(ContactSaver2 contactSaver)
        {
            string searchText = Getters.GetString(
                "Введіть ім'я, частину імені або номер телефону:"
            );

            List<Contact> contacts = contactSaver.Search(searchText);

            if (Validation.IsZero(contacts.Count))
            {
                Console.WriteLine("\nКонтактів не знайдено.");
                return;
            }

            foreach (Contact contact in contacts)
            {
                PrintContact(contact);
            }
        }

        static void PrintContact(Contact contact)
        {
            Console.WriteLine(
                $"\nID: {contact.getId()}" +
                $"\nІм'я: {contact.getName()}" +
                $"\nНомер телефону: {contact.getPhoneNumber()}" +
                $"\nАдреса: {contact.getAddress()}"
            );
        }
    }
}