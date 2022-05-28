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
    /// Логика взаимодействия для PgCartForQuery.xaml
    /// </summary>
    public partial class PgCartForQuery : Page
    {
        List<Chest> CartChest = new List<Chest>();
        Users CurrentUser;
        public PgCartForQuery(List<Chest> CartChest, Users CurrentUser)

        {
            InitializeComponent();
            this.CartChest = CartChest;
            ListC.ItemsSource = CartChest;
            this.CurrentUser = CurrentUser;

        }

        private void CountPLus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                int id = Convert.ToInt32(button.Uid);
                List<Chest> ListForPlus = new List<Chest>();
                ListForPlus = (List<Chest>)ListC.ItemsSource;
                Chest chest = ListForPlus.FirstOrDefault(x => x.Id == id);
                if (chest.CountChest + 1 > Convert.ToInt32(chest.Kol_vo))
                {
                    throw new Exception("Убило меня сильно");
                }
                chest.CountChest += 1;


                ListC.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        private void CountMinus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                int id = Convert.ToInt32(button.Uid);
                List<Chest> ListForPlus = new List<Chest>();
                ListForPlus = (List<Chest>)ListC.ItemsSource;
                Chest chest = ListForPlus.FirstOrDefault(x => x.Id == id);
                if (chest.CountChest == 0)
                {
                    throw new Exception("Убило меня сильно");
                }
                chest.CountChest -= 1;


                ListC.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new ChestList(CurrentUser));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Uid);
            Myperem.ListBigChest.Add(CartChest.FirstOrDefault(x => x.Id == id));
            CartChest.Remove(CartChest.FirstOrDefault(x => x.Id == id));
            ListC.Items.Refresh();
        }
    }
}
