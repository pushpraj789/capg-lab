using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Exceptions;
using Inventory.Entities;


namespace Inventory.DataAccessLayers
{
    public class AddressSupDAL
    {
        public static List<AddressSup> addressSupList = new List<AddressSup>();

        public bool AddAddressSupDAL(AddressSup newAddress)
        {
            bool addressSupAdded = false;
            try
            {
                addressSupList.Add(newAddress);
                addressSupAdded = true;
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return addressSupAdded;

        }

       

        public bool UpdateAddressSupDAL(AddressSup updateAddressSup)
        {
            bool addressSupUpdated = false;
            try
            {
                for (int i = 0; i < addressSupList.Count; i++)
                {
                    if (addressSupList[i].AddressID == updateAddressSup.AddressID)
                    {
                        updateAddressSup.UserType = addressSupList[i].UserType;
                        updateAddressSup.AddressLine1 = addressSupList[i].AddressLine1;
                        updateAddressSup.AddressLine2 = addressSupList[i].AddressLine2;
                        updateAddressSup.PinCode = addressSupList[i].PinCode;
                        updateAddressSup.City = addressSupList[i].City;
                        updateAddressSup.State = addressSupList[i].State;

                        updateAddressSup.SupplierID = addressSupList[i].SupplierID;
                        addressSupUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return addressSupUpdated;

        }

        public bool DeleteAddressSupDAL(int deleteAddressID)
        {
            bool addressSupDeleted = false;
            try
            {
                AddressSup deleteAddressSup = null;
                foreach (AddressSup item in addressSupList)
                {
                    if (item.AddressID == deleteAddressID)
                    {
                        deleteAddressSup = item;
                    }
                }

                if (deleteAddressSup != null)
                {
                    addressSupList.Remove(deleteAddressSup);
                    addressSupDeleted = true;
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return addressSupDeleted;

        }
    }
}
