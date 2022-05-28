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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        Users CurrentUser;
        public Menu(Users user)
        {
            InitializeComponent();
            LoadPages.MainFrame = FrameMain;
        
            BaseConnect.BaseModel = new Entities();
            this.CurrentUser = user;
            FrameMain.Navigate(new ChestList(CurrentUser));
            if (CurrentUser.id_role == 1)
            {
                BtnGoWinAddUser.Visibility = Visibility.Visible;
                del.Visibility = Visibility.Visible;
                ChangeCount.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TopGr_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Del().ShowDialog();
            FrameMain.Navigate(new ChestList(CurrentUser));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new AddNew().ShowDialog();
            FrameMain.Navigate(new ChestList(CurrentUser));

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new Change().ShowDialog();
            FrameMain.Navigate(new ChestList(CurrentUser));

        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new AddrUsers().ShowDialog();
            FrameMain.Navigate(new ChestList(CurrentUser));

        }
    }
}
