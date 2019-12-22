using System.Collections.Generic;
using System.Collections.ObjectModel;

using WpfApplication.DataAccess;
using WpfApplication.Models;

namespace WpfApplication.ViewModels
{
    public class PersonViewModel
    {
        public ObservableCollection<PersonModel> People { get; set; }
        public PersonModel SelectedPersonModel { get; set; }

        public PersonViewModel()
        {
            People = new ObservableCollection<PersonModel>();
            InitializePeople();
        }

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
    }
}
