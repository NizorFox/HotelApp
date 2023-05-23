using HotelApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Runtime.CompilerServices;

namespace HotelApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerListPage.xaml
    /// </summary>
    public partial class ManagerListPage : Page
    {

        Core db = new Core();
		List<users> user;
		int dofilt;

		public ManagerListPage()
        {
            InitializeComponent();
			FilterData();
			ManagerListView.ItemsSource = db.context.users.ToList();

		}


        private void ManagerListBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainMenuPage());
		}

		private void ManagerRegistration_Click(object sender, RoutedEventArgs e)
		{
			this.NavigationService.Navigate(new ManagerRegistrationPage());
			journal_table newJournal = new journal_table()
			{
				login_users = App.CurrentUser.login,
				journal_datetime = DateTime.Now,
				id_do_table = 5
			};
			db.context.journal_table.Add(newJournal);
			db.context.SaveChanges();
		}

		private void TypeManagerFilterComboBoxChanged(object sender, SelectionChangedEventArgs e)
		{
            dofilt = Convert.ToInt32(TypeManagerFilterComboBox.SelectedValue);
            FilterData();
        }



        private void FilterData()
        {
            var logfilt = LoginManFilterTextBox.Text.ToLower();
            user = db.context.users.ToList();
            if (logfilt != String.Empty)
            {
                user = user.Where(x => x.login.ToLower().StartsWith(logfilt)).ToList();
            }
            else
            {
                user = user.ToList();
            }
            if (TypeManagerFilterComboBox.SelectedItem != null)
            {
                user = user.Where(x => x.id_users_type == dofilt).ToList();

            }

            ManagerListView.ItemsSource = user;
        }

        private void LoginManFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            FilterData();
        }
    }
}
