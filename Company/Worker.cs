using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Company
{
    public class Worker : Person
    {
        public string Post { get; private set; }
        private int experience;
        public int Experience
        {
            get
            {
                return experience;
            }
            set
            {
                if(value <= 5)
                {
                    Post = "Junior";
                }
                else
                {
                    if(value <= 10)
                    {
                        Post = "Admin";
                    }
                    else
                    {
                        Post = "Boss";
                    }
                }
                experience = value;
            }
        }

        public Worker(string name, string surname, int exp, Corporation corporation)
        {
            Name = name;
            Surname = surname;
            Experience = exp;
            corporation.Worker_List.Add(this);
        }

        public Worker(string file, Corporation corporation)
        {
            string str;
            try
            {
                using (var sr = new StreamReader(file))
                {
                    while ((str = sr.ReadLine()) != null)
                    {
                        string[] information = str.Split(',');
                        new Worker(information[0], information[1], int.Parse(information[2]), corporation);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int Pay()
        {
            if(Post == "Junior")
            {
                return 3;
            }
            else
            {
                if(Post == "Admin")
                {
                    return 6;
                }
                else
                {
                    return 12;
                }
            }
        }
    }
}
