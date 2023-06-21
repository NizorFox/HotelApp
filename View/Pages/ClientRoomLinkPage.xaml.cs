using HotelApp.Model;
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

namespace HotelApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientRoomLinkPage.xaml
    /// </summary>
    public partial class ClientRoomLinkPage : Page
    {
        Core db = new Core();
        List<listresidents> listresidents;

        public ClientRoomLinkPage()
        {
            InitializeComponent();
            ClientRoomListView.ItemsSource = db.context.listresidents.ToList();
        }

        private void ClientRoomBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClientListPage());
        }

        private void ClientRoomRegButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClientRoomLinkAddPage());
            journal_table newJournal = new journal_table()
            {
                login_users = App.CurrentUser.login,
                journal_datetime = DateTime.Now,
                id_do_table = 11
            };
            db.context.journal_table.Add(newJournal);
            db.context.SaveChanges();
        }

        private void ClientRoomDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int idlistres = Convert.ToInt32((sender as Button).Tag.ToString());
            var clientroom = db.context.listresidents.Where(x => x.id_listres == idlistres).First();
            db.context.listresidents.Remove(clientroom);
            db.context.SaveChanges();
            ClientRoomListView.ItemsSource = db.context.listresidents.ToList();
            journal_table newJournal = new journal_table()
            {
                login_users = App.CurrentUser.login,
                journal_datetime = DateTime.Now,
                id_do_table = 18
            };
            db.context.journal_table.Add(newJournal);
            db.context.SaveChanges();
        }

        private void LoginManRoomFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterData();
        }

        private void FilterData()
        {
            var roomfilt = LoginManRoomFilterTextBox.Text.ToLower();
            listresidents = db.context.listresidents.ToList();
            if (roomfilt != String.Empty)
            {
                listresidents = listresidents.Where(x => x.number_room.ToLower().StartsWith(roomfilt)).ToList();
            }
            else
            {
                listresidents = listresidents.ToList();
            }

            ClientRoomListView.ItemsSource = listresidents;
        }
    }
}
