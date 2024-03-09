using Lab02Prokopchuk.Models;
using Lab02Prokopchuk.Tools;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
        private string _lastName;
        private string _email;
        private DateTime _date;

        private string _usersData = "";
        private bool _enableButton = true;
        public event PropertyChangedEventHandler? PropertyChanged;
        private RelayCommand<object> _proceedCommand;
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

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("Last name");
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

        public string UsersData
        {
            get { return _usersData; }
            set
            {
                _usersData = value;
                OnPropertyChanged("Information");
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
            UsersData = "";
            await Task.Run(() =>
            {
                Thread.Sleep(500);
                Person = new Person(Name, LastName, Email, Date);
                if (Person.CheckIfValidBD())
                    UsersData = Person.ToString();
                else
                    MessageBox.Show("Wrong data entered!");
                Thread.Sleep(500);
            });
        }

        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(Name)
                && !string.IsNullOrWhiteSpace(LastName)
                && !string.IsNullOrWhiteSpace(Email)
                && Date != DateTime.MinValue;
        }

        public RelayCommand<object> ProceedCommand
        {
            get { return _proceedCommand ??= new RelayCommand<object>(InformationProceedCommand, _ => CanExecute()); }
        }

        public void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }
    }
}
