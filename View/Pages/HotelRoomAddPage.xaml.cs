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
    /// Логика взаимодействия для HotelRoomAddPage.xaml
    /// </summary>
    public partial class HotelRoomAddPage : Page
    {
        Core db = new Core();
        int check;

        public HotelRoomAddPage()
        {
            InitializeComponent();
            IDclassHotelRoomComboBox.ItemsSource = db.context.hotelroom_classes.ToList();
            IDclassHotelRoomComboBox.DisplayMemberPath = "class";
            IDclassHotelRoomComboBox.SelectedValuePath = "id_class";
        }

        private void HotelRoomAddButton_Click(object sender, RoutedEventArgs e)
        {
            hotelrooms newNumber = new hotelrooms()
            {
                number_room = HotelRoomNumberTextBox.Text,
                places = CountPlaceRoomTextBox.Text,
                rooms = CountHotelRoomTextBox.Text,
                id_class = IDclassHotelRoomComboBox.SelectedIndex + 1,
                id_bathroom = check,
                Equipment = EquipmentHotelRoomTextBox.Text,
                Count = PriceHotelRoomTextBox.Text
            };

            db.context.hotelrooms.Add(newNumber);
            db.context.SaveChanges();
            this.NavigationService.Navigate(new HotelRoomsPage());
            journal_table newJournal = new journal_table()
            {
                login_users = App.CurrentUser.login,
                journal_datetime = DateTime.Now,
                id_do_table = 13
            };
            db.context.journal_table.Add(newJournal);
            db.context.SaveChanges();
        }

        private void HotelRoomBackAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HotelRoomsPage());
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void YesBathroomRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            check = 3;
        }

        private void NoBathroomRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            check = 4;
        }

        private void IDclassHotelRoomComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
