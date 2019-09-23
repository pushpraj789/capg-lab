using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.Entities;

namespace Capgemini.Inventory.Contracts.BLContracts
{
    public interface ISupplierAddressBL : IDisposable
    {
        Task<bool> AddSupplierAddressBL(SupplierAddress newSupplierAddress);
        Task<List<SupplierAddress>> GetAllSupplierAddresssBL();
        Task<SupplierAddress> GetSupplierAddressByAddressIDBL(Guid searchAddressID);
        Task<List<SupplierAddress>> GetSupplierAddresssByNameBL(string supplierName);
        Task<SupplierAddress> GetSupplierAddressByEmailBL(string email);
        Task<SupplierAddress> GetSupplierAddressByEmailAndPasswordBL(string email, string password);
        Task<bool> UpdateSupplierAddressBL(SupplierAddress updateSupplierAddress);
        Task<bool> UpdateSupplierAddressPasswordBL(SupplierAddress updateSupplierAddress);
        Task<bool> DeleteSupplierAddressBL(Guid deleteAddressID);
    }
}
