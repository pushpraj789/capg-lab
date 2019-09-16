using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Exceptions;
using Inventory.Entities;
using Inventory.DataAccessLayers;
using System.Text.RegularExpressions;

namespace Inventory.BusinessLayer
{
    class SupplierBL
    {
        //creating a method to validate the supplier
        private static bool ValidateSupplier(Supplier supplier)
        {
            StringBuilder sb = new StringBuilder();
            bool validSupplier = true;
            Regex regex1 = new Regex("^[S]{1}[0-9]{3}$");//Four characters,starts with S001
            if (!regex1.IsMatch(supplier.SupplierID) || supplier.SupplierID == String.Empty)
            {
                validSupplier = false;
                sb.Append(Environment.NewLine + "Invalid Supplier ID");

            }
            Regex regex2 = new Regex("^[a-zA-Z ]$");//Only alphabet,Should be less than 30 characters.
            if (!regex2.IsMatch(supplier.SupplierName) || supplier.SupplierName == String.Empty||supplier.SupplierName.Length>30)
            {
                validSupplier = false;
                sb.Append(Environment.NewLine + "Supplier Name Required");

            }
            Regex regex3 = new Regex("^[S]{1}[U]{1}[P]{1}[0-9]{3}]$");// Should be 6 characters,starts with SUP001
            if (!regex3.IsMatch(supplier.AddressID)||supplier.AddressID == string.Empty)
            {
                validSupplier = false;
                sb.Append(Environment.NewLine + "Invalid Address ID");

            }
            Regex regex4 = new Regex("^[1-9]{1}[0-9]{9}]$");//numeric
            //Should be of exact 10 digits, shouldn’t start with 0.

            if (!regex4.IsMatch(supplier.SupplierMobile) || supplier.SupplierMobile.Length ==10)
            {
                validSupplier = false;
                sb.Append(Environment.NewLine + "Required 10 Digit Contact Number");
            }
            Regex regex5 = new Regex("^[]$");//should be valid and contains @ and .com
            if ((!regex5.IsMatch(supplier.SupplierEmail)||(supplier.SupplierEmail.Contains ("@")) && (supplier.SupplierEmail.Contains(".com"))))
            {
                validSupplier = false;
                sb.Append(Environment.NewLine + "valid mailID required");
            }
            if (validSupplier == false)
                throw new InventoryException(sb.ToString());
            return validSupplier;
        }

        //creating a method to add validted supplier
        public  bool AddSupplierBL(Supplier newSupplier)
        {
            bool supplierAdded = false;
            try
            {
                if (ValidateSupplier(newSupplier))
                {
                    SupplierDAL supplierDAL = new SupplierDAL();
                    supplierAdded = supplierDAL.AddSupplierDAL(newSupplier);
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return supplierAdded;

        }

        // get list of All valid suppliers
        public static List<Supplier> GetAllSuppliersBL()
        {
            List<Supplier> supplierList = null;
            try
            {
                SupplierDAL supplierDAL = new SupplierDAL();
                supplierList = supplierDAL.GetAllSuppliersDAL();
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }

            return supplierList;
        }

        //creating a method to search for all valid suppliers by their respective ID
        public static Supplier SearchSupplierBL(string searchSupplierID)
        {
            Supplier searchSupplier = null;
            try
            {
                SupplierDAL supplierDAL = new SupplierDAL();
                searchSupplier = supplierDAL.SearchSupplierDAL(searchSupplierID);
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }

            return searchSupplier;

        }

        //creating a method to update supplier list
        public static bool UpdateSupplierBL(Supplier updateSupplier)
        {
            bool supplierUpdated = false;
            try
            {
                if (ValidateSupplier(updateSupplier))
                {
                    SupplierDAL supplierDAL = new SupplierDAL();
                    supplierUpdated = supplierDAL.UpdateSupplierDAL(updateSupplier);
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }

            return supplierUpdated;
        }

        //creating a method to delete the existing valid suppliers
        public static bool DeleteSupplierBL(string deleteSupplierID)
        {
            bool supplierDeleted = false;
            try
            {
                if (deleteSupplierID == string.Empty)
                {
                    SupplierDAL supplierDAL = new SupplierDAL();
                    supplierDeleted = supplierDAL.DeleteSupplierDAL(deleteSupplierID);
                }
                else
                {
                    throw new InventoryException("Invalid Supplier ID");
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }


            return supplierDeleted;
        }
    }
}
