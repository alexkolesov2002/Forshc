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

namespace Forshc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Users user = BaseConnect.BaseModel.Users.FirstOrDefault(x => x.login == LoginTxt.Text);
            string l = user.login;
            string p = user.password;
            try
            {
                if (LoginTxt.Text == l && PassTxt.Password == p)
                {
                    this.Hide();
                    Menu menu = new Menu(user);
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Логин или пароль неверный!");
                }
            }
            catch { }
        }
    }
}
