using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApp.Entities;
using PersonApp.Services;

namespace PersonApp.DesktopApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        IPersonService m_PersonService;
        Person m_SelectedPerson;

        public ObservableCollection<Person> Persons { get; private set; }

        public Person SelectedPerson
        {
            get { return m_SelectedPerson; }
            set
            {
                m_SelectedPerson = value;
                RaisePropertyChanged(nameof(SelectedPerson));
            }
        }

        public MainWindowViewModel(IPersonService personService)
        {
            m_PersonService = personService;

            this.Persons = new ObservableCollection<Person>(m_PersonService.GetAll());
        }
    }
}
