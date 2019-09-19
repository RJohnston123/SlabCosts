using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace CMPS_285
{
	public class FullScreenPicViewModel : INotifyPropertyChanged
	{
		public ImageSource pic;

		public event PropertyChangedEventHandler PropertyChanged;

		public ImageSource Pic { get { return pic; } set { pic = value; OnPropertyChanged("Pic"); } }

		public FullScreenPicViewModel(ImageSource picture)
		{
			Pic = picture;
		}

		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
