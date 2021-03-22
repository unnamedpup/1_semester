using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Company
{
    public class Shop : Property
    {
        public string Type { get; set; }

        public Shop(int square, int metrCost, string location, string type, Corporation corporation)
        {
            Square = square;
            MetrCost = metrCost;
            Location = location;
            Type = type;
            corporation.Shop_List.Add(this);
        }

        public Shop(string file, Corporation corporation)
        {
            string str;
            try
            {
                using (var sr = new StreamReader(file))
                {
                    while ((str = sr.ReadLine()) != null)
                    {
                        string[] information = str.Split(',');
                        new Shop(int.Parse(information[0]), int.Parse(information[1]), information[2], information[3], corporation);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
