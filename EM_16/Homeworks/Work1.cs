using System;
using System.Collections.Generic;
using System.Text;

namespace EM_16.Homeworks
{
    internal class Work1
    {
        public static void Run()
        {
            //1

           Console.WriteLine("Привіт, вкажи cвою ціль по крокам");
           double goal = Convert.ToDouble(Console.ReadLine());
           
           Console.WriteLine("Вкажи кількість кроків, які ти пройшов");
           double steps = Convert.ToDouble(Console.ReadLine());
           
           
           if (goal <= 0 || steps <= 0)
           {
               Console.WriteLine("Ціль або пройденні кроки не можуть бути від'ємними або нулем");
               return;
           }
           
           double goalDone = Math.Round(steps / goal * 100, 1);
           
           
           
           switch (goalDone)
           {
               case > 0 and < 70:
                   Console.WriteLine($"Треба більше рухатися,пройдено {goalDone}% від цілі ");
                   break;
               case >= 70 and < 90:
                   Console.WriteLine($"Ще трохи порухайтесь,пройдено {goalDone}% від цілі");
                   break;
               case  90 and < 100:
                   Console.WriteLine($"Майже дійшли до цілі! Пройдено {goalDone}% від цілі");
                   break;
               case >= 100 and < 200:
                   Console.WriteLine($"Ціль досягнута! Ви молодець! Пройдено {goalDone}% від цілі");
                   break;
               case >= 200:
                   Console.WriteLine($"Ну ти просто машина! Пройдено {goalDone}% від цілі");
                   break;
           }
           
           
           //2
           
           double cashBack = 0;
           double loyalityCardDiscount = 0;
           double discount = 0;
           bool loyaltyCard = false;
           Console.WriteLine("\nПривіт, вкажи сумму твоєї покупки");
           double purchaseAmount = Convert.ToDouble(Console.ReadLine());
           if (purchaseAmount <= 0)
           {
               Console.WriteLine("\nСума покупки не може бути від'ємною або нулем");
               return;
           }
           Console.WriteLine("\nЧи є у вас картка лояльності?(1 - так, 0 - ні)");
           
           int hasLoyaltyCard = Convert.ToInt32(Console.ReadLine());
           
           if ((hasLoyaltyCard != 0 && hasLoyaltyCard != 1))
           {
               Console.WriteLine("\nВведіть 1 або 0");
               return;
           }
           
           if (hasLoyaltyCard == 1)
           {
               loyaltyCard = true;
           }
           
           if (loyaltyCard)
           {
                Console.WriteLine("\nОскільки ви маєте карту лояльності, вам надається знижка в 3 відсотки");
               loyalityCardDiscount = 0.03;
               if (purchaseAmount >= 20000)
               {
                   loyalityCardDiscount = 0.05;
               }
           }
           
           if (purchaseAmount > 2000 && purchaseAmount <= 10000)
           {
               cashBack = 0.01;
           }
           else if (purchaseAmount > 10000)
           {
               cashBack = 0.05;
           }
           
           if (!loyaltyCard && cashBack == 0)
           {
               Console.WriteLine($"\nВи не отримали знижок, до оплати {purchaseAmount}грн");
               return;
           }
           
           
           discount = cashBack + loyalityCardDiscount;
           double finalAmount = purchaseAmount - (purchaseAmount * discount);
           Console.WriteLine($"\nВи отримуєте {cashBack * 100}% кешбеку, знижка складає {discount * 100}%, до оплати {finalAmount} грн");


            //3

            Console.WriteLine("Введіть кількість спожитих кВт·год");
            double kWh = Convert.ToDouble(Console.ReadLine());
            if (kWh <= 0)
            {
                Console.WriteLine("Кількість спожитих кВт·год не може бути від'ємною");
                return;
            }

            double price = 0;

            if (kWh <= 100)
            {
                price = kWh * 1.44;
            }
            else if (kWh <= 600)
            {
                price = 100 * 1.44 + (kWh - 100) * 1.68;
            }
            else
            {
                price = 100 * 1.44 + 500 * 1.68 + (kWh - 600) * 1.92;
            }

            Console.WriteLine($"Загальна вартість: {price} грн");

        }
    }
}