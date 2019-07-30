using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;



namespace WorkersSimpleCode
{
    #region Class Workers
    /*  
    public class Workers {
        public string Surname { get; set; } // �������
        public string Name { get; set; } // ��'�
        public string Patronymic { get; set; } // �� �������
        public string BirthDate { get; set; } // ���� ����������
        public string Unit { get; set; } // ϳ������
        public string Post { get; set; } // ������
        public string ID { get; set; } // ID
        public string Number { get; set; } // ��������� �����
        public string EMail { get; set; } // ���������� �����
        public string WorkJoin { get; set; } // ���� ��������� �� ������
        public  string RoomNumber { get; set; } // ����� ������
        public string Salary { get; set; } // ̳������ �����
        public string Notes { get; set; } // �������
        public Workers()
    {
    }
    public Workers(string surname, string name, string patronymic,
       string birthDate, string unit, string post, string id, string number,
       string email, string workjoin, string roomNumber, string salary,
       string notes)
    {
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
        BirthDate = birthDate;
        Unit = unit;
        Post = post;
        ID = id;
        Number = number;
        EMail = email;
        WorkJoin = workjoin;
        RoomNumber = roomNumber;
        Salary = salary;
        Notes = notes;
    }
        
        public void Info()
        {
           MessageBox.Show(  ("������� ����������: " + Surname + ", ��'� ����������: " + Name + ", �� ������� ����������: " + Patronymic
                + ", ���� ���������� ����������: "+ BirthDate + ", �������: " + Unit + ", ������:" + Post + ", ID: " + ID + ", ������� �����: "+
                Number + ", E-Mail: " + EMail + ", ���� ��������� �� ������: " + WorkJoin + ", ����� ������: " + RoomNumber + ", ������� �����: " +
                Salary + ", �������: " + Notes) );
        }
} */
    #endregion
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        public void ClearFields()
        {
            Surname.Clear();
            Name.Clear();
            Patronymic.Clear();
            Birthdate.Clear();
            Unit.Clear();
            Post.Clear();
            ID.Clear();
            Number.Clear();
            EMail.Clear();
            WorkJoin.Clear();
            RoomNumber.Clear();
            Salary.Clear();
            Notes.Clear();
        }
        private void AllInfo(object sender, RoutedEventArgs e)
        {
            //������ ������ ����������!
            string myConnection = "server=localhost;user=root;database=employees;password=;";
            string Query = "select * from employees.data";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(Query, myConn);
            myConn.Open();
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(myCommand);
            DataTable dTable = new DataTable("data");
            myAdapter.Fill(dTable);
            viewDataGrid.ItemsSource = dTable.DefaultView;
            myConn.Close();
        }
          

        private void Create(object sender, RoutedEventArgs e)
        {
            //������ ��������� ����������!
            string strconn = "server=localhost;user=root;database=employees;password=;";
            string Query = "insert into employees.data(Surname, Name, Patronymic, BirthDate, Unit, Post, ID, Number, Email, WorkJoin, RoomNumber, Salary, Notes) " +
                "values('" + Surname.Text + "','" + Name.Text + "','" + Patronymic.Text + "','" + Birthdate.Text + "','" + Unit.Text + "','" +
                Post.Text + "','" + ID.Text + "','" + Number.Text + "','" + EMail.Text + "','" + WorkJoin.Text + "','" +
                RoomNumber.Text + "','" + Salary.Text + "','" + Notes.Text + "')";
            MySqlConnection conn = new MySqlConnection(strconn);
            MySqlCommand myCommand = new MySqlCommand(Query, conn);
            MySqlDataReader myReader;
            conn.Open();
            myReader = myCommand.ExecuteReader();
            MessageBox.Show("��� ��������");
            while (myReader.Read()) { }
            conn.Close();

            this.ClearFields();
            
        }

        private void DeleteByID(object sender, RoutedEventArgs e)
        {
            
            try
            {
                string myConnection = "server=localhost; user=root;database=employees;password=;";
                string Query = "delete from employees.data where ID ='" + DoSomethingById.Text + "';";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand myCommand = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = myCommand.ExecuteReader();
                MessageBox.Show("��� ���� ������ �������");
                while (myReader.Read()) { }
                myConn.Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DoSomethingById.Clear();
            
        }

        private void EditByID(object sender, RoutedEventArgs e)
        {
            
            try
            {
                string MyConnection = "server=localhost;user=root;database=employees;password=;";
                string Query = "update employees.data set Surname='" + Surname.Text +
                    "',Name='" + Name.Text + "',Patronymic='" + Patronymic.Text +
                  "',BirthDate='" + Birthdate.Text + "',Unit='" + Unit.Text +
                  "',Post='" + Post.Text + "',ID='" + ID.Text +
                  "',Number='" + Number.Text + "',Email='" + EMail.Text +
                  "',WorkJoin='" + WorkJoin.Text + "',RoomNumber='" + RoomNumber.Text +
                  "',Salary='" + Salary.Text + "',Notes='" + Notes.Text + "'where ID='" + DoSomethingById.Text + "';";

                MySqlConnection myConn = new MySqlConnection(MyConnection);
                MySqlCommand myCommand = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = myCommand.ExecuteReader();
                MessageBox.Show("��� ������");
                while (myReader.Read()) { }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.ClearFields();
            DoSomethingById.Clear();
            
        }

        private void ViewSpecificInfo(object sender, RoutedEventArgs e)
        { ShowSpecificInfo s = new ShowSpecificInfo();
            
            string myConnection = "server=localhost;user=root;database=employees;password=;";
            string Query = "select * from employees.data where ID='" + DoSomethingById.Text + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(Query, myConn);
            myConn.Open();
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(myCommand);
            DataTable dTable = new DataTable("data");
            myAdapter.Fill(dTable);
            s.ShowSpecific.ItemsSource = dTable.DefaultView;
            myConn.Close();
            s.Show();
            DoSomethingById.Clear();
        }

        private void ShowAllDataInNewWindow(object sender, RoutedEventArgs e)
        {
            ViewAllDataWindow view = new ViewAllDataWindow();
            view.Show();
            string myConnection = "server=localhost;user=root;database=employees;password=;";
            string Query = "select * from employees.data";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(Query, myConn);
            myConn.Open();
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(myCommand);
            DataTable dTable = new DataTable("data");
            myAdapter.Fill(dTable);
            view.NewAllDataWindow.ItemsSource = dTable.DefaultView;
            myConn.Close();
        }
    }
}