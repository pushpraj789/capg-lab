using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capgemini.Inventory.Contracts.DALContracts;
using Capgemini.Inventory.Entities;
using Capgemini.Inventory.Exceptions;
using Capgemini.Inventory.Helpers;

namespace Capgemini.Inventory.DataAccessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting SupplierAddresss from SupplierAddresss collection.
    /// </summary>
    public class SupplierAddressDAL : SupplierAddressDALBase, IDisposable
    {
        /// <summary>
        /// Adds new SupplierAddress to SupplierAddresss collection.
        /// </summary>
        /// <param name="newSupplierAddress">Contains the SupplierAddress details to be added.</param>
        /// <returns>Determinates whether the new SupplierAddress is added.</returns>
        public override bool AddSupplierAddressDAL(SupplierAddress newSupplierAddress)
        {
            bool SupplierAddressAdded = false;
            try
            {
                newSupplierAddress.AddressID = Guid.NewGuid();
                newSupplierAddress.CreationDateTime = DateTime.Now;
                newSupplierAddress.LastModifiedDateTime = DateTime.Now;
                SupplierAddressList.Add(newSupplierAddress);
                SupplierAddressAdded = true;
            }
            catch (Exception)
            {
                throw;
            }
            return SupplierAddressAdded;
        }

        /// <summary>
        /// Gets all SupplierAddresss from the collection.
        /// </summary>
        /// <returns>Returns list of all SupplierAddresss.</returns>
        public override List<SupplierAddress> GetAllSupplierAddresssDAL()
        {
            return SupplierAddressList;
        }

        /// <summary>
        /// Gets SupplierAddress based on AddressID.
        /// </summary>
        /// <param name="searchAddressID">Represents AddressID to search.</param>
        /// <returns>Returns SupplierAddress object.</returns>
        public override SupplierAddress GetSupplierAddressByAddressIDDAL(Guid searchAddressID)
        {
            SupplierAddress matchingSupplierAddress = null;
            try
            {
                //Find SupplierAddress based on searchAddressID
                matchingSupplierAddress = SupplierAddressList.Find(
                    (item) => { return item.AddressID == searchAddressID; }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSupplierAddress;
        }

        /// <summary>
        /// Gets SupplierAddress based on SupplierAddressName.
        /// </summary>
        /// <param name="SupplierAddressName">Represents SupplierAddressName to search.</param>
        /// <returns>Returns SupplierAddress object.</returns>
        public override List<SupplierAddress> GetSupplierAddresssByNameDAL(string SupplierAddressName)
        {
            List<SupplierAddress> matchingSupplierAddresss = new List<SupplierAddress>();
            try
            {
                //Find All SupplierAddresss based on SupplierAddressName
                matchingSupplierAddresss = SupplierAddressList.FindAll(
                    (item) => { return item.SupplierAddressName.Equals(SupplierAddressName, StringComparison.OrdinalIgnoreCase); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSupplierAddresss;
        }

        /// <summary>
        /// Gets SupplierAddress based on email.
        /// </summary>
        /// <param name="email">Represents SupplierAddress's Email Address.</param>
        /// <returns>Returns SupplierAddress object.</returns>
        public override SupplierAddress GetSupplierAddressByEmailDAL(string email)
        {
            SupplierAddress matchingSupplierAddress = null;
            try
            {
                //Find SupplierAddress based on Email and Password
                matchingSupplierAddress = SupplierAddressList.Find(
                    (item) => { return item.Email.Equals(email); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSupplierAddress;
        }

        /// <summary>
        /// Gets SupplierAddress based on Email and Password.
        /// </summary>
        /// <param name="email">Represents SupplierAddress's Email Address.</param>
        /// <param name="password">Represents SupplierAddress's Password.</param>
        /// <returns>Returns SupplierAddress object.</returns>
        public override SupplierAddress GetSupplierAddressByEmailAndPasswordDAL(string email, string password)
        {
            SupplierAddress matchingSupplierAddress = null;
            try
            {
                //Find SupplierAddress based on Email and Password
                matchingSupplierAddress = SupplierAddressList.Find(
                    (item) => { return item.Email.Equals(email) && item.Password.Equals(password); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSupplierAddress;
        }

        /// <summary>
        /// Updates SupplierAddress based on AddressID.
        /// </summary>
        /// <param name="updateSupplierAddress">Represents SupplierAddress details including AddressID, SupplierAddressName etc.</param>
        /// <returns>Determinates whether the existing SupplierAddress is updated.</returns>
        public override bool UpdateSupplierAddressDAL(SupplierAddress updateSupplierAddress)
        {
            bool SupplierAddressUpdated = false;
            try
            {
                //Find SupplierAddress based on AddressID
                SupplierAddress matchingSupplierAddress = GetSupplierAddressByAddressIDDAL(updateSupplierAddress.AddressID);

                if (matchingSupplierAddress != null)
                {
                    //Update SupplierAddress details
                    ReflectionHelpers.CopyProperties(updateSupplierAddress, matchingSupplierAddress, new List<string>() { "SupplierAddressName", "Email" });
                    matchingSupplierAddress.LastModifiedDateTime = DateTime.Now;

                    SupplierAddressUpdated = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return SupplierAddressUpdated;
        }

        /// <summary>
        /// Deletes SupplierAddress based on AddressID.
        /// </summary>
        /// <param name="deleteAddressID">Represents AddressID to delete.</param>
        /// <returns>Determinates whether the existing SupplierAddress is updated.</returns>
        public override bool DeleteSupplierAddressDAL(Guid deleteAddressID)
        {
            bool SupplierAddressDeleted = false;
            try
            {
                //Find SupplierAddress based on searchAddressID
                SupplierAddress matchingSupplierAddress = SupplierAddressList.Find(
                    (item) => { return item.AddressID == deleteAddressID; }
                );

                if (matchingSupplierAddress != null)
                {
                    //Delete SupplierAddress from the collection
                    SupplierAddressList.Remove(matchingSupplierAddress);
                    SupplierAddressDeleted = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return SupplierAddressDeleted;
        }

        /// <summary>
        /// Updates SupplierAddress's password based on AddressID.
        /// </summary>
        /// <param name="updateSupplierAddress">Represents SupplierAddress details including AddressID, Password.</param>
        /// <returns>Determinates whether the existing SupplierAddress's password is updated.</returns>
        public override bool UpdateSupplierAddressPasswordDAL(SupplierAddress updateSupplierAddress)
        {
            bool passwordUpdated = false;
            try
            {
                //Find SupplierAddress based on AddressID
                SupplierAddress matchingSupplierAddress = GetSupplierAddressByAddressIDDAL(updateSupplierAddress.AddressID);

                if (matchingSupplierAddress != null)
                {
                    //Update SupplierAddress details
                    ReflectionHelpers.CopyProperties(updateSupplierAddress, matchingSupplierAddress, new List<string>() { "Password" });
                    matchingSupplierAddress.LastModifiedDateTime = DateTime.Now;

                    passwordUpdated = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return passwordUpdated;
        }

        /// <summary>
        /// Clears unmanaged resources such as db connections or file streams.
        /// </summary>
        public void Dispose()
        {
            //No unmanaged resources currently
        }
    }
}