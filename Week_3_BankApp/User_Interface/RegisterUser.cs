using System;
using Week_3_BankApp.Abstraction.Interfaces;
using Week_3_BankApp.DI;
using Week_3_BankApp.Implementation.Repositories;
using Week_3_BankApp.Repository.Abstraction;
using Week_3_BankApp.Utilities;

namespace Week_3_BankApp.Model
{
    public class RegisterUser
    {
        private  static readonly IMenu _Menu = new Menu();
        
        public static void RegisterCustomer(DIContainer dIContainer)
        {
            Console.Clear();
            Console.WriteLine("Enter Your First Name:    ");
            string firstName = Console.ReadLine();
            while (string.IsNullOrEmpty(firstName) || char.IsDigit(firstName[0]) || char.IsLower(firstName[0]))
            {
                firstName = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("Enter Your Last Name:    ");
            string lastName = Console.ReadLine();
            while (string.IsNullOrEmpty(lastName) || char.IsDigit(lastName[0]) || char.IsLower(lastName[0]))
            {
                lastName = Console.ReadLine();
            }

            string FullName = firstName + " " + lastName;
            Console.WriteLine("Enter Your Email");
            string email = Console.ReadLine();
            while (string.IsNullOrEmpty(email) || !email.Contains('@') || !email.Contains('.'))
            {
                email = Console.ReadLine();
            }

            Console.WriteLine("Enter your password. Should not be less than 6 characters");
            string password = Console.ReadLine();

            while (string.IsNullOrEmpty(password) && password.Length <= 6)
            {
                Console.WriteLine("Invalid Input Detected! \n Ensure Your Password is not empty \n Ensure it contains at least a special character \n Ensure it contains has more than 6 characters ");
                password = Console.ReadLine();
            }

            Customer newCustomer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PasswordHashed = PasswordGenerator.GenerateHash(password)
            };

            dIContainer.CustomerRepo.Add(newCustomer);
            dIContainer.UserService.CreateAccount(newCustomer);
            _Menu.MenuMethod(dIContainer, newCustomer);
        }
    }
}
 