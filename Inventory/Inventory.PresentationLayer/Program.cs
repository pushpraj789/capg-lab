using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.DataAccessLayers;
using Inventory.BusinessLayer;

namespace Inventory.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                PrintMenu();
                Console.WriteLine("Enter your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddSupplierBL();
                        break;
                    case 2:
                        ListAllSuppliersBL();
                        break;
                    case 3:
                        SearchGuestByID();
                        break;
                    case 4:
                        UpdateSupplierBL();
                        break;
                    case 5:
                        DeleteSupplierBL();
                        break;
                    case 6:

                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != -1);
        }

        private static void DeleteSupplierBL()
        {
            try
            {
                string deleteSupplierID;
                Console.WriteLine("Enter SupplierID to Delete:");
                deleteSupplierID = Console.ReadLine();
                Supplier deleteSupplier = SupplierBL.SearchSupplierBL(deleteSupplierID);
                if (deleteSupplier != null)
                {
                    bool supplierdeleted = SupplierBL.DeleteSupplierBL(deleteSupplierID);
                    if (supplierdeleted)
                        Console.WriteLine("Supplier Deleted");
                    else
                        Console.WriteLine("Supplier not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Supplier Details Available");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //delete address Sup
        private static void DeleteAddressSupBL()
        {
            try
            {
                string deleteAddressID;
                Console.WriteLine("Enter AddressID to Delete:");
                deleteAddressID = Console.ReadLine();
                AddressSup DeleteaddressSup = AddressSupBL.SearchAddressSupBL(deleteAddressID);
                if (DeleteaddressSup!=null)
                {
                    bool AddressSupdeleted = AddressSupBL.DeleteAddressSupBL(deleteAddressID);
                    if (AddressSupdeleted)
                        Console.WriteLine("Supplier address Deleted");
                    else
                        Console.WriteLine("Supplier address not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Supplier address Details Available");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void UpdateSupplierBL()
        {
            try
            {
                Supplier updateSupplier= null;
                Console.WriteLine("Enter SupplierID to Update Details:");
                updateSupplier.SupplierID= Console.ReadLine();
                Supplier updatedSupplier = SupplierBL.SearchSupplierBL(updateSupplier.SupplierID);
                if (updatedSupplier != null)
                {
                    Console.WriteLine("Update Supplier Name :");
                    updatedSupplier.SupplierName = Console.ReadLine();
                    Console.WriteLine("Update MobileNumber :");
                    updatedSupplier.SupplierMobile = Console.ReadLine();
                    bool supplierUpdated = SupplierBL.UpdateSupplierBL(updatedSupplier);
                    if (supplierUpdated)
                        Console.WriteLine("Guest Details Updated");
                    else
                        Console.WriteLine("Guest Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Guest Details Available");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //update address supplier
        private static void UpdateAddressSupBL()
        {
            bool AddressSupUpdated = false;
            try
            {
                AddressSup updateAddressSup = null;
                Console.WriteLine("Enter AddressID to Update Details:");
                updateAddressSup.AddressID = Console.ReadLine();
                AddressSup updatedAddressSup = AddressSupBL.SearchAddressSupBL(updateAddressSup.AddressID);
                if(updateAddressSup!=null)
                
                {
                        Console.WriteLine("Update Address Line1:");
                        updateAddressSup.AddressLine1= Console.ReadLine();
                        Console.WriteLine("Update Address Line2 :");
                        updateAddressSup.AddressLine2 = Console.ReadLine();
                        Console.WriteLine("Update City Name :");
                        updateAddressSup.City = Console.ReadLine();
                        Console.WriteLine("Update State Name :");
                        updateAddressSup.State = Console.ReadLine();
                        Console.WriteLine("Update PinCode:");
                        updateAddressSup.PinCode = Console.ReadLine();


                         AddressSupUpdated = AddressSupBL.UpdateAddressSupBL(updatedAddressSup);
                        if (AddressSupUpdated)
                            Console.WriteLine("Supplier Details Updated");
                        else
                            Console.WriteLine("Supplier Details not Updated ");
                }
                else
                {
                        Console.WriteLine("No Supplier Details Available");
                    
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); 
            }
        }

        private static void SearchGuestByID()
        {
            try
            {
                string searchSupplierID;
                Console.WriteLine("Enter SupplierID to Search:");
                searchSupplierID = Console.ReadLine();
                Supplier searchSupplier = SupplierBL.SearchSupplierBL(searchSupplierID);
                if (searchSupplier != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("SupplierID\t\tSupplierName\t\tAddressID\t\tMobile\t\tEmail");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", searchSupplier.SupplierID, searchSupplier.SupplierName, searchSupplier.AddressID, searchSupplier.SupplierMobile, searchSupplier.SupplierEmail);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Guest Details Available");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void ListAllSuppliersBL()
        {
            try
            {
                List<Supplier> supplierList = SupplierBL.GetAllSuppliersBL();
                if (supplierList != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("SupplierID\t\tSupplierName\t\tAddressID\t\tMobile\t\tSupplierEmail");
                    Console.WriteLine("******************************************************************************");
                    foreach (Supplier supplier in supplierList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", supplier.SupplierID,supplier.SupplierName, supplier.AddressID,supplier.SupplierMobile,supplier.SupplierEmail);
                    }
                    Console.WriteLine("******************************************************************************");

                }
                else
                {
                    Console.WriteLine("No Supplier Details Available");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddSupplierBL()
        {
            try
            {
                Supplier newSupplier = new Supplier();
                Console.WriteLine("Enter SupplierID :");
                newSupplier.SupplierID =Console.ReadLine();
                Console.WriteLine("Enter Supplier Name :");
                newSupplier.SupplierName = Console.ReadLine();
                Console.WriteLine("Enter AddressID :");
                newSupplier.AddressID = Console.ReadLine();
                Console.WriteLine("Enter supplier mobile:");
                newSupplier.SupplierMobile = Console.ReadLine();
                Console.WriteLine("Enter Supplier Email :");
                newSupplier.SupplierEmail = Console.ReadLine();
                bool supplierAdded = SupplierBL.AddSupplierBL(newSupplier);
                if (supplierAdded)
                    Console.WriteLine("Supplier Added");
                else
                    Console.WriteLine("Supplier not Added");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// for address sup
        /// </summary>
        private static void AddAddressSupDAL(AddressSup newAddress)
        {
            try
            {
                AddressSup newAddressSup = new AddressSup();
                Console.WriteLine("Enter AddressID :");
                newAddressSup.AddressID = Console.ReadLine();
                Console.WriteLine("Enter User Type :");
                newAddressSup.UserType = Console.ReadLine();
                Console.WriteLine("Enter AddressLine1:");
                newAddressSup.AddressLine1 = Console.ReadLine();
                Console.WriteLine("Enter AddressLine2 :");
                newAddressSup.AddressLine2 = Console.ReadLine();
                Console.WriteLine("Enter PIN :");
                newAddressSup.PinCode = Console.ReadLine();
                Console.WriteLine("Enter city:");
                newAddressSup.City = Console.ReadLine();
                Console.WriteLine("Enter State:");
                newAddressSup.State = Console.ReadLine();

                bool AddressSupAdded = AddressSupBL.AddAddressSupBL(newAddressSup);
                if (AddressSupAdded)
                    Console.WriteLine("Supplier Address Added");
                else
                    Console.WriteLine("Supplier Address not  Added");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\n***********Supplier Menu***********");
            Console.WriteLine("1. Add Supplier");
            Console.WriteLine("2. List All Supplier");
            Console.WriteLine("3. Search Supplier by ID");
            Console.WriteLine("4. Update Supplier");
            Console.WriteLine("5. Delete Supplier");
            Console.WriteLine("6. Exit");
            Console.WriteLine("******************************************\n");

        }
        

    }
}
