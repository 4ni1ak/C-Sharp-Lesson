using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace LINQMethods.Presentation
{
    public class FakeDataService
    {
        private readonly Random _random;

        public FakeDataService()
        {
            _random = new Random();
        }



        public List<Pet> GeneratePetData(int generateData)
        {
            var fakeBankAccountRules = new Faker<Pet>("tr")
                .RuleFor(s => s.Id, f => f.Random.Guid())
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                .RuleFor(s => s.Age, f => f.Date.Past(1).ToUniversalTime());

            var pets = fakeBankAccountRules.Generate(generateData);
            
            foreach (var bankAccount in pets)
                bankAccount.Id = Guid.NewGuid();

            return pets;
        }

    }
}
