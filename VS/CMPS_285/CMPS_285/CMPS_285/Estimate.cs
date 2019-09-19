using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CMPS_285
{
    [Table("table_name2")]
    public class Estimate : INotifyPropertyChanged
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
        public string estimateName;
        public string total = "0";
        public string completeTotal;
        public double jobSize;
		public string statusColor = Constants.statusPENDING;
		public string status = "PENDING";

		public string EstimateName { get { return estimateName; } set { estimateName = value; OnPropertyChanged("EstimateName"); } }
        public string EstimateTotal { get { return total; } set { total = value; OnPropertyChanged("EstimateTotal"); } }
        public string CompleteTotal { get { return completeTotal; } set { completeTotal = value; OnPropertyChanged("CompleteTotal"); } }
        public double JobSize { get { return jobSize; } set { jobSize = value; OnPropertyChanged("JobSize"); } }
		public string StatusColor { get { return statusColor; } set { statusColor = value; OnPropertyChanged("StatusColor"); } }
		public string Status { get { return status; } set { status = value; OnPropertyChanged("Status"); } }


		public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
