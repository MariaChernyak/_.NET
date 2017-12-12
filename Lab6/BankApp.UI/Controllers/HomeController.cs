using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using BankApp.DAL;
using BankApp.Models;
using BankApp.UI.Models;

namespace BankApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBankService _service;

        public HomeController()
        {
            var connection = ConfigurationManager.ConnectionStrings["BankConnection"];
            _service = new BankService(connection.ConnectionString, new GenerateGuid(), new BonusGenerate());
        }
        // GET: Home
        public ActionResult Index()
        {
            return View(_service.GetAllAccounts().Select(p =>
            {
                var tempClient = _service.GetClientById(p.ClientId);
                var client = new ClientModel
                {
                    Id = tempClient.Id,
                    Name = $"{tempClient.FirstName} {tempClient.SecondName}"
                };
                return new AccountViewModel
                {
                    Id = p.Id,
                    Client = client,
                    Amount = p.Amount,
                    Number = p.Number
                };
            }));
        }

        public ActionResult CreateAccount()
        {
            var clients = new SelectList(_service.GetAllClients()
                .Select(p => new ClientModel()
                {
                    Id = p.Id,
                    Name = $"{p.SecondName} {p.FirstName}"
                }), "Id", "Name");
            var types = new SelectList(_service.GetAllTypeOfBills(), "Id", "Name");
            var account = new CreateAccountViewModel()
            {
                Clients = clients,
                Types = types
            };
            return View(account);
        }

        [HttpPost]
        public ActionResult CreateAccount(CreateAccountViewModel account)
        {
            _service.Create(new BankAccount()
            {
                TypeOfBillId = account.TypeOfBillId,
                Amount = account.Amount,
                ClientId = account.ClientId
            });
            return RedirectToAction("Index");
        }
        public ActionResult Change(AccountViewModel model, string action)
        {
            if (action == "minus")
            {
                _service.WriteAmount(model.Id, model.Summ);
            }
            else if(action == "plus")
            {
                _service.ReplenishAmount(model.Id, model.Summ);
            }
            else
            {
                _service.CloseAccount(model.Id);
            }

           return RedirectToAction("Index");
        }
    }
}