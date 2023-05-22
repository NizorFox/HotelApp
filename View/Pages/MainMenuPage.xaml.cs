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
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
         Core db = new Core();
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void journalEvents_Click(object sender, RoutedEventArgs e)
        {
           
                journal_table newJournal = new journal_table()
                {
                    login_users = App.CurrentUser.login,
                    journal_datetime = DateTime.Now,
                    id_do_table = 2
                };
                db.context.journal_table.Add(newJournal);
                db.context.SaveChanges();
                this.NavigationService.Navigate(new JournalPage());
        }

        private void ManagerList_Click(object sender, RoutedEventArgs e)
        {
            journal_table newJournal = new journal_table()
            {
                login_users = App.CurrentUser.login,
                journal_datetime = DateTime.Now,
                id_do_table = 4
            };
            db.context.journal_table.Add(newJournal);
            db.context.SaveChanges();
            this.NavigationService.Navigate(new ManagerListPage());
        }

		private void ClientList_Click(object sender, RoutedEventArgs e)
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
    }
}
