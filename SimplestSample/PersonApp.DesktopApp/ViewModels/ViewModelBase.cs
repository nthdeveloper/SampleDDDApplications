using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp.DesktopApp.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var _ev = PropertyChanged;
            if (_ev != null)
                _ev(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
