using System.Collections.Generic;

namespace BankApp.UI.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public double Amount { get; set; }
        public int Summ { get; set; }
        public ClientModel Client { get; set; }
        public IEnumerable<ClientModel> Clients { get; set; }
    }
}