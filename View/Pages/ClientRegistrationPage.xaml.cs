using HotelApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientRegistrationPage.xaml
    /// </summary>
    public partial class ClientRegistrationPage : Page
    {
        Core db = new Core();
        int check;
        public ClientRegistrationPage()
        {
            InitializeComponent();
        }

        private void ClientRegButton_Click(object sender, RoutedEventArgs e)
        {
            residents newResident = new residents()
            {
                passport = PassportRegClientTextBox.Text,
                last_name = LastNameRegClientTextBox.Text,
                first_name = FirstNameRegClientTextBox.Text,
                patronymic = PatronymicRegClientTextBox.Text,
                birth = BirthDateRegClientDate.DisplayDate,
                gend_id = check,
                address = AdressRegClientTextBox.Text,
                number_phone= NumberRegClientTextBox.Text,
                //scanpass = ScanRegClientTextBox.Text,
                destination = TargerRegClientTextBox.Text,
                info = HowRegClientTextBox.Text,
            };

            db.context.residents.Add(newResident);
            db.context.SaveChanges();
            this.NavigationService.Navigate(new ClientListPage());
            journal_table newJournal = new journal_table()
            {
                login_users = App.CurrentUser.login,
                journal_datetime = DateTime.Now,
                id_do_table = 14
            };
            db.context.journal_table.Add(newJournal);
            db.context.SaveChanges();
        }

        private void ClientBackRegButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClientListPage());
            journal_table newJournal = new journal_table()
            {
                login_users = App.CurrentUser.login,
                journal_datetime = DateTime.Now,
                id_do_table = 6
            };
            db.context.journal_table.Add(newJournal);
            db.context.SaveChanges();
        }

        private void MaleGender_Checked(object sender, RoutedEventArgs e)
        {
            check = 1;
        }

        private void FemaleGender_Checked(object sender, RoutedEventArgs e)
        {
            check = 2;
        }
    }
}
