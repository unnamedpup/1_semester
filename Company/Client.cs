using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Company
{
    public class Client : Person
    {    
        public string Status { get; private set; }
        private int amountOfMoney;
        public int AmountOfMoney
        {
            get
            {
                return amountOfMoney;
            }
            set
            {
                if(value > 1000)
                {
                    Status = "VIP";
                }
                else
                {
                    Status = "Simple";
                }
                amountOfMoney = value; 
            }
        }

        public Client(string name, string surname, int amountOfMoney, Corporation corporation)
        {
            Name = name;
            Surname = surname;
            AmountOfMoney = amountOfMoney;
            corporation.Client_List.Add(this);
        }

        public Client(string file, Corporation corporation)
        {
            string str;
            try
            {
                using (var sr = new StreamReader(file))
                {
                    while ((str = sr.ReadLine()) != null)
                    {
                        string[] information = str.Split(',');
                        new Client(information[0], information[1], int.Parse(information[2]), corporation);
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
