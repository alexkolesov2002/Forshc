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
    /// Логика взаимодействия для PgCheckHistory.xaml
    /// </summary>
    public partial class PgCheckHistory : Page
    {
        public PgCheckHistory()
        {
            InitializeComponent();
            ListHistory.ItemsSource = BaseConnect.BaseModel.History.ToList();
        }

        private void BtnOtvet_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void S_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (S.SelectedDate != null && PO.SelectedDate != null)

            {
                DateTime Po = (DateTime)PO.SelectedDate;
                Po = Po.AddDays(1);
                  ListHistory.ItemsSource= BaseConnect.BaseModel.History.Where(x=>x.dateaddr<= Po && x.dateaddr>= S.SelectedDate).ToList();
            }
        }

        private void PO_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (S.SelectedDate != null && PO.SelectedDate != null)

            {
                DateTime Po = (DateTime)PO.SelectedDate;
                Po = Po.AddDays(1);
                ListHistory.ItemsSource = BaseConnect.BaseModel.History.Where(x => x.dateaddr <= Po && x.dateaddr >= S.SelectedDate).ToList();
            }
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.GoBack();
        }

        private void BtnAddHistory_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(ListHistory, "Отчет");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Uid);
            History zapis = BaseConnect.BaseModel.History.FirstOrDefault(x => x.id == id);
            List<History> histories = (List<History>)ListHistory.ItemsSource;
            histories.Remove(zapis);
            ListHistory.ItemsSource = histories;
            ListHistory.Items.Refresh();
        }
    }
}
