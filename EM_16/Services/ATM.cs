using EM_16.Entities;
using EM_16.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM_16.Services
{
    internal class ATM
    {
            private List<Banknote> banknotes;

            public ATM()
            {
                Random random = new Random();

                banknotes = new List<Banknote>
        {
            new Banknote(1000, random.Next(0, 101)),
            new Banknote(500, random.Next(0, 101)),
            new Banknote(200, random.Next(0, 101)),
            new Banknote(100, random.Next(0, 101))
        };
            }

        public void Withdraw(BankCard card, string pin, int amount)
        {
            
            if (card.GetBalance(pin) < amount)
                throw new Exception("Insufficient funds.");

           
            if (!FindCashCombination(amount, out int[] counts))
                throw new Exception("The ATM cannot dispense this amount.");

             
            card.Withdraw(pin, amount);

            
            for (int i = 0; i < counts.Length; i++)
            {
                banknotes[i].Remove(counts[i]);
            }
        }

        private bool FindCashCombination(int amount, out int[] counts)
        {
            
            counts = new int[4];


            int max1000 = Math.Min(amount / 1000, banknotes[0].GetCount());
            int usedBanknotes = 0;
            for (int count1000 = max1000; count1000 >= 0; count1000--)
            {
                int remaining1000 = amount - count1000 * 1000;
                

                int max500 = Math.Min(remaining1000 / 500, banknotes[1].GetCount());
                for (int count500 = max500; count500 >= 0; count500--)
                {
                    int remaining500 = remaining1000 - count500 * 500;
                    
                    int max200 = Math.Min(remaining500 / 200, banknotes[2].GetCount());
                    for (int count200 = max200; count200 >= 0; count200--)
                    {
                        int remaining200 = remaining500 - count200 * 200;
                        

                            int count100 = remaining200 / 100;
                            usedBanknotes = count100 + count200 + count500 + count1000;
                            if (count100 <= banknotes[3].GetCount() && usedBanknotes <= 30)
                            {
                                    counts[0] = count1000;
                                    counts[1] = count500;
                                    counts[2] = count200;
                                    counts[3] = count100;
                                    return true;
                            }
                        

                    }
                }
            }
            

            return false;
        }
    }
}
