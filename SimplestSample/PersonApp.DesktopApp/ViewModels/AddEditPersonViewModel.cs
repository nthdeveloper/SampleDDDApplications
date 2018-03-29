using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalRecorder.Commands;
using PersonApp.DesktopApp.ViewContracts;
using PersonApp.Entities;
using PersonApp.Services;

namespace PersonApp.DesktopApp.ViewModels
{
    public class AddEditPersonViewModel : ViewModelBase
    {
        IPersonService m_PersonService;

        public IWindowView View { get; set; }

        public string Title { get; private set; }
        public string NameText { get; private set; }
        public string SurnameText { get; private set; }

        public Person Person { get; private set; }

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public AddEditPersonViewModel(IPersonService personService, Person person)
        {
            m_PersonService = personService;
            this.Person = person;

            this.Title = person.Id > 0 ? "Edit Person-" + person.Name : "Add Person";
            this.NameText = "Name";
            this.SurnameText = "Surname";

            this.SaveCommand = new DelegateCommand<object>(executeSaveCommand, null, "Save");
            this.CancelCommand = new DelegateCommand<object>(executeCancelCommand, null, "Cancel");
        }

        private void executeSaveCommand(object arg)
        {
            //TODO: Validate person

            if (this.Person.Id == 0)//New person -> Add
            {
                if(m_PersonService.Add(this.Person) != null)
                {
                    this.View.Close(true);
                }
            }  
            else //Existing person -> Update
            {
                if (m_PersonService.Update(this.Person))
                {
                    this.View.Close(true);
                }
            }                      
        }

        private void executeCancelCommand(object arg)
        {
            this.View.Close(false);
        }        
    }
}
