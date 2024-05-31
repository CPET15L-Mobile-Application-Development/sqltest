using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sqltest.View;
using sqltest.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Runtime.InteropServices.ComTypes;

namespace sqltest.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeePage : ContentPage
    {
        public EmployeePage()
        {
            InitializeComponent();
        }
        protected  override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                
                myCollectionView.ItemsSource = await App.MyDatabase.ReadEmployees();
            } catch { }
            
        }

       async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmployeeDetail());
        }

        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as EmployeeModel;
            await Navigation.PushAsync(new EmployeeDetail(emp));
        }

        async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as EmployeeModel;
            var result = await DisplayAlert("Delete",$"Delete {emp.Name} from the database","Yes","No");
            if (result)
            {
                await App.MyDatabase.DeleteEmployee(emp);
                myCollectionView.ItemsSource = await App.MyDatabase.ReadEmployees(); 
            }
        }

        async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            myCollectionView.ItemsSource = await App.MyDatabase.Search(e.NewTextValue);
        }
    }
}