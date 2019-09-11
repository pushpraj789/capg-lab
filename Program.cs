using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q4_L1
{
    class Program
    {

        static void Main()
        {
        }

        private class Bird
        {
            public string Name;
            public double Maxheight;
            public Bird() //Default Constructor
            {
                this.Name = "Mountain Eagle";
                this.Maxheight = 500;
                //
                // TODO: Add constructor logic here
                //
            }
            public Bird(string birdname, double max_ht) //Overloaded Constructor
            {
                this.Name = "Another Bird";
                this.Maxheight = 0;
            }
            public void fly()
            {
                Console.WriteLine(this.Name + "is flying at altitude" + this.Maxheight);
            }
            public void fly(string AtHeight)
            {
                if (AtHeight.Length <= this.Maxheight)
                {
                    Console.WriteLine(this.Name + " flying at " + AtHeight.ToString());
                }
                else
                {
                    Console.WriteLine(this.Name + "cannot fly at" + AtHeight.ToString());
                }
            }
        }
    }
} 
  

