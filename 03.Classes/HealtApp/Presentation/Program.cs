using HealtApp.Domain.Entities;
using HealtApp.Domain.Enum;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine($"Welcome to HealtApp \nDate==>{DateTime.UtcNow}\nVersion 0.1.0.0");


        Console.WriteLine("Enter Patient Information");

        Console.Write("First Name==> ");
        string name = Console.ReadLine();

        Console.Write("Last Name==> ");
        string surName = Console.ReadLine();

        DateTime birthday;
        while (true)
        {
            Console.Write("Date of Birth (yyyy-MM-dd) Ex==> ");
            if (DateTime.TryParse(Console.ReadLine(), out birthday))
                break;
            Console.WriteLine("Invalid date format! Please try again.");
        }

        int bigBeats;
        while (true)
        {
            Console.Write("High Blood Pressure==> ");
            if (int.TryParse(Console.ReadLine(), out bigBeats))
                break;
            Console.WriteLine("Invalid input! Please try again.");
        }

        int smallBeats;
        while (true)
        {
            Console.Write("Low Blood Pressure==> ");
            if (int.TryParse(Console.ReadLine(), out smallBeats))
                break;
            Console.WriteLine("Invalid input! Please try again.");
        }

        Genders gender;
        while (true)
        {
            Console.Write("Gender (Male, Female, Other)==> ");
            if (Enum.TryParse(Console.ReadLine(), true ,out gender))
                break;
            Console.WriteLine("Invalid gender! Please try again.");
        }
 
        Console.Write("Disease Description==> ");
        string descriptionDisease = Console.ReadLine();

        Patient patient = new(name, surName, birthday, bigBeats, smallBeats, descriptionDisease, gender);
        #region Print Patient

        Console.WriteLine("Patient Created:"
                     + $"\nFirst Name: {patient.FirstName}"
                     + $"\nLast Name: {patient.LastName}"
                     + $"\nDate of Birth: {patient.Birthday.ToString()}"
                     + $"\nHigh Blood Pressure: {patient.BigBeats}"
                     + $"\nLow Blood Pressure: {patient.SmallBeats}"
                     + $"\nGender: {patient.Gender}"
                     + $"\nTarget Heart Rate Maximum: {patient.TargetHeartRateMax} current big beat is {patient.BigBeats}"
                     + $"\nTarget Heart Rate Minimum: {patient.TargetHeartRateMin }current smal beat is {patient.SmallBeats}"                   
                     + $"\nMaximum Heart Rate: {patient.MaxHeartRate}"
                     + $"\nGender: {patient.Gender}"
                     + $"\nDisease Description: {patient.DescriptionDisease}");



        #endregion

    }
}