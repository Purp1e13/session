using MySql.Data.MySqlClient;

using System.Data;

using System.Windows;

namespace session
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string login, password;
        public MySqlCommand command;
        public MySqlConnection connect;
        public string connection = "server = 127.0.0.1;port = 3306;username=root;password=1234;database=test";
        public MainWindow()
        {
            InitializeComponent();
            DBLoad();
        }

        public void DBLoad()
        {
            try
            {
                string script = "Select * from test";
                connect = new MySqlConnection(connection);
                connect.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(script, connect);
                DataTable table = new DataTable();
                adapter.Fill(table);
                DG_Text.ItemsSource = table.DefaultView;
                connect.Close();
            }
            catch
            {
                MessageBox.Show("Чтото не так");
            }
        }
        private void ConBut_Click(object sender, RoutedEventArgs e)
        {
            login = TB_Login.Text;
            try
            {
                string script = $"update test set login = '23' where login='{login}'";
                connect = new MySqlConnection(connection);
                connect.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(script, connect);
                DataTable table = new DataTable();
                adapter.Fill(table);
                DG_Text.ItemsSource = table.DefaultView;
                DBLoad();
            }
            catch
            {
                MessageBox.Show("Чтото не так");
            }
        }

        private void DG_Select(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void DoBut_Click(object sender, RoutedEventArgs e)
        {
            login = TB_Login.Text;
            password = PB_Password.Password;

            DB db = new DB();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            command = new MySqlCommand("Select * from test.test Where login = @ul && password=@uP", db.GetConnection());
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;
            command.Parameters.AddWithValue("@uL", login);
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь есть");
            }
            else { MessageBox.Show("Пользователь не найден"); }
        }
    }
}
