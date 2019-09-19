using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CMPS_285
{
	public class ClientPictures : INotifyPropertyChanged
    {
		private int _id;

		[PrimaryKey, AutoIncrement]
		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				this._id = value;
				OnPropertyChanged(nameof(Id));
			}
		}


		public byte[] pictures;
        public byte[] Pictures { get { return pictures; } set { pictures = value; OnPropertyChanged("Pictures"); } }


        int clientId;

		[Indexed]
		public int ClientId { get { return clientId; } set { clientId = value; OnPropertyChanged("ClientId"); } }

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
