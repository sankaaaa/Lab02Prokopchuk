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
        private readonly UserDataViewModel _viewModel;
        public UserDataView()
        {
            InitializeComponent();
            DataContext = _viewModel = new UserDataViewModel();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? chosenDate = datePicker.SelectedDate;
            if (chosenDate != null)
                _viewModel.Date = chosenDate.Value;
        }
    }
}
