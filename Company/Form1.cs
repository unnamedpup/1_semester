using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Company
{
    public partial class Form1 : Form
    {
        Corporation MathMech = new Corporation("Corporation.txt");
        public Form1(string[] args)
        {
            InitializeComponent();
            if (args[0] == "apa")
            {
                Apartament_button.Visible = true;
                Add_Apartament_button.Visible = true;
                Sale_Apartament_button.Visible = true;
                Apartament_Save_button.Visible = true;
                new Apartament("Apartament.txt", MathMech);
                new Client("Client.txt", MathMech);
            }

            if (args[0] == "sho")
            {
                Shop_button.Visible = true;
                Add_Shop_button.Visible = true;
                Sale_Shop_button.Visible = true;
                Shop_Save_button.Visible = true;
                new Shop("Shop.txt", MathMech);
                new Client("Client.txt", MathMech);
            }

            if (args[0] == "hou")
            {
                House_button.Visible = true;
                Add_House_button.Visible = true;
                Sale_House_button.Visible = true;
                House_Save_button.Visible = true;
                new House("House.txt", MathMech);
                new Client("Client.txt", MathMech);
            }

            if (args[0] == "are")
            {
                Area_button.Visible = true;
                Add_Area_button.Visible = true;
                Sale_Area_button.Visible = true;
                Area_Save_button.Visible = true;
                new Area("Area.txt", MathMech);
                new Client("Client.txt", MathMech);
            }

            if (args[0] == "cor")
            {
                Corporation_button.Visible = true;
                Worker_button.Visible = true;
                Client_button.Visible = true;
                Add_Worker_button.Visible = true;
                Add_Client_button.Visible = true;
                Corporation_Save_button.Visible = true;
                new Worker("Worker.txt", MathMech);
                new Client("Client.txt", MathMech);
                new Apartament("Apartament.txt", MathMech);
                new Shop("Shop.txt", MathMech);
                new House("House.txt", MathMech);
                new Area("Area.txt", MathMech);
            }
        }
//////////////////////////////////////////////////////////////////////////////// 

        private void Apartament_button_Click(object sender, EventArgs e)
        {
            Info_label.Text = MathMech.Apartament_Info();
            Info_label.Visible = true;
        }

        private void Sale_Apartament_button_Click(object sender, EventArgs e)
        {
            ClientNumber_textBox.Visible = true;
            ClientNumber_textBox.Text = "Номер клиента";
            PropertyNumber_textBox.Visible = true;
            PropertyNumber_textBox.Text = "Номер квартиры";
            Delete_Apartament_button.Visible = true;
            Info_label.Visible = false;
            Apartament_button.Visible = false;
            Add_Apartament_button.Visible = false;
            Sale_Apartament_button.Visible = false;
            Apartament_Save_button.Visible = false;
        }

        private void Delete_Apartament_button_Click(object sender, EventArgs e)
        {
            int i = int.Parse(ClientNumber_textBox.Text) - 1;
            int j = int.Parse(PropertyNumber_textBox.Text) - 1;
            if (i + 1 <= MathMech.Client_List.Count)
            {
                if (j + 1 <= MathMech.Apartament_List.Count)
                {
                    int cli = MathMech.Client_List[i].AmountOfMoney;
                    int apa = MathMech.Apartament_List[j].GetPrice();
                    if (cli >= apa)
                    {
                        MathMech.Client_List[i].AmountOfMoney = cli - apa;
                        MathMech.Apartament_List.RemoveAt(j);
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно денег(((");
                    }
                }
                else
                {
                    MessageBox.Show("Квартир меньше");
                }
            }
            else
            {
                MessageBox.Show("Клиентов меньше");
            }
            Apartament_button.Visible = true;
            Add_Apartament_button.Visible = true;
            Sale_Apartament_button.Visible = true;
            Apartament_Save_button.Visible = true;
            ClientNumber_textBox.Visible = false;
            PropertyNumber_textBox.Visible = false;
            Delete_Apartament_button.Visible = false;
        }

        private void Apartament_Save_button_Click(object sender, EventArgs e)
        {
            MathMech.Save_Apartament();
            MathMech.Save_Client();
        }

        private void Add_Apartament_button_Click(object sender, EventArgs e)
        {
            Info_label.Visible = false;
            Apartament_button.Visible = false;
            Add_Apartament_button.Visible = false;
            Sale_Apartament_button.Visible = false;
            Apartament_Save_button.Visible = false;
            Square_textBox.Visible = true;
            MetrCost_textBox.Visible = true;
            Location_textBox.Visible = true;
            Elevator_textBox.Visible = true;
            Furniture_textBox.Visible = true;
            Apartament_Floors_textBox.Visible = true;
            Plus_Apartament_button.Visible = true;
            Square_textBox.Text = "Площадь";
            MetrCost_textBox.Text = "Цена за м^2";
            Location_textBox.Text = "Город";
            Elevator_textBox.Text = "Лифт";
            Furniture_textBox.Text = "Мебель";
            Apartament_Floors_textBox.Text = "Этажей";
        }

        private void Plus_Apartament_button_Click(object sender, EventArgs e)
        {
            new Apartament(int.Parse(Square_textBox.Text), int.Parse(MetrCost_textBox.Text), Location_textBox.Text, Convert.ToBoolean(Elevator_textBox.Text), Convert.ToBoolean(Furniture_textBox.Text), int.Parse(Apartament_Floors_textBox.Text), MathMech);
            Apartament_button.Visible = true;
            Add_Apartament_button.Visible = true;
            Sale_Apartament_button.Visible = true;
            Apartament_Save_button.Visible = true;
            Square_textBox.Visible = false;
            MetrCost_textBox.Visible = false;
            Location_textBox.Visible = false;
            Elevator_textBox.Visible = false;
            Furniture_textBox.Visible = false;
            Apartament_Floors_textBox.Visible = false;
            Plus_Apartament_button.Visible = false;
        }

////////////////////////////////////////////////////////////////////////////////

        private void Shop_button_Click(object sender, EventArgs e)
        {
            Info_label.Text = MathMech.Shop_Info();
            Info_label.Visible = true;
        }

        private void Sale_Shop_button_Click(object sender, EventArgs e)
        {
            ClientNumber_textBox.Visible = true;
            ClientNumber_textBox.Text = "Номер клиента";
            PropertyNumber_textBox.Visible = true;
            PropertyNumber_textBox.Text = "Номер магазина";
            Delete_Shop_button.Visible = true;
            Info_label.Visible = false;
            Shop_button.Visible = false;
            Add_Shop_button.Visible = false;
            Sale_Shop_button.Visible = false;
            Shop_Save_button.Visible = false;
        }

        private void Delete_Shop_button_Click(object sender, EventArgs e)
        {
            int i = int.Parse(ClientNumber_textBox.Text) - 1;
            int j = int.Parse(PropertyNumber_textBox.Text) - 1;
            if (i + 1 <= MathMech.Client_List.Count)
            {
                if (j + 1 <= MathMech.Shop_List.Count)
                {
                    int cli = MathMech.Client_List[i].AmountOfMoney;
                    int sho = MathMech.Shop_List[j].GetPrice();
                    if (cli >= sho)
                    {
                        MathMech.Client_List[i].AmountOfMoney = cli - sho;
                        MathMech.Shop_List.RemoveAt(j);
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно денег(((");
                    }
                }
                else
                {
                    MessageBox.Show("Магазинов меньше");
                }
            }
            else
            {
                MessageBox.Show("Клиентов меньше");
            }
            Shop_button.Visible = true;
            Add_Shop_button.Visible = true;
            Sale_Shop_button.Visible = true;
            Shop_Save_button.Visible = true;
            ClientNumber_textBox.Visible = false;
            PropertyNumber_textBox.Visible = false;
            Delete_Shop_button.Visible = false;
        }

        private void Shop_Save_button_Click_1(object sender, EventArgs e)
        {
            MathMech.Save_Shop();
            MathMech.Save_Client();
        }

        private void Add_Shop_button_Click(object sender, EventArgs e)
        {
            Info_label.Visible = false;
            Shop_button.Visible = false;
            Add_Shop_button.Visible = false;
            Sale_Shop_button.Visible = false;
            Shop_Save_button.Visible = false;
            Square_textBox.Visible = true;
            MetrCost_textBox.Visible = true;
            Location_textBox.Visible = true;
            Type_textBox.Visible = true;
            Plus_Shop_button.Visible = true;
            Square_textBox.Text = "Площадь";
            MetrCost_textBox.Text = "Цена за м^2";
            Location_textBox.Text = "Город";
            Type_textBox.Text = "Тип";
        }

        private void Plus_Shop_button_Click(object sender, EventArgs e)
        {
            new Shop(int.Parse(Square_textBox.Text), int.Parse(MetrCost_textBox.Text), Location_textBox.Text, Type_textBox.Text, MathMech);
            Shop_button.Visible = true;
            Add_Shop_button.Visible = true;
            Sale_Shop_button.Visible = true;
            Shop_Save_button.Visible = true;
            Square_textBox.Visible = false;
            MetrCost_textBox.Visible = false;
            Location_textBox.Visible = false;
            Type_textBox.Visible = false;
            Plus_Shop_button.Visible = false;
        }
/////////////////////////////////////////////////////////////////////////////////////

        private void House_button_Click(object sender, EventArgs e)
        {
            Info_label.Text = MathMech.House_Info();
            Info_label.Visible = true;
        }

        private void Sale_House_button_Click(object sender, EventArgs e)
        {
            ClientNumber_textBox.Visible = true;
            ClientNumber_textBox.Text = "Номер клиента";
            PropertyNumber_textBox.Visible = true;
            PropertyNumber_textBox.Text = "Номер дома";
            Delete_House_button.Visible = true;
            Info_label.Visible = false;
            House_button.Visible = false;
            Add_House_button.Visible = false;
            Sale_House_button.Visible = false;
            House_Save_button.Visible = false;
        }

        private void Delete_House_button_Click(object sender, EventArgs e)
        {
            int i = int.Parse(ClientNumber_textBox.Text) - 1;
            int j = int.Parse(PropertyNumber_textBox.Text) - 1;
            if (i + 1 <= MathMech.Client_List.Count)
            {
                if (j + 1 <= MathMech.House_List.Count)
                {
                    int cli = MathMech.Client_List[i].AmountOfMoney;
                    int hou = MathMech.House_List[j].GetPrice();
                    if (cli >= hou)
                    {
                        MathMech.Client_List[i].AmountOfMoney = cli - hou;
                        MathMech.House_List.RemoveAt(j);
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно денег(((");
                    }
                }
                else
                {
                    MessageBox.Show("Домов меньше");
                }
            }
            else
            {
                MessageBox.Show("Клиентов меньше");
            }
            House_button.Visible = true;
            Add_House_button.Visible = true;
            Sale_House_button.Visible = true;
            House_Save_button.Visible = true;
            ClientNumber_textBox.Visible = false;
            PropertyNumber_textBox.Visible = false;
            Delete_House_button.Visible = false;
        }

        private void House_Save_button_Click(object sender, EventArgs e)
        {
            MathMech.Save_House();
            MathMech.Save_Client();
        }

        private void Add_House_button_Click(object sender, EventArgs e)
        {
            Info_label.Visible = false;
            House_button.Visible = false;
            Add_House_button.Visible = false;
            Sale_House_button.Visible = false;
            House_Save_button.Visible = false;
            Square_textBox.Visible = true;
            MetrCost_textBox.Visible = true;
            Location_textBox.Visible = true;
            House_Floors_textBox.Visible = true;
            SwimmingPool_textBox.Visible = true;
            Plus_House_button.Visible = true;
            Square_textBox.Text = "Площадь";
            MetrCost_textBox.Text = "Цена за м^2";
            Location_textBox.Text = "Город";
            House_Floors_textBox.Text = "Этажей";
            SwimmingPool_textBox.Text = "Бассейн";
        }

        private void Plus_House_button_Click(object sender, EventArgs e)
        {
            new House(int.Parse(Square_textBox.Text), int.Parse(MetrCost_textBox.Text), Location_textBox.Text, int.Parse(House_Floors_textBox.Text), Convert.ToBoolean(SwimmingPool_textBox.Text), MathMech);
            House_button.Visible = true;
            Add_House_button.Visible = true;
            Sale_House_button.Visible = true;
            House_Save_button.Visible = true;
            Square_textBox.Visible = false;
            MetrCost_textBox.Visible = false;
            Location_textBox.Visible = false;
            House_Floors_textBox.Visible = false;
            SwimmingPool_textBox.Visible = false;
            Plus_House_button.Visible = false;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Area_button_Click(object sender, EventArgs e)
        {
            Info_label.Text = MathMech.Area_Info();
            Info_label.Visible = true;
        }

        private void Sale_Area_button_Click(object sender, EventArgs e)
        {
            ClientNumber_textBox.Visible = true;
            ClientNumber_textBox.Text = "Номер клиента";
            PropertyNumber_textBox.Visible = true;
            PropertyNumber_textBox.Text = "Номер участка";
            Delete_Area_button.Visible = true;
            Info_label.Visible = false;
            Area_button.Visible = false;
            Add_Area_button.Visible = false;
            Sale_Area_button.Visible = false;
            Area_Save_button.Visible = false;
        }

        private void Delete_Area_button_Click(object sender, EventArgs e)
        {
            int i = int.Parse(ClientNumber_textBox.Text) - 1;
            int j = int.Parse(PropertyNumber_textBox.Text) - 1;
            if (i + 1 <= MathMech.Client_List.Count)
            {
                if (j + 1 <= MathMech.Area_List.Count)
                {
                    int cli = MathMech.Client_List[i].AmountOfMoney;
                    int are = MathMech.Area_List[j].GetPrice();
                    if (cli >= are)
                    {
                        MathMech.Client_List[i].AmountOfMoney = cli - are;
                        MathMech.Area_List.RemoveAt(j);
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно денег(((");
                    }
                }
                else
                {
                    MessageBox.Show("Участков меньше");
                }
            }
            else
            {
                MessageBox.Show("Клиентов меньше");
            }
            Area_button.Visible = true;
            Add_Area_button.Visible = true;
            Sale_Area_button.Visible = true;
            Area_Save_button.Visible = true;
            ClientNumber_textBox.Visible = false;
            PropertyNumber_textBox.Visible = false;
            Delete_Area_button.Visible = false;
        }

        private void Area_Save_button_Click(object sender, EventArgs e)
        {
            MathMech.Save_Area();
            MathMech.Save_Client();
        }

        private void Add_Area_button_Click(object sender, EventArgs e)
        {

            Info_label.Visible = false;
            Area_button.Visible = false;
            Add_Area_button.Visible = false;
            Sale_Area_button.Visible = false;
            Area_Save_button.Visible = false;
            Square_textBox.Visible = true;
            MetrCost_textBox.Visible = true;
            Location_textBox.Visible = true;
            Plus_Area_button.Visible = true;
            Clear_textBox.Visible = true;
            Square_textBox.Text = "Площадь";
            MetrCost_textBox.Text = "Цена за м^2";
            Location_textBox.Text = "Город";
            Clear_textBox.Text = "Чистый";
        }

        private void Plus_Area_button_Click(object sender, EventArgs e)
        {
            new Area(int.Parse(Square_textBox.Text), int.Parse(MetrCost_textBox.Text), Location_textBox.Text, Convert.ToBoolean(Clear_textBox.Text), MathMech);
            Area_button.Visible = true;
            Add_Area_button.Visible = true;
            Sale_Area_button.Visible = true;
            Area_Save_button.Visible = true;
            Square_textBox.Visible = false;
            MetrCost_textBox.Visible = false;
            Location_textBox.Visible = false;
            Clear_textBox.Visible = false;
            Plus_Area_button.Visible = false;
        }
//////////////////////////////////////////////////////////////////////////////////////

        private void Corporation_button_Click(object sender, EventArgs e)
        {
            Info_label.Text = MathMech.Info();
            Info_label.Visible = true;
        }

        private void Worker_button_Click(object sender, EventArgs e)
        {
            Info_label.Text = MathMech.Worker_Info();
            Info_label.Visible = true;
        }

        private void Client_button_Click(object sender, EventArgs e)
        {
            Info_label.Text = MathMech.Client_Info();
            Info_label.Visible = true;
        }

        private void Corporation_Save_button_Click(object sender, EventArgs e)
        {
            MathMech.Save();
        }

        private void Add_Worker_button_Click(object sender, EventArgs e)
        {
            Corporation_button.Visible = false;
            Worker_button.Visible = false;
            Client_button.Visible = false;
            Add_Worker_button.Visible = false;
            Add_Client_button.Visible = false;
            Info_label.Visible = false;
            Corporation_Save_button.Visible = false;
            Name_textBox.Visible = true;
            Surname_textBox.Visible = true;
            Experience_textBox.Visible = true;
            Plus_Worker_button.Visible = true;
            Name_textBox.Text = "Имя";
            Surname_textBox.Text = "Фамилия";
            Experience_textBox.Text = "Опыт";
        }

        private void Plus_Worker_textBox_Click(object sender, EventArgs e)
        {
            new Worker(Name_textBox.Text, Surname_textBox.Text, int.Parse(Experience_textBox.Text), MathMech);
            Corporation_button.Visible = true;
            Worker_button.Visible = true;
            Client_button.Visible = true;
            Add_Worker_button.Visible = true;
            Add_Client_button.Visible = true;
            Corporation_Save_button.Visible = true;
            Name_textBox.Visible = false;
            Surname_textBox.Visible = false;
            Experience_textBox.Visible = false;
            Plus_Worker_button.Visible = false;
        }

        private void Add_Client_button_Click(object sender, EventArgs e)
        {
            Corporation_button.Visible = false;
            Worker_button.Visible = false;
            Client_button.Visible = false;
            Add_Worker_button.Visible = false;
            Add_Client_button.Visible = false;
            Info_label.Visible = false;
            Corporation_Save_button.Visible = false;
            Name_textBox.Visible = true;
            Surname_textBox.Visible = true;
            AmountOfMoney_textBox.Visible = true;
            Plus_Client_button.Visible = true;
            Name_textBox.Text = "Имя";
            Surname_textBox.Text = "Фамилия";
            AmountOfMoney_textBox.Text = "Бюджет";
        }

        private void Plus_Client_button_Click(object sender, EventArgs e)
        {
            new Client(Name_textBox.Text, Surname_textBox.Text, int.Parse(AmountOfMoney_textBox.Text), MathMech);
            Corporation_button.Visible = true;
            Worker_button.Visible = true;
            Client_button.Visible = true;
            Add_Worker_button.Visible = true;
            Add_Client_button.Visible = true;
            Corporation_Save_button.Visible = true;
            Name_textBox.Visible = false;
            Surname_textBox.Visible = false;
            AmountOfMoney_textBox.Visible = false;
            Plus_Client_button.Visible = false;
        }
    }
}
