using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Company
{
    public class Area : Property
    {
        public bool Clear { get; set; }

        public Area(int square, int metrCost, string location, bool clear, Corporation corporation)
        {
            Square = square;
            MetrCost = metrCost;
            Location = location;
            Clear = clear;
            corporation.Area_List.Add(this);
        }

        public Area(string file, Corporation corporation)
        {
            string str;
            try
            {
                using (var sr = new StreamReader(file))
                {
                    while ((str = sr.ReadLine()) != null)
                    {
                        string[] information = str.Split(',');
                        new Area(int.Parse(information[0]), int.Parse(information[1]), information[2], Convert.ToBoolean(information[3]), corporation);
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
            if(Clear == true)
            {
                return Square * MetrCost * 2;
            }
            else
            {
                return Square * MetrCost;
            }
        }
    }
}
