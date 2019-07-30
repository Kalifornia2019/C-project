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
            Console.Write("Введіть ID працівника: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть прізвище працівника: ");
            string Surname = Console.ReadLine();
            Console.Write("Введіть ім'я працівника: ");
            string Name = Console.ReadLine();
            Console.Write("Введіть по-батькові працівника: ");
            string Patronymicname = Console.ReadLine();
            Console.Write("Введіть дату народження працівника: ");
            string Birthday =Console.ReadLine();
            Console.Write("Введіть посаду працівника: ");
            string Department = Console.ReadLine();
            Console.Write("Введіть відділ працівника: ");
            string Position = Console.ReadLine();
            Console.Write("Введіть номер кімнати працівника: ");
            int RoomNomber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть номер телефону працівника: ");
            int TelephoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть e-mail працівника: ");
            string Email = Console.ReadLine();
            Console.Write("Введіть заробітну плату працівника: ");
            double MonthlySalary = double.Parse(Console.ReadLine());
            Console.Write("Введіть дату прийняття на роботу працівника: ");
            string AcceptanceDate = Console.ReadLine();
            Console.Write("Введіть додаткові дані працівника: ");
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
            Console.WriteLine("Введіть прізвище працівника, якого Ви хочете видалити: ");
            string Sur1 = Console.ReadLine();
            Console.WriteLine("Введіть ID  працівника, якого Ви хочете видалити: ");

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

       /*empl[0]=new Employee (1, "Петренко", "Петро", "Петрович", "09/11/1995", "Програміст",
            "ІОЦ", 548, 4672, "petrenko@gmail.com", 3500, new DateTime(2010, 11, 14), "Крутий" );*/

        bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;//виводимо список дій зелемим кольором

                Console.WriteLine("1. Додати нового працівника  \n2. Переглянути дані працівника \n3. Редагувати існуючого працівника");
                Console.WriteLine("4. Видалити існуючого працівника  \n5. Згенерувати звіт \n6. Вихід");
                Console.WriteLine("Введіть номер пункта: ");

                Console.ForegroundColor = color;

                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1://Виклик метода, який додає нового працівника у список
                      
                            empl.Add(Employee.New());

                            Console.WriteLine("Ви ввели наступного працівника: ");
                            foreach (var b in empl)
                            Console.WriteLine(b.FIOToString());

                        
                            break;

                        case 2: //Виклик метода, який дає можливість переглядати дані про працівника
                            Console.WriteLine("Введіть прізвище працівника дані, якого Ви хочете переглянути: ");
                            string Sur = Console.ReadLine();
                            Console.WriteLine("Введіть ID  працівника дані, якого Ви хочете переглянути: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            var itemToDelete = empl.Where(x => x.Surname == Sur || x.ID == id);
                            foreach (var em in itemToDelete)
                            {
                                Console.WriteLine(em.FIOToString());
                            }

                        break;

                        case 3: //Виклик метода, який дозволяє редагувати існуючого працівника
                        Console.WriteLine("Введіть прізвище працівника дані, якого Ви хочете редагувати: ");
                        string Sur2 = Console.ReadLine();
                        Console.WriteLine("Введіть ID  працівника дані, якого Ви хочете редагувати: ");
                        int id2 = Convert.ToInt32(Console.ReadLine());
                        var itemToDelete2 = empl.Where(x => x.Surname == Sur2);
                        foreach (var em in itemToDelete2)
                        {
                            Console.WriteLine(em.FIOToString());
                        }

                        Console.WriteLine("Поле, яке Ви хочете редагувати: ");
                        Console.WriteLine("1. ID  \n" +
                            "2. Прізвище \n");
                         
                        int command1 = Convert.ToInt32(Console.ReadLine());
                        switch (command1)
                        {
                            case 1:
                                Console.WriteLine("Введіть редагування ID: ");
                                int newID = Convert.ToInt32(Console.ReadLine());

                                empl.Where(x => x.ID.Equals(id2)).ToList().ForEach(y => y.ID = newID);

                                Console.WriteLine("Дані відредаговані!!! ");
                                break;

                            case 2:
                                Console.WriteLine("Введіть редагування прізвища: ");
                                string newSur = Console.ReadLine();

                                empl.Where(x => x.Surname.Equals(Sur2)).ToList().ForEach(y => y.Surname = newSur);

                                Console.WriteLine("Дані відредаговані!!! ");
                                break;
                            //case 3:
                               
                                /* Console.WriteLine("Введіть редагування прізвища: ");
                                 string newName = Console.ReadLine();
                                 empl.Where(x => x.Name.Equals(Name)).ToList().ForEach(y => y.Surname = newSur);
                                 Console.WriteLine("Дані відредаговані!!! ");
                                 break;*/
                        }
                        break;

                        case 4:// Метод, який дозволяє видалити існуючого працівника
                        
                        
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
                            Console.WriteLine("Прочитати файл неможливо!!!");
                            Console.WriteLine(e.Message);
                        }

                        Console.WriteLine("Введіть прізвище працівника, якого Ви хочете видалити: ");
                        string Sur1 = Console.ReadLine();
                        Console.WriteLine("Введіть ID  працівника, якого Ви хочете видалити: ");
                        int id1 = Convert.ToInt32(Console.ReadLine());
                        var itemToDelete1 = empl.Where(x => x.Surname == Sur1 || x.ID == id1).Select(x => x);
                       
                       
                        foreach (var em in itemToDelete1)
                        {
                            Console.WriteLine(em.FIOToString());

                            Console.WriteLine("Ви підтверджуєте видалення працівника: \n" +
                           "-Так \n" +
                           "-Ні \n");
                            string del = Console.ReadLine();

                            if (del == "Так")
                            {
                                empl.Remove(em);
                                Console.WriteLine("Дані видалено!!!");
                            }
                            else
                                Console.WriteLine("Ви не підтвердили видалення!!!");
                        }
                       

                        Console.WriteLine("Count: {0}", empl.Count);

                        break;
                   
                        case 5: //Згенерувати звіт
                            Console.WriteLine("Введіть\n 1, якщо Ви хочете вивести дані працівників на екран " +
                                "і \n 2, якщо Ви хочете зберегти звіт у файл");
                           
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
                                Console.WriteLine("Прочитати файл неможливо!!!");
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
                            Console.WriteLine("Ви ввели неправильний запит!!!");
                            Console.ForegroundColor = color;

                        }
                            
                            break;

                        case 6:
                            alive = false;   // Вихід
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