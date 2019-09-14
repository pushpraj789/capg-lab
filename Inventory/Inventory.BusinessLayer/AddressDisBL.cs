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
    class AddressDisBL
    {
        private static bool ValidateAddressDis(AddressDis addressDis)
        {
            StringBuilder sb = new StringBuilder();
            bool validAddressDis = true;
            if (addressDis.AddressID <= 0)
            {
                validAddressDis = false;
                sb.Append(Environment.NewLine + "Invalid Address ID");

            }
            if (addressDis.AddressLine1 == string.Empty)
            {
                validAddressDis = false;
                sb.Append(Environment.NewLine + "Address Line 1 Required");

            }
            if (addressDis.AddressLine2 == string.Empty)
            {
                validAddressDis= false;
                sb.Append(Environment.NewLine + "Address line 2 Required");

            }
            if (addressDis.PinCode == 0)
            {
                validAddressDis = false;
                sb.Append(Environment.NewLine + "Pin Code Required");

            }
            if (addressDis.City == string.Empty)
            {
                validAddressDis = false;
                sb.Append(Environment.NewLine + "City Name required");
            }
            if (addressDis.State == string.Empty)
            {
                validAddressDis = false;
                sb.Append(Environment.NewLine + "State Name Required");

            }
            if (addressDis.DistributorID == 0)
            {
                validAddressDis= false;
                sb.Append(Environment.NewLine + "Distributor Required");

            }

            if (validAddressDis == false)
                throw new InventoryException(sb.ToString());
            return validAddressDis;
        }

        public static bool AddAddressDisBL(AddressDis newAddressDis)
        {
            bool addressDisAdded = false;
            try
            {
                if (ValidateAddressDis(newAddressDis))
                {
                    AddressDisDAL addressDisDAL = new AddressDisDAL();
                    addressDisAdded = addressDisDAL.AddAddressDisDAL(newAddressDis);
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

            return addressDisAdded;
        }



        public static bool UpdateAddressDisBL(AddressDis updateAddressDis)
        {
            bool addressDisUpdated = false;
            try
            {
                if (ValidateAddressDis(updateAddressDis))
                {
                    AddressDisDAL addressDisDAL = new AddressDisDAL();
                    addressDisUpdated = addressDisDAL.UpdateAddressDisDAL(updateAddressDis);
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

            return addressDisUpdated;
        }

        public static bool DeleteAddressDisBL(int deleteAddressID)
        {
            bool addressDisDeleted = false;
            try
            {
                if (deleteAddressID > 0)
                {
                    AddressDisDAL addressDisDAL = new AddressDisDAL();
                    addressDisDeleted = addressDisDAL.DeleteAddressDisDAL(deleteAddressID);
                }
                else
                {
                    throw new InventoryException("Invalid Address ID");
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

            return addressDisDeleted;
        }
    }
}
