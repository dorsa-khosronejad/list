using System;
using System.Collections.Generic;

namespace ListAndDictionary
{
    internal class Program
    {
        // List variable containing names of persons
        private static List<string> personList = new List<string>();

        // Dictionary containing person name and age where the string TKey is for name and the int TValue is for age
        private static Dictionary<string, int> personAgeDictionary = new Dictionary<string, int>();

        public static void Main()
        {
            Console.WriteLine("Welcome to the Person Manager!");
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Add New Person");
                Console.WriteLine("2. Remove Person");
                Console.WriteLine("3. Find Person");
                Console.WriteLine("4. List All Persons");
                Console.WriteLine("5. Exit");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        AddPerson();
                        break;
                    case "2":
                        RemovePerson();
                        break;
                    case "3":
                        FindPerson();
                        break;
                    case "4":
                        DisplayAllPersons();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        public static void AddPerson()
        {
            Console.WriteLine("Enter the person's name:");
            string name = Console.ReadLine();

            if (!personList.Contains(name))
            {
                personList.Add(name);
                Console.WriteLine($"Person '{name}' added successfully.");

                if (!personAgeDictionary.ContainsKey(name))
                {
                    Console.WriteLine($"Enter the age for {name}:");
                    if (int.TryParse(Console.ReadLine(), out int age))
                    {
                        personAgeDictionary.Add(name, age);
                        Console.WriteLine($"Age for {name} added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid age format. Age not added.");
                    }
                }
                else
                {
                    Console.WriteLine($"{name} already exists in the age dictionary.");
                }
            }
            else
            {
                Console.WriteLine($"{name} already exists in the person list.");
            }
        }

        public static void RemovePerson()
        {
            Console.WriteLine("Enter the name of the person to remove:");
            string nameToRemove = Console.ReadLine();

            if (personList.Contains(nameToRemove))
            {
                personList.Remove(nameToRemove);
                Console.WriteLine($"Person '{nameToRemove}' removed successfully from the person list.");

                if (personAgeDictionary.ContainsKey(nameToRemove))
                {
                    personAgeDictionary.Remove(nameToRemove);
                    Console.WriteLine($"Person '{nameToRemove}' removed successfully from the age dictionary.");
                }
                else
                {
                    Console.WriteLine($"{nameToRemove} not found in the age dictionary.");
                }
            }
            else
            {
                Console.WriteLine($"{nameToRemove} not found in the person list.");
            }
        }

        public static void FindPerson()
        {
            Console.WriteLine("Enter the name of the person to find:");
            string nameToFind = Console.ReadLine();

            if (personList.Contains(nameToFind))
            {
                Console.WriteLine($"{nameToFind} found in the person list.");
            }
            else
            {
                Console.WriteLine($"{nameToFind} not found in the person list.");
            }

            if (personAgeDictionary.ContainsKey(nameToFind))
            {
                Console.WriteLine($"{nameToFind} found in the age dictionary with age {personAgeDictionary[nameToFind]}.");
            }
            else
            {
                Console.WriteLine($"{nameToFind} not found in the age dictionary.");
            }
        }

        public static void DisplayAllPersons()
        {
            if (personList.Count > 0)
            {
                Console.WriteLine("\nPersons in the list:");
                foreach (var person in personList)
                {
                    Console.WriteLine(person);
                }
            }
            else
            {
                Console.WriteLine("\nPerson list is empty.");
            }

            if (personAgeDictionary.Count > 0)
            {
                Console.WriteLine("\nPersons and their ages in the dictionary:");
                foreach (var entry in personAgeDictionary)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value} years old");
                }
            }
            else
            {
                Console.WriteLine("\nAge dictionary is empty.");
            }
        }
    }
}
