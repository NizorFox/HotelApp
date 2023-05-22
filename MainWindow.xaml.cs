using HotelApp.Model;
using HotelApp.View.Pages;
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

namespace HotelApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Core db = new Core();
        public MainWindow()
        {
            InitializeComponent();
   MainFrame.Navigate(new AuthPage());
         
        }


        private void WindowClosed(object sender, EventArgs e)
        {
            if (App.CurrentUser != null)
            {
                journal_table newJournal = new journal_table()
                {
                    login_users = App.CurrentUser.login,
                    journal_datetime = DateTime.Now,
                    id_do_table = 3
                };
                db.context.journal_table.Add(newJournal);
                db.context.SaveChanges();
                App.CurrentUser = null;
            }
        }
    }
}
