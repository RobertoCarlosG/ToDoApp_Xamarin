using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.App.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList.App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadItemsAsync();
        }

        private async Task LoadItemsAsync()
        {
            var items = await App.Context.GetItemsAsync();
            lista_tareas.ItemsSource = items;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private async void Btn_delete_Clicked(object sender, EventArgs e)
        {
            if(await DisplayAlert("Confirmacion", "¿Estas seguro que deseas eliminar el elemento?", "Si", "No"))
            {
                var item = (ToDoItem)(sender as MenuItem).CommandParameter;
                var result = await App.Context.DeleteItemAsync(item);
                if(result == 1)
                {
                    LoadItemsAsync();
                }
            }
        }
    }
}