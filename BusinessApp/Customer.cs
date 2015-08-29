using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary
{
    public class Customer
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime AccountNumber { get; }

        public Customer(string firstName, string lastName, DateTime accountExpiry)
        {
            if (accountExpiry == null)
            {
                throw new ArgumentNullException(nameof(accountExpiry));
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.AccountNumber = accountExpiry;
        }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
