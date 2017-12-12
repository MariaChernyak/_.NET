using BankApp.Models;

namespace BankApp.DAL
{
    public interface IBonusGenerate
    {
        int GeneratePlus(TypeOfBill type);
        int GenerateMinus(TypeOfBill type);
    }
}
