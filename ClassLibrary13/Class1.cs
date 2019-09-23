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
    /// Contains data access layer methods for inserting, updating, deleting DistributorAddresss from DistributorAddresss collection.
    /// </summary>
    public class DistributorAddressDAL : DistributorAddressDALBase, IDisposable
    {
        /// <summary>
        /// Adds new DistributorAddress to DistributorAddresss collection.
        /// </summary>
        /// <param name="newDistributorAddress">Contains the DistributorAddress details to be added.</param>
        /// <returns>Determinates whether the new DistributorAddress is added.</returns>
        public override bool AddDistributorAddressDAL(DistributorAddress newDistributorAddress)
        {
            bool DistributorAddressAdded = false;
            try
            {
                newDistributorAddress.AddressID = Guid.NewGuid();
                newDistributorAddress.CreationDateTime = DateTime.Now;
                newDistributorAddress.LastModifiedDateTime = DateTime.Now;
                DistributorAddressList.Add(newDistributorAddress);
                DistributorAddressAdded = true;
            }
            catch (Exception)
            {
                throw;
            }
            return DistributorAddressAdded;
        }

        /// <summary>
        /// Gets all DistributorAddresss from the collection.
        /// </summary>
        /// <returns>Returns list of all DistributorAddresss.</returns>
        public override List<DistributorAddress> GetAllDistributorAddresssDAL()
        {
            return DistributorAddressList;
        }

        /// <summary>
        /// Gets DistributorAddress based on AddressID.
        /// </summary>
        /// <param name="searchAddressID">Represents AddressID to search.</param>
        /// <returns>Returns DistributorAddress object.</returns>
        public override DistributorAddress GetDistributorAddressByAddressIDDAL(Guid searchAddressID)
        {
            DistributorAddress matchingDistributorAddress = null;
            try
            {
                //Find DistributorAddress based on searchAddressID
                matchingDistributorAddress = DistributorAddressList.Find(
                    (item) => { return item.AddressID == searchAddressID; }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingDistributorAddress;
        }

        /// <summary>
        /// Gets DistributorAddress based on DistributorAddressName.
        /// </summary>
        /// <param name="DistributorAddressName">Represents DistributorAddressName to search.</param>
        /// <returns>Returns DistributorAddress object.</returns>
        public override List<DistributorAddress> GetDistributorAddresssByNameDAL(string DistributorAddressName)
        {
            List<DistributorAddress> matchingDistributorAddresss = new List<DistributorAddress>();
            try
            {
                //Find All DistributorAddresss based on DistributorAddressName
                matchingDistributorAddresss = DistributorAddressList.FindAll(
                    (item) => { return item.DistributorAddressName.Equals(DistributorAddressName, StringComparison.OrdinalIgnoreCase); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingDistributorAddresss;
        }

        /// <summary>
        /// Gets DistributorAddress based on email.
        /// </summary>
        /// <param name="email">Represents DistributorAddress's Email Address.</param>
        /// <returns>Returns DistributorAddress object.</returns>
        public override DistributorAddress GetDistributorAddressByEmailDAL(string email)
        {
            DistributorAddress matchingDistributorAddress = null;
            try
            {
                //Find DistributorAddress based on Email and Password
                matchingDistributorAddress = DistributorAddressList.Find(
                    (item) => { return item.Email.Equals(email); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingDistributorAddress;
        }

        /// <summary>
        /// Gets DistributorAddress based on Email and Password.
        /// </summary>
        /// <param name="email">Represents DistributorAddress's Email Address.</param>
        /// <param name="password">Represents DistributorAddress's Password.</param>
        /// <returns>Returns DistributorAddress object.</returns>
        public override DistributorAddress GetDistributorAddressByEmailAndPasswordDAL(string email, string password)
        {
            DistributorAddress matchingDistributorAddress = null;
            try
            {
                //Find DistributorAddress based on Email and Password
                matchingDistributorAddress = DistributorAddressList.Find(
                    (item) => { return item.Email.Equals(email) && item.Password.Equals(password); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingDistributorAddress;
        }

        /// <summary>
        /// Updates DistributorAddress based on AddressID.
        /// </summary>
        /// <param name="updateDistributorAddress">Represents DistributorAddress details including AddressID, DistributorAddressName etc.</param>
        /// <returns>Determinates whether the existing DistributorAddress is updated.</returns>
        public override bool UpdateDistributorAddressDAL(DistributorAddress updateDistributorAddress)
        {
            bool DistributorAddressUpdated = false;
            try
            {
                //Find DistributorAddress based on AddressID
                DistributorAddress matchingDistributorAddress = GetDistributorAddressByAddressIDDAL(updateDistributorAddress.AddressID);

                if (matchingDistributorAddress != null)
                {
                    //Update DistributorAddress details
                    ReflectionHelpers.CopyProperties(updateDistributorAddress, matchingDistributorAddress, new List<string>() { "DistributorAddressName", "Email" });
                    matchingDistributorAddress.LastModifiedDateTime = DateTime.Now;

                    DistributorAddressUpdated = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return DistributorAddressUpdated;
        }

        /// <summary>
        /// Deletes DistributorAddress based on AddressID.
        /// </summary>
        /// <param name="deleteAddressID">Represents AddressID to delete.</param>
        /// <returns>Determinates whether the existing DistributorAddress is updated.</returns>
        public override bool DeleteDistributorAddressDAL(Guid deleteAddressID)
        {
            bool DistributorAddressDeleted = false;
            try
            {
                //Find DistributorAddress based on searchAddressID
                DistributorAddress matchingDistributorAddress = DistributorAddressList.Find(
                    (item) => { return item.AddressID == deleteAddressID; }
                );

                if (matchingDistributorAddress != null)
                {
                    //Delete DistributorAddress from the collection
                    DistributorAddressList.Remove(matchingDistributorAddress);
                    DistributorAddressDeleted = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return DistributorAddressDeleted;
        }

        /// <summary>
        /// Updates DistributorAddress's password based on AddressID.
        /// </summary>
        /// <param name="updateDistributorAddress">Represents DistributorAddress details including AddressID, Password.</param>
        /// <returns>Determinates whether the existing DistributorAddress's password is updated.</returns>
        public override bool UpdateDistributorAddressPasswordDAL(DistributorAddress updateDistributorAddress)
        {
            bool passwordUpdated = false;
            try
            {
                //Find DistributorAddress based on AddressID
                DistributorAddress matchingDistributorAddress = GetDistributorAddressByAddressIDDAL(updateDistributorAddress.AddressID);

                if (matchingDistributorAddress != null)
                {
                    //Update DistributorAddress details
                    ReflectionHelpers.CopyProperties(updateDistributorAddress, matchingDistributorAddress, new List<string>() { "Password" });
                    matchingDistributorAddress.LastModifiedDateTime = DateTime.Now;

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