using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CMPS_285
{
    public partial class MainPage : TabbedPage
    {       
        private MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();          

            BindingContext = viewModel = new MainPageViewModel(Navigation);
		}


        protected override void OnAppearing(){
            viewModel.RefreshList();
		}


		/*KEEP FOR NOW, WILL PROBABLY DELETE LATER, IM KEEPING THIS FOR REFERENCE DOWN THE ROAD
        public void OnMore(object sender, EventArgs e)
        {

            var menuItem = sender as MenuItem;

            var clientInfo = menuItem.CommandParameter as ClientName;

            var getInfo = BindingContext as MainPageViewModel;
             
            var clientIndexID = getInfo.GetClientInfo(clientInfo);

            Navigation.PushAsync(editPages[clientIndexID]);


        }
        
        public void OnDelete(object sender, EventArgs e)
        {

            var menuItem = sender as MenuItem;

            var estItem = menuItem.CommandParameter as ClientName;

            var remove = BindingContext as MainPageViewModel;

            var clientIndexID = remove.GetClientInfo(estItem);            

            editPages.RemoveAt(clientIndexID);

            remove.RemoveClient(estItem);

            DisplayAlert("Client", estItem.Name + " has been removed!", "OK");
            
        }

        private void Add_Button(object sender, EventArgs e)
        {
            clientsName.Text = string.Empty;

            clientsNumber.Text = string.Empty;

            popupLoginView.IsVisible = true;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var add = BindingContext as MainPageViewModel;

            var name = BindingContext as MainPageViewModel;

            var address = BindingContext as MainPageViewModel;

            //name.name = clientsName.Text;

            //address.address = clientsNumber.Text;

            add.AddClient();

            popupLoginView.IsVisible = false;

            clientInfoPages.Add(new ClientInfoPage(clientsName.Text, clientsNumber.Text));

            editPages.Add(new EditPage());//TODO fix date formate!

        }

        private void OnClient(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;

            var clientInfo = menuItem.CommandParameter as ClientName;

            var getInfo = BindingContext as MainPageViewModel;

            var clientIndexID = getInfo.GetClientInfo(clientInfo);

            Navigation.PushAsync(clientInfoPages[clientIndexID]);
        }*/

	}
}
