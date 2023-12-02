using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Excel.Presentation.Domain.Entities;

namespace Excel.Presentation.Services
{
    public class FakeDataService
    {
        private readonly Random _random;

        public FakeDataService()
        {
            _random = new Random();
        }



        public List<Student> GeneratePetData(int generateData)
        {
            var fakeStudentRules = new Faker<Student>("tr")
                .RuleFor(s => s.Id, f => f.Random.Guid())
                .RuleFor(s => s.Name, f => f.Name.FirstName())
                .RuleFor(s => s.Age, f =>(Int16) f.Random.Number(10,120))
                .RuleFor(s => s.Department,f=>f.Company.Locale);

            var students = fakeStudentRules.Generate(generateData);

            foreach (var student in students)
                student.Id = Guid.NewGuid();

            return students;
        }

    }
}
