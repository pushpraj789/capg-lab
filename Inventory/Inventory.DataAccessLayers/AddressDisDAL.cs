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
        public static List<AddressDis> addressDisList = new List<AddressDis>();

        public bool AddAddressDisDAL(AddressDis newAddress)
        {
            bool addressDisAdded = false;
            try
            {
                addressDisList.Add(newAddress);
                addressDisAdded = true;
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return addressDisAdded;

        }



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
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return addressDisUpdated;

        }

        public bool DeleteAddressDisDAL(int deleteAddressID)
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
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return addressDisDeleted;

        }
    }
}
