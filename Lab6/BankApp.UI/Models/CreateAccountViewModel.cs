using System.Collections.Generic;
using System.Web.Mvc;

namespace BankApp.UI.Models
{
    public class CreateAccountViewModel
    {
        public int ClientId { get; set; }
        public double Amount { get; set; }
        public int TypeOfBillId { get; set; }
        public SelectList Clients { get; set; }
        public SelectList Types { get; set; }
    }

    public class TypeOfBillModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}