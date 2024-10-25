/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Day3_Day4_Tasks
{
    public class Customer
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    public class CustomerValidator
    {
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return false;

            string phonePattern = @"^\d{10}$"; // Assumes a 10-digit number
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        
        public bool IsValidDateOfBirth(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;

            if (dateOfBirth > DateTime.Now.AddYears(-age))
                age--;

            return age >= 18; //customer must be at least 18 years old
        }
    }
    public class Program2
    {
        public static void Main()
        {
            Customer customer = new Customer
            {
                Name = "Srinithi",
                Email = "srisparks@test.com",
                PhoneNumber = "1234567890",
                DateOfBirth = new DateTime(2002, 1, 1)
            };

            CustomerValidator validator = new CustomerValidator();

            bool isEmailValid = validator.IsValidEmail(customer.Email);
            bool isPhoneValid = validator.IsValidPhoneNumber(customer.PhoneNumber);
            bool isDateOfBirthValid = validator.IsValidDateOfBirth(customer.DateOfBirth);

            Console.WriteLine($"Email valid: {isEmailValid}");
            Console.WriteLine($"Phone number valid: {isPhoneValid}");
            Console.WriteLine($"Date of birth valid: {isDateOfBirthValid}");
        }
    }


}
*/