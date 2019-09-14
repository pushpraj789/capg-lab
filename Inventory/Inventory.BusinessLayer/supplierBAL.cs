using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Exceptions;
using Inventory.Entities;
using Inventory.DataAccessLayers;


namespace Inventory.BusinessLayer
{
    class SupplierBL
    {
        private static bool ValidateSupplier(Supplier supplier)
        {
            StringBuilder sb = new StringBuilder();
            bool validSupplier = true;
            if (supplier.SupplierID <= 0)
            {
                validSupplier = false;
                sb.Append(Environment.NewLine + "Invalid Supplier ID");

            }
            if (supplier.SupplierName == string.Empty)
            {
                validSupplier = false;
                sb.Append(Environment.NewLine + "Supplier Name Required");

            }
            if (supplier.AddressID <= 0)
            {
                validSupplier = false;
                sb.Append(Environment.NewLine + "Invalid Address ID");

            }
            if (supplier.SupplierMobile.Length < 10)
            {
                validSupplier = false;
                sb.Append(Environment.NewLine + "Required 10 Digit Contact Number");
            }
            //if (supplier.SupplierEmail.Length < 10)
            //{
            //    validSupplier = false;
            //    sb.Append(Environment.NewLine + "Required 10 Digit Contact Number");
            //}
            if (validSupplier == false)
                throw new InventoryException(sb.ToString());
            return validSupplier;
        }

        public static bool AddSupplierBL(Supplier newSupplier)
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
            catch (InventoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return supplierAdded;
        }

        public static List<Supplier> GetAllSuppliersBL()
        {
            List<Supplier> supplierList = null;
            try
            {
                SupplierDAL supplierDAL = new SupplierDAL();
                supplierList = supplierDAL.GetAllSuppliersDAL();
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return supplierList;
        }

        public static Supplier SearchSupplierBL(int searchSupplierID)
        {
            Supplier searchSupplier = null;
            try
            {
                SupplierDAL supplierDAL = new SupplierDAL();
                searchSupplier = supplierDAL.SearchSupplierDAL(searchSupplierID);
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchSupplier;

        }

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
            catch (InventoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return supplierUpdated;
        }

        public static bool DeleteSupplierBL(int deleteSupplierID)
        {
            bool supplierDeleted = false;
            try
            {
                if (deleteSupplierID > 0)
                {
                    SupplierDAL supplierDAL = new SupplierDAL();
                    supplierDeleted = supplierDAL.DeleteSupplierDAL(deleteSupplierID);
                }
                else
                {
                    throw new InventoryException("Invalid Supplier ID");
                }
            }
            catch (InventoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return supplierDeleted;
        }
    }
}
