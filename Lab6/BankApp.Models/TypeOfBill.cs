using System.Collections.Generic;

namespace BankApp.Models
{
    public class TypeOfBill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CostOfBalance { get; set; }
        public int RefillOfBalance { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
