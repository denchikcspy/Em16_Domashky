using System;
using System.Collections.Generic;
using System.Text;

namespace EM_16.Homeworks
{
    internal class Work1
    {
        static void Print(string message)
        {
            Console.WriteLine("\n" + message);
        }

        static int GetInt(string message)
        {
            Print(message);

            int value;

            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Print("Введіть ціле число:");
            }

            return value;
        }

        static double GetDouble(string message)
        {
            Print(message);

            double value;

            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Print("Введіть число:");
            }

            return value;
        }

        public static void Run()
        {
            // 1

            double goal = GetDouble("Привіт, вкажи свою ціль по крокам");

            double steps = GetDouble("Вкажи кількість кроків, які ти пройшов");

            if (goal <= 0 || steps <= 0)
            {
                Print("Ціль або пройденні кроки не можуть бути від'ємними або нулем");
                return;
            }

            double goalDone = Math.Round(steps / goal * 100, 1);

            switch (goalDone)
            {
                case > 0 and < 70:
                    Print($"Треба більше рухатися, пройдено {goalDone}% від цілі");
                    break;

                case >= 70 and < 90:
                    Print($"Ще трохи порухайтесь, пройдено {goalDone}% від цілі");
                    break;

                case 90 and < 100:
                    Print($"Майже дійшли до цілі! Пройдено {goalDone}% від цілі");
                    break;

                case >= 100 and < 200:
                    Print($"Ціль досягнута! Ви молодець! Пройдено {goalDone}% від цілі");
                    break;

                case >= 200:
                    Print($"Ну ти просто машина! Пройдено {goalDone}% від цілі");
                    break;
            }


            // 2

            double cashBack = 0;
            double loyalityCardDiscount = 0;
            double discount = 0;
            bool loyaltyCard = false;

            double purchaseAmount = GetDouble("Привіт, вкажи суму твоєї покупки");

            if (purchaseAmount <= 0)
            {
                Print("Сума покупки не може бути від'ємною або нулем");
                return;
            }

            int hasLoyaltyCard = GetInt("Чи є у вас картка лояльності?(1 - так, 0 - ні)");

            if (hasLoyaltyCard != 0 && hasLoyaltyCard != 1)
            {
                Print("Введіть 1 або 0");
                return;
            }

            if (hasLoyaltyCard == 1)
            {
                loyaltyCard = true;
            }

            if (loyaltyCard)
            {
                Print("Оскільки ви маєте карту лояльності, вам надається знижка в 3 відсотки");

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
                Print($"Ви не отримали знижок, до оплати {purchaseAmount}грн");
                return;
            }

            discount = cashBack + loyalityCardDiscount;

            double finalAmount = purchaseAmount - (purchaseAmount * discount);

            Print($"Ви отримуєте {cashBack * 100}% кешбеку, знижка складає {discount * 100}%, до оплати {finalAmount} грн");


            // 3

            double kWh = GetDouble("Введіть кількість спожитих кВт·год");

            if (kWh <= 0)
            {
                Print("Кількість спожитих кВт·год не може бути від'ємною");
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

            Print($"Загальна вартість: {price} грн");
        }
    }
}