using System;
using System.Collections.Generic;
using System.Linq;
using BankApp.Models;

namespace BankApp.DAL
{
    public class BankService:IBankService
    {
        private readonly DBContext _db;
        private IGenerateNumber _generateNumber;
        private IBonusGenerate _bonusGenerate;

        public BankService(string connectionString, IGenerateNumber generate, IBonusGenerate bonus)
        {
            _db = new DBContext(connectionString);
            _generateNumber = generate;
            _bonusGenerate = bonus;
        }

        public IEnumerable<BankAccount> GetAllAccounts()
        {
            return _db.BankAccounts.Where(p=>p.IsActive).ToList();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _db.Clients.ToList();
        }

        public IEnumerable<TypeOfBill> GetAllTypeOfBills()
        {
            return _db.TypeOfBills.ToList();
        }

        public Client GetClientById(int id)
        {
            return _db.Clients.Find(id);
        }

        public BankAccount GetById(int id)
        {
            return _db.BankAccounts.Find(id);
        }

        public void Create(BankAccount account)
        {
            if (account==null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            var number = _generateNumber.Generate();
            account.Number = number;
            account.Bonus = 0;
            account.IsActive = true;
            _db.BankAccounts.Add(account);
            _db.SaveChanges();
        }

        public void ReplenishAmount(int id,int summ)
        {
            var account = _db.BankAccounts.Find(id);
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            account.Amount += summ;
            account.Bonus += _bonusGenerate.GeneratePlus(account.TypeOfBill);
            _db.SaveChanges();
        }

        public void WriteAmount(int id,int summ)
        {
            var account = _db.BankAccounts.Find(id);
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            account.Bonus += _bonusGenerate.GenerateMinus(account.TypeOfBill);
            account.Amount -= summ;
            _db.SaveChanges();
        }

        public void CloseAccount(int id)
        {
            var account = _db.BankAccounts.Find(id);
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            account.IsActive = false;
            _db.SaveChanges();
        }

    }
}
