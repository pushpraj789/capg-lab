using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace TeamDclasses
{
    interface ISupplierService
    {
        public List<Supplier> suppliers = new List<Supplier>();
    }
    class Supplier : ISupplierService
    {
        //fields
        private string _supplierID;
        private string _supplierName;
        private string _addressId;
        private string _supplierMobile;
        private string _supplierEmail;

        //properties
        public string SupplierID
        //starts with S001, Four characters
        {
            set
            {
                Regex regex = new Regex("^[S]{1}[0-9]{3}$");
                bool b = regex.IsMatch(value);
                if (b == true)
                {
                    _supplierID = value;
                }
                else
                {
                    throw new Exception("Incorrect Supplier ID");
                }
            }
            get
                {
                  return _supplierID;
                }
        }
        public string SupplierName
        {
            //Should be less than 30 characters, only alphabet
            set
            {
                Regex regex = new Regex("^[A-Za-z ]{1,30}$");
                bool b = regex.IsMatch(value);
                if (b == true)
                {
                    _supplierName = value;
                }
                else
                {
                    throw new Exception("Incorrect format for Supplier name");
                }
            }
            get
            {
                return _supplierName;
            }
        }
        public string AddressID
        {
            //SUP001,Should be 6 characters.


            set
            {
                Regex regex = new Regex("^[A-Z]{1}[A-Z]{1}[A-Z]{1}[0-9]{3}$");
                bool b = regex.IsMatch(value);
                if (b == true)
                {
                    _addressId = value;
                }
                else
                {
                    throw new Exception("Incorrect format for address id");
                }
            }
            get
            {
                return _addressId;
            }
        }
        public string SupplierMobile
        {
            //numeric Should be of exact 10 digits, shouldn’t start with 0.


            set
            {
                Regex regex = new Regex("^[1-9][0-9]{9}$");
                bool b = regex.IsMatch(value);
                if (b == true)
                {
                    _supplierMobile = value;
                }
                else
                {
                    throw new Exception("Incorrect Mobile Number");
                }
            }
            get
            {
                return _supplierMobile;
            }
        }
        public string SupplierEmail
        {
            //should contain “@” and “.com”, should not contain space.
            set
            {
                Regex regex = new Regex(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$");
                bool b = regex.IsMatch(value);
                if (b == true)
                {
                    _supplierEmail = value;
                }
                else
                {
                    throw new Exception("Invalid email");
                }
            }
            get
            {
                return _supplierEmail;
            }
        }

        public List<Supplier> supplier { get => supplier; set => supplier = value; }

        public void  AddSupplierDetails()
        {
            Supplier supp = new Supplier();
           
            
            Console.WriteLine("enter your id");
            supp.SupplierID = Console.ReadLine();
            Console.WriteLine("enter your name ");
            supp.SupplierName = Console.ReadLine();
            Console.WriteLine("enter your address");
            supp.AddressID = Console.ReadLine();
            Console.WriteLine("enter your mobile number");
            supp.SupplierMobile = Console.ReadLine();
            Console.WriteLine("enter your email");
            supp.SupplierEmail = Console.ReadLine();

            supplier.Add(supp);


            for (int i = 0; i < supplier.Count; i++)
            {
                Console.WriteLine(supplier[i].SupplierID);
                Console.WriteLine(supplier[i].SupplierName);
                Console.WriteLine(supplier[i].AddressID);
                Console.WriteLine(supplier[i].SupplierMobile);
                Console.WriteLine(supplier[i].SupplierEmail);
                Console.WriteLine("----------------");
            }
        }
        
        
        
        //constructor
        public Supplier() { }
        public Supplier(string SI, string SN, string AI, string SM, string SE)
        {
            this.SupplierID = SI;
            this.SupplierName = SN;
            this.AddressID = AI;
            this.SupplierMobile = SM;
            this.SupplierEmail = SE;
        }
        





    }
    
    class Program
    {
        static void Main()
        {
            try
            {

                Supplier s = new Supplier();
                s.AddSupplierDetails();



            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.Message);


            }
            





           






            Console.ReadKey();
        }
    }
}
