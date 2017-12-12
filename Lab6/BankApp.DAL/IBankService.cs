using System.Collections.Generic;
using BankApp.Models;

namespace BankApp.DAL
{
    public interface IBankService
    {
        IEnumerable<BankAccount> GetAllAccounts();
        IEnumerable<Client> GetAllClients();
        IEnumerable<TypeOfBill> GetAllTypeOfBills();
        BankAccount GetById(int id);
        Client GetClientById(int id);
        void Create(BankAccount account);
        void ReplenishAmount(int id, int summ);
        void WriteAmount(int id, int summ);
        void CloseAccount(int id);
    }
}
