using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalRecorder.Commands;
using PersonApp.Entities;
using PersonApp.Services;

namespace PersonApp.DesktopApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        IPersonService m_PersonService;
        Person m_SelectedPerson;

        public ObservableCollection<Person> Persons { get; private set; }

        public ICommand RefreshCommand { get; private set; }

        public ICommand AddCommand { get; private set; }

        public ICommand RemoveCommand { get; private set; }        

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

            this.Persons = new ObservableCollection<Person>();

            this.RefreshCommand = new DelegateCommand<object>(executeRefreshCommand, null, "Refresh");
            this.AddCommand = new DelegateCommand<object>(executeAddCommand, null, "Add");
            this.RemoveCommand = new DelegateCommand<object>(executeRemoveCommand, null, "Remove");

            executeRefreshCommand(null);
        }

        private void executeRefreshCommand(object arg)
        {
            this.Persons.Clear();

            var _allPersons = m_PersonService.GetAll();
            foreach (var person in _allPersons)
                this.Persons.Add(person);
        }

        private void executeAddCommand(object arg)
        {

        }

        private void executeRemoveCommand(object arg)
        {
            if(m_SelectedPerson != null)
            {
                if (m_PersonService.Remove(m_SelectedPerson.Id))
                    Persons.Remove(m_SelectedPerson);
            }
        }              
    }
}
