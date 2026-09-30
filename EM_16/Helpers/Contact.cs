namespace EM_16.Helpers
{
    class Contact
    {
        private int id = 0;
        private static int autoInc = 1;

        private string name = "";
        private string phoneNumber = "";
        private string address = "";

        public Contact(string name, string phoneNumber, string address = "")
        {
            this.id = autoInc++;

            this.name = name;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }

        public int getId() { return id; }

        public string getName() { return name; }
        public void setName(string newName)
        {
            if (name.Trim().Length != 0)
            {
                this.name = newName;
            }
        }

        public string getAddress() { return address; }
        public void setAddress(string address)
        {
            if (address.Trim().Length != 0)
            {
                this.address = address;
            }
        }


        public string getPhoneNumber()
        {
            return phoneNumber;
        }

        public void setPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Trim().Length != 0)
            {
                this.phoneNumber = phoneNumber;
            }
        }
    }
}


        

