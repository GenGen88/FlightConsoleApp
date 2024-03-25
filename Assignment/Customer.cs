using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Customer
    {
        // fields
        private string name;
        private string email;
        private string mobile;
        private string address;

        // properties
        public string Name
        {
            get { return name; }
            private set { value = name; }
        }

        public string Email
        {
            get { return email; }
            private set { value = email; }
        }

        public string Address
        {
            get { return address; }
            private set { value = address; }
        }

        public string Mobile
        {
            get { return mobile; }
            private set { value = mobile; }
        }


        // constructor
        public Customer(string Name, string Email, string Address,string Mobile)
        {
            this.name = Name;
            this.email = Email;
            this.address = Address;
            this.mobile = Mobile;
        }


    }
}
