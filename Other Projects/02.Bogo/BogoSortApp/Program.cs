using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
class Program
{
    static Random random = new Random();

    static void Main()
    {
        int arrayLenght = int.Parse(Console.ReadLine());

        int[] array = new int[arrayLenght];
        BigInteger shuffleCounter = 0;

        for (int i = 0; i < arrayLenght; i++)
        {
            array[i] = random.Next(0,100); 
        }
        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine("Başlangıç Dizi:");
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }

        stopwatch.Start(); 
        int[] sortedArray = BogoSort(array, stopwatch,ref shuffleCounter);
        stopwatch.Stop(); 
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(shuffleCounter);

        Console.WriteLine("\nSorted array ");
        foreach (int num in sortedArray)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine($"\nSort time: {stopwatch.ElapsedMilliseconds} ms");
    }

    static bool IsSorted(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1])
                return false;
        }
        return true;
    }

    static int[] Shuffle(int[] array)
    {
        int[] shuffledArray = array.OrderBy(x => random.Next()).ToArray();
        return shuffledArray;
    }

    static int[] BogoSort(int[] array, Stopwatch stopwatch, ref BigInteger shuffleCounter)
    {
        while (!IsSorted(array))
        {
            
            array = Shuffle(array);
            shuffleCounter ++;
            if (shuffleCounter %10000000== 0)
            {
                foreach (int num in array)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine(shuffleCounter);
            }
        }
        return array;
    }
}
