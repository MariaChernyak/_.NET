using System;

namespace BankApp.DAL
{
    public class GenerateGuid:IGenerateNumber
    {
        public string Generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
