using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    public class AddressSup
    {
        private int addressID;

        public int AddressID
        {
            get { return AddressID; }
            set { AddressID = value; }
        }
        private string userType;

        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }
        private string addressLine1;

        public string AddressLine1
        {
            get { return addressLine1; }
            set { addressLine1 = value; }
        }
        private string addressLine2;

        public string AddressLine2
        {
            get { return addressLine2; }
            set { addressLine2 = value; }
        }
        private int pinCode;

        public int PinCode
        {
            get { return pinCode; }
            set { pinCode = value; }
        }
        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }
       

       
        private int supplierID;

        public int SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }



        public AddressSup()
        {
            AddressID = 0;
            userType = string.Empty;
            AddressLine1 = string.Empty;
            AddressLine2 = string.Empty;
            PinCode = 0;
            City = string.Empty;
            State = string.Empty;
           
            SupplierID = 0;
        }
    }
}
