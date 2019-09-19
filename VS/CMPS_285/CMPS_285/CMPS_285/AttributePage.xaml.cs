using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CMPS_285
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AttributePage : ContentPage
	{
        
		public AttributePage(int jobId,int ClientId, string joborEs, bool notCustomVisible)
		{
			InitializeComponent ();

            BindingContext = new AttributeCustomPageViewModel(Navigation, jobId, ClientId, joborEs, notCustomVisible);
        }


    }
}