using Lab02Prokopchuk.Models;
using Lab02Prokopchuk.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Lab02Prokopchuk.ViewModels
{
    class UserDataViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Person _person;
        private string _name;
        private string _lastname;
        private string _email;
        private DateTime _date;

        private string _userdata = "";
        private bool _enableButton = true;
        private RelayCommand<object> _proceedCommand;
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged("Lastname");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged("Person");
            }
        }

        public string UserData
        {
            get { return _userdata; }
            set
            {
                _userdata = value;
                OnPropertyChanged("UserData");
            }
        }

        public bool ProceedEnabled
        {
            get { return _enableButton; }
            set
            {
                _enableButton = value;
                OnPropertyChanged("ProceedEnabled");
            }
        }
        #endregion

        private async void InformationProceedCommand(object obj)
        {
            UserData = "";
            await Task.Run(() =>
            {
                Thread.Sleep(500);
                Person = new Person(Name, Surname, Email, Date);
                if (Person.CheckIfValidBD())
                    UserData = Person.ToString();
                else
                    MessageBox.Show("Wrong data entered!");
                Thread.Sleep(500);
            });
        }

        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(Name)
                && !string.IsNullOrWhiteSpace(Surname)
                && !string.IsNullOrWhiteSpace(Email)
                && Date != DateTime.MinValue;
        }

        public RelayCommand<object> ProceedCommand
        {
            get
            { 
                return _proceedCommand ??= new RelayCommand<object>(InformationProceedCommand, _ => CanExecute()); 
            }
        } 

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
