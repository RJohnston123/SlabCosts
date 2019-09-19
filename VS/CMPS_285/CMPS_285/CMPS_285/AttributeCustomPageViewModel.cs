using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CMPS_285
{
    public class AttributeCustomPageViewModel : INotifyPropertyChanged
    {

        InfoBridge tempBridge = new InfoBridge(1);
        private SQLiteConnection database;
        private static object collisionLock = new object();
        private readonly INavigation navigation;

        public JobName Job { get; set; } = new JobName();

        ObservableCollection<Attribute> attributeList;

        ObservableCollection<Attribute> tempAttributeList;

        private bool attributeAddVisible;
        private List<string> attributeNameList;

        public ObservableCollection<Attribute> AttributeList { get { return attributeList; } set { attributeList = value; OnPropertyChanged("AttributeList"); } }

        public ObservableCollection<Attribute> TempAttributeList { get { return tempAttributeList; } set { tempAttributeList = value; OnPropertyChanged("TempAttributeList"); } }

        public List<string> AttributeNameList { get { return attributeNameList; } set { attributeNameList = value; OnPropertyChanged("AttributeNameList"); } }

        public bool AttributeAddVisible { get { return attributeAddVisible; } set { attributeAddVisible = value; OnPropertyChanged("AttributeAddVisible"); } }

        public bool clientVisible;
        public bool eVisible;
        public bool isNormal;

        public bool customOrNormal;

        public bool customAttributeVis;

        public List<string> cunstructionJobList;

        public List<string> CunstructionJobList { get { return cunstructionJobList; } set { cunstructionJobList = value; OnPropertyChanged("CunstructionJobList"); } }

        public Attribute attributeInfo;
        public Attribute NewAttributeName { get; set; } = new Attribute();

        public event PropertyChangedEventHandler PropertyChanged;

        public bool CustomOrNormal { get { return customOrNormal; } set { customOrNormal = value; OnPropertyChanged("CustomOrNormal"); } }

        public bool CustomAttributeVis { get { return customAttributeVis; } set { customAttributeVis = value; OnPropertyChanged("CustomAttributeVis"); } }

        public bool ClientVisible { get { return clientVisible; } set { clientVisible = value; OnPropertyChanged("ClientVisible"); } }
        public bool IsNormal { get { return isNormal; } set { isNormal = value; OnPropertyChanged("IsNormal"); } }

        public ClientName Client { get; set; }

        //Error Message Bools
        public bool errorVisible_Option;

        //Error Messages
        public String errorMsg_Option;

        //Error Message Visibility
        public bool ErrorOptionNameVis { get { return errorVisible_Option; } set { errorVisible_Option = value; OnPropertyChanged("ErrorOptionNameVis"); } }

        //Error Messages
        public String ErrorMsgOptionName { get { return errorMsg_Option; } set { errorMsg_Option = value; OnPropertyChanged("ErrorMsgOptionName"); } }


        public ICommand SaveCommand { get; set; }

        public ICommand AddAttribute { get; set; }

        public ICommand OkAttributeCommand { get; set; }

        public ICommand RemoveCommand { get; set; }

        public ICommand RemoveECommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public ICommand JobOptionChangedCommand { get; set; }

        //public ICommand EntryLengthChangeCommand { get; set; }

        //public ICommand EntryWidthChangeCommand { get; set; }

		public ICommand EntryChangeCommand { get; set; }

		public ICommand JobEstimateOptionChangedCommand { get; set; }

        public ICommand EntryEstimateLengthChangeCommand { get; set; }

        public ICommand EntryEstimateWidthChangeCommand { get; set; }

        public ICommand EntryPricePerChangeCommand { get; set; }

        public ICommand EntryEstimatePricePerChangeCommand { get; set; }

        public ICommand EntryQuantityChangeCommand { get; set; }

        public ICommand EntryEstimateQuantityChangeCommand { get; set; }

        public AttributeCustomPageViewModel(INavigation navigation, int jobId,int clientId, string joborestimate, bool notCustomVisible)
        {
            GetConstructionJobList();

            this.navigation = navigation;

            customOrNormal = notCustomVisible;

            if (notCustomVisible == true) { IsNormal = false; } else { IsNormal = true; }

            if (notCustomVisible == true && joborestimate.Equals("job")) { CustomAttributeVis = true; }

            else { IsNormal = true; }



           

            CreateDatabase(jobId, clientId);
            //add stuff here

            RemoveCommand = new Command<Attribute>(RemoveOption);

            AddAttribute = new Command(AddToAttributeList);
            OkAttributeCommand = new Command(OkAttribute);
            SaveCommand = new Command(SaveOption);
            CancelCommand = new Command(CancelOption);

            JobOptionChangedCommand = new Command(SelectedJobOptionChanged);
            //EntryLengthChangeCommand = new Command(EntryLengthChange);
            //EntryWidthChangeCommand = new Command(EntryWidthChange);
			EntryChangeCommand = new Command(EntryChange);



            EntryPricePerChangeCommand = new Command(EntryPricePerChange);

    }

        private void CancelOption()
        {
            AttributeAddVisible = false;
        }

        private void RemoveOption(Attribute attribute)
        {
 
                database.Table<Attribute>().Delete(x => x.Id == attribute.Id);

                AttributeList.Remove(attribute);

        }

        public void SaveOption()
        {
            if (CustomOrNormal == true)
            {
          
                    if (Job != null && Job.Id != 0)
                    {
                        if (CheckClientEntries() == true)
                        {
                            if (InfoBridge.PickerChecker(Job.Option) == false)
                            {
                               
                                Job.PricePer = "1";// TODO MAKE IT A BINDED SET MAX LENGTH OF 1!!!!!
                                string temp = (Convert.ToDouble(Job.Size) + Convert.ToDouble(Job.PricePer) - 1).ToString();                              
                                Job.Quantity = temp;
                                string temp2 = (InfoBridge.GetPrice(InfoBridge.OptionStringToObject(Job.Option), Convert.ToDouble(Job.Quantity))).ToString();
                                Job.Total = temp2;

                                database.Update(Job);
                            }
                            else
                            {                                               
                               database.Update(Job);
                            }
                            navigation.PopAsync();
                        }
                    }
            }
                
            
            else
            {

                lock (collisionLock)

                        if (Job != null && Job.Id != 0)
                        {

                            if (CheckClientEntries() == true)
                            {
                            database.Update(Job);
                            navigation.PopAsync();
                            }
                        }
                    
                    
            }
            
        }

        public void SelectedJobOptionChanged()
        {
            if (IsNormal == false)
            {
                GetAttributeJobList(Job.Option);
                Job.Size     = "0";
                Job.PricePer = "0";
                ClearTempAttributes();
            }
        }
		
		public void EntryChange()
		{
			if (IsNormal == false)
			{
				string pricePer, quantity, size;

				//Length Change
				if ((Job.PricePer.Equals("")) || (Job.PricePer.Equals(".")) || (Job.PricePer.Equals("-.")) || (Job.PricePer.Equals("-")))
				{ pricePer = "0"; }
				else
				{ pricePer = Job.PricePer; }

				//Quantity Change
				if ((Job.Quantity.Equals("")) || (Job.Quantity.Equals(".")) || (Job.Quantity.Equals("-.")) || (Job.Quantity.Equals("-")))
				{ quantity = "0"; }
				else
				{ quantity = Job.Quantity; }

				//Size Change
				if ((Job.Size.Equals("")) || (Job.Size.Equals(".")) || (Job.Size.Equals("-.")) || (Job.Size.Equals("-")))
				{ size = "0"; }
				else
				{ size = Job.Size; }

				//Calculations
				double temp  = Convert.ToDouble(pricePer) * Convert.ToDouble(quantity);
				double temp2 = Convert.ToDouble(quantity) + Client.JobSize;
				double temp3 = tempBridge.GetOptionPrice(Job.Option, Convert.ToDouble(size), Convert.ToDouble(pricePer), temp2, Client.ColorValue);
				Job.Quantity = (Convert.ToDouble(size) * Convert.ToDouble(pricePer)).ToString();

				Job.Total = temp3.ToString();
				Job.FormattedTotal = temp3.ToString("C2");
			}
		}
		
        public void AddToAttributeList()
        {

            AttributeAddVisible = true;            

        }

        public bool CheckClientEntries()
        {
            bool allowAdd = true;

            if (Job.Option == string.Empty)
            {
                ErrorMsgOptionName = "Entry fields are empty or out of range [-20, 10,000].";
                ErrorOptionNameVis = true;
                allowAdd = false;
            }

            if ((Job.PricePer.Equals("")) || (Job.PricePer.Equals(".")) || (Job.PricePer.Equals("-.")) || (Job.PricePer.Equals("-")) || (Convert.ToDouble(Job.PricePer) > 10000) || (Convert.ToDouble(Job.PricePer) < -20))
			{
				ErrorMsgOptionName = "Entry fields are empty or out of range [-20, 10,000].";
				ErrorOptionNameVis = true;
                allowAdd = false;
            }

            if ((Job.Quantity.Equals("")) || (Job.Quantity.Equals(".")) || (Job.Quantity.Equals("-.")) || (Job.Quantity.Equals("-")) || (Convert.ToDouble(Job.Quantity) > 10000) || (Convert.ToDouble(Job.Quantity) < -20))
			{
				ErrorMsgOptionName = "Entry fields are empty or out of range [-20, 10,000].";
				ErrorOptionNameVis = true;
                allowAdd = false;
            }

            if (CustomOrNormal == true)
            {
                if ((Job.Size.Equals("")) || (Job.Size.Equals(".")) || (Job.Size.Equals("-.")) || (Job.Size.Equals("-")) || (Convert.ToDouble(Job.Size) > 10000) || (Convert.ToDouble(Job.Size) < -20))
                {
                    ErrorMsgOptionName = "Entry fields are empty or out of range [-20, 10,000].";
                    ErrorOptionNameVis = true;
                    allowAdd = false;
                }
            }
            else
            {
                if (Job.Size == string.Empty)
                {
                    ErrorMsgOptionName = "Entry fields are empty or out of range [-20, 10,000].";
                    ErrorOptionNameVis = true;
                    allowAdd = false;
                }
            }
            return allowAdd;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OkAttribute()
        {

                attributeInfo = new Attribute
                {
                    OptionId = Job.Id,
                    AttributeName = NewAttributeName.AttributeName,
                };

                AttributeList.Add(attributeInfo);
                database.Insert(attributeInfo);
                       
            AttributeAddVisible = false;
        }            

        public void ClearTempAttributes()
        {

            for (int i = 0; i < AttributeList.Count; i++)
            {
                Attribute tempAttribute = AttributeList[i];
                database.Table<Attribute>().Delete(x => x.Id == tempAttribute.Id);
            }

        AttributeList.Clear();
        }

        public void GetConstructionJobList()
        {
            CunstructionJobList = new List<string>();
            CunstructionJobList = Constants.optionList;
        }

        public void EntryPricePerChange()
        {
            if (IsNormal == true)
            {
                String pricePer, quantity;

                if ((Job.PricePer.Equals("")) || (Job.PricePer.Equals(".")) || (Job.PricePer.Equals("-.")) || (Job.PricePer.Equals("-")))
                { pricePer = "0"; }
                else
                { pricePer = Job.PricePer; }

				if ((Job.Quantity.Equals("")) || (Job.Quantity.Equals(".")) || (Job.Quantity.Equals("-.")) || (Job.Quantity.Equals("-")))
				{ quantity = "0"; }
				else
				{ quantity = Job.Quantity; }

				double temp = (Convert.ToDouble(pricePer) * Convert.ToDouble(quantity));
                Job.Total = temp.ToString();
                Job.FormattedTotal = temp.ToString("C2");
            }
        }

        public void CreateDatabase(int jobId, int clientId)
        {

            database =
        DependencyService.Get<IDatabaseConnection>().
        DbConnection();

                ClientVisible = true;
                Job = database.Table<JobName>().FirstOrDefault(job => job.Id == jobId);
                Client = database.Table<ClientName>().FirstOrDefault(client => client.Id == clientId);
                GetAttributeJobList(Job.Option);
            

            RefreshList();
        }

        public void RefreshList()
        {

            database.CreateTable<Attribute>();
            database.CreateTable<EstimateAttribute>();

            AttributeList =
            new ObservableCollection<Attribute>(database.Table<Attribute>().ToList().Where(x => x.OptionId == Job.Id).ToList());

            Client.JobSize = Client.JobSize - Convert.ToDouble(Job.Quantity);
        }

        public void GetAttributeJobList(string OptionTitle)
        {
            AttributeNameList = new List<string>();
            AttributeNameList = Attributes.GetAttributes(OptionTitle);
        }

		//Old entry check method. KEEP IN CASE NEW METHOD BREAKS
		/*
        public void EntryLengthChange()
        {
            if (IsNormal == false)
            {
				String x;

				if ((Job.Size.Equals("")) || (Job.Size.Equals(".")) || (Job.Size.Equals("-.")) || (Job.Size.Equals("-")))
				{ x = "0"; }
				else
				{ x = Job.Size; }

				Job.Quantity = (Convert.ToDouble(x) * Convert.ToDouble(Job.PricePer)).ToString();
                double temp2 =  Convert.ToDouble(Job.Quantity) + Client.JobSize;

                double temp = tempBridge.GetOptionPrice(Job.Option, Convert.ToDouble(x), Convert.ToDouble(Job.PricePer), temp2);

                Job.Total = temp.ToString();
				Job.FormattedTotal = temp.ToString("C2");
            }
        }

        public void EntryWidthChange()
		{ 
            if (IsNormal == false)
            {
				String x;

                if ((Job.PricePer.Equals("")) || (Job.PricePer.Equals(".")) || (Job.PricePer.Equals("-.")) || (Job.PricePer.Equals("-")))
				{ x = "0"; }
				else
				{ x = Job.PricePer; }

				Job.Quantity = (Convert.ToDouble(Job.Size) * Convert.ToDouble(x)).ToString();
                double temp2 = Convert.ToDouble(Job.Quantity) + Client.JobSize;

                
                double temp = tempBridge.GetOptionPrice(Job.Option, Convert.ToDouble(Job.Size), Convert.ToDouble(x), temp2);

                Job.Total = temp.ToString();
				Job.FormattedTotal = temp.ToString("C2");
			}
        }

        public void EntryPricePerChange()
        {
            if (IsNormal == true)
            {
				String x;

				if ((Job.PricePer.Equals("")) || (Job.PricePer.Equals(".")) || (Job.PricePer.Equals("-.")) || (Job.PricePer.Equals("-")))
				{ x = "0"; }
				else
				{ x = Job.PricePer; }

				double temp = (Convert.ToDouble(x) * Convert.ToDouble(Job.Quantity));
				Job.Total = temp.ToString();
				Job.FormattedTotal = temp.ToString("C2");
			}
        }

        public void EntryQuantityChange()
        {
            if (IsNormal == true)
            {
				String x;

				if ((Job.Quantity.Equals("")) || (Job.Quantity.Equals(".")) || (Job.Quantity.Equals("-.")) || (Job.Quantity.Equals("-")))
				{ x = "0"; }
				else
				{ x = Job.Quantity; }

				double temp = (Convert.ToDouble(Job.PricePer) * Convert.ToDouble(x));
				Job.Total = temp.ToString();
				Job.FormattedTotal = temp.ToString("C2");
            }
        }
*/

	}
}
