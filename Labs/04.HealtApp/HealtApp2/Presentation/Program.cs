using HealtApp2.Domain.Entities;
using HealtApp2.Domain.Enum;

class Program
{
    static void Main()
    {
        Console.WriteLine($"Welcome to HealtApp \nDate==>{DateTime.UtcNow}\nVersion 0.2.0.0");


        Console.WriteLine("Enter Patient Information");

        Console.Write("First Name==> ");
        string name = Console.ReadLine();

        Console.Write("Last Name==> ");
        string surName = Console.ReadLine();

		DateTime birthday = ReadDateTime("Date of Birth (yyyy-MM-dd) Ex==> ");
		int bigBeats = ReadInteger("High Blood Pressure==> ");
		int smallBeats = ReadInteger("Low Blood Pressure==> ");
		Genders gender = ReadGender("Gender (Male, Female, Other)==> ");

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
	static DateTime ReadDateTime(string prompt)
	{
		DateTime result;
		while (true)
		{
			Console.Write(prompt);
			if (DateTime.TryParse(Console.ReadLine(), out result))
				return result;

			Console.WriteLine("Invalid date format! Please try again.");
		}
	}

	static int ReadInteger(string prompt)
	{
		int result;
		while (true)
		{
			Console.Write(prompt);
			if (int.TryParse(Console.ReadLine(), out result))
				return result;

			Console.WriteLine("Invalid input! Please try again.");
		}
	}

	static Genders ReadGender(string prompt)
	{
		Genders result;
		while (true)
		{
			Console.Write(prompt);
			if (Enum.TryParse(Console.ReadLine(), true, out result))
				return result;

			Console.WriteLine("Invalid gender! Please try again.");
		}
	}
}
/*
 
 public enum WeightStatus
{
    BelowIdealWeight, // Below 18.5 kg/m²
    AtIdealWeight,    // Between 18.5 kg/m² and 24.9 kg/m²
    AboveIdealWeight, // Between 25 kg/m² and 29.9 kg/m²
    VeryOverweight,   // Between 30 kg/m² and 39.9 kg/m²
    MorbidlyObese     // Above 40 kg/m²
}

public WeightStatus CalculateWeightStatus(double bmi)
{
    if (bmi < 18.5)
    {
        return WeightStatus.BelowIdealWeight;
    }
    else if (bmi >= 18.5 && bmi <= 24.9)
    {
        return WeightStatus.AtIdealWeight;
    }
    else if (bmi >= 25 && bmi <= 29.9)
    {
        return WeightStatus.AboveIdealWeight;
    }
    else if (bmi >= 30 && bmi <= 39.9)
    {
        return WeightStatus.VeryOverweight;
    }
    else
    {
        return WeightStatus.MorbidlyObese;
    }
}

// BMI Calculation
public double CalculateBMI(double weightInPounds, double heightInInches)
{
    if (heightInInches <= 0 || weightInPounds <= 0)
    {
        return 0; // You can return 0 in case of an error.
    }

    return (weightInPounds / (heightInInches * heightInInches)) * 703;
}

public double BMI { get; set; }
*/