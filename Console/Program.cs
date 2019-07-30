using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Project_Csharp;
using System.Collections;
using System.Xml.Linq;


namespace Project_Csharp
{
    public interface IFIOToString
    {
        string FIOToString();
    }

    [Serializable]
    class Employee : IFIOToString
    {

        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymicname { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string AcceptanceDate = DateTime.Now.ToString("dd/MM/yyyy");
        public double MonthlySalary { get; set; }
        public int RoomNomber { get; set; }
        public string FieldNotes { get; set; }
        public string Birthday = DateTime.Now.ToString("dd/MM/yyyy");
        public string Country { get; set; }
        public string Town { get; set; }
        public int TelephoneNumber { get; set; }
        public string Email { get; set; }

        List<Employee> employees = new List<Employee>();
       

        public Employee()
        {

        }
        public Employee(int ID, string Surname) 
        {
            this.ID = ID;
            this.Surname = Surname;
        }

        public Employee(int ID, string Surname, string Name, string Patronymicname, string Birthday, string Department, string Position,
        int RoomNomber, int TelephoneNumber, string Email, double MonthlySalary, string AcceptanceDate, string FieldNotes)
        {
            this.ID = ID;
            this.Surname = Surname;
            this.Name = Name;
            this.Patronymicname = Patronymicname;
            this.Birthday = Birthday;
            this.Department = Department;
            this.Position = Position;
            this.RoomNomber = RoomNomber;
            this.TelephoneNumber = TelephoneNumber;
            this.Email = Email;
            this.MonthlySalary = MonthlySalary;
            this.AcceptanceDate = AcceptanceDate;
            this.FieldNotes = FieldNotes;
        }


        public string FIOToString()
        {
            return String.Format("{0}; {1}; {2}; {3}; {4}; {5}; {6}; {7}; {8}; {9}; {10}; {11}; {12} ",
                ID, Surname, Name, Patronymicname, Birthday, Department,
                Position, RoomNomber, TelephoneNumber, Email, MonthlySalary,
                AcceptanceDate, FieldNotes);
        }


        public static Employee New()
        {
            Console.Write("������ ID ����������: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("������ ������� ����������: ");
            string Surname = Console.ReadLine();
            Console.Write("������ ��'� ����������: ");
            string Name = Console.ReadLine();
            Console.Write("������ ��-������� ����������: ");
            string Patronymicname = Console.ReadLine();
            Console.Write("������ ���� ���������� ����������: ");
            string Birthday =Console.ReadLine();
            Console.Write("������ ������ ����������: ");
            string Department = Console.ReadLine();
            Console.Write("������ ���� ����������: ");
            string Position = Console.ReadLine();
            Console.Write("������ ����� ������ ����������: ");
            int RoomNomber = Convert.ToInt32(Console.ReadLine());
            Console.Write("������ ����� �������� ����������: ");
            int TelephoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("������ e-mail ����������: ");
            string Email = Console.ReadLine();
            Console.Write("������ �������� ����� ����������: ");
            double MonthlySalary = double.Parse(Console.ReadLine());
            Console.Write("������ ���� ��������� �� ������ ����������: ");
            string AcceptanceDate = Console.ReadLine();
            Console.Write("������ �������� ��� ����������: ");
            string FieldNotes = Console.ReadLine();

            return new Employee(ID, Surname, Name,
                Patronymicname,
                Birthday,
                Department,
                Position,
                RoomNomber,
                TelephoneNumber,
                Email,
                MonthlySalary,
                AcceptanceDate,
                FieldNotes);
        }
        public void DeleteEmployee()
        {
            Console.WriteLine("������ ������� ����������, ����� �� ������ ��������: ");
            string Sur1 = Console.ReadLine();
            Console.WriteLine("������ ID  ����������, ����� �� ������ ��������: ");

            var itemToDelete = employees.Where(x => x.ID == ID).Select(x => x).First();
            employees.Remove(itemToDelete);
        }

        public Employee this[int index]
        {
            get 
                
            { return employees[index]; }

            set

            { employees[index] = value; }
        }  
    }
}
    class Program
    {
        static void Main(string[] args)
        {

            List<Employee> empl = new List<Employee>();

       /*empl[0]=new Employee (1, "��������", "�����", "��������", "09/11/1995", "���������",
            "���", 548, 4672, "petrenko@gmail.com", 3500, new DateTime(2010, 11, 14), "������" );*/

        bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;//�������� ������ �� ������� ��������

                Console.WriteLine("1. ������ ������ ����������  \n2. ����������� ��� ���������� \n3. ���������� ��������� ����������");
                Console.WriteLine("4. �������� ��������� ����������  \n5. ����������� ��� \n6. �����");
                Console.WriteLine("������ ����� ������: ");

                Console.ForegroundColor = color;

                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1://������ ������, ���� ���� ������ ���������� � ������
                      
                            empl.Add(Employee.New());

                            Console.WriteLine("�� ����� ���������� ����������: ");
                            foreach (var b in empl)
                            Console.WriteLine(b.FIOToString());

                        
                            break;

                        case 2: //������ ������, ���� �� ��������� ����������� ��� ��� ����������
                            Console.WriteLine("������ ������� ���������� ���, ����� �� ������ �����������: ");
                            string Sur = Console.ReadLine();
                            Console.WriteLine("������ ID  ���������� ���, ����� �� ������ �����������: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            var itemToDelete = empl.Where(x => x.Surname == Sur || x.ID == id);
                            foreach (var em in itemToDelete)
                            {
                                Console.WriteLine(em.FIOToString());
                            }

                        break;

                        case 3: //������ ������, ���� �������� ���������� ��������� ����������
                        Console.WriteLine("������ ������� ���������� ���, ����� �� ������ ����������: ");
                        string Sur2 = Console.ReadLine();
                        Console.WriteLine("������ ID  ���������� ���, ����� �� ������ ����������: ");
                        int id2 = Convert.ToInt32(Console.ReadLine());
                        var itemToDelete2 = empl.Where(x => x.Surname == Sur2);
                        foreach (var em in itemToDelete2)
                        {
                            Console.WriteLine(em.FIOToString());
                        }

                        Console.WriteLine("����, ��� �� ������ ����������: ");
                        Console.WriteLine("1. ID  \n" +
                            "2. ������� \n");
                         
                        int command1 = Convert.ToInt32(Console.ReadLine());
                        switch (command1)
                        {
                            case 1:
                                Console.WriteLine("������ ����������� ID: ");
                                int newID = Convert.ToInt32(Console.ReadLine());

                                empl.Where(x => x.ID.Equals(id2)).ToList().ForEach(y => y.ID = newID);

                                Console.WriteLine("��� �����������!!! ");
                                break;

                            case 2:
                                Console.WriteLine("������ ����������� �������: ");
                                string newSur = Console.ReadLine();

                                empl.Where(x => x.Surname.Equals(Sur2)).ToList().ForEach(y => y.Surname = newSur);

                                Console.WriteLine("��� �����������!!! ");
                                break;
                            //case 3:
                               
                                /* Console.WriteLine("������ ����������� �������: ");
                                 string newName = Console.ReadLine();
                                 empl.Where(x => x.Name.Equals(Name)).ToList().ForEach(y => y.Surname = newSur);
                                 Console.WriteLine("��� �����������!!! ");
                                 break;*/
                        }
                        break;

                        case 4:// �����, ���� �������� �������� ��������� ����������
                        
                        
                        try
                        {
                            
                         
                             using (StreamReader sr = new StreamReader(System.Net.Mime.MediaTypeNames.Application.StartupPath+@"D:\1.txt"))
                             {
                                 string line = sr.ReadToEnd();
                                 Console.WriteLine(line);
                             }
                            foreach (var b in empl)
                                Console.WriteLine(b.FIOToString());

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("��������� ���� ���������!!!");
                            Console.WriteLine(e.Message);
                        }

                        Console.WriteLine("������ ������� ����������, ����� �� ������ ��������: ");
                        string Sur1 = Console.ReadLine();
                        Console.WriteLine("������ ID  ����������, ����� �� ������ ��������: ");
                        int id1 = Convert.ToInt32(Console.ReadLine());
                        var itemToDelete1 = empl.Where(x => x.Surname == Sur1 || x.ID == id1).Select(x => x);
                       
                       
                        foreach (var em in itemToDelete1)
                        {
                            Console.WriteLine(em.FIOToString());

                            Console.WriteLine("�� ����������� ��������� ����������: \n" +
                           "-��� \n" +
                           "-ͳ \n");
                            string del = Console.ReadLine();

                            if (del == "���")
                            {
                                empl.Remove(em);
                                Console.WriteLine("��� ��������!!!");
                            }
                            else
                                Console.WriteLine("�� �� ���������� ���������!!!");
                        }
                       

                        Console.WriteLine("Count: {0}", empl.Count);

                        break;
                   
                        case 5: //����������� ���
                            Console.WriteLine("������\n 1, ���� �� ������ ������� ��� ���������� �� ����� " +
                                "� \n 2, ���� �� ������ �������� ��� � ����");
                           
                                int zvit = Convert.ToInt32(Console.ReadLine());
                        if (zvit == 1)
                        {
                            
                            FileInfo file = new FileInfo(@"D:\1.txt");

                            using (StreamWriter sw = file.AppendText())
                            {
                                foreach (Employee b in empl)

                                    sw.WriteLine(b.FIOToString());

                            }
                            
                            try
                            {
                                
                                using (StreamReader sr = new StreamReader(@"D:\1.txt"))
                                {
                                    string line = sr.ReadToEnd();
                                    Console.WriteLine(line);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("��������� ���� ���������!!!");
                                Console.WriteLine(e.Message);
                            }
                            
                        }

                        else if (zvit == 2)
                        {
                            
                            FileInfo file = new FileInfo(@"D:\1.txt");

                            using (StreamWriter sw = file.AppendText())
                            {
                                foreach (Employee b in empl)

                                    sw.WriteLine(b.FIOToString());
                            }
                        }
                        else
                        {
                            color = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("�� ����� ������������ �����!!!");
                            Console.ForegroundColor = color;

                        }
                            
                            break;

                        case 6:
                            alive = false;   // �����
                            continue;

                    }
                }
                catch (Exception ex)
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }

         }
       
          /* void Serialize()
            {
                FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, empl);
                fs.Close();
            }
            void Deserialize()
            {
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                BinaryFormatter bf = new BinaryFormatter();
                empl = (List<Employee>)bf.Deserialize(fs);
                fs.Close();
                foreach (var w in empl)
                {
                    Console.WriteLine(w);
                }
            }*/
            Console.ReadKey();

            }
        }