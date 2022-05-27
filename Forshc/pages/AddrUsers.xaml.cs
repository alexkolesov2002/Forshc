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
using System.Windows.Shapes;

namespace Forshc
{
    /// <summary>
    /// Логика взаимодействия для AddrUsers.xaml
    /// </summary>
    public partial class AddrUsers : Window
    {
        public AddrUsers()
        {
            try
            {
                InitializeComponent();
                ComboRoles.ItemsSource = BaseConnect.BaseModel.Roles.ToList();
                ComboRoles.SelectedValuePath = "id_role";
                ComboRoles.DisplayMemberPath = "title_role";
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }




        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Users NewUser = new Users() { id_role = (int)ComboRoles.SelectedValue, login = TxtLogin.Text, password = TxtPassw.Text, Name = TxtName.Text };
                BaseConnect.BaseModel.Users.Add(NewUser);
                BaseConnect.BaseModel.SaveChanges();
                MessageBox.Show("Пользователь зарегистрирован!");
            }
            catch
            {
                MessageBox.Show("Ошибка создания пользователя");
            }


        }

        private void TopGr_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ex_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
