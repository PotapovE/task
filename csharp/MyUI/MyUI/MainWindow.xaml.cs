using System;
using System.Collections.Generic;
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

namespace MyUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = UILogin.Text.Trim();
            string pass = UIPass.Password.Trim();
            string verPass = UIVerPass.Password.Trim();
            string email = UIEmail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                UILogin.ToolTip = "Введите корректный логин";
                UILogin.Background = Brushes.DarkGray;
            } 
            else if (pass.Length < 5)
            {
                UIPass.ToolTip = "Введите корректный пароль";
                UIPass.Background = Brushes.DarkGray;
            }
            else if (verPass != pass)
            {
                UIVerPass.ToolTip = "Пароли не совпадают";
                UIVerPass.Background = Brushes.DarkGray;
            }
            else if (email.Length < 5 || !email.Contains('@') || !email.Contains('.'))
            {
                UIEmail.ToolTip = "Введите корректный Email";
                UIEmail.Background = Brushes.DarkGray;
            }
            else
            {
                UILogin.ToolTip = "";
                UILogin.Background = Brushes.Transparent;
                UIPass.ToolTip = "";
                UIPass.Background = Brushes.Transparent;
                UIVerPass.ToolTip = "";
                UIVerPass.Background = Brushes.Transparent;
                UIEmail.ToolTip = "";
                UIEmail.Background = Brushes.Transparent;

                MessageBox.Show("Oks");
                User user = new User(login, pass, email);

                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
