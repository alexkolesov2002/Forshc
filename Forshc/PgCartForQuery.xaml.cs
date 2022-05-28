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

        Users CurrentUser;
        public PgCartForQuery(Users CurrentUser)

        {
            InitializeComponent();

            ListC.ItemsSource = Myperem.ListLittleChest;
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
            try
            {
                Button button = (Button)sender;
                int id = Convert.ToInt32(button.Uid);
                Myperem.ListBigChest.Add(Myperem.ListLittleChest.FirstOrDefault(x => x.Id == id));
                Myperem.ListLittleChest.Remove(Myperem.ListLittleChest.FirstOrDefault(x => x.Id == id));
                ListC.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void BtnAddHistory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (Chest chest in Myperem.ListLittleChest)
                {
                    History history = new History() { count = chest.CountChest, idChest = chest.Id, idUsers = CurrentUser.id, dateaddr = DateTime.Now };
                    BaseConnect.BaseModel.History.Add(history);
                }
                BaseConnect.BaseModel.SaveChanges();

                MessageBox.Show("Заявка успешно составлена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                  Myperem.ListBigChest = BaseConnect.BaseModel.Chest.ToList();
                Myperem.ListLittleChest = new List<Chest>();
                LoadPages.MainFrame.GoBack();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
