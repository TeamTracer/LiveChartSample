using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCaliburnDemo.Models;

namespace WpfCaliburnDemo.ViewModels
{
    public class HomeViewModel : Conductor<Object>
    {
        private string _firstName;
        private string _lastName;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;

        public HomeViewModel()
        {
            ActivateItem(new PieChartViewModel());
        }

        public void PieChart()
        {
            ActivateItem(new PieChartViewModel());
        }

        public void MaterialDesign()
        {
            ActivateItem(new MaterialDesignViewModel());
        }

        public void BasicColumn()
        {
            ActivateItem(new BasicColumnViewModel());
        }

        public void StackedArea()
        {
            ActivateItem(new StackedAreaViewModel());
        }

        public void DoughnutChart()
        {
            ActivateItem(new DoughnutChartViewModel());
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get { return $"{ FirstName } { LastName }"; }
        }

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public void ClearText(string firstName, string lastName)
        {
            FirstName = null;
            LastName = null;
        }
    }
}
