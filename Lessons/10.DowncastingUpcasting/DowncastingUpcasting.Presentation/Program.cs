using System;

class Animal
{

    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Dog barks");
    }
}

class Cat : Animal
{
    public Cat(string name) : base(name)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Cat meows");
    }
}

class Program
{
    static void Main()
    {
        Animal dog = new Dog("Buddy");
        Animal cat = new Cat("Whiskers");

        MakeSpecificSound(dog);
        MakeSpecificSound(cat);

        Console.Write("Enter the animal type (Dog or Cat): ");
        string userInput = Console.ReadLine();

        Animal userAnimal = CreateAnimal(userInput);
        if (userAnimal != null)
        {
            MakeSpecificSound(userAnimal);
        }
        else
        {
            Console.WriteLine("Invalid animal type");
        }
    }

    static void MakeSpecificSound(Animal animal)
    {
        if (animal is Dog)
        {
            Dog dog = (Dog)animal;
            dog.MakeSound();
        }
        else if (animal is Cat)
        {
            Cat cat = (Cat)animal;
            cat.MakeSound();
        }
        else
        {
            Console.WriteLine("Unknown animal type");
        }
    }

    static Animal CreateAnimal(string userInput)
    {
        switch (userInput.ToLower())
        {
            case "dog":
                return new Dog("UserDog");
            case "cat":
                return new Cat("UserCat");
            default:
                return null;
        }
    }
}
