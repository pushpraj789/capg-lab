using System;
using System.Collections.Generic;
using System.Linq;
using Capgemini.Inventory.Helpers.ValidationAttributes;

namespace Capgemini.Inventory.Entities
{
    /// <summary>
    /// Interface for SystemUser Entity
    /// </summary>
    public interface IDistributorAddress
    {
        Guid AddressID { get; set; }
        string UserType { get; set; }
        Guid DistributorID { get; set; }
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string PinCode { get; set; }
        string City { get; set; }
        string State { get; set; }
    }
}

/// <summary>
/// Represents SystemUser
/// </summary>
public class DistributorAddress : IDistributorAddress, IUser
{
    /* Auto-Implemented Properties */
    [Required("Address ID can't be blank.")]
    [RegExp(@"^(\w{2,40})$", "SystemUser Name should contain only 2 to 40 characters.")]
    public Guid AddressID { get; set; }

    [Required("User Type should be supplier or  distributor")]
    public string UserType { get; set; }

    [Required("AddressLine1 should be supplier or  distributor")]
    public string AddressLine1 { get; set; }

    [Required("AddressLine2 should not be blank")]
    public string AddressLine2 { get; set; }

    [Required("PinCode should not be blank")]
    public string PinCode { get; set; }

    [Required("City should not be blank")]
    public string City { get; set; }

    [Required("State should not be blank")]
    public string State { get; set; }

    [Required("Address ID can't be blank.")]
    [RegExp(@"^(\w{2,40})$", "SystemUser Name should contain only 2 to 40 characters.")]
    public Guid DistributorID { get; set; }


    public DistributorAddress()
    {
        AddressID = default(Guid);
        UserType = string.Empty;
        AddressLine1 = string.Empty;
        AddressLine2 = string.Empty;
        PinCode = string.Empty;
        City = string.Empty;
        State = string.Empty;
        DistributorID = default(Guid);
    }


