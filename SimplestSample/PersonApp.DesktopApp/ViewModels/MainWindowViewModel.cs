using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalRecorder.Commands;
using PersonApp.DesktopApp.ViewFactories;
using PersonApp.Entities;
using PersonApp.Services;

namespace PersonApp.DesktopApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        IPersonService m_PersonService;
        Person m_SelectedPerson;
        IDialogFactory m_DialogFactory;

        public ObservableCollection<Person> Persons { get; private set; }

        public ICommand RefreshCommand { get; private set; }

        public ICommand AddCommand { get; private set; }

        public ICommand UpdateCommand { get; private set; }

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

        public MainWindowViewModel(IPersonService personService, IDialogFactory dialogFactory)
        {
            m_PersonService = personService;
            m_DialogFactory = dialogFactory;

            this.Persons = new ObservableCollection<Person>();

            this.RefreshCommand = new DelegateCommand<object>(executeRefreshCommand, null, "Refresh");
            this.AddCommand = new DelegateCommand<object>(executeAddCommand, null, "Add");
            this.UpdateCommand = new DelegateCommand<object>(executeUpdateCommand, null, "Update");
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
            var _window = m_DialogFactory.CreateAddEditPersonDialog(new AddEditPersonViewModel(m_PersonService, new Person() { Name = "", Surname = "" }));
            var _result = _window.ShowDialog();
            if(_result.HasValue && _result.Value)
            {
                executeRefreshCommand(null);
            }
        }

        private void executeUpdateCommand(object arg)
        {
            if (m_SelectedPerson != null)
            {
                var _window = m_DialogFactory.CreateAddEditPersonDialog(new AddEditPersonViewModel(m_PersonService, m_SelectedPerson));
                var _result = _window.ShowDialog();
                if (_result.HasValue && _result.Value)
                {
                    executeRefreshCommand(null);
                }
            }
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
