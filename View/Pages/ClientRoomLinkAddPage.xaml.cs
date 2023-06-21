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
    /// Логика взаимодействия для ClientRoomLinkAddPage.xaml
    /// </summary>
    public partial class ClientRoomLinkAddPage : Page
    {
        Core db = new Core();

        public ClientRoomLinkAddPage()
        {
            InitializeComponent();
            PassportComboBox.ItemsSource = db.context.residents.ToList();
            PassportComboBox.DisplayMemberPath = "passport";
            PassportComboBox.SelectedValuePath = "passport";
            
            RoomLinkComboBox.ItemsSource = db.context.hotelrooms.ToList();
            RoomLinkComboBox.DisplayMemberPath = "number_room";
            RoomLinkComboBox.SelectedValuePath = "number_room";
        }

        private void ClientRoomLinkAddButton_Click(object sender, RoutedEventArgs e)
        {

            listresidents newlistres = new listresidents()
            {
                passport = PassportComboBox.SelectedValuePath,
                number_room = RoomLinkComboBox.SelectedValuePath,
                settlement_date = StartEnterRoomDatePicker.DisplayDate,
                eviction_date = StartEndRoomDatePicker.DisplayDate,

            };

            db.context.listresidents.Add(newlistres);
            db.context.SaveChanges();

            this.NavigationService.Navigate(new ClientRoomLinkPage());
            journal_table newJournal = new journal_table()
            {
                login_users = App.CurrentUser.login,
                journal_datetime = DateTime.Now,
                id_do_table = 15
            };
            db.context.journal_table.Add(newJournal);
            db.context.SaveChanges();
        }

        private void ClientRoomLinkAddBackAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClientRoomLinkPage());
        }

        private void PassportComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RoomLinkComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
