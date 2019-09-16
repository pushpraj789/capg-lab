using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Exceptions;
using Inventory.Entities;

namespace Inventory.DataAccessLayers
{
    public class AddressDisDAL
    {
        //creting a list of type AddressSup
        public static List<AddressDis> addressDisList = new List<AddressDis>();

        //creating a method to add new Address to the list
        public bool AddAddressDisDAL(AddressDis newAddress)
        {
            bool addressDisAdded = false;
            try
            {
                addressDisList.Add(newAddress);
                addressDisAdded = true;
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return addressDisAdded;

        }


        //creating a method to update new Address to the list
        public bool UpdateAddressDisDAL(AddressDis updateAddressDis)
        {
            bool addressDisUpdated = false;
            try
            {
                for (int i = 0; i < addressDisList.Count; i++)
                {
                    if (addressDisList[i].AddressID == updateAddressDis.AddressID)
                    {
                        updateAddressDis.UserType = addressDisList[i].UserType;
                        updateAddressDis.AddressLine1 = addressDisList[i].AddressLine1;
                        updateAddressDis.AddressLine2 = addressDisList[i].AddressLine2;
                        updateAddressDis.PinCode = addressDisList[i].PinCode;
                        updateAddressDis.City = addressDisList[i].City;
                        updateAddressDis.State = addressDisList[i].State;

                        updateAddressDis.DistributorID = addressDisList[i].DistributorID;
                        addressDisUpdated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return addressDisUpdated;

        }

        //creating a method to delete address and update the list
        public bool DeleteAddressDisDAL(string deleteAddressID)
        {
            bool addressDisDeleted = false;
            try
            {
                AddressDis deleteAddressDis = null;
                foreach (AddressDis item in addressDisList)
                {
                    if (item.AddressID == deleteAddressID)
                    {
                        deleteAddressDis = item;
                    }
                }

                if (deleteAddressDis != null)
                {
                    addressDisList.Remove(deleteAddressDis);
                    addressDisDeleted = true;
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }
            return addressDisDeleted;

        }
    }
}
