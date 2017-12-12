using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public double Amount { get; set; }
        public int Bonus { get; set; }
        public bool IsActive { get; set; }
        public int TypeOfBillId { get; set; }
        public virtual TypeOfBill TypeOfBill { get; set; }
    }
}
