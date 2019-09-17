using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    public class AddressSup
    {
        //fields
        private string addressID;
        private string userType;
        private string addressLine1;
        private string addressLine2;
        private string pinCode;
        private string city;
        private string state;
        private string supplierID;

        //properties
        public string AddressID { get => addressID; set => addressID = value; }
        public string UserType { get => userType; set => userType = value; }
        public string AddressLine1 { get => addressLine1; set => addressLine1 = value; }
        public string AddressLine2 { get => addressLine2; set => addressLine2 = value; }
        public string PinCode { get => pinCode; set => pinCode = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
      
        public string SupplierID { get => supplierID; set => supplierID = value; }


        //Constructor
        public AddressSup()
        {
            AddressID = string.Empty;
            UserType = string.Empty;
            AddressLine1 = string.Empty;
            AddressLine2 = string.Empty;
            PinCode = string.Empty;
            City = string.Empty;
            State = string.Empty;
            SupplierID = string.Empty;
        }

       
    }
}
