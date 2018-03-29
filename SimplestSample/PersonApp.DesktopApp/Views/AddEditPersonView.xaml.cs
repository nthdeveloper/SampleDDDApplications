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
using System.Windows.Shapes;
using PersonApp.DesktopApp.ViewContracts;
using PersonApp.DesktopApp.ViewModels;

namespace PersonApp.DesktopApp.Views
{
    /// <summary>
    /// Interaction logic for AddEditPersonView.xaml
    /// </summary>
    public partial class AddEditPersonView : Window, IAddEditPersonView
    {
        AddEditPersonViewModel m_ViewModel;

        public AddEditPersonView(AddEditPersonViewModel viewModel)
        {
            InitializeComponent();

            m_ViewModel = viewModel;
            m_ViewModel.View = this;
            this.DataContext = viewModel;
        }

        public void Close(bool result)
        {
            this.DialogResult = result;
            this.Close();
        }
    }
}
