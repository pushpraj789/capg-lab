﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Capgemini.Inventory.Contracts.BLContracts;
using Capgemini.Inventory.Contracts.DALContracts;
using Capgemini.Inventory.DataAccessLayer;
using Capgemini.Inventory.Entities;
using Capgemini.Inventory.Exceptions;
using Capgemini.Inventory.Helpers.ValidationAttributes;

namespace Capgemini.Inventory.BusinessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting DistributorAddresss from DistributorAddresss collection.
    /// </summary>
    public class DistributorAddressBL : BLBase<DistributorAddress>, IDistributorAddressBL, IDisposable
    {
        //fields
        DistributorAddressDALBase DistributorAddressDAL;

        /// <summary>
        /// Constructor.
        /// </summary>
        public DistributorAddressBL()
        {
            this.DistributorAddressDAL = new DistributorAddressDAL();
        }

        /// <summary>
        /// Validations on data before adding or updating.
        /// </summary>
        /// <param name="entityObject">Represents object to be validated.</param>
        /// <returns>Returns a boolean value, that indicates whether the data is valid or not.</returns>
        protected async override Task<bool> Validate(DistributorAddress entityObject)
        {
            //Create string builder
            StringBuilder sb = new StringBuilder();
            bool valid = await base.Validate(entityObject);

            //Email is Unique
            var existingObject = await GetDistributorAddressByEmailBL(entityObject.Email);
            if (existingObject != null && existingObject?.AddressID != entityObject.AddressID)
            {
                valid = false;
                sb.Append(Environment.NewLine + $"Email {entityObject.Email} already exists");
            }

            if (valid == false)
                throw new InventoryException(sb.ToString());
            return valid;
        }

        /// <summary>
        /// Adds new DistributorAddress to DistributorAddresss collection.
        /// </summary>
        /// <param name="newDistributorAddress">Contains the DistributorAddress details to be added.</param>
        /// <returns>Determinates whether the new DistributorAddress is added.</returns>
        public async Task<bool> AddDistributorAddressBL(DistributorAddress newDistributorAddress)
        {
            bool DistributorAddressAdded = false;
            try
            {
                if (await Validate(newDistributorAddress))
                {
                    await Task.Run(() =>
                    {
                        this.DistributorAddressDAL.AddDistributorAddressDAL(newDistributorAddress);
                        DistributorAddressAdded = true;
                        Serialize();
                    });
                }
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
        public async Task<List<DistributorAddress>> GetAllDistributorAddresssBL()
        {
            List<DistributorAddress> DistributorAddresssList = null;
            try
            {
                await Task.Run(() =>
                {
                    DistributorAddresssList = DistributorAddressDAL.GetAllDistributorAddresssDAL();
                });
            }
            catch (Exception)
            {
                throw;
            }
            return DistributorAddresssList;
        }

        /// <summary>
        /// Gets DistributorAddress based on AddressID.
        /// </summary>
        /// <param name="searchAddressID">Represents AddressID to search.</param>
        /// <returns>Returns DistributorAddress object.</returns>
        public async Task<DistributorAddress> GetDistributorAddressByAddressIDBL(Guid searchAddressID)
        {
            DistributorAddress matchingDistributorAddress = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingDistributorAddress = DistributorAddressDAL.GetDistributorAddressByAddressIDDAL(searchAddressID);
                });
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
        public async Task<List<DistributorAddress>> GetDistributorAddresssByNameBL(string DistributorAddressName)
        {
            List<DistributorAddress> matchingDistributorAddresss = new List<DistributorAddress>();
            try
            {
                await Task.Run(() =>
                {
                    matchingDistributorAddresss = DistributorAddressDAL.GetDistributorAddresssByNameDAL(DistributorAddressName);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingDistributorAddresss;
        }

        /// <summary>
        /// Gets DistributorAddress based on Email and Password.
        /// </summary>
        /// <param name="email">Represents DistributorAddress's Email Address.</param>
        /// <returns>Returns DistributorAddress object.</returns>
        public async Task<DistributorAddress> GetDistributorAddressByEmailBL(string email)
        {
            DistributorAddress matchingDistributorAddress = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingDistributorAddress = DistributorAddressDAL.GetDistributorAddressByEmailDAL(email);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingDistributorAddress;
        }

        /// <summary>
        /// Gets DistributorAddress based on Password.
        /// </summary>
        /// <param name="email">Represents DistributorAddress's Email Address.</param>
        /// <param name="password">Represents DistributorAddress's Password.</param>
        /// <returns>Returns DistributorAddress object.</returns>
        public async Task<DistributorAddress> GetDistributorAddressByEmailAndPasswordBL(string email, string password)
        {
            DistributorAddress matchingDistributorAddress = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingDistributorAddress = DistributorAddressDAL.GetDistributorAddressByEmailAndPasswordDAL(email, password);
                });
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
        public async Task<bool> UpdateDistributorAddressBL(DistributorAddress updateDistributorAddress)
        {
            bool DistributorAddressUpdated = false;
            try
            {
                if ((await Validate(updateDistributorAddress)) && (await GetDistributorAddressByAddressIDBL(updateDistributorAddress.AddressID)) != null)
                {
                    this.DistributorAddressDAL.UpdateDistributorAddressDAL(updateDistributorAddress);
                    DistributorAddressUpdated = true;
                    Serialize();
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
        public async Task<bool> DeleteDistributorAddressBL(Guid deleteAddressID)
        {
            bool DistributorAddressDeleted = false;
            try
            {
                await Task.Run(() =>
                {
                    DistributorAddressDeleted = DistributorAddressDAL.DeleteDistributorAddressDAL(deleteAddressID);
                    Serialize();
                });
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
        public async Task<bool> UpdateDistributorAddressPasswordBL(DistributorAddress updateDistributorAddress)
        {
            bool passwordUpdated = false;
            try
            {
                if ((await Validate(updateDistributorAddress)) && (await GetDistributorAddressByAddressIDBL(updateDistributorAddress.AddressID)) != null)
                {
                    this.DistributorAddressDAL.UpdateDistributorAddressPasswordDAL(updateDistributorAddress);
                    passwordUpdated = true;
                    Serialize();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return passwordUpdated;
        }

        /// <summary>
        /// Disposes DAL object(s).
        /// </summary>
        public void Dispose()
        {
            ((DistributorAddressDAL)DistributorAddressDAL).Dispose();
        }

        /// <summary>
        /// Invokes Serialize method of DAL.
        /// </summary>
        public void Serialize()
        {
            try
            {
                DistributorAddressDAL.Serialize();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///Invokes Deserialize method of DAL.
        /// </summary>
        public void Deserialize()
        {
            try
            {
                DistributorAddressDAL.Deserialize();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}