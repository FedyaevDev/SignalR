using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp49.ViewModels;
using WpfApp49.Views;

namespace WpfApp49
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            HubConnection _hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7239/chat").Build();

            MainWindow window = new MainWindow
            {
                DataContext = MainViewModel.CreateMainViewModel(new Services.ChatService(_hubConnection))
            };


            window.Show();
        }

    }
}
