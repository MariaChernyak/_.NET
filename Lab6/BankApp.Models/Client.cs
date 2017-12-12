using System;
using System.Collections.Generic;

namespace BankApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
