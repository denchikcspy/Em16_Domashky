
using System;
using EM_16.Entities;
using EM_16.Helpers;
using EM_16.Services;

namespace EM_16.Homeworks
{
    internal class Work5
    {
        private enum LoginResult
        {
            Success,
            Exit,
            Retry
        }

        public static void Run5()
        {
            BankCardManager manager = new BankCardManager();
            ATM atm = new ATM();

            while (true)
            {
                LoginResult result = Login(
                    manager, out BankCard card, out string pin);

                if (result == LoginResult.Exit)
                {
                    Console.WriteLine("Goodbye!");
                    return;
                }

                if (result == LoginResult.Retry)
                    continue;

                bool cardSession = true;

                while (cardSession)
                {
                    ShowMenu();

                    int choice = Getters.GetInt("Choose an option: ");

                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                ShowBalance(card, pin);
                                break;

                            case 2:
                                WithdrawMoney(atm, card, pin);
                                break;

                            case 3:
                                Console.WriteLine("Card returned. Goodbye!");
                                return;

                            default:
                                Console.WriteLine("Invalid option.");
                                continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    int answer = Getters.GetInt(
                        "Do you want another operation? (yes - 1 / no - 2): ");

                    if (answer != 1)
                    {
                        Console.WriteLine("Card returned. Goodbye!");
                        return;
                    }

                    while (true)
                    {
                        pin = Getters.GetStringNum("Enter PIN again: ");

                        try
                        {
                            if (card.CheckPin(pin))
                                break;

                            Console.WriteLine("Invalid PIN");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Session ended.");

                            cardSession = false;
                            break;
                        }
                    }
                }

            }
        }

        private static LoginResult Login(
            BankCardManager manager,
            out BankCard card,
            out string pin)
        {
            card = null!;
            pin = "";

            
            while (true)
            {
                string cardNumber = Getters.GetStringNum(
                    "Enter card number (or 0 to exit): ");
                
                if (cardNumber == "0")
                    return LoginResult.Exit;

                try
                {
                    card = manager.GetBankCard(cardNumber);

                    if (card != null)
                        break;

                    Console.WriteLine("Card not found.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            
            while (true)
            {

                pin = Getters.GetStringNum("Enter PIN: ");

                try
                {
                    if (card.CheckPin(pin))
                    {
                        Console.WriteLine(
                            $"Welcome, {card.GetOwnerName()}!");

                        return LoginResult.Success;
                    }

                    Console.WriteLine("Invalid PIN");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Choose another card.");

                    return LoginResult.Retry;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\n===== ATM MENU =====");
            Console.WriteLine("1. Show balance");
            Console.WriteLine("2. Withdraw money");
            Console.WriteLine("3. Return card");
        }

        private static void ShowBalance(BankCard card, string pin)
        {
            decimal balance = card.GetBalance(pin);
            Console.WriteLine($"Your balance: {balance} UAH");
        }

        private static void WithdrawMoney(
            ATM atm, BankCard card, string pin)
        {
            int amount = Getters.GetInt("Enter withdrawal amount: ");
            while (!Validation.IsPositive(amount) || amount % 100 != 0)
            {
                amount = Getters.GetInt("Invalid amount. Please enter a positive amount in multiples of 100: ");

            }

            atm.Withdraw(card, pin, amount);

            

            Console.WriteLine(
                $"Successfully withdrawn: {amount} UAH");
        }
    }
}
