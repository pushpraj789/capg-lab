using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.PresentationLayer
{
    class SupplierPL
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
                        AddSupplier();
                        break;
                    case 2:
                        ListAllSuppliers();
                        break;
                    case 3:
                        SearchSupplierByID();
                        break;
                    case 4:
                        UpdateSupplier();
                        break;
                    case 5:
                        DeleteSupplier();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != -1);
        }

        private static void DeleteSupplier()
        {
            try
            {
                int deleteSupplierID;
                Console.WriteLine("Enter SupplierID to Delete:");
                deleteSupplierID = Convert.ToInt32(Console.ReadLine());
                Supplier deleteSupplier = SupplierBL.SearchSupplierBL(deleteSupplierID);
                if (deleteGuest != null)
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
            catch (InventoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateSupplier()
        {
            try
            {
                int updateSupplierID;
                Console.WriteLine("Enter SupplierID to Update Details:");
                updateSupplierID = Convert.ToInt32(Console.ReadLine());
                Supplier updatedSupplier = SupplierBL.SearchSupplierBL(updateSupplierID);
                if (updatedSupplier != null)
                {
                    Console.WriteLine("Update Supplier Name :");
                    updatedSupplier.SupplierName = Console.ReadLine();
                    Console.WriteLine("Update MobileNumber :");
                    updatedSupplier.SupplierMobile = Console.ReadLine();
                    bool supplierUpdated = SupplierBL.UpdateGuestBL(updatedSupplier);
                    if (supplierUpdated)
                        Console.WriteLine("Supplier Details Updated");
                    else
                        Console.WriteLine("Supplier Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Supplier Details Available");
                }


            }
            catch (Inventory ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SearchSupplierByID()
        {
            try
            {
                int searchSupplierID;
                Console.WriteLine("Enter SupplierID to Search:");
                searchSupplierID = Convert.ToInt32(Console.ReadLine());
                Supplier searchSupplier = SupplierBL.SearchSupplierBL(searchSupplierID);
                if (searchSupplier != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("SupplierID\t\tName\t\tAddressID\t\tMobileNumber\t\tEmail");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", searchSupplier.SupplierID, searchSupplier.SupplierName, searchSupplier.AddressID, searchSupplier.SupplierMobile, searchSupplier.SupplierEmail);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Supplier Details Available");
                }

            }
            catch (InventoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void ListAllSuppliers()
        {
            try
            {
                List<Supplier> supplierList = SupplierBL.GetAllSuppliersBL();
                if (supplierList != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("SupplierID\t\tName\t\tAddressID\t\tMobileNumber\t\tEmail");
                    Console.WriteLine("******************************************************************************");
                    foreach (Supplier supplier in supplierList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", supplier.SupplierID, supplier.SupplierName, supplier.AddressID, supplier.SupplierMobile, supplier.SupplierEmail);
                    }
                    Console.WriteLine("******************************************************************************");

                }
                else
                {
                    Console.WriteLine("No Supplier Details Available");
                }
            }
            catch (Inventory ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddSupplier()
        {
            try
            {
                Supplier newSupplier = new Supplier();
                Console.WriteLine("Enter SupplierID :");
                newSupplier.SupplierID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Guest Name :");
                newSupplier.SupplierName = Console.ReadLine();
                Console.WriteLine("Enter Address ID :");
                newSupplier.AddressID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Supplier Mobile number:");
                newSupplier.SupplierMobile = Console.ReadLine();
                Console.WriteLine("Enter Supplier Email:");
                newSupplier.SupplierEmail = Console.ReadLine();

                bool supplierAdded = SupplierBL.Add SupplierBL(newSupplier);
                if ( supplierAdded)
                    Console.WriteLine(" Supplier Added");
                else
                    Console.WriteLine(" Supplier not Added");
            }
            catch (InventoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\n***********Supplier Details***********");
            Console.WriteLine("1. Add  Supplier");
            Console.WriteLine("2. List All  Suppliers");
            Console.WriteLine("3. Search Supplier by ID");
            Console.WriteLine("4. Update  Supplier");
            Console.WriteLine("5. Delete  Supplier");
            Console.WriteLine("6. Exit");
            Console.WriteLine("******************************************\n");

        }
    }
}
