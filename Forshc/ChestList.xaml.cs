using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для ChestList.xaml
    /// </summary>
    public partial class ChestList : Page, INotifyPropertyChanged
    {
        VModel VM = new VModel();
        List<Chest> chests;
        Users CurentUsers;
        List<Chest> CartChests = new List<Chest>();

        public event PropertyChangedEventHandler PropertyChanged;

        public int CountInCart { get; set; }

        public ChestList(Users cu)
        {
            try
            {
               
               InitializeComponent();
                Myperem.ListBigChest = Myperem.ListBigChest.OrderBy(x => x.Id).ToList();
                ListC.ItemsSource = BaseConnect.BaseModel.Chest.ToList();
                ListC.Items.Refresh();
                CountInCart = Myperem.ListLittleChest.Count;
                PropertyChanged(this, new PropertyChangedEventArgs("CountInCart"));
                CurentUsers = cu;
                if (cu.id_role == 2)
                {
                    Bange.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
            }
            }

        private void SearchTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter();
        }

        private void SortTxt1_Click(object sender, RoutedEventArgs e)
        {
            if (SortTxt1.Content == "Сортировка по Id ↑")
            {
                SortTxt1.Content = "Сортировка по Id ↓";
                SortTxt2.Content = "Сортировка по использованию";
            }
            else
            {
                SortTxt2.Content = "Сортировка по использованию";
                SortTxt1.Content = "Сортировка по Id ↑";
            }


            filter();
        }

        private void SortTxt2_Click(object sender, RoutedEventArgs e)
        {
            if (SortTxt2.Content == "Сортировка по использованию ↑")
            {
                SortTxt2.Content = "Сортировка по использованию ↓";
                SortTxt1.Content = "Сортировка по Id";
            }
            else
            {
                SortTxt2.Content = "Сортировка по использованию ↑";
                SortTxt1.Content = "Сортировка по Id";
            }
            filter();
        }

        public void filter()
        {

            chests = VM.chest;
            ListC.ItemsSource = chests;

            try
            {
                if (SortTxt1.Content == "Сортировка по Id ↑")
                {
                    chests = chests.OrderBy(x => x.Id).ToList();
                }
                else
                {
                    chests = chests.OrderBy(x => x.Id).ToList();
                    chests.Reverse();
                }

                if (SortTxt2.Content == "Сортировка по использованию ↑")
                {
                    chests = chests.OrderBy(x => x.isp).ToList();
                }
                else if (SortTxt2.Content == "Сортировка по использованию ↓")
                {
                    chests = chests.OrderBy(x => x.isp).ToList();
                    chests.Reverse();
                }
            }
            catch { }

            try
            {
                chests = chests.Where(x => x.Name.Contains(SearchTxt.Text)).ToList();
            }
            catch { }

            ListC.ItemsSource = chests;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Uid);
            new Cart(id, CurentUsers).ShowDialog();

        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (CurentUsers.id_role == 2)
            {
                button.Visibility = Visibility.Collapsed;
            }

        }

        private void AddCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Uid);
            Chest chest = BaseConnect.BaseModel.Chest.FirstOrDefault(x=>x.Id == id );
            Myperem.ListLittleChest.Add(chest);

            Myperem.ListBigChest  = (List<Chest>) ListC.ItemsSource;
            Myperem.ListBigChest.Remove(chest);
            CountInCart = Myperem.ListLittleChest.Count;
            PropertyChanged(this, new PropertyChangedEventArgs("CountInCart"));
            ListC.ItemsSource = Myperem.ListBigChest;
            ListC.Items.Refresh();



        }

        private void BtnGoCarteAll_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new PgCartForQuery( CurentUsers));
        }

        private void AddCart_Loaded(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (CurentUsers.id_role == 1)
            {
                button.Visibility = Visibility.Collapsed;
            }
        }
    }
}
