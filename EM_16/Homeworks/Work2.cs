using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using System.Text;
using EM_16.Helpers;

namespace EM_16.Homeworks
{
    internal class Work2
    {
        public static void Run2()
        {

            //1

            Random random1 = new Random();
            int[] array1 = new int[1000];
            int[] counts1 = new int[11];
            
            
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = random1.Next(1, 11);
                Console.Write($"{array1[i]}\t"); //в рядок
                counts1[array1[i]]++;
            }
            
            
            int minCount = counts1[1];
            int minNumber = 1;
            
            for (int i = 2; i <= 10; i++)
            {
                if (counts1[i] < minCount)
                {
                    minCount = counts1[i];
                    minNumber = i;
                }
            }
            
            Console.WriteLine($"\nЧисло {minNumber} зустрічається найменше разів: {minCount}");
            
            
            //2
            
            int Length2 = Getters.GetInt("Введіть довжину масиву: ");
            int max = Getters.GetInt("Введіть максимальне значення елементів масиву: ");
            int min = Getters.GetInt("Введіть мінімальне значення елементів масиву: ");
            
            if (Validation.IsPositive(Length2) && Validation.IsPositive(max) && Validation.IsPositiveOrZero(min) && max > min)
            { 
                Random random2 = new Random();
                int[] array2 = new int[Length2];
                int[] UnDuplicates = new int[Length2];
            
            
                int index = 0;
                Console.WriteLine("\nЗгенерований масив:");
                for (int i = 0; i < Length2; i++)
                {
                    array2[i] = random2.Next(min, max+1);
                    Console.Write($"{array2[i]}\t");
            
                    bool isDublicate = false;
                    
                    for (int j = 0; j < index; j++)
                    {
                        if (array2[i] == UnDuplicates[j])
                        {
                            isDublicate = true;
                        }
                    }
            
                    if (!isDublicate)
                    {
                        UnDuplicates[index] = array2[i];
                        index++;
            
                    }
                }
                Console.WriteLine("\nУнікальні числа масиву:");
            
                for (int i = 0; i < index; i++)
                {
                    Console.Write($"{UnDuplicates[i]}\t");
                }
            }
            
            
            else
            {
                Console.WriteLine("Введені некоректні дані. Довжина масиву та максимальне значення повинні бути додатними числами, а мінімальне значення - невід'ємним числом. Також максимальне значення повинно бути більше мінімального.");
            }
            
            
            //3
            int Length3 = Getters.GetInt("\nВведіть довжину масиву: ");
            if (Length3 < 2)
            {
                Console.WriteLine("Введена некоректна довжина масиву.\nДовжина масиву повинна бути додатнім числом та більше 1");
                return;
            }
            int[] array3 = new int[Length3];
            Random random3 = new Random();
            Console.WriteLine("\nЗгенерований масив:");
            for (int i = 0; i < array3.Length; i++)
            {
                array3[i] = random3.Next(100, 901);
                Console.Write($"{array3[i]}\t");
            }
            
            
            int peackCounter = 0;

            for (int j = 0; j < array3.Length; j++)
            {
                if (j == 0 && array3[j] >= array3[j + 1])
                {
                    peackCounter++;
                    Console.WriteLine($"\nПік {peackCounter} під індексом {j}: {array3[j]}");
                }
                else if (j == array3.Length - 1 && array3[j] >= array3[j - 1])
                {
                    peackCounter++;
                    Console.WriteLine($"\nПік {peackCounter} під індексом {j}: {array3[j]}");
                }
                else if (j > 0 && j < array3.Length - 1 &&
                         array3[j] >= array3[j + 1] &&
                         array3[j] >= array3[j - 1])
                {
                    peackCounter++;
                    Console.WriteLine($"\nПік {peackCounter} під індексом {j}: {array3[j]}");
                }
            }

        
            if (peackCounter == 0)
            {
                Console.WriteLine("\nПіків не знайдено");
            }

            //4

            string input = Getters.GetString("\nВведіть рядок: ");

            int wordCount = 0;
            
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ' && (i == 0 || input[i - 1] == ' '))
                {
                    wordCount++;
                }
            }

            Console.WriteLine($"Кількість слів у рядку: {wordCount}");






            input = input.Replace(" ", "").ToLower();
            
            int[] letterCount = new int[input.Length];
            
            bool isDuplicate = false;
            int previousIndex = 0;
            
            for (int i = 0; i < input.Length; i++)
            {
                isDuplicate = false;
            
                if (i != 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (input[i] == input[j])
                        {
                            isDuplicate = true;
                            previousIndex = j;
                            break;
                        }
                    }
                }
            
                if (isDuplicate)
                {
                    letterCount[previousIndex]++;
                }
                else
                {
                    letterCount[i] = 1;
                }
            }
            
            for (int i = 0; i < input.Length; i++)
            {
                if (letterCount[i] != 0)
                {
                    Console.WriteLine($"\nБуква '{input[i]}' зустрічається {letterCount[i]} разів");
                }
            }
            
           //5
           Console.WriteLine("5 завдання");
            int[] array5 = new int[20];
            Random random5 = new Random();
            for (int i = 0; i < array5.Length; i++)
            {
                array5[i] = random5.Next(10, 100);
            }

            int maxSum = 0;
            int maxIndex = 0;
            for (int i = 0; i < array5.Length - 2; i++)
            {
                int sum = array5[i] + array5[i + 1] + array5[i + 2];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxIndex = i;
                }
            }
            Console.WriteLine(
                            $"\nНайбільша сума трьох сусідніх елементів: {maxSum}" +
                            $"\nІндекси: {maxIndex}, {maxIndex + 1}, {maxIndex + 2}" +
                            $"\nЧисла: {array5[maxIndex]}, {array5[maxIndex + 1]}, {array5[maxIndex + 2]}"
                            );
                

                            
                       

        }
    }
}
