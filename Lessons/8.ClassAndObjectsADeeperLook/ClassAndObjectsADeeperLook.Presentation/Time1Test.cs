namespace ClassAndObjectsADeeperLook.Presentation
{
    public class Time1Test
    {
        static void Main()
        {
            #region Exp1

            var time = new Time1();
            Console.WriteLine($"The initial universal time is: {time.ToUniversalString()}");
            Console.WriteLine($"The initial standard time is: {time.ToString()}");
            Console.WriteLine();

            time.SetTime(13, 27, 6);
            Console.WriteLine($"Universal time after SetTime is: {time.ToUniversalString()}");
            Console.WriteLine($"Standard time after SetTime is: {time.ToString()}");
            Console.WriteLine();
            try
            {
                time.SetTime(99, 99, 99);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }


            Console.WriteLine("After attempting invalid settings:");
            Console.WriteLine($"Universal time: {time.ToUniversalString()}");
            Console.WriteLine($"Standard time: {time.ToString()}");
            Console.WriteLine($"Exp1 end");
            #endregion

            #region Exp2

            var time2 = new Time1();


            #endregion

            #region Exp3

            var t1 = new Time2(); 
            var t2 = new Time2(2); 
            var t3 = new Time2(21, 34);
            var t4 = new Time2(12, 25, 42); 
            var t5 = new Time2(t4); 
            Console.WriteLine("Constructed with: \n");
            Console.WriteLine("tl: all arguments defaulted");
            Console.WriteLine($" {t1.ToUniversalString()}");
            Console.WriteLine($" {t1.ToString()}\n");
            Console.WriteLine("t2: hour specified; minute and second defaulted");
            Console.WriteLine($"{t2.ToUniversalString()}");
            Console.WriteLine($"{t2.ToString()}");
            Console.WriteLine("t3: hour and minute specified; second defaulted");
            Console.WriteLine($"{t3.ToUniversalString()}");
            Console.WriteLine($"{t3.ToString()}");
            #endregion

            #region Exp4

            Console.WriteLine($"Employees before instantiation: {Employee.Count}");
             var e1=new Employee("Susan", "Baker");
             var e2= new Employee("Bob", "Blue");
            Console.WriteLine( $"\nEmployees after instantiation: {Employee.Count}");
            Console.WriteLine($"\nEmployee 1: {e1.FirstName} {e1.LastName}");
            Console.WriteLine($"Employee 2: {e2.FirstName} {e2.LastName}");
            e1= null;
            e2= null;
            #endregion
        }

    }
    }