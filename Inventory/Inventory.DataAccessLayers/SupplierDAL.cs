using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Exceptions;
using Inventory.Entities;


namespace Inventory.DataAccessLayers
{
    public class SupplierDAL
    {
        public static List<Supplier> supplierList = new List<Supplier>();
        public bool AddSupplierDAL(Supplier newSupplier)
        {
            bool supplierAdded = false;
            try
            {
                supplierList.Add(newSupplier);
                supplierAdded = true;
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return supplierAdded;
        }
        public List<Supplier> GetAllSuppliersDAL()
        {
            return supplierList;
        }
        public Supplier SearchSupplierDAL(int searchSupplierID)
        {
            Supplier searchSupplier = null;
            try
            {
                foreach (Supplier item in supplierList)
                {
                    if (item.SupplierID == searchSupplierID)
                    {
                        searchSupplier = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchSupplier;
        }
        public List<Supplier> GetSuppliersByNameDAL(string supplierName)
        {
            List<Supplier> searchSupplier = new List<Supplier>();
            try
            {
                foreach (Supplier item in supplierList)
                {
                    if (item.SupplierName == supplierName)
                    {
                        searchSupplier.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchSupplier;
        }
        public bool UpdateSupplierDAL(Supplier updateSupplier)
        {
            bool supplierUpdated = false;
            try
            {
                for (int i = 0; i < supplierList.Count; i++)
                {
                    if (supplierList[i].SupplierID == updateSupplier.SupplierID)
                    {
                        updateSupplier.SupplierName = supplierList[i].SupplierName;
                        updateSupplier.AddressID = supplierList[i].AddressID;
                        updateSupplier.SupplierMobile = supplierList[i].SupplierMobile;
                        updateSupplier.SupplierEmail = supplierList[i].SupplierEmail;
                        supplierUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return supplierUpdated;
        }
        public bool DeleteSupplierDAL(int deleteSupplierID)
        {
            bool supplierDeleted = false;
            try
            {
                Supplier deleteSupplier = null;
                foreach (Supplier item in supplierList)
                {
                    if (item.SupplierID == deleteSupplierID)
                    {
                        deleteSupplier = item;
                    }
                }
                if (deleteSupplier != null)
                {
                    supplierList.Remove(deleteSupplier);
                    supplierDeleted = true;
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return supplierDeleted;
        }
    }
}
