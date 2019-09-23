using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.Entities;

namespace Capgemini.Inventory.Contracts.BLContracts
{
    public interface IDistributorAddressBL : IDisposable
    {
        Task<bool> AddDistributorAddressBL(DistributorAddress newDistributorAddress);
        Task<List<DistributorAddress>> GetAllDistributorAddresssBL();
        Task<DistributorAddress> GetDistributorAddressByAddressIDBL(Guid searchAddressID);
        Task<List<DistributorAddress>> GetDistributorAddresssByNameBL(string supplierName);
        Task<DistributorAddress> GetDistributorAddressByEmailBL(string email);
        Task<DistributorAddress> GetDistributorAddressByEmailAndPasswordBL(string email, string password);
        Task<bool> UpdateDistributorAddressBL(DistributorAddress updateDistributorAddress);
        Task<bool> UpdateDistributorAddressPasswordBL(DistributorAddress updateDistributorAddress);
        Task<bool> DeleteDistributorAddressBL(Guid deleteAddressID);
    }
}