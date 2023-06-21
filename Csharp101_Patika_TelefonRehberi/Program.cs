using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp101_Patika_TelefonRehberi
{
    class Program
    {
        static List<Contact> contacts = new List<Contact>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Telefon Rehberi Uygulaması");
                Console.WriteLine("1. Telefon Numarası Kaydet");
                Console.WriteLine("2. Telefon Numarası Sil");
                Console.WriteLine("3. Telefon Numarası Güncelle");
                Console.WriteLine("4. Rehber Listeleme (A-Z)");
                Console.WriteLine("5. Rehber Listeleme (Z-A)");
                Console.WriteLine("6. Rehberde Arama");
                Console.WriteLine("7. Çıkış");
                Console.Write("Seçiminizi yapın (1-7): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        DeleteContact();
                        break;
                    case "3":
                        UpdateContact();
                        break;
                    case "4":
                        ListContacts(true);
                        break;
                    case "5":
                        ListContacts(false);
                        break;
                    case "6":
                        SearchContact();
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddContact()
        {
            Console.WriteLine("Yeni Kişi Ekleme");
            Console.Write("İsim: ");
            string name = Console.ReadLine();
            Console.Write("Telefon Numarası: ");
            string phoneNumber = Console.ReadLine();

            Contact newContact = new Contact(name, phoneNumber);
            contacts.Add(newContact);

            Console.WriteLine("Kişi başarıyla eklendi.");
        }

        static void DeleteContact()
        {
            Console.WriteLine("Kişi Silme");
            Console.Write("Silinecek kişinin İsim veya Telefon Numarasını girin: ");
            string searchQuery = Console.ReadLine();

            Contact contactToRemove = null;

            foreach (var contact in contacts)
            {
                if (contact.Name.Contains(searchQuery) || contact.PhoneNumber.Contains(searchQuery))
                {
                    contactToRemove = contact;
                    break;
                }
            }

            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                Console.WriteLine("Kişi başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Kişi bulunamadı.");
            }
        }

        static void UpdateContact()
        {
            Console.WriteLine("Kişi Güncelleme");
            Console.Write("Güncellenecek kişinin İsim veya Telefon Numarasını girin: ");
            string searchQuery = Console.ReadLine();

            Contact contactToUpdate = null;

            foreach (var contact in contacts)
            {
                if (contact.Name.Contains(searchQuery) || contact.PhoneNumber.Contains(searchQuery))
                {
                    contactToUpdate = contact;
                    break;
                }
            }

            if (contactToUpdate != null)
            {
                Console.Write("Yeni İsim: ");
                string newName = Console.ReadLine();
                Console.Write("Yeni Telefon Numarası: ");
                string newPhoneNumber = Console.ReadLine();

                contactToUpdate.Name = newName;
                contactToUpdate.PhoneNumber = newPhoneNumber;

                Console.WriteLine("Kişi başarıyla güncellendi.");
            }
            else
            {
                Console.WriteLine("Kişi bulunamadı.");
            }
        }

        static void ListContacts(bool ascendingOrder)
        {
            Console.WriteLine("Rehber Listeleme");

            if (ascendingOrder)
                contacts.Sort((x, y) => string.Compare(x.Name, y.Name));
            else
                contacts.Sort((x, y) => string.Compare(y.Name, x.Name));

            if (contacts.Count > 0)
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine("İsim: " + contact.Name);
                    Console.WriteLine("Telefon Numarası: " + contact.PhoneNumber);
                    Console.WriteLine("-------------");
                }
            }
            else
            {
                Console.WriteLine("Rehber boş.");
            }
        }

        static void SearchContact()
        {
            Console.WriteLine("Kişi Arama");
            Console.Write("Aranacak kişinin İsim veya Telefon Numarasını girin: ");
            string searchQuery = Console.ReadLine();

            List<Contact> searchResults = new List<Contact>();

            foreach (var contact in contacts)
            {
                if (contact.Name.Contains(searchQuery) || contact.PhoneNumber.Contains(searchQuery))
                {
                    searchResults.Add(contact);
                }
            }

            if (searchResults.Count > 0)
            {
                Console.WriteLine("Arama Sonuçları:");
                foreach (var contact in searchResults)
                {
                    Console.WriteLine("İsim: " + contact.Name);
                    Console.WriteLine("Telefon Numarası: " + contact.PhoneNumber);
                    Console.WriteLine("-------------");
                }
            }
            else
            {
                Console.WriteLine("Kişi bulunamadı.");
            }
        }
    }

    class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Contact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }


}
