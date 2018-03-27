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
using PersonApp.DesktopApp.ViewModels;
using PersonApp.Persistence.EntityFramework;

namespace PersonApp.DesktopApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel m_ViewModel;

        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();

            m_ViewModel = viewModel;

            this.DataContext = viewModel;
        }        
    }
}
