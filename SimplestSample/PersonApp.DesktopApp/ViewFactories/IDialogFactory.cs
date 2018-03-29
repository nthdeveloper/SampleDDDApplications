using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApp.DesktopApp.ViewContracts;
using PersonApp.DesktopApp.ViewModels;
using PersonApp.DesktopApp.Views;

namespace PersonApp.DesktopApp.ViewFactories
{
    public interface IDialogFactory
    {
        IWindowView CreateAddEditPersonDialog(AddEditPersonViewModel model);
    }
}
