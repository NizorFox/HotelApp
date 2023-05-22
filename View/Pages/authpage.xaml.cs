using HotelApp.Model;
using System;
using System.Collections.Generic;
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
using static HotelApp.MainWindow;

namespace HotelApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Core db = new Core();
      
        public AuthPage()
        {
            InitializeComponent();

    
        }
        
        private void LoginBbutton_Click(object sender, RoutedEventArgs e)
        {
           users activeUser=db.context.users.Where(x => x.login == LoginTextBox.Text && x.pass == pass.Password).FirstOrDefault();
            if (activeUser != null)
            {
                journal_table newJournal = new journal_table() { 
                    login_users = LoginTextBox.Text,
                    journal_datetime= DateTime.Now,
                    id_do_table=1
                };
                db.context.journal_table.Add(newJournal);
                db.context.SaveChanges();
                App.CurrentUser = activeUser;
                this.NavigationService.Navigate(new MainMenuPage());
            }

        }
    }
}
