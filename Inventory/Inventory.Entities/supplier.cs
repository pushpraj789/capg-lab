using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    public class Supplier
    {
        //fields
        private string supplierID;

       
        private string supplierName;

        
        private string addressID;

       
        private string supplierMobile;

       

        private string supplierEmail;

        //properties
        public string SupplierID { get => supplierID; set => supplierID = value; }
        public string SupplierName { get => supplierName; set => supplierName = value; }
        public string AddressID { get => addressID; set => addressID = value; }
        public string SupplierMobile { get => supplierMobile; set => supplierMobile = value; }
        public string SupplierEmail { get => supplierEmail; set => supplierEmail = value; }


        //constructor
        public Supplier()
        {
            SupplierID = string.Empty;
            SupplierName = string.Empty;
            AddressID = string.Empty;
            SupplierMobile = string.Empty;
            SupplierEmail = string.Empty;
        }

        
    }
}
