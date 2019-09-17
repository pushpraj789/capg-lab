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
    
    public class AddressSupBL
    {
        // validating supplier address
        private static bool ValidateAddressSup(AddressSup addressSup)
        {
            StringBuilder sb = new StringBuilder();
            bool validAddressSup = true;
            if (addressSup.AddressID == string.Empty)
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


            Regex regex1= new Regex("^[0-9]{6}$");//six characters
            if (!regex1.IsMatch(addressSup.PinCode) || addressSup.PinCode == string.Empty)
            
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
            if (addressSup.SupplierID == string.Empty)
            {
                validAddressSup = false;
                sb.Append(Environment.NewLine + "Supplier Required");

            }

            if (validAddressSup == false)
                throw new InventoryException(sb.ToString());
            return validAddressSup;
        }
        //Validating the address
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
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
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
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }



            return addressSupUpdated;
        }

        public static bool DeleteAddressSupBL(string deleteAddressID)
        {
            bool addressSupDeleted = false;
            try
            {
                if (deleteAddressID != string.Empty)
                {
                    AddressSupDAL addressSupDAL = new AddressSupDAL();
                    addressSupDeleted = addressSupDAL.DeleteAddressSupDAL(deleteAddressID);
                }
                else
                {
                    throw new InventoryException("Invalid Address ID");
                }
            }
            catch (Exception ex)
            {
                throw new InventoryException(ex.Message);
            }



            return addressSupDeleted;
        }





        public static AddressSup SearchAddressSupBL(String AddressID)
        {
            AddressSup searchAddressSup = null;
            try
            {
                AddressSupDAL addressSupDAL = new AddressSupDAL();
                searchAddressSup = addressSupDAL.SearchAddressSupDAL(AddressID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
            return searchAddressSup;

        }
    }
}
