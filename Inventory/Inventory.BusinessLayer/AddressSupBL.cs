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
    class AddressSupBL
    {
        private static bool ValidateAddressSup(AddressSup addressSup)
        {
            StringBuilder sb = new StringBuilder();
            bool validAddressSup = true;
            if (addressSup.AddressID <= 0)
            {
                validAddressSup = false;
                sb.Append(Environment.NewLine + "Invalid Address ID");

            }
            if (addressSup.AddressLine1 == string.Empty)
            {
                validAddressSup = false;
                sb.Append(Environment.NewLine + "Address Line 1 Required");

            }
            if (addressSup.AddressLine2 == string.Empty)
            {
                validAddressSup = false;
                sb.Append(Environment.NewLine + "Address line 2 Required");

            }
            if (addressSup.PinCode == 0)
            {
                validAddressSup = false;
                sb.Append(Environment.NewLine + "Pin Code Required");

            }
            if (addressSup.City == string.Empty)
            {
                validAddressSup = false;
                sb.Append(Environment.NewLine + "City Name required");
            }
            if (addressSup.State == string.Empty)
            {
                validAddressSup = false;
                sb.Append(Environment.NewLine + "State Name Required");

            }
            if (addressSup.SupplierID == 0)
            {
                validAddressSup = false;
                sb.Append(Environment.NewLine + "Supplier Required");

            }

            if (validAddressSup == false)
                throw new InventoryException(sb.ToString());
            return validAddressSup;
        }

        public static bool AddAddressSupBL(AddressSup newAddressSup)
        {
            bool addressSupAdded = false;
            try
            {
                if (ValidateAddressSup(newAddressSup))
                {
                    AddressSupDAL addressSupDAL = new AddressSupDAL();
                    addressSupAdded = addressSupDAL.AddAddressSupDAL(newAddressSup);
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

            return addressSupAdded;
        }

        

        public static bool UpdateAddressSupBL(AddressSup updateAddressSup)
        {
            bool addressSupUpdated = false;
            try
            {
                if (ValidateAddressSup(updateAddressSup))
                {
                    AddressSupDAL addressSupDAL = new AddressSupDAL();
                    addressSupUpdated = addressSupDAL.UpdateAddressSupDAL(updateAddressSup);
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

            return addressSupUpdated;
        }

        public static bool DeleteAddressSupBL(int deleteAddressID)
        {
            bool addressSupDeleted = false;
            try
            {
                if (deleteAddressID > 0)
                {
                    AddressSupDAL addressSupDAL = new AddressSupDAL();
                    addressSupDeleted = addressSupDAL.DeleteAddressSupDAL(deleteAddressID);
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

            return addressSupDeleted;
        }
    }
}
