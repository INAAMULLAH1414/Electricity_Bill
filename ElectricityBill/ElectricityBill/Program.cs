using System;
using System.IO;


namespace ElectricityBill
{
    class Program
    {
        public static Double surcharge(double currbill)
        {
            Double bill=0;
            if (currbill > 400)
            {
                bill = currbill * 0.15;
            }
            Console.WriteLine("Surcharge Amount : "+bill);
            return bill ;
        }
        public static void createFile()
        {
            Console.WriteLine("Enter file name : ");
            string fileN = Console.ReadLine();
            Console.WriteLine("Enter path in proper format " );
            string p = Console.ReadLine();

            string path = p + @"\"+fileN+".txt";
            
            if (File.Exists(path)) 
            {
                Console.WriteLine("file already exists");
                return ;
            }
            try
            {
                // Create the file, or overwrite if the file exists.
                FileStream fs = new FileStream(path, FileMode.Create);
           
                Console.WriteLine("file created sucessfully");
            }
            catch (Exception ex)  
            {
                Console.WriteLine("incorrect path");

            }
            
        }
        public static double calculateBill(int unit)
        {
            
            double bill=-1;
             if (unit <=199)
            {
                bill = unit * 1.20;
                Console.WriteLine("Amount Charges @RS.: 1.2 per unit : "+ bill);
               
            }
             else if(unit >= 200 && unit <400)
            {
                bill = unit * 1.50;
                Console.WriteLine("Amount Charges @RS.: 1.50 per unit : " + bill);
            }
            else if (unit >= 400 && unit < 600)
            {
                bill = unit * 1.80;
                Console.WriteLine("Amount Charges @RS.: 1.80 per unit : " + bill);

            }
            else if (unit >= 600)
            {

                bill = unit * 2.0;
                Console.WriteLine("Amount Charges @RS.: 2.0 per unit : " + bill);
               }

            return bill;
        }

        

        public static void Main(string[] args)
        {
            try
            {
                int id = -1, unit = 0;
                string name = "";
                Console.WriteLine("Enter id :");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Name :");
                name = Console.ReadLine();
                Console.WriteLine("Enter unit :");
                unit = int.Parse(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("Customer Id : " + id);
                Console.WriteLine("Customer Name : " + name);
                Console.WriteLine("Units Consume:  " + unit);
                Double curr = calculateBill(unit);
                Double net = surcharge(curr);
                Console.WriteLine("Surcharge Amount : " + net);
                Console.WriteLine("Net amount paid by the customer : " + (net + curr));
                //Task 3 : 
                //saving data
                Console.WriteLine(" '\n' Task 3 :");
                save.save_file(id, name, unit, net, curr);
            }
            catch (Exception e)
            {
                Console.WriteLine("Incorrect input");
            }
            finally
            {

                // Task 2 :
                Console.WriteLine("Task 2 :");
                createFile();

            }



        }
    }
}
