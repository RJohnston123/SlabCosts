using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CMPS_285
{
    public class JobEstimateName : INotifyPropertyChanged
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
        public string option = "";
        public string size;
        public string pricePer;
        public string quantity;
        public string total = "0";
        public static string completeTotal;
		public string statusColor = Constants.statusPENDING;

		public string typeOrLength;
        public string pricePerorWidthLabel;
        public string quantityLabel;

        public bool notCustomVisible = false;

        private int clientId;

        [Indexed]
        public int ClientId { get { return clientId; } set { clientId = value; OnPropertyChanged("ClientId"); } }

        public string Option { get { return option; } set { option = value; OnPropertyChanged("Option"); } }
        public string Size { get { return size; } set { size = value; OnPropertyChanged("Size"); } }
        public string PricePer { get { return pricePer; } set { pricePer = value; OnPropertyChanged("PricePer"); } }
        public string Quantity { get { return quantity; } set { quantity = value; OnPropertyChanged("Quantity"); } }
        public string Total { get { return total; } set { total = value; OnPropertyChanged("Total"); } }
        public static string CompleteTotal { get { return completeTotal; } set { completeTotal = value; } }
		public string StatusColor { get { return statusColor; } set { statusColor = value; OnPropertyChanged("StatusColor"); } }

		public bool NotCustomVisible { get { return notCustomVisible; } set { notCustomVisible = value; OnPropertyChanged("NotCustomVisible"); } }

        public string TypeorLengthLabel { get { return typeOrLength; } set { typeOrLength = value; OnPropertyChanged("TypeorLengthLabel"); } }
        public string PricePerorWidthLabel { get { return pricePerorWidthLabel; } set { pricePerorWidthLabel = value; OnPropertyChanged("PricePerorWidthLabel"); } }
        public string QuantityLabel { get { return quantityLabel; } set { quantityLabel = value; OnPropertyChanged("QuantityLabel"); } }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


