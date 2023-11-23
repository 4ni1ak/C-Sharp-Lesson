using Linq;

class Program
{
    static void Main()
    {
        #region Ex0

        

        var employees = new[]
        {
            new Employee("Jatson","Green",500M),
            new Employee("Ali","Green",400M),
            new Employee("Hakan","Green",300M),
            new Employee("Hüseyin","Blue",200M),
            new Employee("Nigar","Red",100M),
            new Employee("Ice","Green",900M),
        };
        foreach (var e in employees)
        {
            Console.WriteLine(e);
            
        }

        var between4k6k = employees.Where(x => x.MonthlySalary >= 4000M && x.MonthlySalary <= 6000M).ToList();

        foreach (var employe in between4k6k)
        {
            Console.Write(employe);
        }

        var nameSorted = employees.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        
        foreach (var employee in nameSorted)
        {
            Console.WriteLine($"{employee.LastName}, {employee.FirstName}");
        }
        #endregion

        #region Ex1




        var values = new[] { 20, 2, 4, 4, 66, 6, 65449, 7 };
            Console.WriteLine("Oirginal Array");
            foreach (var value in values)
            {
                Console.Write($"{value}, ");
            }

    
        #endregion

        #region Ex2

        var filtered =
            from value in values
            where value > 4
            select value;

        foreach (var filteredValue in filtered)
        {
            Console.Write(filteredValue);
        }
        #endregion

        #region Ex3

        var sorted =
            from value in values
            orderby value
            select value;
        foreach (var element in sorted)
        {
            Console.Write(element);
        }



        //imparating and recariative

        #endregion

        #region Ex4
        var sortedDis =
            from value in values
            orderby value descending 
            select value;
        int i=1;
        
        foreach (var element in sortedDis)
        {
            Console.Write(element);
        }
        #endregion

        #region Ex5
        var sortedfil =
            from value in values
            where value > 4
            orderby value
            select value;
        foreach (var element in sortedfil)
        {
            Console.Write(element);
        }
        #endregion

        //IEnumerable<T>
        //Employee 

        #region Ex6

        var items =new List<string>();
        Console.WriteLine("before adding to items:"+$"Count={items.Count}; Capacity = {items.Capacity}");
        items.Add("red");
        items.Insert(0,"yelloq");
        Console.WriteLine("afrer adding to items:" + $"Count={items.Count}; Capacity = {items.Capacity}");
        items.Remove("yellow");
        items.RemoveAt(1);



        #endregion

        #region Ex7

        var Items=new List<string>();
        items.Add("aQua");
        items.Add("Rust ");
        items.Add("yeLLOw");
        items.Add("rED");
        var startsWithR = items.Select(item => (UppercaseString: item.ToUpper(), OriginalString: item))
            .Where(x => x.UppercaseString.StartsWith("R"))
            .OrderBy(x => x.UppercaseString)
            .Select(x => x.UppercaseString);
        foreach (var item in startsWithR)
        {
            Console.WriteLine(item);
        }
        #endregion

    }
}