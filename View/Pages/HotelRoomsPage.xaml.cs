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
    /// Логика взаимодействия для HotelRoomsPage.xaml
    /// </summary>
    public partial class HotelRoomsPage : Page
    {
        Core db = new Core();

        public HotelRoomsPage()
        {
            InitializeComponent();
            HotelRoomsListView.ItemsSource = db.context.hotelrooms.ToList();
        }

        private void NumberRoomFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RoomListBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainMenuPage());
        }

        private void HotelRoomDelete_Click(object sender, RoutedEventArgs e)
        { 
            int idRoom = Convert.ToInt32((sender as Button).Tag.ToString());
            var room = db.context.hotelrooms.Where(x => x.id_room == idRoom).First();
            db.context.hotelrooms.Remove(room);
            db.context.SaveChanges();
            HotelRoomsListView.ItemsSource = db.context.hotelrooms.ToList();

        }

        private void RoomAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HotelRoomAddPage());
            journal_table newJournal = new journal_table()
            {
                login_users = App.CurrentUser.login,
                journal_datetime = DateTime.Now,
                id_do_table = 9
            };
            db.context.journal_table.Add(newJournal);
            db.context.SaveChanges();
        }
    }
}
