using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Exceptions;
using Inventory.Entities;

//creating DAL namespace
namespace Inventory.DataAccessLayers
{
    public class SupplierDAL
    {
        //creting a list of type supplier
        public static List<Supplier> supplierList = new List<Supplier>();
        //creating method to add new supplier to the list
        public bool AddSupplierDAL(Supplier newSupplier)
        {
            bool supplierAdded = false;
            try
            {
                supplierList.Add(newSupplier);
                supplierAdded = true;
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return supplierAdded;
        }
        //creating method to get All suppliers
        public List<Supplier> GetAllSuppliersDAL()
        {
            return supplierList;
        }
        //creating method to search supplier by their respective ID
        public Supplier SearchSupplierDAL(string searchSupplierID)
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
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchSupplier;
        }
        //creating method to search supplier by their respective names
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
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchSupplier;
        }
        //creating method to update supplier list
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
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return supplierUpdated;
        }

        //creating method to delete supplier in supplier list
        public bool DeleteSupplierDAL(string deleteSupplierID)
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
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return supplierDeleted;
        }
    }
}
