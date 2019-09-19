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
	public partial class SoftDeletePage : TabbedPage
	{
		public SoftDeletePage ()
		{
			InitializeComponent ();

            BindingContext = new SoftDeleteViewModel(Navigation);

        }
	}
}