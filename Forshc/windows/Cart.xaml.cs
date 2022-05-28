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
    /// Логика взаимодействия для Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        Users user;
        int i = 0;
        public Cart(int ident, Users users)
        {
            InitializeComponent();
            user = users;
            i = ident;
            Chest chest = BaseConnect.BaseModel.Chest.FirstOrDefault(x => x.Id == ident);
            IdenTxt.Text = chest.Id.ToString();
            nameTxt.Text = chest.Name.ToString();
            kol_voTxt.Text = chest.Kol_vo.ToString();
            if(chest.isp.ToString().Contains("Не"))
            {
                ispcm.SelectedIndex = 1;
            }
            else
            {
                ispcm.SelectedIndex = 0;
            }
        }




        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Chest chest = BaseConnect.BaseModel.Chest.FirstOrDefault(x => x.Id == i);
            chest.Name = nameTxt.Text;
            chest.Kol_vo = kol_voTxt.Text;
            if (ispcm.SelectedIndex == 0)
            {
                chest.isp = "Используется";
            }
            else
            {
                chest.isp = "Не используется";
            }
            BaseConnect.BaseModel.SaveChanges();
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
    }
}
