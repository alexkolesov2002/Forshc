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
    /// Логика взаимодействия для Change.xaml
    /// </summary>
    public partial class Change : Window
    {
        public Change()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void TopGr_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(IdenTxt.Text);
                Chest c = BaseConnect.BaseModel.Chest.FirstOrDefault(x => x.Id == i);
                c.Kol_vo = kol_voTxt.Text;
                BaseConnect.BaseModel.SaveChanges();
                MessageBox.Show("Количество изменено!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {

            }
        }

        private void IdenTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(IdenTxt.Text);
                Chest c = BaseConnect.BaseModel.Chest.FirstOrDefault(x => x.Id == i);
                if (c != null)
                {
                    nameTxt.Text = c.Name;
                    ChangeBtn.IsEnabled = true;
                    kol_voTxt.Visibility = Visibility.Visible;
                    kol_voTxt.Text = c.Kol_vo;

                }
                else
                {
                    nameTxt.Text = "Наименование оборудования";
                    ChangeBtn.IsEnabled = false;
                    kol_voTxt.Visibility = Visibility.Hidden;

                }
            }
            catch { }
        }
    }
}
