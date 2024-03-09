using Lab02Prokopchuk.ViewModels;
using System;
using System.Windows.Controls;

namespace Lab02Prokopchuk.Views
{
    /// <summary>
    /// Interaction logic for UserDataView.xaml
    /// </summary>
    public partial class UserDataView : UserControl
    {
        private readonly UserDataViewModel _userDataViewModel;
        public UserDataView()
        {
            InitializeComponent();
            DataContext = _userDataViewModel = new UserDataViewModel();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? chosenDate = datePicker.SelectedDate;
            if (chosenDate != null)
                _userDataViewModel.Date = chosenDate.Value;
        }
    }
}
