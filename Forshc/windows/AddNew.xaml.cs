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
    /// Логика взаимодействия для AddNew.xaml
    /// </summary>
    public partial class AddNew : Window
    {
        Users user;
        public AddNew(Users CurrentUser)
        {
            user = CurrentUser;
            InitializeComponent();
            ispBt.SelectedIndex = 0;
            StatusCB.SelectedIndex = 0;
        }

        private void TopGr_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new ChestList(user));
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameTxt.Text == "" && kolvoTxt.Text == "")
                {
                    MessageBox.Show("Необходимо заполнить поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Chest chest = new Chest() { isp = ispBt.Text, Status = StatusCB.Text, Kol_vo = kolvoTxt.Text, Name = NameTxt.Text };
                    BaseConnect.BaseModel.Chest.Add(chest);
                    BaseConnect.BaseModel.SaveChanges();

                    MessageBox.Show("Оборудование добавлено!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch { }
        }
    }
}
