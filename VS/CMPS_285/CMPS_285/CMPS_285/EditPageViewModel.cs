using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CMPS_285
{
    public class EditPageViewModel : INotifyPropertyChanged
    {

        //TODO Add CustomJoBOption Total under JobOptionTotal
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public JobName jobInfo;

        string titleName;
        string colorText;

        private ObservableCollection<JobName> jobNameList;
        private List<string> cunstructionJobList;

        public bool errorVisible_Name;

        public bool errorVisibleLength;

        public bool errorVisibleWidth;

        public bool widthVisible;
        public bool _isVisible;
        public bool _isCustomVisible;
        public bool _listVisible;
        public bool _listEVisible;
        private bool secondEntry;

        public string errorLength;
        public string errorWidth;
        public String errorMsg_Name;

        public double colorValue;

        public double ColorValue { get { return colorValue; } set { colorValue = value; OnPropertyChanged("ColorValue"); } }

        public string formattedClientTotal;

        public string sliderColor;



        public string SliderColor { get { return sliderColor; } set { sliderColor = value; OnPropertyChanged("SliderColor"); } }

        public string TitleName { get { return titleName; } set { titleName = value; OnPropertyChanged("TitleName"); } }

 

        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool ErrorNameVisible { get { return errorVisible_Name; } set { errorVisible_Name = value; OnPropertyChanged("ErrorNameVisible"); } }

        public bool ErrorLengthVisible { get { return errorVisibleLength; } set { errorVisibleLength = value; OnPropertyChanged("ErrorLengthVisible"); } }

        public bool ErrorWidthVisible { get { return errorVisibleWidth; } set { errorVisibleWidth = value; OnPropertyChanged("ErrorWidthVisible"); } }

        public List<string> CunstructionJobList { get { return cunstructionJobList; } set { cunstructionJobList = value; OnPropertyChanged("CunstructionJobList"); } }//= new ObservableCollection<JobName>();

        public ObservableCollection<JobName> JobNameList { get { return jobNameList; } set { jobNameList = value; OnPropertyChanged("JobNameList"); } }// = new ObservableCollection<Estimate>();

        public ICommand AddCommand { get; set; }

        public ICommand RemoveCommand { get; set; }

        public ICommand RemoveECommand { get; set; }

        public ICommand OkCommand { get; set; }

        public ICommand AttributeCommand { get; set; }

        public ICommand AttributeECommand { get; set; }

        public ICommand AddCustomCommand { get; set; }

        public ICommand OkCustomCommand { get; set; }

        public ICommand Ok2Command { get; set; }

        public ICommand CancelCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand CancelCustomCommand { get; set; }

        public ICommand SliderChangedCommand { get; set; }

        public ICommand SliderCompletedCommand { get; set; }

        public JobName NewJobName { get; set; } = new JobName();

        public String ErrorMsgName { get { return errorMsg_Name; } set { errorMsg_Name = value; OnPropertyChanged("ErrorMsgName"); } }

        public String ErrorMsgLength { get { return errorLength; } set { errorLength = value; OnPropertyChanged("ErrorMsgLength"); } }

        public String ErrorMsgWidth { get { return errorWidth; } set { errorWidth = value; OnPropertyChanged("ErrorMsgWidth"); } }

		//Formatted Job Total to US Currency
		public String FormattedClientTotal { get { return formattedClientTotal; } set { formattedClientTotal = value; OnPropertyChanged("FormattedClientTotal"); } }

		public ClientName Client { get; set; }

        public bool SecondEntry { get { return secondEntry; } set { secondEntry = value; OnPropertyChanged("SecondEntry"); } }
        public bool ListEVisible { get { return _listEVisible; } set { _listEVisible = value; OnPropertyChanged("ListEVisible"); } }
        public bool WidthVisible { get { return widthVisible; } set { widthVisible = value; OnPropertyChanged("WidthVisible"); } }
        public bool ListVisible { get { return _listVisible; } set { _listVisible = value; OnPropertyChanged("ListVisible"); } }
        public bool ItIsVisible { get { return _isVisible; } set { _isVisible = value; OnPropertyChanged("ItIsVisible"); } }
        public bool ItCustomIsVisible { get { return _isCustomVisible; } set { _isCustomVisible = value; OnPropertyChanged("ItCustomIsVisible"); } }

		//Error Message Bools
		public bool errorVisible_Option;
        public bool errorVisible_Type;
        public bool errorVisible_Per;
        public bool errorVisible_Quantity;
		public bool errorJustPeriods;

        //Error Messages
        public String errorMsg_Option;
        public String errorMsg_Type;
        public String errorMsg_Per;
        public String errorMsg_Quantity;

        //Error Message Visibility
        public bool ErrorOptionNameVis { get { return errorVisible_Option; } set { errorVisible_Option = value; OnPropertyChanged("ErrorOptionNameVis"); } }
        public bool ErrorOptionTypeVis { get { return errorVisible_Type; } set { errorVisible_Type = value; OnPropertyChanged("ErrorOptionTypeVis"); } }
        public bool ErrorPricePerVis { get { return errorVisible_Per; } set { errorVisible_Per = value; OnPropertyChanged("ErrorPricePerVis"); } }
        public bool ErrorQuantityVis { get { return errorVisible_Quantity; } set { errorVisible_Quantity = value; OnPropertyChanged("ErrorQuantityVis"); } }

		//Error Messages
		public String ErrorMsgOptionName { get { return errorMsg_Option; } set { errorMsg_Option = value; OnPropertyChanged("ErrorMsgOptionName"); } }
        public String ErrorMsgType { get { return errorMsg_Type; } set { errorMsg_Type = value; OnPropertyChanged("ErrorMsgType"); } }
        public String ErrorMsgPer { get { return errorMsg_Per; } set { errorMsg_Per = value; OnPropertyChanged("ErrorMsgPer"); } }
        public String ErrorMsgQuantity { get { return errorMsg_Quantity; } set { errorMsg_Quantity = value; OnPropertyChanged("ErrorMsgQuantity"); } }

		public EditPageViewModel(INavigation navigation, int clientId, string clientOrEstimate)
        {

            this.Navigation = navigation;

             database =
                DependencyService.Get<IDatabaseConnection>().
                    DbConnection();

            Client = database.Table<ClientName>().FirstOrDefault(client => client.Id == clientId);
            CreateDatabase();

            ColorValue = Client.ColorValue;
            SliderColor = Client.Color;
                ListVisible = true;

            if (Client.Name != null)
                TitleName = Client.Name + ": Job Page"; 
            else
                TitleName = Client.EstimateName + ": Job Page";
        

			GetTotalsInUSD();

			AddCommand = new Command(AddOption);

            SaveCommand = new Command(SaveOption);

            OkCommand = new Command(OkOption);

            OkCustomCommand = new Command(OkCustomOption);

            CancelCommand = new Command(CancelOption);

            CancelCustomCommand = new Command(CancelCustomOption);

            AddCustomCommand = new Command(AddCustomOption);

            AttributeCommand = new Command<JobName>(AttributeClient);

            RemoveCommand = new Command<JobName>(RemoveOption);

            Ok2Command = new Command(OkSecond);

            SliderChangedCommand = new Command(SliderChangedOption);

            SliderCompletedCommand = new Command(SliderCompletedOption);

        }

        public void SliderChangedOption()
        {
            Client.ColorValue = ColorValue;

            if (ColorValue > 0.66)
            {
                ColorValue = 1;
                Client.ColorText = "Green";
                SliderColor = "#9907e921";
                Client.Color = SliderColor;

			}
            else if(ColorValue > 0.33)
            {
                ColorValue = 0.5;
                Client.ColorText = "Yellow";
                SliderColor = "#99e99607";
                Client.Color = SliderColor;
			}
            else
            {
                ColorValue = 0;
                Client.ColorText = "Red";
                SliderColor = "#99e90707";
                Client.Color = SliderColor;
			}


            database.Update(Client);
        }

        public void SliderCompletedOption()
        {


            ReCalibratePrices();

            database.Update(Client);
        }

        public void AddOption()
        {
            GetConstructionJobList();
            ItIsVisible = true;
            ItCustomIsVisible = false;
        }

        public void AddCustomOption()
        {
            NewJobName.Option = string.Empty;
            NewJobName.Size = string.Empty;
            NewJobName.PricePer = string.Empty;
            NewJobName.Quantity = string.Empty;
            ItCustomIsVisible = true;
            ItIsVisible = false;
        }

        public void OkOption()
        {

            ErrorCleanup();

                if (CheckOptionClientPickerEntries() == true)
                {
                    ItIsVisible = false;
                jobInfo = new JobName
                {
                    CustomOption = false,
                        ClientId = Client.Id,
                        Option = NewJobName.Option,
                        NotCustomVisible = true
                    };
                    WidthVisible = InfoBridge.PickerChecker(NewJobName.Option);
                    NewJobName.Option = string.Empty;

                    NewJobName.Size = string.Empty;
                    NewJobName.PricePer = string.Empty;
                    NewJobName.Quantity = string.Empty;
                    SecondEntry = true;
                }                       
        }

        public async void OkSecond()
        {
			if (CheckWandLEntries() == true)
			{
				jobInfo.Size = NewJobName.Size;//length
				jobInfo.PricePer = NewJobName.PricePer;//width


				bool result;
				if (NewJobName.PricePer != string.Empty)
				{result = await LessThanTwoWarning(Convert.ToDouble(NewJobName.Size), Convert.ToDouble(NewJobName.PricePer)); }
				else
				{result = await LessThanTwoWarning(Convert.ToDouble(NewJobName.Size), 3); }

				if(!result)
				{ 
					if (jobInfo.PricePer != "")
					{
					    jobInfo.Quantity = (Convert.ToDouble(NewJobName.Size) * Convert.ToDouble(NewJobName.PricePer)).ToString();
					}
					else
					{
					    jobInfo.PricePer = "1";
					    jobInfo.Quantity = NewJobName.Size;
					}

					JobNameList.Add(jobInfo);
					                 
					jobInfo.TypeorLengthLabel = "Length: ";
					jobInfo.PricePerorWidthLabel = "Width: ";
					jobInfo.QuantityLabel = "Unit Total: ";

					ReCalibratePrices();
					database.Insert(jobInfo);
					
					SecondEntry = false;
				}
				database.Update(Client);
			}
            //TODO - Add a popup window that tells the user that something went wrong, and kick back to the main page.
            //Something went wrong when entering length and width
		}

		public void GetTotalsInUSD()
		{
			//Lets USD format have negatives
			CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
			CultureInfo newCulture     = new CultureInfo(currentCulture.Name);
			newCulture.NumberFormat.CurrencyNegativePattern = 1;
			Thread.CurrentThread.CurrentCulture = newCulture;

			double est1 = Convert.ToDouble(Client.CompleteTotal);
			FormattedClientTotal = est1.ToString("C2");
			Client.FormattedTotal = est1.ToString("C2");
		}

		public void ReCalibratePrices()
        {
            
            InfoBridge tempBridge = new InfoBridge(1);

            Client.CompleteTotal  = "0";
			Client.FormattedTotal = "0";
			Client.JobSize = 0;

            for (int i = 0; i < JobNameList.Count; i++)
            {
                if(JobNameList[i].CustomOption == false)
                Client.JobSize = Client.JobSize + Convert.ToDouble(JobNameList[i].Quantity);
                
            }

            database.Update(Client);

            for (int i = 0; i < JobNameList.Count; i++)
                {
                if (JobNameList[i].CustomOption == false)
                {

                    double temp2 = tempBridge.GetOptionPrice(JobNameList[i].Option, Convert.ToDouble(JobNameList[i].Size), Convert.ToDouble(JobNameList[i].PricePer), Client.JobSize, Client.ColorValue);
                    //double temp = InfoBridge.GetPrice(InfoBridge.OptionStringToObject(jobInfo.Option), Convert.ToDouble(jobInfo.Quantity));

                    JobNameList[i].Total          = temp2.ToString();
					JobNameList[i].FormattedTotal = temp2.ToString("C2");

					Client.CompleteTotal = (Convert.ToDouble(JobNameList[i].Total) + Convert.ToDouble(Client.CompleteTotal)).ToString();

                    database.Update(JobNameList[i]);
                    database.Update(Client);
                }
                else
                {
                    Client.CompleteTotal = (Convert.ToDouble(JobNameList[i].Total) + Convert.ToDouble(Client.CompleteTotal)).ToString();
                    database.Update(JobNameList[i]);
                    database.Update(Client);
                }
            }

			GetTotalsInUSD();
		}

		public void GetJobTotalInUSD(String total)
		{
			double est1 = Convert.ToDouble(Client.CompleteTotal);
			FormattedClientTotal = est1.ToString("C2");
			Client.FormattedTotal = est1.ToString("C2");
		}

		public void ErrorCleanup()
        {
            ErrorNameVisible = false;
            ErrorLengthVisible = false;
            ErrorWidthVisible = false;
        }

        public void CancelOption()
        {
            ItIsVisible = false;
        }

        public void OkCustomOption()
        {

                if (CheckCustomClientEntries() == true)
                {
                jobInfo = new JobName
                {
                    CustomOption = true,
                        ClientId = Client.Id,
                        Option = NewJobName.Option,
                        Size = NewJobName.Size,
                        PricePer = NewJobName.PricePer,
                        Quantity = NewJobName.Quantity,
                        FormattedTotal = (Convert.ToDouble(NewJobName.PricePer) * Convert.ToDouble(NewJobName.Quantity)).ToString("C2"),
                        Total = (Convert.ToDouble(NewJobName.PricePer) * Convert.ToDouble(NewJobName.Quantity)).ToString()
                
                    };

					JobNameList.Add(jobInfo);
                ReCalibratePrices();


                    jobInfo.TypeorLengthLabel = "Unit Type: ";
                    jobInfo.PricePerorWidthLabel = "Price Per Unit: ";
                    jobInfo.QuantityLabel = "Unit Quantity: ";
                    database.Insert(jobInfo);
                database.Update(Client);
                ItCustomIsVisible = false;
                }
        }

        public bool CheckOptionClientPickerEntries()
        {
            bool allowAdd = true;

            //Name
            if (NewJobName.Option == null)
            {
                ErrorMsgName = "Please Select an Option.";
                ErrorNameVisible = true;
                allowAdd = false;
            }

            return allowAdd;
        }

        public bool CheckWandLEntries()
        {
			//Size     = Length
			//Priceper = Width

            bool allowAdd = true;

            //Length
            if ((NewJobName.Size == "") || (NewJobName.Size == ".") || (NewJobName.Size == "-.") || (NewJobName.Size == "-"))
			{
                ErrorMsgLength = Constants.err_NoNum;
				ErrorLengthVisible = true;
                allowAdd = false;
            }
            else 
			if ((Convert.ToDouble(NewJobName.Size) > 10000) || (Convert.ToDouble(NewJobName.Size) < -20))
			{
				ErrorMsgLength = Constants.err_NumOutOfRange;
				ErrorLengthVisible = true;
				allowAdd = false;
			}
			else
			{ ErrorLengthVisible = false; }


			//Width
			if (((NewJobName.PricePer == "") || (NewJobName.PricePer == ".") || (NewJobName.PricePer == "-.")) && InfoBridge.PickerChecker(jobInfo.Option) == true)
			{
				ErrorMsgWidth = Constants.err_NoNum;
				ErrorWidthVisible = true;
				allowAdd = false;
			}
			else
			if (NewJobName.PricePer != string.Empty)
			{
				if ((Convert.ToDouble(NewJobName.PricePer) > 10000) || (Convert.ToDouble(NewJobName.PricePer) < -20))
				{
					ErrorMsgWidth = Constants.err_NumOutOfRange;
					ErrorWidthVisible = true;
					allowAdd = false;
				}
				else
				{ ErrorWidthVisible = false; }
			}
			else
			{ ErrorWidthVisible = false; }

			return allowAdd;
        }

        public bool CheckLEntries()
        {
            bool allowAdd = true;

			//Name
			if ((NewJobName.Size == "") || (NewJobName.Size == ".") || (NewJobName.Size == "-."))
			{
                ErrorMsgLength = Constants.err_NoNum;
				ErrorLengthVisible = true;
                allowAdd = false;
            }
			else
			if ((Convert.ToDouble(NewJobName.Size) > 10000) || (Convert.ToDouble(NewJobName.Size) < -20))
			{
				ErrorMsgLength = Constants.err_NumOutOfRange; ;
				ErrorLengthVisible = true;
				allowAdd = false;
			}
			else
			{ ErrorLengthVisible = false; }
            
            return allowAdd;
        }

		public async Task<bool> LessThanTwoWarning(double lgth, double width)
		{
			if ((lgth < 2) || (width < 2))
			{
				return await Application.Current.MainPage.DisplayAlert("WARNING", "The length or width is less than 2. Do you want to proceed?", "No", "Yes");
			}
			else
			return false;
		}

		public void LessThanTwoYes()
		{
			jobInfo.Size = NewJobName.Size;//length
			jobInfo.PricePer = NewJobName.PricePer;//width

			if (jobInfo.PricePer != "")
			{
				jobInfo.Quantity = (Convert.ToDouble(NewJobName.Size) * Convert.ToDouble(NewJobName.PricePer)).ToString();
			}
			else
			{
				jobInfo.PricePer = "1";
				jobInfo.Quantity = NewJobName.Size;
			}

			JobNameList.Add(jobInfo);

			jobInfo.TypeorLengthLabel = "Length: ";
			jobInfo.PricePerorWidthLabel = "Width: ";
			jobInfo.QuantityLabel = "Unit Total: ";

			ReCalibratePrices();
			database.Insert(jobInfo);
			SecondEntry = false;
		}

		public void LessThanTwoNo()
		{
			SecondEntry = true;
		}

		public bool CheckCustomClientEntries()
        {
            bool allowAdd = true;


            //Name
            if (NewJobName.Option == "")
            {
                ErrorMsgOptionName = "Please Enter an Option Name.";
                ErrorOptionNameVis = true;
                allowAdd = false;
            }
            else { ErrorOptionNameVis = false; }

			//Size
            if (NewJobName.Size == "")
            {
                ErrorMsgType = "Please Enter a Unit Type.";
                ErrorOptionTypeVis = true;
                allowAdd = false;
            }
            else { ErrorOptionTypeVis = false; }

			//Length
            if ((NewJobName.PricePer == "") || (NewJobName.PricePer == ".") || (NewJobName.PricePer == ".-") || (NewJobName.PricePer == "-"))
			{
                ErrorMsgPer = "Please Enter a Price Per Unit.";
                ErrorPricePerVis = true;
                allowAdd = false;
            }
            else
			if ((Convert.ToDouble(NewJobName.PricePer) > 10000) || (Convert.ToDouble(NewJobName.PricePer) < -20))
			{
				ErrorMsgPer = "Please enter a value between [-20 - 10,000]";
				ErrorPricePerVis = true;
				allowAdd = false;
			}
			else
			{ ErrorPricePerVis = false; }

			//Width
            if ((NewJobName.Quantity == "") || (NewJobName.Quantity == ".") || (NewJobName.Quantity == ".-") || (NewJobName.Quantity == "-"))
			{
                ErrorMsgQuantity = "Please Enter a Quantity.";
                ErrorQuantityVis = true;
                allowAdd = false;
            }
			else
			if ((Convert.ToDouble(NewJobName.Quantity) > 10000) || (Convert.ToDouble(NewJobName.Quantity) < -20))
			{
				ErrorMsgQuantity = "Please enter a value between [-20 - 10,000]";
				ErrorQuantityVis = true;
				allowAdd = false;
			}
			else
			{ ErrorQuantityVis = false; }

            return allowAdd;
        }

        public void SaveOption()
        {
           database.Update(Client);
           Navigation.PopAsync();
        }

        public void CancelCustomOption()
        {

            ItCustomIsVisible = false;
        }

        public void AttributeClient(JobName job)
        {

            
            Navigation.PushAsync(new AttributePage(job.Id,Client.Id ,"job", job.NotCustomVisible));
        }

        public async void RemoveOption(JobName job)
        {
			bool result = await DeleteJobWarning();
			if (!result)
			{
				database.Table<JobName>().Delete(x => x.Id == job.Id);
				database.Update(job);
         
				JobNameList.Remove(job);
				ReCalibratePrices();
			}
        }

		public async Task<bool> DeleteJobWarning()
		{
			return await Application.Current.MainPage.DisplayAlert("Deleting Job", "Are you sure you want to delete this job?", "No", "Yes");
		}

		public void CreateDatabase()
        {
            database.CreateTable<JobName>();
            database.CreateTable<JobEstimateName>();

            RefreshList();
        }

        public void RefreshList()
        {  
            this.JobNameList =
                new ObservableCollection<JobName>(database.Table<JobName>().ToList().Where(x => x.ClientId == Client.Id).ToList());

            //this.JobEstimateNameList =
             //new ObservableCollection<JobEstimateName>(database.Table<JobEstimateName>().Where(x => x.ClientId == Estimate.Id).ToList());
            if (Client != null)
            {
                ReCalibratePrices();
            }

			database.Update(Client);
		}

        public void GetConstructionJobList()
        {
            CunstructionJobList = new List<string>();
            CunstructionJobList = Constants.optionList;           
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        //database.Table<JobName>().Where(x => x.ClientId == clientId)

    }
}
