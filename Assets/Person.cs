using System;

public class Person
{
    public string Name { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string Gender { get; private set; }
    public string Address { get; private set; }

    public bool Dementia { get; private set; }

    public Person(string name, DateTime dateOfBirth, string gender, string address, bool dementia)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Address = address;
        Dementia = dementia;
    }

    // Method to generate random person's information
    public static Person GenerateRandomPerson()
    {
        // Generate random name
        string[] names = { "John", "Alice", "Michael", "Emma", "James", "Olivia", "Robert", "Sophia" };
        string randomName = names[UnityEngine.Random.Range(0, names.Length)];

        // Generate random date of birth (age between 18 and 80)
        DateTime randomDateOfBirth = DateTime.Now.AddYears(-UnityEngine.Random.Range(18, 80));

        // Generate random gender
        string[] genders = { "Male", "Female" };
        string randomGender = genders[UnityEngine.Random.Range(0, genders.Length)];

        // Generate random address (for simplicity, let's use a placeholder)
        string randomAddress = "123 Main St, City, Country";

        // Generate random dementia status
        bool randomDementia = UnityEngine.Random.Range(0, 2) == 0; // 50% chance of having dementia

        // Create and return the Person object
        return new Person(randomName, randomDateOfBirth, randomGender, randomAddress, randomDementia);
    }

    // Method to print person's information
    public void PrintInformation()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Date of Birth: {DateOfBirth.ToShortDateString()}");
        Console.WriteLine($"Gender: {Gender}");
        Console.WriteLine($"Address: {Address}");
        Console.WriteLine($"Dementia: {(Dementia ? "Yes" : "No")}");
    }
}
