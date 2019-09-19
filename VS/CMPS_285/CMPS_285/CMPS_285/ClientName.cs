using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using CMPS_285;
using Plugin.Media.Abstractions;
using SQLite;
using Xamarin.Forms;

namespace CMPS_285
{
    [Table("table_name")]
    public class ClientName : INotifyPropertyChanged
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

        public string color = "#9907e921";
        public bool isSoftDeleted;//here
        public string name;
        public string estimateName;
        public string address;
        public string phoneNum;
		public string formattedPhone;
        public string email;
        public string description;
        public string completeTotal;
		public string formattedTotal;
		public double jobSize;
        public string colorText = "Green";
		public double colorValue = 1;
		public string status = "PENDING";
		public string statusColor = Constants.statusPENDING;
		public byte[] pictures;

		public string total = "0";

        public string ColorText { get { return colorText; } set { colorText = value; OnPropertyChanged("ColorText"); } }
        public string Color { get { return color; } set { color = value; OnPropertyChanged("Color"); } }
        public bool IsSoftDeleted { get { return isSoftDeleted; } set { isSoftDeleted = value; OnPropertyChanged("IsSoftDeleted"); } }//here
        public string EstimateName { get { return estimateName; } set { estimateName = value; OnPropertyChanged("EstimateName"); } }
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public string Address { get { return address; } set { address = value; OnPropertyChanged("Address"); } }
        public string PhoneNumber { get { return phoneNum; } set { phoneNum = value; OnPropertyChanged("PhoneNumber"); } }
		public string FormattedPhone { get { return formattedPhone; } set { formattedPhone = value; OnPropertyChanged("FormattedPhone"); } }
		public string Email { get { return email; } set { email = value; OnPropertyChanged("Email"); } }
        public string Description { get { return description; } set { description = value; OnPropertyChanged("Description"); } }
        public string Totaler { get { return total; } set { total = value; OnPropertyChanged("Totaler"); } }
        public string CompleteTotal { get { return completeTotal; } set { completeTotal = value; OnPropertyChanged("CompleteTotal"); } }
		public string FormattedTotal { get { return formattedTotal; } set { formattedTotal = value; OnPropertyChanged("FormattedTotal"); } }
		public double JobSize { get { return jobSize; } set { jobSize = value; OnPropertyChanged("JobSize"); } }
        public double ColorValue { get { return colorValue; } set { colorValue = value; OnPropertyChanged("ColorValue"); } }
		public string Status { get { return status; } set { status = value; OnPropertyChanged("Status"); } }
		public string StatusColor { get { return statusColor; } set { statusColor = value; OnPropertyChanged("StatusColor"); } }
		public byte[] Pictures { get { return pictures; } set { pictures = value; OnPropertyChanged("Pictures"); } }



		public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
