using System;
using EM_16.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace EM_16.Homeworks
{
    internal class Work3
    {
        public static void Run3()
        {
            //1

            string input = Getters.GetString("\nВведіть рядок: ");

            List<string> words = input.Split(' ').ToList();

            int i = 0;
            foreach (string word in words)
            {
                Console.WriteLine($"{i + 1} - {word}");
                i++;
            }

            //2


            ContactSaver contactSaver = new ContactSaver();

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine(
                    "\nМеню контактів:" +
                    "\n1. Додати контакт" +
                    "\n2. Редагувати контакт" +
                    "\n3. Видалити контакт" +
                    "\n4. Пошук контактів" +
                    "\n5. Показати всі контакти" +
                    "\n0. Вийти"
                );

                int choice = Getters.GetInt("Оберіть дію:");

                try
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                string name = Getters.GetString("Введіть ім'я:");
                                string phone = Getters.GetPhone("Введіть номер телефону:");

                                contactSaver.Create(name, phone);

                                Console.WriteLine("\nКонтакт успішно додано.");
                                break;
                            }

                        case 2:
                            {
                                string oldName = Getters.GetString("Введіть ім'я контакту:");

                                Console.WriteLine(
                                    "\nЩо ви хочете змінити?" +
                                    "\n1. Ім'я" +
                                    "\n2. Номер телефону"
                                );

                                int updateChoice = Getters.GetInt("Оберіть дію:");

                                if (updateChoice == 1)
                                {
                                    string newName = Getters.GetString("Введіть нове ім'я:");

                                    contactSaver.Update(oldName, newName, "");

                                    Console.WriteLine("\nІм'я контакту успішно змінено.");
                                }
                                else if (updateChoice == 2)
                                {
                                    string newPhone = Getters.GetPhone("Введіть новий номер телефону:");

                                    contactSaver.Update(oldName, "", newPhone);

                                    Console.WriteLine("\nНомер телефону успішно змінено.");
                                }
                                else
                                {
                                    Console.WriteLine("\nНекоректний пункт меню.");
                                }

                                break;
                            }

                        case 3:
                            {
                                string name = Getters.GetString("Введіть ім'я контакту:");

                                if (contactSaver.Delete(name))
                                {
                                    Console.WriteLine("\nКонтакт успішно видалено.");
                                }
                                else
                                {
                                    Console.WriteLine("\nКонтакт з таким ім'ям не знайдено.");
                                }

                                break;
                            }

                        case 4:
                            {
                                string searchText = Getters.GetString("Введіть ім'я або частину імені:");

                                List<string> foundContacts = contactSaver.Search(searchText);

                                if (Validation.IsZero(foundContacts.Count))
                                {
                                    Console.WriteLine("\nКонтактів не знайдено.");
                                }
                                else
                                {
                                    Console.WriteLine("\nЗнайдені контакти:");

                                    foreach (string name in foundContacts)
                                    {
                                        Console.WriteLine($"{name} - {contactSaver.GetOne(name)}");
                                    }
                                }

                                break;
                            }

                        case 5:
                            {
                                Dictionary<string, string> contacts = contactSaver.GetAll();

                                if (Validation.IsZero(contacts.Count))
                                {
                                    Console.WriteLine("\nСписок контактів порожній.");
                                }
                                else
                                {
                                    Console.WriteLine("\nУсі контакти:");

                                    foreach (var contact in contacts)
                                    {
                                        Console.WriteLine($"{contact.Key} - {contact.Value}");
                                    }
                                }

                                break;
                            }

                        case 0:
                            {
                                isRunning = false;
                                Console.WriteLine("\nПрограму завершено.");
                                break;
                            }

                        default:
                            {
                                Console.WriteLine("\nНекоректний пункт меню.");
                                break;
                            }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"\nПомилка: {exception.Message}");
                }
            }
        }
    }
}