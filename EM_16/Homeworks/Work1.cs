using System;
using System.Collections.Generic;
using System.Text;
using EM_16.Helpers;

namespace EM_16.Homeworks
{
    internal class Work1
    {

        

        public static void Run()
        {
            // 1

            double goal = Getters.GetDouble("Привіт, вкажи свою ціль по крокам");

            double steps = Getters.GetDouble("Вкажи кількість кроків, які ти пройшов");

            if (!Validation.IsPositive(goal) ||!Validation.IsPositive(steps))
            {
                Console.WriteLine("\nЦіль або пройденні кроки не можуть бути від'ємними або нулем");
                return;
            }

            double goalDone = Math.Round(steps / goal * 100, 1);

            switch (goalDone)
            {
                case > 0 and < 70:
                    Console.WriteLine($"\nТреба більше рухатися, пройдено {goalDone}% від цілі");
                    break;

                case >= 70 and < 90:
                    Console.WriteLine($"\nЩе трохи порухайтесь, пройдено {goalDone}% від цілі");
                    break;

                case 90 and < 100:
                    Console.WriteLine($"\nМайже дійшли до цілі! Пройдено {goalDone}% від цілі");
                    break;

                case >= 100 and < 200:
                    Console.WriteLine($"\nЦіль досягнута! Ви молодець! Пройдено {goalDone}% від цілі");
                    break;

                case >= 200:
                    Console.WriteLine($"\nНу ти просто машина! Пройдено {goalDone}% від цілі");
                    break;
            }


            // 2

            double cashBack = 0;
            double loyalityCardDiscount = 0;
            double discount = 0;
            bool loyaltyCard = false;

            double purchaseAmount = Getters.GetDouble("Привіт, вкажи суму твоєї покупки");

            if (purchaseAmount <= 0)
            {
                Console.WriteLine("\nСума покупки не може бути від'ємною або нулем");
                return;
            }

            int hasLoyaltyCard = Getters.GetInt("Чи є у вас картка лояльності?(1 - так, 0 - ні)");

            if (hasLoyaltyCard != 0 && hasLoyaltyCard != 1)
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


            // 3

            double kWh = Getters.GetDouble("Введіть кількість спожитих кВт·год");

            if (kWh <= 0)
            {
                Console.WriteLine("\nКількість спожитих кВт·год не може бути від'ємною");
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

            Console.WriteLine($"\nЗагальна вартість: {price} грн");
        }
    }
}
