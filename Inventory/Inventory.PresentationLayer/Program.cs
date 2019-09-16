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
                        AddSupplier();
                        break;
                    case 2:
                        ListAllGuests();
                        break;
                    case 3:
                        SearchGuestByID();
                        break;
                    case 4:
                        UpdateGuest();
                        break;
                    case 5:
                        DeleteGuest();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != -1);
        }

        private static void DeleteGuest()
        {
            try
            {
                int deleteGuestID;
                Console.WriteLine("Enter GuestID to Delete:");
                deleteGuestID = Convert.ToInt32(Console.ReadLine());
                Guest deleteGuest = GuestBL.SearchGuestBL(deleteGuestID);
                if (deleteGuest != null)
                {
                    bool guestdeleted = GuestBL.DeleteGuestBL(deleteGuestID);
                    if (guestdeleted)
                        Console.WriteLine("Guest Deleted");
                    else
                        Console.WriteLine("Guest not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Guest Details Available");
                }


            }
            catch (GuestPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateSupplier()
        {
            try
            {
                int updateGuestID;
                Console.WriteLine("Enter SupplierID to Update Details:");
                updateSupplierID = Console.ReadLine();
                Supplier updatedGuest = SupplierBL.SearchSupplierBL(updateSupplierID);
                if (updatedSupplier != null)
                {
                    Console.WriteLine("Update Supplier Name :");
                    updatedSupplier.SupplierName = Console.ReadLine();
                    Console.WriteLine("Update MobileNumber :");
                    updatedSupplier.SupplierMobile = Console.ReadLine();
                    bool guestUpdated = GuestBL.UpdateGuestBL(updatedGuest);
                    if (guestUpdated)
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

        private static void SearchGuestByID()
        {
            try
            {
                int searchSupplierID;
                Console.WriteLine("Enter SupplierID to Search:");
                searchSupplierID = Console.ReadLine();
                Supplier searchSupplier = SupplierBL.SearchSupplierBL(searchSupplierID);
                if (searchSupplier != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("GuestID\t\tName\t\tAddressID\t\tPhoneNumber");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", searchSupplier.SupplierID, searchSupplier.SupplierName, searchSupplier.AddressID, searchSupplier.SupplierMobile, searchSupplier.SupplierEmail);
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


        private static void ListAllGuests()
        {
            try
            {
                List<Guest> guestList = GuestBL.GetAllGuestsBL();
                if (guestList != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("GuestID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("******************************************************************************");
                    foreach (Guest guest in guestList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", guest.GuestID, guest.GuestName, guest.GuestContactNumber);
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

        private static void AddSupplier()
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
                bool guestAdded = SupplierBL.AddGuestBL(newSupplier);
                if (guestAdded)
                    Console.WriteLine("Guest Added");
                else
                    Console.WriteLine("Guest not Added");
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
