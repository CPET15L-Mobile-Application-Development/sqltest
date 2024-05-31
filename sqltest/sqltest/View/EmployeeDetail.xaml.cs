using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sqltest.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeDetail : ContentPage
    {
        public EmployeeDetail()
        {
            InitializeComponent();
        }
        Model.EmployeeModel _employee;
        public EmployeeDetail(Model.EmployeeModel employee)
        {
            InitializeComponent();
            Title = "Edit Information";
            _employee = employee;
            nameEntry.Text = _employee.Name;
            addressEntry.Text = _employee.Address;
            nameEntry.Focus();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameEntry.Text) || string.IsNullOrWhiteSpace(addressEntry.Text))
            {
                await DisplayAlert("Invalid", "Blank or Whitespace value is Invalid!", "OK");
            }else if (_employee != null)
            {
                UpdateEmployee();
            }
            else
                AddNewEmployee();



        }
        async void AddNewEmployee()
        {
            await App.MyDatabase.CreateEmployee(new Model.EmployeeModel
            {
                Name = nameEntry.Text,
                Address = addressEntry.Text
            });
            await Navigation.PopAsync();
        }
        async void UpdateEmployee()
        {
            _employee.Name = nameEntry.Text;
            _employee.Address = addressEntry.Text;
            await App.MyDatabase.UpdateEmployee(_employee);
            await Navigation.PopAsync();
        }
    }
}