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
	/// Логика взаимодействия для ManagerRegistrationPage.xaml
	/// </summary>
	public partial class ManagerRegistrationPage : Page
	{
		Core db = new Core();
		public ManagerRegistrationPage()
		{
			InitializeComponent();
		}

		private void RegButton_Click(object sender, RoutedEventArgs e)
		{

			users newUser = new users()
			{
				last_name = LastNameRegTextBox.Text,
				first_name = FirstNameRegTextBox.Text,
				login = LoginRegTextBox.Text,
				pass = PassRegTextBox.Password,
				id_users_type = 1
			};

			db.context.users.Add(newUser);
			db.context.SaveChanges();
            this.NavigationService.Navigate(new ManagerListPage());
			journal_table newJournal = new journal_table()
			{
				login_users = App.CurrentUser.login,
				journal_datetime = DateTime.Now,
				id_do_table = 12
			};
			db.context.journal_table.Add(newJournal);
			db.context.SaveChanges();
		}

		private void BackRegButton_Click(object sender, RoutedEventArgs e)
		{
			this.NavigationService.Navigate(new ManagerListPage());
		}
    }
}
