using System;
using System.IO;
using System.Collections;

namespace Phonebook
{
    class Program
    {
        static string path = @"/Users/soniatan/Projects/Phonebook/Phonebook.txt";

        static void Main(string[] args)
        {

            Hashtable filler = new Hashtable
            {
                { "Peter", "81234567" },
                { "Susan", "81234509" },
                { "Daisy", "81234704" },
                { "Josie", "81235927" },
                { "Jared", "81232238" }
            };


            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (DictionaryEntry contact in filler)
                    {
                        string newEntry = "Name: " + contact.Key + ", Number: " + contact.Value;
                        sw.WriteLine(newEntry);
                    }
                }
            }

            static void AddContact()
            {
                Console.WriteLine("Enter new contact name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter new contact number: ");
                string number = Console.ReadLine();

                using (StreamWriter sw = File.CreateText(path))
                {
                        string newEntry = "Name: " + name + ", Number: " + number;
                        sw.WriteLine(newEntry);
                }
            }

            static void FindContact()
            {
                Console.WriteLine("Enter name of contact to search: ");
                string input = Console.ReadLine();
                bool contactFound = false;
                string name, number;

                using (StreamReader sr = File.OpenText(path))
                {

                    string savedContacts;
                    while ((savedContacts = sr.ReadLine()) != null)
                        {
                        name = savedContacts.Split(", ")[0].Split(": ")[1];
                        number = savedContacts.Split(", ")[1].Split(": ")[1];

                        if (name.ToLower() == input.ToLower())
                        {
                            contactFound = true;
                            Console.WriteLine("{0}: {1}", name, number);
                        }
                    }

                }

                if (contactFound == false)
                {
                    Console.WriteLine("Contact matching '{0}' not found.", input);
                }

            }

            Console.WriteLine("Input number to select phonebook action: ");
            Console.WriteLine("1. Search for existing contact");
            Console.WriteLine("2. Add new contact");

            string action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    FindContact();
                    break;
                case "2":
                    AddContact();
                    break;
                default:
                    Console.WriteLine("Please enter a valid number input for your selection.");
                    break;
            }

            Console.ReadLine();
        }
    }
}

