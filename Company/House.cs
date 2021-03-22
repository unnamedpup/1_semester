using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Company
{
    public class House : Property
    {
        public bool SwimmingPool { get; set; }
        public int Floors { get; set; }
        public House(int square, int metrCost, string location, int floors, bool swimmingpool, Corporation corporation)
        {
            Square = square;
            MetrCost = metrCost;
            Location = location;
            Floors = floors;
            SwimmingPool = swimmingpool;
            corporation.House_List.Add(this);
        }

        public House(string file, Corporation corporation)
        {
            string str;
            try
            {
                using (var sr = new StreamReader(file))
                {
                    while ((str = sr.ReadLine()) != null)
                    {
                        string[] information = str.Split(',');
                        new House(int.Parse(information[0]), int.Parse(information[1]), information[2], int.Parse(information[3]), Convert.ToBoolean(information[4]), corporation);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override int GetPrice()
        {
            if(SwimmingPool == true)
            {
                return Square * MetrCost * Floors / 10 + 50;
            }
            else
            {
                return Square * MetrCost * Floors / 10;
            }
        }
    }
}
