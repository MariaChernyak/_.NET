using System;
using BankApp.Models;

namespace BankApp.DAL
{
    public class BonusGenerate:IBonusGenerate
    {
        public int GeneratePlus(TypeOfBill type)
        {
            return type.CostOfBalance * 2;
        }

        public int GenerateMinus(TypeOfBill type)
        {
            return type.RefillOfBalance * 3;
        }
    }
}
