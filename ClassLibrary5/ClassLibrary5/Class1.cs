using System;
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
    /// Contains data access layer methods for inserting, updating, deleting SupplierAddresss from SupplierAddresss collection.
    /// </summary>
    public class SupplierAddressBL : BLBase<SupplierAddress>, ISupplierAddressBL, IDisposable
    {
        //fields
        SupplierAddressDALBase SupplierAddressDAL;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SupplierAddressBL()
        {
            this.SupplierAddressDAL = new SupplierAddressDAL();
        }

        /// <summary>
        /// Validations on data before adding or updating.
        /// </summary>
        /// <param name="entityObject">Represents object to be validated.</param>
        /// <returns>Returns a boolean value, that indicates whether the data is valid or not.</returns>
        protected async override Task<bool> Validate(SupplierAddress entityObject)
        {
            //Create string builder
            StringBuilder sb = new StringBuilder();
            bool valid = await base.Validate(entityObject);

            //Email is Unique
            var existingObject = await GetSupplierAddressByEmailBL(entityObject.Email);
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
        /// Adds new SupplierAddress to SupplierAddresss collection.
        /// </summary>
        /// <param name="newSupplierAddress">Contains the SupplierAddress details to be added.</param>
        /// <returns>Determinates whether the new SupplierAddress is added.</returns>
        public async Task<bool> AddSupplierAddressBL(SupplierAddress newSupplierAddress)
        {
            bool SupplierAddressAdded = false;
            try
            {
                if (await Validate(newSupplierAddress))
                {
                    await Task.Run(() =>
                    {
                        this.SupplierAddressDAL.AddSupplierAddressDAL(newSupplierAddress);
                        SupplierAddressAdded = true;
                        Serialize();
                    });
                }
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
        public async Task<List<SupplierAddress>> GetAllSupplierAddresssBL()
        {
            List<SupplierAddress> SupplierAddresssList = null;
            try
            {
                await Task.Run(() =>
                {
                    SupplierAddresssList = SupplierAddressDAL.GetAllSupplierAddresssDAL();
                });
            }
            catch (Exception)
            {
                throw;
            }
            return SupplierAddresssList;
        }

        /// <summary>
        /// Gets SupplierAddress based on AddressID.
        /// </summary>
        /// <param name="searchAddressID">Represents AddressID to search.</param>
        /// <returns>Returns SupplierAddress object.</returns>
        public async Task<SupplierAddress> GetSupplierAddressByAddressIDBL(Guid searchAddressID)
        {
            SupplierAddress matchingSupplierAddress = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingSupplierAddress = SupplierAddressDAL.GetSupplierAddressByAddressIDDAL(searchAddressID);
                });
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
        public async Task<List<SupplierAddress>> GetSupplierAddresssByNameBL(string SupplierAddressName)
        {
            List<SupplierAddress> matchingSupplierAddresss = new List<SupplierAddress>();
            try
            {
                await Task.Run(() =>
                {
                    matchingSupplierAddresss = SupplierAddressDAL.GetSupplierAddresssByNameDAL(SupplierAddressName);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSupplierAddresss;
        }

        /// <summary>
        /// Gets SupplierAddress based on Email and Password.
        /// </summary>
        /// <param name="email">Represents SupplierAddress's Email Address.</param>
        /// <returns>Returns SupplierAddress object.</returns>
        public async Task<SupplierAddress> GetSupplierAddressByEmailBL(string email)
        {
            SupplierAddress matchingSupplierAddress = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingSupplierAddress = SupplierAddressDAL.GetSupplierAddressByEmailDAL(email);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSupplierAddress;
        }

        /// <summary>
        /// Gets SupplierAddress based on Password.
        /// </summary>
        /// <param name="email">Represents SupplierAddress's Email Address.</param>
        /// <param name="password">Represents SupplierAddress's Password.</param>
        /// <returns>Returns SupplierAddress object.</returns>
        public async Task<SupplierAddress> GetSupplierAddressByEmailAndPasswordBL(string email, string password)
        {
            SupplierAddress matchingSupplierAddress = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingSupplierAddress = SupplierAddressDAL.GetSupplierAddressByEmailAndPasswordDAL(email, password);
                });
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
        public async Task<bool> UpdateSupplierAddressBL(SupplierAddress updateSupplierAddress)
        {
            bool SupplierAddressUpdated = false;
            try
            {
                if ((await Validate(updateSupplierAddress)) && (await GetSupplierAddressByAddressIDBL(updateSupplierAddress.AddressID)) != null)
                {
                    this.SupplierAddressDAL.UpdateSupplierAddressDAL(updateSupplierAddress);
                    SupplierAddressUpdated = true;
                    Serialize();
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
        public async Task<bool> DeleteSupplierAddressBL(Guid deleteAddressID)
        {
            bool SupplierAddressDeleted = false;
            try
            {
                await Task.Run(() =>
                {
                    SupplierAddressDeleted = SupplierAddressDAL.DeleteSupplierAddressDAL(deleteAddressID);
                    Serialize();
                });
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
        public async Task<bool> UpdateSupplierAddressPasswordBL(SupplierAddress updateSupplierAddress)
        {
            bool passwordUpdated = false;
            try
            {
                if ((await Validate(updateSupplierAddress)) && (await GetSupplierAddressByAddressIDBL(updateSupplierAddress.AddressID)) != null)
                {
                    this.SupplierAddressDAL.UpdateSupplierAddressPasswordDAL(updateSupplierAddress);
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
            ((SupplierAddressDAL)SupplierAddressDAL).Dispose();
        }

        /// <summary>
        /// Invokes Serialize method of DAL.
        /// </summary>
        public void Serialize()
        {
            try
            {
                SupplierAddressDAL.Serialize();
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
                SupplierAddressDAL.Deserialize();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
