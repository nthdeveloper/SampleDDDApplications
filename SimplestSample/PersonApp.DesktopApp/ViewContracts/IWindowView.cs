using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp.DesktopApp.ViewContracts
{
    public interface IWindowView : IView
    {
        void Show();
        bool? ShowDialog();
        void Close(bool result);
    }
}
