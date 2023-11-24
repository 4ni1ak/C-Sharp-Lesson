using System;
using System.Collections.Generic;
using System.Linq;
using LINQMethods.Presentation;

namespace LINQMethods.Presentation
{
    internal class Program
    {
        private readonly static FakeDataService _fakeDataService= new FakeDataService();


        static void Main()
        {
            
            List<Pet> pets = _fakeDataService.GeneratePetData(3);

            Console.WriteLine("Sorted in ascending order:");
            var sortedPetsAscending = pets.OrderBy(pet => pet.FirstName).ToList();
            DisplayNames(sortedPetsAscending);

            Console.WriteLine("\nSorted in descending order:");
            DisplayNames(pets.OrderByDescending(pet => pet.FirstName).ToList());

            Console.WriteLine($"\nCount after removing duplicates: {pets.Count()}");
        }

        static void DisplayNames(List<Pet> pets)
        {
            foreach (var pet in pets)
            {
                Console.WriteLine($"{pet.FirstName} {pet.LastName}");
            }
        }

    }

}