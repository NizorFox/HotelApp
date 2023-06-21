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
	/// Логика взаимодействия для ClientListPage.xaml
	/// </summary>
	public partial class ClientListPage : Page
	{
		Core db = new Core();
        List<residents> residents;



		public ClientListPage()
		{
			InitializeComponent();

			ClientListView.ItemsSource = db.context.residents.ToList();

        }

		private void ClientListBack_Click(object sender, RoutedEventArgs e)
		{
			this.NavigationService.Navigate(new MainMenuPage());
		}

        private void PassportManFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterData();
        }

        private void LoginManFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterData();
        }



        private void ClientRegClick_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClientRegistrationPage());
            journal_table newJournal = new journal_table()
            {
                login_users = App.CurrentUser.login,
                journal_datetime = DateTime.Now,
                id_do_table = 7
            };
            db.context.journal_table.Add(newJournal);
            db.context.SaveChanges();
        }

        private void FilterData()
        {
            var passfilt = PassportManFilterTextBox.Text.ToLower();
            residents = db.context.residents.ToList();
            if (passfilt != String.Empty)
            {
                residents = residents.Where(x => x.passport.ToLower().StartsWith(passfilt)).ToList();
            }
            else
            {
                residents = residents.ToList();
            }

            var lastnamefilt = LoginManFilterTextBox.Text.ToLower();
            residents = db.context.residents.ToList();
            if (lastnamefilt != String.Empty)
            {
                residents = residents.Where(x => x.last_name.ToLower().StartsWith(lastnamefilt) || x.first_name.ToLower().StartsWith(lastnamefilt) || x.patronymic.ToLower().StartsWith(lastnamefilt)).ToList();
            }
            else
            {
                residents = residents.ToList();
            }

            ClientListView.ItemsSource = residents;
        }

        private void ClientDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string idPassport = Convert.ToString((sender as Button).Tag.ToString());
            var client = db.context.residents.Where(x => x.passport == idPassport).First();
            db.context.residents.Remove(client);
            db.context.SaveChanges();
            ClientListView.ItemsSource = db.context.residents.ToList();
            journal_table newJournal = new journal_table()
            {
                login_users = App.CurrentUser.login,
                journal_datetime = DateTime.Now,
                id_do_table = 16
            };
            db.context.journal_table.Add(newJournal);
            db.context.SaveChanges();
        }

        private void PickClientHotelRoomComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ClientRoomClick_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClientRoomLinkPage());
            journal_table newJournal = new journal_table()
            {
                login_users = App.CurrentUser.login,
                journal_datetime = DateTime.Now,
                id_do_table = 10
            };
            db.context.journal_table.Add(newJournal);
            db.context.SaveChanges();
        }
    }
}
