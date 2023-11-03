using System;
using System.Diagnostics;

namespace _220201013Random.Presentation
{
    internal class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            while (true)
            {
                if (AskQuestion())
                {
                    break;
                }
            }
        }

        static int GenerateQuestion()
        {
            string idString = Guid.NewGuid().ToString();
            char randomFactor = idString[idString.Length - 1];
            var random = new Random(randomFactor);

            int num1 = random.Next(1, 10);
            return num1;
        }

        static bool AskQuestion()
        {
            int correctAnswers = 0;
            int totalQuestions = 0;
            double totalTimeForCorrectAnswers = 0;
            double totalTimeForWrongAnswers = 0;

            while (true)
            {
                int num1 = GenerateQuestion();
                int num2 = GenerateQuestion();
                int correctAnswer = num1 * num2;
                int userAnswer;

                do
                {
                    Console.Write($"How much is {num1} * {num2}? ");
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    if (int.TryParse(Console.ReadLine(), out userAnswer))
                    {
                        stopwatch.Stop();
                        double timeSpent = stopwatch.Elapsed.TotalSeconds;

                        totalQuestions++;

                        if (userAnswer == correctAnswer)
                        {
                            correctAnswers++;
                            totalTimeForCorrectAnswers += timeSpent;
                            Console.WriteLine("Very good!");

                            if (totalQuestions % 5 == 0)
                            {
                                Console.WriteLine("Do you want to exit? (Yes/No)");
                                string userInput = Console.ReadLine();

                                if (userInput.ToLower() == "y" || userInput.ToLower() == "yes")
                                {
                                    Console.WriteLine("Exiting the program.");
                                    if (totalQuestions > 0)
                                    {
                                        double averageTimeForCorrectAnswers = totalTimeForCorrectAnswers / correctAnswers;
                                        double averageTimeForWrongAnswers = totalTimeForWrongAnswers / (totalQuestions - correctAnswers);
                                        Console.WriteLine($"You answered {correctAnswers} questions correctly.");
                                        Console.WriteLine($"Average time for correct answers: {averageTimeForCorrectAnswers} seconds");
                                        Console.WriteLine($"Average time for wrong answers: {averageTimeForWrongAnswers} seconds");
                                    }
                                    return true; // Exit the program
                                }
                                else if (userInput.ToLower() == "n" || userInput.ToLower() == "no")
                                {
                                    Console.WriteLine("Continuing with the program.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter 'Yes' or 'No'.");
                                }
                            }
                        }
                        else
                        {
                            totalTimeForWrongAnswers += timeSpent;
                            Console.WriteLine("No. Please try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                } while (userAnswer != correctAnswer);


            }

        }
    }
}