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
	public partial class FullScreenPic : ContentPage
	{
		private FullScreenPicViewModel viewModel;

		public FullScreenPic (ImageSource picture)
		{
			InitializeComponent ();
			BindingContext = viewModel = new FullScreenPicViewModel(picture);
		}
	}
}