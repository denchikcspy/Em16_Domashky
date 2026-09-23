using System;
using System.Collections.Generic;
using System.Text;

namespace EM_16.Helpers
{
        public class Getters
        {
            public static int GetInt(string message)
            {
                Console.WriteLine("\n" + message);

                int value;

                while (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("\nВведіть ціле число:");
                }

                return value;
            }

            public static double GetDouble(string message)
            {
                Console.WriteLine("\n" + message);

                double value;

                while (!double.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("\nВведіть число:");
                }

                return value;
            }

            public static string GetString(string message)
            {
                Console.WriteLine("\n" + message);

                string value = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(value) || double.TryParse(value, out _))
                {
                    Console.WriteLine("\nВведено порожній рядок або некоректний тип даних.\nВведіть текст:");
                    value = Console.ReadLine();
                }

                return value.Trim();
            }

            public static string GetPhone(string message)
            {
                Console.WriteLine("\n" + message);

                string value = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("\nНомер телефону не може бути порожнім.\nВведіть номер телефону:");
                    value = Console.ReadLine();
                }

                return value.Trim();
            }
        }
    }
