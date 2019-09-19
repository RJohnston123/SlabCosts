using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CMPS_285
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPage : ContentPage
	{

        
        private EditPageViewModel viewModel;
        public EditPage(int clientId, string clientOrEstimate)
        {
            InitializeComponent();

			NavigationPage.SetHasBackButton(this, false);
			BindingContext = viewModel = new EditPageViewModel(Navigation, clientId, clientOrEstimate);
        }


        protected override void OnAppearing()
        {
            viewModel.RefreshList();
        }
	}
}

