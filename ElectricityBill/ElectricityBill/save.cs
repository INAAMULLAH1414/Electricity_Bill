using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ElectricityBill
{
    public class save
    {
         public static void save_file(int id,String name,int unit,Double net,Double curr)
        {
            string str = id + "_" + name;
            try
            {
                // Create the file, or overwrite if the file exists.

                FileStream fs =new FileStream(str + ".txt",FileMode.Append,FileAccess.Write);
                var sr = new StreamWriter(fs);
                sr.WriteLine("Customer Id : " + id);
                sr.WriteLine("Customer Name : " + name);
                sr.WriteLine("Units Consume:  " + unit);
                if (unit <= 199)
                {
                   
                    sr.WriteLine("Amount Charges @RS.: 1.2 per unit : " + curr);

                }
                else if (unit >= 200 && unit < 400)
                {
                    
                    sr.WriteLine("Amount Charges @RS.: 1.50 per unit : " + curr);
                }
                else if (unit >= 400 && unit < 600)
                {
                   
                    sr.WriteLine("Amount Charges @RS.: 1.80 per unit : " + curr);

                }
                else if (unit >= 600)
                { 
        
                    sr.WriteLine("Amount Charges @RS.: 2.0 per unit : " + curr);
                }

                sr.WriteLine("Surcharge Amount : " + net);
                sr.WriteLine("Net amount paid by the customer : " + (net + curr));
                sr.Close();
                Console.WriteLine("info saved");

            }
            catch (Exception ex)
            {
                Console.WriteLine("error");

            }

        }
    }
}
