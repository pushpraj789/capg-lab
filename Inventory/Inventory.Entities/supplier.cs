using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    public class Supplier
    {

        private int supplierID;

        public int SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }
        private string supplierName;

        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }
        private int addressID;

        public int AddressID
        {
            get { return addressID; }
            set { addressID = value; }
        }
        private string supplierMobile;

        public string SupplierMobile
        {
            get { return supplierMobile; }
            set { supplierMobile = value; }
        }

        private string supplierEmail;

        public string SupplierEmail
        {
            get { return supplierEmail; }
            set { supplierEmail = value; }
        }

        public Supplier()
        {
            SupplierID = 0;
            SupplierName = string.Empty;
            AddressID = 0;
            SupplierMobile = string.Empty;
            SupplierEmail = string.Empty;
        }

    }
}
