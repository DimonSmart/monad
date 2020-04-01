using System;
using ReturnType;

namespace MonadSample
{
    public static class Program
    {
        public static void Main()
        {
            var customerId = 10;

            var customerNameResult =
                customerId.Wrap()
                    .Bind(GetCustomerById)
                    .Bind(GetCustomerName);

            Console.WriteLine($"Customer name:{customerNameResult}");
        }

        private static Result<string> GetCustomerName(Customer customer)
        {
            return string.Join(" ", customer.Name, customer.Surname);
        }

        public static Result<Customer> GetCustomerById(int id)
        {
            return new Customer {Name = "John", Surname = "Doe"};
        }

        public class Customer
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}