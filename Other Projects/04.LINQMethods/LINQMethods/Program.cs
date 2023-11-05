using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LINQMethods
{
    class Program
    {
        static void Main()
        {
            var data = Enumerable.Range(1, 1000000).ToList();
            var otherData = Enumerable.Range(1000001, 10000000);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // LINQ Methods
            #region LINQ Methods


            //  1. SkipWhile - Skip elements while a condition is met
            var skippedWhileData = data.SkipWhile(x => x < 500000).ToList();
                
            //  2. TakeWhile - Take elements while a condition is met
            var takenWhileData = data.TakeWhile(x => x < 500000).ToList();
                
            //  3. All - Check if all elements satisfy a condition
            bool  allEven = data.All(x => x % 2 == 0);
                
            //  4. Any with Condition - Check if any element satisfies a condition
            bool  anyGreaterThan500000 = data.Any(x => x > 500000);
                
            //  5. Average with Selector - Calculate average with a selector
            double averageSquared = data.Average(x => x * x);
                
            //  6. Count with Condition - Count elements that satisfy a condition
            int countGreaterThan500000 = data.Count(x => x > 500000);
                
            //  7. Sum with Condition - Sum elements that satisfy a condition
            double sumEven = data.Where(x => x % 2 == 0).Sum(x=>(double)x);
                
            //  8. ToDictionary - Convert a collection into a dictionary
            var dictionary = data.ToDictionary(x => x, x => x * x);
                
            //  9. ToLookup - Convert a collection into a lookup
            var lookup = data.ToLookup(x => x % 2);

            //  10. Cast - Explicitly cast elements to a different type
            var doubleData = data.Select(x => (double)x).ToList();


            //  11. OfType - Filter elements of a specific type
            var evenNumbers = data.OfType<int>().Where(x => x % 2 == 0).ToList();
                
            //  12. Zip - Combine two collections element-wise
            var zippedData = data.Zip(otherData, (x, y) => x * y).ToList();

            //  13. ToList - Convert a collection to a List
            var dataList = data.ToList();
           
            //  14. Single - Get the single element that satisfies a condition
            var singleElement = data.Single(x => x == 500000);
                
            //  15. ElementAt - Get an element at a specific index
            var elementAtIndex = data.ElementAt(999);
           
            //  16. ToArray - Convert a collection to an array
            var dataArray = data.ToArray();
           
            //  17. ToHashSet - Convert a collection to a HashSet
            var dataHashSet = data.ToHashSet();
                
            //  18. ToObservableCollection - Convert a collection to an ObservableCollection
            var observableCollection = new System.Collections.ObjectModel.ObservableCollection<int>(data);

            #endregion

            stopwatch.Stop();

            // Printing execution times for each LINQ method
            Console.WriteLine("Execution Times:");
            Console.WriteLine($"Total Time: {stopwatch.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}
