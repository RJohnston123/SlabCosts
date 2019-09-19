using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CMPS_285
{
    public class Attribute : INotifyPropertyChanged
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

        private string attribute;

        private string attributeCost;

        private int optionId;

        [Indexed]
        public int OptionId { get { return optionId; } set { optionId = value; OnPropertyChanged("OptionId"); } }
        
        public string AttributeName { get { return attribute; } set { attribute = value; OnPropertyChanged("AttributeName"); } }
        public string AttributeCost { get { return attributeCost; } set { attributeCost = value; OnPropertyChanged("AttributeCost"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
