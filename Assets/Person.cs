using System;
using System.IO;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;



public class Address
{
    public string street;
    public int num;
    public char letter;

    public Address(string street, int num, char letter)
    {
        this.street = street;
        this.num = num;
        this.letter = letter;
    }

    public static Address GenerateAdress()
    {
        string[] streets =
        {
            "Ленина ул.",
            "Куйбышева ул.",
            "Малышева ул.",
            "Шейнкмана ул.",
            "Белинского ул.",
            "Толмачева ул.",
            "Бажова ул.",
            "Свердлова ул.",
            "Гагарина ул.",
            "Репина ул.",
            "Пролетарская ул.",
            "Вильямса ул.",
            "Красноармейская ул.",
            "Пушкина ул.",
            "Красная ул.",
            "Советская ул.",
            "Парковая ул.",
            "8 Марта ул.",
            "Попова ул.",
            "Мичурина ул."
        };
        string randomStreet = streets[UnityEngine.Random.Range(0, streets.Length)];

        // Генерируем случайный номер дома от 1 до 100
        int randomHouseNumber = UnityEngine.Random.Range(1, 101);

        // Генерируем случайную букву для номера дома
        char randomLetter = (char)UnityEngine.Random.Range('А', 'Г' + 1);

        // Формируем адрес
        return new Address(randomStreet, randomHouseNumber, randomLetter);
    }
    
    public string GetAddressString()
    {
        return $"{street}, {num}-{letter}";
    }
}

public class Person
{
    public string Name { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public bool Gender { get; private set; }
    public string Address { get; private set; }
    
    public string Description { get; private set; }
    public string[] Diseases { get; private set; }
    public bool Dementia { get; private set; }

    public MedicalCard MedicalCard { get; private set; }

    public Person(string name, DateTime dateOfBirth, bool gender, Address address,  string[] diseases, string description, bool dementia, MedicalCard medicalCard)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Address = address.GetAddressString();
        Dementia = dementia;
        Diseases = diseases;
        Description = description;
        MedicalCard = medicalCard;

    }

    public static Person GenerateRandomPerson()
    {
        // Generate random name based on gender
        string[] maleNames = { "Ваня", "Миша", "Владимир", "Тимофей", "Петр", "Александр", "Иван", "Сергей", "Дмитрий", "Николай", "Артем" };

        string[] femaleNames = { "Анна", "Мария", "Екатерина", "Александра", "София", "Виктория", "Ольга", "Татьяна", "Ирина", "Елена", "Анастасия" };

        bool randomGender = UnityEngine.Random.Range(0, 2) == 0; // true for male, false for female

        var randomName = randomGender ? maleNames[UnityEngine.Random.Range(0, maleNames.Length)] : femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];

        // Generate random date of birth (age between 18 and 80)
        DateTime randomDateOfBirth = DateTime.Now.AddYears(-UnityEngine.Random.Range(18, 80));

        // Generate random address (for simplicity, let's use a placeholder)
        Address randomAddress = global::Address.GenerateAdress();

        // Generate random dementia status
        bool randomDementia = UnityEngine.Random.Range(0, 2) == 0; // 50% chance of having dementia
        string[] diseases = GenerateRandomDiseases();
        string description = GenerateRandomDescription(randomDementia, randomGender);

        MedicalCard medicalCard = new MedicalCard(randomAddress.GetAddressString(), randomDateOfBirth.ToShortDateString(), randomName, description, diseases);

        // Create and return the Person object
        return new Person(randomName, randomDateOfBirth, randomGender, randomAddress, GenerateRandomDiseases(), null, randomDementia, medicalCard);
    }

    private static string GenerateRandomDescription(bool hasDementia, bool gender)
    {
        string filePath = "./Assets/CoolStoryBob";

        if (hasDementia)
        {
            string[] allDescriptions = File.ReadAllLines(filePath +"//description_demention.txt");
            return allDescriptions[UnityEngine.Random.Range(0, allDescriptions.Length)];
        }

        string[] normalDescriptions;
        normalDescriptions = gender ? File.ReadAllLines(filePath + "//description_male.txt") : File.ReadAllLines(filePath + "//description_female.txt");
        return normalDescriptions[UnityEngine.Random.Range(0, normalDescriptions.Length)];
    }

    
    private static string[] GenerateRandomDiseases()
    {
        string[] mentalDisorders = {
            "Депрессия",
            "Биполярное расстройство",
            "Шизофрения",
            "Тревожные расстройства",
            "Расстройства аутистического спектра",
            "Посттравматическое стрессовое расстройство",
            "Нарциссическое расстройство личности",
            "Обсессивно-компульсивное расстройство",
            "Эпилепсия",
            "Деменция",
            "Психопатия",
            "Генерализованное тревожное расстройство",
            "Паническое расстройство",
            "Соматоформные расстройства",
            "Проблемы с пищеводом",
            "Нарушения сна",
            "Паранойя",
            "Расстройства аутоагрессии",
            "Личностные расстройства",
            "Расстройства аффективного спектра"
        };

        // Количество заболеваний, которые нужно сгенерировать
        int numberOfDiseases = UnityEngine.Random.Range(1, 3); // Генерируем от 1 до 4 заболеваний

        // Создаем массив для хранения сгенерированных заболеваний
        string[] generatedDiseases = new string[numberOfDiseases];

        // Выбираем случайные заболевания из списка
        for (int i = 0; i < numberOfDiseases; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, mentalDisorders.Length - 1);
            generatedDiseases[i] = mentalDisorders[randomIndex];
        }

        return generatedDiseases;
    }
    
    // Method to print person's information
    public void PrintInformation()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Date of Birth: {DateOfBirth.ToShortDateString()}");
        Console.WriteLine($"Gender: {Gender}");
        Console.WriteLine($"Address: {Address}");
        Console.WriteLine($"Dementia: {(Dementia ? "Yes" : "No")}");
        Console.WriteLine($"Diseases: {Diseases.Length}, {Diseases}");
        Console.WriteLine($"Description: {Description}" );
    }
}
