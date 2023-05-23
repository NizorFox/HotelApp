﻿using HotelApp.Model;
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
		public ClientListPage()
		{
			InitializeComponent();
			ClientListView.ItemsSource = db.context.residents.ToList();
		}

		private void ClientListBack_Click(object sender, RoutedEventArgs e)
		{
			this.NavigationService.Navigate(new MainMenuPage());
		}

        private void LoginManFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TypeManagerFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
