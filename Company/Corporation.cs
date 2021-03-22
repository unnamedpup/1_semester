using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Company
{
    public class Corporation
    {
        public string Name { get; private set; }
        public string Owner { get; private set; }
        public string Index { get; private set; }

        public Corporation(string name, string owner, string index)
        {
            Name = name;
            Owner = owner;
            Index = index;
        }

        public Corporation(string file)
        {
            try
            {
                using (var sr = new StreamReader(file))
                {
                    string[] str = sr.ReadLine().Split(',');
                    Name = str[0];
                    Owner = str[1];
                    Index = str[2];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Worker> Worker_List = new List<Worker>();
        public List<Client> Client_List = new List<Client>();
        public List<Apartament> Apartament_List = new List<Apartament>();
        public List<Shop> Shop_List = new List<Shop>();
        public List<House> House_List = new List<House>();
        public List<Area> Area_List = new List<Area>();

        public string Info()
        {
            string str = "";
            str += $"Название: {Name}, Владелец: {Owner}, Индекс: {Index} \r\n Работников: {AmountOfWorker()}, Клиентов: {AmountOfClient()}, Недвижимости: {AmountOfProperty()}\r\n Стоимость всей недвижимости: {Cost()}$, Общая зарплата: {AllPay()}$";
            return str;
        }

        public string Apartament_Info()
        {
            string str = "";
            for(int i = 0; i < Apartament_List.Count; i++)
            {
                str += $"Квартира {i + 1}: Площадь: {Apartament_List[i].Square} м^2, Цена за м^2: {Apartament_List[i].MetrCost}$, Город: {Apartament_List[i].Location}, Лифт: {Apartament_List[i].Elevator}, Мебель: {Apartament_List[i].Furniture}, Этажей: {Apartament_List[i].Floors}, Цена: {Apartament_List[i].GetPrice()}$ \r\n";
            }
            return str;
        }

        public void Save_Apartament()
        {
            try
            {
                if (Apartament_List.Count == 0)
                {
                    using (var sw = new StreamWriter("Apartament.txt"))
                    {
                        sw.WriteLine("");
                    }
                }
                else
                {
                    for (int i = 0; i < Apartament_List.Count; i++)
                    {

                        using (var sw = new StreamWriter("Apartament.txt", Convert.ToBoolean(i)))
                        {
                            sw.WriteLine($"{Apartament_List[i].Square},{Apartament_List[i].MetrCost},{Apartament_List[i].Location},{Apartament_List[i].Elevator},{Apartament_List[i].Furniture},{Apartament_List[i].Floors}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

       public string Shop_Info()
        {
            string str = "";
            for (int i = 0; i < Shop_List.Count; i++)
            {
                str += $"Магазин {i + 1}: Площадь: {Shop_List[i].Square} м^2, Цена за м^2: {Shop_List[i].MetrCost}$, Город: {Shop_List[i].Location}, Тип: {Shop_List[i].Type}, Цена: {Shop_List[i].GetPrice()}$ \r\n";
            }
            return str;
        }

        public void Save_Shop()
        {
            try
            {
                if (Shop_List.Count == 0)
                {
                    using (var sw = new StreamWriter("Shop.txt"))
                    {
                        sw.WriteLine("");
                    }
                }
                else
                {
                    for (int i = 0; i < Shop_List.Count; i++)
                    {
                        using (var sw = new StreamWriter("Shop.txt", Convert.ToBoolean(i)))
                        {
                            sw.WriteLine($"{Shop_List[i].Square},{Shop_List[i].MetrCost},{Shop_List[i].Location},{Shop_List[i].Type}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string House_Info()
        {
            string str = "";
            for(int i = 0; i < House_List.Count; i++)
            {
                str += $"Дом {i + 1}: Площадь: {House_List[i].Square} м^2, Цена за м^2: {House_List[i].MetrCost}$, Город: {House_List[i].Location}, Этажей: {House_List[i].Floors}, Бассейн: {House_List[i].SwimmingPool}, Цена: {House_List[i].GetPrice()}$ \r\n";
            }
            return str;
        }

        public void Save_House()
        {
            try
            {
                if (House_List.Count == 0)
                {
                    using (var sw = new StreamWriter("House.txt"))
                    {
                        sw.WriteLine("");
                    }
                }
                else
                {
                    for (int i = 0; i < House_List.Count; i++)
                    {
                        using (var sw = new StreamWriter("House.txt", Convert.ToBoolean(i)))
                        {
                            sw.WriteLine($"{House_List[i].Square},{House_List[i].MetrCost},{House_List[i].Location},{House_List[i].Floors},{House_List[i].SwimmingPool}");
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string Area_Info()
        {
            string str = "";
            for(int i = 0; i < Area_List.Count; i++)
            {
                str+= $"Участок {i + 1}: Площадь: {Area_List[i].Square} м^2, Цена за м^2: {Area_List[i].MetrCost}$, Город: {Area_List[i].Location}, Чистый: {Area_List[i].Clear}, Цена: {Area_List[i].GetPrice()}$ \r\n";
            }
            return str;
        }

        public void Save_Area()
        {
            try
            {
                if (Area_List.Count == 0)
                {
                    using (var sw = new StreamWriter("Area.txt"))
                    {
                        sw.WriteLine("");
                    }
                }
                else
                {
                    for (int i = 0; i < Area_List.Count; i++)
                    {
                        using (var sw = new StreamWriter("Area.txt", Convert.ToBoolean(i)))
                        {
                            sw.WriteLine($"{Area_List[i].Square},{Area_List[i].MetrCost},{Area_List[i].Location},{Area_List[i].Clear}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string Worker_Info()
        {
            string str = "";
            for(int i = 0; i < Worker_List.Count; i++)
            {
                str+= $"Работник {i+1}: Имя: {Worker_List[i].Name}, Фамилия: {Worker_List[i].Surname}, Опыт: {Worker_List[i].Experience}, Должность: {Worker_List[i].Post}, Зарплата: {Worker_List[i].Pay()}$ \r\n";
            }
            return str;
        }

        public void Save_Worker()
        {
            try
            {
                if (Worker_List.Count == 0)
                {
                    using (var sw = new StreamWriter("Worker.txt"))
                    {
                        sw.WriteLine("");
                    }
                }
                else
                {
                    for (int i = 0; i < Worker_List.Count; i++)
                    {
                        using (var sw = new StreamWriter("Worker.txt", Convert.ToBoolean(i)))
                        {
                            sw.WriteLine($"{Worker_List[i].Name},{Worker_List[i].Surname},{Worker_List[i].Experience}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string Client_Info()
        {
            string str = "";
            for(int i = 0; i < Client_List.Count; i++)
            {
                str+= $"Клиент {i + 1}, Имя: {Client_List[i].Name}, Фамилия: {Client_List[i].Surname}, Количество денег: {Client_List[i].AmountOfMoney}$, Статус: {Client_List[i].Status} \r\n";
            }
            return str;
        }

        public void Save_Client()
        {
            try
            {
                if (Client_List.Count == 0)
                {
                    using (var sw = new StreamWriter("Client.txt"))
                    {
                        sw.WriteLine("");
                    }
                }
                else
                {
                    for (int i = 0; i < Client_List.Count; i++)
                    {
                        using (var sw = new StreamWriter("Client.txt", Convert.ToBoolean(i)))
                        {
                            sw.WriteLine($"{Client_List[i].Name},{Client_List[i].Surname},{Client_List[i].AmountOfMoney}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Save()
        {
            Save_Worker();
            Save_Client();
        }

        public int Cost()
        {
            int sum = 0;
            for(int i = 0; i < Apartament_List.Count; i++)
            {
                sum += Apartament_List[i].GetPrice();
            }

            for(int i = 0; i < Shop_List.Count; i++)
            {
                sum += Shop_List[i].GetPrice();
            }

            for(int i = 0; i < House_List.Count; i++)
            {
                sum += House_List[i].GetPrice();
            }

            for(int i = 0; i < Area_List.Count; i++)
            {
                sum += Area_List[i].GetPrice();
            }
            return sum;
        }

        public int AllPay()
        {
            int sum = 0;
            for(int i = 0; i < Worker_List.Count; i++)
            {
                sum += Worker_List[i].Pay();
            }
            return sum;
        }

        public int AmountOfProperty()
        {
            return Apartament_List.Count + Shop_List.Count + House_List.Count + Area_List.Count;
        }

        public int AmountOfWorker()
        {
            return Worker_List.Count;
        }

        public int AmountOfClient()
        {
            return Client_List.Count;
        }
    }
}
