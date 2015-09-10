using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary
{
    public class Customer
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime AccountNumber { get; private set; }

        public Customer(string firstName, string lastName, DateTime accountExpiry)
        {
            if (accountExpiry == null)
            {
                throw new ArgumentNullException("accountExpiry");
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.AccountNumber = accountExpiry;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
