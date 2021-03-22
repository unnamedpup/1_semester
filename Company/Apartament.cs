using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Company
{
    public class Apartament : Property
    {
        public bool Elevator { get; set; }
        public bool Furniture { get; set; }
        public int Floors { get; set; }

        public Apartament(int square, int metrCost, string location, bool elevator, bool furniture, int floors, Corporation corporation)
        {
            Square = square;
            MetrCost = metrCost;
            Location = location;
            Elevator = elevator;
            Furniture = furniture;
            Floors = floors;
            corporation.Apartament_List.Add(this);
        }

        public Apartament(string file, Corporation corporation)
        {
            string str;
            try
            {
                using(var sr = new StreamReader(file))
                {
                    while ((str = sr.ReadLine()) != null)
                    {
                        string[] information = str.Split(',');
                        new Apartament(int.Parse(information[0]), int.Parse(information[1]), information[2], Convert.ToBoolean(information[3]), Convert.ToBoolean(information[4]), int.Parse(information[5]), corporation);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override int GetPrice()
        {
            if(Furniture == true)
            {
                return Square * MetrCost + 10 * Floors + 100;
            }
            else
            {
                return Square * MetrCost + 10 * Floors;
            }
        }
    }
}
