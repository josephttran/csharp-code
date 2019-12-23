using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApplication.DataAccess;
using WpfApplication.Models;

namespace WpfApplication.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        public ObservableCollection<PersonModel> People { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public bool IsPersonModelSelected => (SelectedPersonModel == null) ? false : true;

        private PersonModel _selectedPersonModel;

        public PersonModel SelectedPersonModel
        {
            get { return _selectedPersonModel; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _firstName, value.FirstName, "FirstName");
                    SetProperty(ref _lastName, value.LastName, "LastName");
                    SetProperty(ref _email, value.Email, "Email");
                }

                SetProperty(ref _selectedPersonModel, value);
            }
        }

        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        private string _email;

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        #region Constructor
        public PersonViewModel()
        {
            People = new ObservableCollection<PersonModel>();
            InitializePeople();

            CreateCommand = new RelayCommand(ExecuteCreate, CanExecuteCreate);
            UpdateCommand = new RelayCommand(ExecuteUpdate, CanExecuteUpdate);
        }
        #endregion

        #region Methods
        // Get data from mongodb collection and add to property people
        private async void InitializePeople()
        {
            PeopleRepository peopleRepository = new PeopleRepository();
            List<PersonModel> personList = await peopleRepository.GetAll();

            if (personList.Count > 0)
            {
                foreach (var person in personList)
                {
                    People.Add(person);
                }
            }
        }

        private bool CanExecuteCreate(object parameter)
        {
            return IsPersonModelSelected == false;
        }

        private bool CanExecuteUpdate(object parameter)
        {
            return IsPersonModelSelected == true;
        }

        private void ExecuteCreate(object parameter)
        {
            PersonModel personModel = new PersonModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email
            };

            PeopleRepository peopleRepository = new PeopleRepository();

            peopleRepository.CreatePerson(personModel);

            MessageBox.Show("Record created");
        }

        private void ExecuteUpdate(object parameter)
        {
            PersonModel personModel = new PersonModel
            {
                Id = SelectedPersonModel.Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email
            };

            PeopleRepository peopleRepository = new PeopleRepository();

            bool success = peopleRepository.UpdatePerson(personModel);

            if (success)
            {
                MessageBox.Show("Update successful");
            }
        }
        #endregion
    }
}
