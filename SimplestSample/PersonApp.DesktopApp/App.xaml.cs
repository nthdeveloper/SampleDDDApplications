using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PersonApp.DesktopApp.Views;
using PersonApp.DesktopApp.ViewModels;
using PersonApp.Services;
using PersonApp.Persistence.EntityFramework;
using PersonApp.DesktopApp.ViewFactories;

namespace PersonApp.DesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            IPersonService _personService = new PersonService(new PersonRepository());
            IDialogFactory _dialogFactory = new DialogFactory();

            MainWindow _mainView = new MainWindow(new MainWindowViewModel(_personService, _dialogFactory));
            _mainView.Show();
        }
    }
}
