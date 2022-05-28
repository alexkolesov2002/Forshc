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
    /// Логика взаимодействия для Del.xaml
    /// </summary>
    public partial class Del : Window
    {
        Users user = new Users();
        public Del(Users CurrentUser)
        {
            InitializeComponent();
            user = CurrentUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new ChestList(user));
            this.Close();
        }

        private void TopGr_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void IdenTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(IdenTxt.Text);
                Chest c = BaseConnect.BaseModel.Chest.FirstOrDefault(x => x.Id == i );
                if (c != null)
                {
                    nameTxt.Text = c.Name;
                    DelBt.IsEnabled = true;
                }
                else
                {
                    nameTxt.Text = "Наименование оборудования";
                    DelBt.IsEnabled = false;
                }
            }
            catch
            {

            }
        }

        private void DelBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(IdenTxt.Text);
                Chest c = BaseConnect.BaseModel.Chest.FirstOrDefault(x => x.Id == i);
                BaseConnect.BaseModel.Chest.Remove(c);
                BaseConnect.BaseModel.SaveChanges();
                MessageBox.Show("Оборудование списано!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {

            }
        }
    }
}
