using CMPS_285;
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
using static Xamarin.Forms.VisualElement;

namespace CMPS_285
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public static DatabasePrices DBPrices = new DatabasePrices();

        public string name;
        public string eName;
        public string address;
        public string phoneNum;
        public string email;
        public ClientName clientName;

        public String popupBG = "#f2f6f7";

        private ObservableCollection<ClientName> clientList;
        private ObservableCollection<ClientName> estimateList;
        private ObservableCollection<ClientName> allList;
        private ObservableCollection<ClientName> searchedClientList;
        private ObservableCollection<ClientName> eSearchedClientList;

        public bool editEstimateVis = false;

        public bool _isVisible;

        public bool searchVisible;
        public bool esearchVisible;
        public bool searchListVisibility;
        public bool esearchListVisibility;
        public bool clientListVisibility = true;
        public bool estimateListVisibility = true;


		public string searchText = "";
        public string eSearchText = "";

        //Error Message Bools
        public bool errorVisible_Name;
        public bool errorVisible_Address;
        public bool errorVisible_PhoneNum;
        public bool errorVisible_Email;
		public bool errorVisible_Estimate;
        public bool hamburgerVis;

        //Error Messages
        public String errorMsg_Name;
        public String errorMsg_Address;
        public String errorMsg_PhoneNum;
        public String errorMsg_Email;
		public String errorMsg_Estimate;
        private List<string> statusList;


        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> StatusList { get { return statusList; } set { statusList = value; OnPropertyChanged("StatusList"); } }

        public ObservableCollection<ClientName> AllList { get { return allList; } set { allList = value; OnPropertyChanged("AllList"); } }

        public ObservableCollection<ClientName> ClientList { get { return clientList; } set { clientList = value; OnPropertyChanged("ClientList"); } } //= new ObservableCollection<ClientName>();

        public ObservableCollection<ClientName> SearchedClientList { get { return searchedClientList; } set { searchedClientList = value; OnPropertyChanged("SearchedClientList"); } } //= new ObservableCollection<ClientName>();

        public ObservableCollection<ClientName> EstimateList { get { return estimateList; } set { estimateList = value; OnPropertyChanged("EstimateList"); } }// = new ObservableCollection<Estimate>();

        public ObservableCollection<ClientName> ESearchedClientList { get { return eSearchedClientList; } set { eSearchedClientList = value; OnPropertyChanged("ESearchedClientList"); } } //= new ObservableCollection<ClientName>();

        public bool EditEstimateVis { get { return editEstimateVis; } set { editEstimateVis = value; OnPropertyChanged("EditEstimateVis"); } }

        public String PopupBGColor { get { return popupBG; } set { popupBG = value; } }

        public ICommand AddCommand { get; set; }

        public ICommand RemoveCommand { get; set; }

        public ICommand OkCommand { get; set; }

        public ICommand OkECommand { get; set; }

        public ICommand InfoCommand { get; set; }

        public ICommand OptionCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public ICommand HamCommand { get; set; }

        public ICommand PricesPageCommand { get; set; }

        public ICommand SoftDeletePageCommand { get; set; }

        public ICommand SearchedTextCommand { get; set; }

        public ICommand ESearchedTextCommand { get; set; }

        public ICommand EInfoCommand { get; set; }

        public ICommand EInfoOkCommand { get; set; }

        public ClientName NewClient { get; set; } = new ClientName();

        public ClientName NewEstimate { get; set; } = new ClientName();

        public ClientName Estimate { get; set; }

        public string estimateText;
        public string EstimateText { get { return estimateText; } set { estimateText = value; OnPropertyChanged("EstimateText"); } }

        public bool ItIsVisible { get { return _isVisible; } set { _isVisible = value; OnPropertyChanged("ItIsVisible"); } }

		public bool   ShowSearch { get { return searchVisible; } set { searchVisible = value; OnPropertyChanged("ShowSearch"); } }
        public bool EShowSearch { get { return esearchVisible; } set { esearchVisible = value; OnPropertyChanged("EShowSearch"); } }
        public bool   SearchListVisibility { get { return searchListVisibility; } set { searchListVisibility = value; OnPropertyChanged("SearchListVisibility"); } }
        public bool ESearchListVisibility { get { return esearchListVisibility; } set { esearchListVisibility = value; OnPropertyChanged("ESearchListVisibility"); } }
        public bool   ClientListVisibility { get { return clientListVisibility; } set { clientListVisibility = value; OnPropertyChanged("ClientListVisibility"); } }
        public bool EstimateListVisibility { get { return estimateListVisibility; } set { estimateListVisibility = value; OnPropertyChanged("EstimateListVisibility"); } }
        public string SearchText { get { return searchText; } set { searchText = value; OnPropertyChanged("SearchText"); } }
        public string ESearchText { get { return eSearchText; } set { eSearchText = value; OnPropertyChanged("ESearchText"); } }

        //Error Message Visibility
        public bool ErrorNameVisible { get { return errorVisible_Name; } set { errorVisible_Name = value; OnPropertyChanged("ErrorNameVisible"); } }
		public bool ErrorAddressVisible { get { return errorVisible_Address; } set { errorVisible_Address = value; OnPropertyChanged("ErrorAddressVisible"); } }
		public bool ErrorPhoneNumVisible { get { return errorVisible_PhoneNum; } set { errorVisible_PhoneNum = value; OnPropertyChanged("ErrorPhoneNumVisible"); } }
		public bool ErrorEmailVisible { get { return errorVisible_Email; } set { errorVisible_Email = value; OnPropertyChanged("ErrorEmailVisible"); } }
		public bool ErrorEstimateVisible { get { return errorVisible_Estimate; } set { errorVisible_Estimate = value; OnPropertyChanged("ErrorEstimateVisible"); } }

		public bool HamburgerVis { get { return hamburgerVis; } set { hamburgerVis = value; OnPropertyChanged("HamburgerVis"); } }

        //Error Messages
        public String ErrorMsgName     { get { return errorMsg_Name; } set { errorMsg_Name = value; OnPropertyChanged("ErrorMsgName"); } }
		public String ErrorMsgAddress  { get { return errorMsg_Address; } set { errorMsg_Address = value; OnPropertyChanged("ErrorMsgAddress"); } }
		public String ErrorMsgPhoneNum { get { return errorMsg_PhoneNum; } set { errorMsg_PhoneNum = value; OnPropertyChanged("ErrorMsgPhoneNum"); } }
		public String ErrorMsgEmail    { get { return errorMsg_Email; } set { errorMsg_Email = value; OnPropertyChanged("ErrorMsgEmail"); } }
		public String ErrorMsgEstimate { get { return errorMsg_Estimate; } set { errorMsg_Estimate = value; OnPropertyChanged("ErrorMsgEstimate"); } }

		public MainPageViewModel()
        {
            CreateDatabase();
        }

        public MainPageViewModel(INavigation navigation)
        {

            CreateDatabase();
            this.Navigation = navigation;

            AddCommand = new Command(AddClient);

            OkCommand = new Command(OkClient);

            OkECommand = new Command(OkEstimate);

            InfoCommand = new Command<ClientName>(InfoClient);

            OptionCommand = new Command<ClientName>(OptionClient);

            RemoveCommand = new Command<ClientName>(RemoveClient);

            HamCommand = new Command(ShowHamMenu);

            PricesPageCommand = new Command(GoToOptionPricePage);

            SoftDeletePageCommand = new Command(SoftDeletePageOption);

            CancelCommand = new Command(CancelOption);

            SearchedTextCommand = new Command(SearchTextChanged);

            ESearchedTextCommand = new Command(SearchETextChanged);

            EInfoCommand = new Command<ClientName>(EInfoCommandOption);

            EInfoOkCommand = new Command(EInfoOkayOption);

            GetClientStatusList();

            SearchBarVisible();
            ESearchBarVisible();

        }

        public void EInfoCommandOption(ClientName estimate)
        {
            this.Estimate = estimate;

            EditEstimateVis = true;

            EstimateText = estimate.EstimateName;
            
        }

        public void EInfoOkayOption()
        {
			//Set Status Color
			switch (Estimate.Status)
			{
				case "PENDING":
					Estimate.StatusColor = Constants.statusPENDING;
					break;
				case "PAID":
					Estimate.StatusColor = Constants.statusPAID;
					break;
				case "FINISHED":
					Estimate.StatusColor = Constants.statusFINISHED;
					break;
			}

			Estimate.EstimateName = EstimateText;

            EditEstimateVis = false;

            database.Update(Estimate);
        }

        public void SoftDeletePageOption()
        {
            HamburgerVis = false;
            Navigation.PushAsync(new SoftDeletePage());
        }

        public void SearchTextChanged()
        {
            if (!SearchText.Equals(""))
            {
				SearchListVisibility = true;
				ClientListVisibility = false;

				SearchedClientList =
              new ObservableCollection<ClientName>(database.Table<ClientName>().ToList().Where(x => x.Name != null && x.IsSoftDeleted == false && ( x.Name.ToUpper().Contains(SearchText.ToUpper()) 
             || x.PhoneNumber.ToUpper().Contains(SearchText.ToUpper()) || x.Address.ToUpper().Contains(SearchText.ToUpper()) || x.Email.ToUpper().Contains(SearchText.ToUpper()) 
             || x.Status.ToUpper().Contains(SearchText.ToUpper()))).ToList());

            }
            else
			{
				SearchListVisibility = false;
			    ClientListVisibility = true;
			}

            RefreshList();
        }

        public void SearchETextChanged()
        {
            if (!ESearchText.Equals(""))
            {
                ESearchListVisibility = true;
                EstimateListVisibility = false;

                ESearchedClientList =
              new ObservableCollection<ClientName>(database.Table<ClientName>().ToList().Where(x => x.Name == null && x.IsSoftDeleted == false && 
              (x.EstimateName.ToUpper().Contains(ESearchText.ToUpper()) || x.Status.ToUpper().Contains(ESearchText.ToUpper()))).ToList());
                //x.EstimateName.ToUpper().Contains(ESearchText.ToUpper()) || x.Status.ToUpper().Contains(SearchText.ToUpper()))
            }
            else
            {
                ESearchListVisibility = false;
                EstimateListVisibility = true;
            }

            RefreshList();
        }

        public void ShowHamMenu()
        {
            if(HamburgerVis == false)
                HamburgerVis = true;
            else
                HamburgerVis = false;
        }

        public void GoToOptionPricePage()
        {
            HamburgerVis = false;
            Navigation.PushAsync(new OptionPricePage());
        }

		public void AddClient()
        {
			NewClient.Name = string.Empty;
            NewClient.Address = string.Empty;
            NewClient.PhoneNumber = string.Empty;
            NewClient.Email = string.Empty;
			NewClient.EstimateName = string.Empty;
            ItIsVisible = true;            
        }

        public void OkClient()
        {
			//Cleans up errors messages that may be left hanging around.
			ErrorCleanup();
			
			//Check if all client entries are okay.
			if (CheckClientEntries())
			{
				clientName = new ClientName
				{
				    Name           = NewClient.Name,
				    Address        = NewClient.Address,
				    PhoneNumber    = NewClient.PhoneNumber,
					FormattedPhone = string.Format("{0:(###) ###-####}", Convert.ToDouble(NewClient.PhoneNumber)),
				    Email          = NewClient.Email,
				};

                AllList.Add(clientName);
                database.Insert(clientName);
				ClientList.Add(clientName);
				ItIsVisible = false;

				SearchBarVisible();
				Navigation.PushAsync(new EditPage(clientName.Id, "client"));
            }			
		}

		public bool CheckClientEntries()
		{
			bool allowAdd = true;

			//Name
			if(NewClient.Name == string.Empty)
			{
				ErrorMsgName     = "Please enter a name.";
				ErrorNameVisible = true;
				allowAdd =  false;
			}

			//Address
			if (NewClient.Address == string.Empty)
			{
				ErrorMsgAddress = "Please enter an address.";
				ErrorAddressVisible = true;
				allowAdd = false;
			}

			//Email
			if (NewClient.Email == string.Empty)
			{
				ErrorMsgEmail = "Please enter an e-mail address.";
				ErrorEmailVisible = true;
				allowAdd = false;
			}
			else
			if (!RegexUtil.ValidateEmailAddress().IsMatch(NewClient.Email))
			{
				ErrorMsgEmail = "Please enter a valid e-mail address.";
				ErrorEmailVisible = true;
				allowAdd = false;
			}

			//Phone Number
			if (NewClient.PhoneNumber == string.Empty)
			{
				ErrorMsgPhoneNum = "Please enter a phone number.";
				ErrorPhoneNumVisible = true;
				allowAdd = false;
			}
			else
			if (!RegexUtil.ValidatePhoneNumber().IsMatch(NewClient.PhoneNumber))
			{
				ErrorMsgPhoneNum = "Please enter a valid 10 digit phone number.";
				ErrorPhoneNumVisible = true;
				allowAdd = false;
			}

			return allowAdd;
		}

		public void ErrorCleanup()
		{
			ErrorNameVisible     = false;
			ErrorAddressVisible  = false;
			ErrorPhoneNumVisible = false;
			ErrorEmailVisible    = false;
			ErrorEstimateVisible = false;
		}

		public void OkEstimate()
        {
			ErrorCleanup();

			if (CheckEstimateEntry())
			{
				clientName = new ClientName
				{
				    EstimateName = NewClient.EstimateName
				};

				AllList.Add(clientName);
				database.Insert(clientName);
				EstimateList.Add(clientName);

				ItIsVisible = false;

				Navigation.PushAsync(new EditPage(clientName.Id, "client"));
			}

        }

		public bool CheckEstimateEntry()
		{
			bool allowAdd = true;

			//Name
			if (NewClient.EstimateName == string.Empty)
			{
				ErrorMsgEstimate = "Please enter a name.";
				ErrorEstimateVisible = true;
				allowAdd = false;
			}

			return allowAdd;
		}

        public void CancelOption()
        {
			ErrorCleanup();
			ItIsVisible = false;
        }

		public void InfoClient(ClientName client)
        {  
            SaveClient(client);
          
            Navigation.PushAsync(new ClientInfoPage(client.Id));
      
        }

        public void OptionClient(ClientName client)
        {

            SaveClient(client);

            Navigation.PushAsync(new EditPage(client.Id, "client"));
        }

		public async void RemoveClient(ClientName client)
        {
			bool result = await DeleteClientWarning();
			if (!result)
			{ 
				if (client.Name != null)
				    ClientList.Remove(client);
				else
				    EstimateList.Remove(client);

                client.IsSoftDeleted = true;

                database.Update(client);

                RefreshList();

                SearchBarVisible();
                ESearchBarVisible();

                if (ClientList.Count == 3)
                {
                    SearchText = "";
                    SearchTextChanged();
                }
                else
                    SearchTextChanged();

                if (EstimateList.Count == 3)
                {
                    ESearchText = "";
                    SearchETextChanged();
                }
                else
                    SearchETextChanged();

            }
        }

		public async Task<bool> DeleteClientWarning()
		{
			return await Application.Current.MainPage.DisplayAlert("Deleting Selection", "Are you sure you want to delete this selection?", "No", "Yes");
		}

		/*public void EditClientInfo(string name, string address, string number, string email, int index)
        {          
            ClientList[index].Name = name;
            ClientList[index].Address = address;
            ClientList[index].PhoneNumber = number;
            ClientList[index].Email = email;
        }*/

		public void SaveClient(ClientName index)
        {
            lock (collisionLock)

                if (index.Id != 0)
                {
                    database.Update(index);
                }
                else
                {
                    database.Insert(index);
                }
        }      

        public void CreateDatabase()
        {
            database =
        DependencyService.Get<IDatabaseConnection>().
        DbConnection();

            database.CreateTable<ClientName>();
            
            database.CreateTable<DatabasePrices>();

            if (!database.Table<DatabasePrices>().Any())
            {
                //Start Driveway
                DBPrices.M_DrivewayGreen = Constants.M_DrivewayGreen;
                DBPrices.B_DrivewayGreen = Constants.B_DrivewayGreen;
                DBPrices.MIN_DrivewayGreen = Constants.Min_DrivewayGreen;

                DBPrices.M_DrivewayYellow = Constants.M_DrivewayYellow;
                DBPrices.B_DrivewayYellow = Constants.B_DrivewayYellow;
                DBPrices.MIN_DrivewayYellow = Constants.Min_DrivewayYellow;

                DBPrices.M_DrivewayRed = Constants.M_DrivewayRed;
                DBPrices.B_DrivewayRed = Constants.B_DrivewayRed;
                DBPrices.MIN_DrivewayRed = Constants.Min_DrivewayRed;

                //End Driveway

                //Start DriveReplace
                DBPrices.M_DriveReplaceGreen = Constants.M_DriveReplaceGreen;
                DBPrices.B_DriveReplaceGreen = Constants.B_DriveReplaceGreen;
                DBPrices.MIN_DriveReplaceGreen = Constants.Min_DriveReplaceGreen;

                DBPrices.M_DriveReplaceYellow = Constants.M_DriveReplaceYellow;
                DBPrices.B_DriveReplaceYellow = Constants.B_DriveReplaceYellow;
                DBPrices.MIN_DriveReplaceYellow = Constants.Min_DriveReplaceYellow;

                DBPrices.M_DriveReplaceRed = Constants.M_DriveReplaceRed;
                DBPrices.B_DriveReplaceRed = Constants.B_DriveReplaceRed;
                DBPrices.MIN_DriveReplaceRed = Constants.Min_DriveReplaceRed;

                //End DriveReplace

                //Start Patio
                DBPrices.M_PatioGreen = Constants.M_PatioGreen;
                DBPrices.B_PatioGreen = Constants.B_PatioGreen;
                DBPrices.MIN_PatioGreen = Constants.Min_PatioGreen;

                DBPrices.M_PatioYellow = Constants.M_PatioYellow;
                DBPrices.B_PatioYellow = Constants.B_PatioYellow;
                DBPrices.MIN_PatioYellow = Constants.Min_PatioYellow;

                DBPrices.M_PatioRed = Constants.M_PatioRed;
                DBPrices.B_PatioRed = Constants.B_PatioRed;
                DBPrices.MIN_PatioRed = Constants.Min_PatioRed;

                //End Patio

                //Start PatioReplace
                DBPrices.M_PatioReplaceGreen = Constants.M_PatioReplaceGreen;
                DBPrices.B_PatioReplaceGreen = Constants.B_PatioReplaceGreen;
                DBPrices.MIN_PatioReplaceGreen = Constants.Min_PatioReplaceGreen;

                DBPrices.M_PatioReplaceYellow = Constants.M_PatioReplaceYellow;
                DBPrices.B_PatioReplaceYellow = Constants.B_PatioReplaceYellow;
                DBPrices.MIN_PatioReplaceYellow = Constants.Min_PatioReplaceYellow;

                DBPrices.M_PatioReplaceRed = Constants.M_PatioReplaceRed;
                DBPrices.B_PatioReplaceRed = Constants.B_PatioReplaceRed;
                DBPrices.MIN_PatioReplaceRed = Constants.Min_PatioReplaceRed;

                //End PatioReplace

                //Start Pooldeck
                DBPrices.M_PooldeckGreen = Constants.M_PooldeckGreen;
                DBPrices.B_PooldeckGreen = Constants.B_PooldeckGreen;
                DBPrices.MIN_PooldeckGreen = Constants.Min_PooldeckGreen;

                DBPrices.M_PooldeckYellow = Constants.M_PooldeckYellow;
                DBPrices.B_PooldeckYellow = Constants.B_PooldeckYellow;
                DBPrices.MIN_PooldeckYellow = Constants.Min_PooldeckYellow;

                DBPrices.M_PooldeckRed = Constants.M_PooldeckRed;
                DBPrices.B_PooldeckRed = Constants.B_PooldeckRed;
                DBPrices.MIN_PooldeckRed = Constants.Min_PooldeckRed;

                //End Pooldeck

                //Start PooldeckReplace
                DBPrices.M_PooldeckReplaceGreen = Constants.M_PooldeckReplaceGreen;
                DBPrices.B_PooldeckReplaceGreen = Constants.B_PooldeckReplaceGreen;
                DBPrices.MIN_PooldeckReplaceGreen = Constants.Min_PooldeckReplaceGreen;

                DBPrices.M_PooldeckReplaceYellow = Constants.M_PooldeckReplaceYellow;
                DBPrices.B_PooldeckReplaceYellow = Constants.B_PooldeckReplaceYellow;
                DBPrices.MIN_PooldeckReplaceYellow = Constants.Min_PooldeckReplaceYellow;

                DBPrices.M_PooldeckReplaceRed = Constants.M_PooldeckReplaceRed;
                DBPrices.B_PooldeckReplaceRed = Constants.B_PooldeckReplaceRed;
                DBPrices.MIN_PooldeckReplaceRed = Constants.Min_PooldeckReplaceRed;

                //End PooldeckReplace

                //Start Sidewalk
                DBPrices.Cost_SidewalkGreen = Constants.cost_sidewalkGreen;
                DBPrices.Cost_SidewalkYellow = Constants.cost_sidewalkYellow;
                DBPrices.Cost_SidewalkRed = Constants.cost_sidewalkRed;

                //End Sidewalk

                //Start SidewalkReplace
                DBPrices.Cost_SidewalkReplaceGreen = Constants.cost_sidewalkReplaceGreen;
                DBPrices.Cost_SidewalkReplaceYellow = Constants.cost_sidewalkReplaceYellow;
                DBPrices.Cost_SidewalkReplaceRed = Constants.cost_sidewalkReplaceRed;

                //End SidewalkReplace

                //Start GarageCap
                DBPrices.Cost_GarageCapGreen = Constants.cost_garageCapGreen;
                DBPrices.Cost_GarageCapYellow = Constants.cost_garageCapYellow;
                DBPrices.Cost_GarageCapRed = Constants.cost_garageCapRed;

                //End GrageCap

                //Start Curb
                DBPrices.Cost_Curb = Constants.cost_curb;

                //End Curb

                //Start CurbReplace
                DBPrices.Cost_CurbReplace = Constants.cost_curbReplace;

                //End CurbReplace

                //Start AddFill
                DBPrices.Cost_AddFill = Constants.cost_addFill;

                //End AddFill

                //Start Footing
                DBPrices.Cost_Footing = Constants.cost_footing;

                //End Footing

                //Start ConcreteBreakout
                DBPrices.Cost_ConcreteBreakout = Constants.cost_concreteBreakout;

                //End ConcreteBreakout

                //Start Sawcut
                DBPrices.Cost_Sawcut = Constants.cost_sawcut;

                //End Sawcut

                //Start RemoveFill
                DBPrices.Cost_RemoveFill = Constants.cost_removeFill;

                //End RemoveFill

                //Start WoodDeckRemoval
                DBPrices.Cost_WoodDeckRemoval = Constants.cost_WoodDeckRemoval;

                //End WoodDeckRemoval

                //Start BrickLedge
                DBPrices.Cost_BrickLedge = Constants.cost_brickLedge;

                //End BrickLedge

                //Start ThickenedEdge
                DBPrices.Cost_ThickenedEdge = Constants.cost_thickenedEdge;

                //End ThickendEdge

                //Start 6gwire
                DBPrices.Cost_6gWire = Constants.cost_6gWire;

                //End 6gwire

                //Start HighwayMat
                DBPrices.Cost_HighwayMat = Constants.cost_highwayMat;

                //End Highwaymat

                //Start 4000PSI
                DBPrices.Cost_4000PSI = Constants.cost_4000PSI;

                //End 4000PSI

                //Start Fiber
                DBPrices.Cost_Fiber = Constants.cost_fiber;

                //End Fiber

                //Start ExposedAggregate
                DBPrices.Cost_ExposedAggregate = Constants.cost_exposedAggregate;

                //End ExposedAggregate

                //Start NarrowDrive1
                DBPrices.Cost_NarrowDrive1 = Constants.cost_narrowDrive1;

                //End NarrowDrive1

                //Start NarrowDrive2
                DBPrices.Cost_NarrowDrive2 = Constants.cost_narrowDrive2;

                //End NarrowDrive2

                //Start NarrowDrive3
                DBPrices.Cost_NarrowDrive3 = Constants.cost_narrowDrive3;

                //End NarrowDrive3

                //Start FillRemoved1
                DBPrices.Cost_FillRemoved1 = Constants.cost_fillRemoved1;

                //End FillRemoved1

                //Start FillRemoved2
                DBPrices.Cost_FillRemoved2 = Constants.cost_fillRemoved2;

                //End FillRemoved2

                //Start Thick5Inchnes
                DBPrices.Cost_Thick5Inches = Constants.cost_thick5Inches;

                //End Thick5Inches

                //Start Thick6Inches
                DBPrices.Cost_Thick6Inches = Constants.cost_thick6Inches;

                //End Thick6Inches

                //Start 12x8With_2numb5s
                DBPrices.Cost_12x8With_2numb5s = Constants.cost_12x8With_2numb5s;

                //End 12x8With_2numb5s

                //Start 12x12With_4numb5s
                DBPrices.Cost_12x12With_4numb5s = Constants.cost_12x12With_4numb5s;

                //End 12x12With_4numb5s

                //Start 12x14With_4numb5s
                DBPrices.Cost_12x14With_4numb5s = Constants.cost_12x14With_4numb5s;

                //End 12x14With_4numb5s

                //Start ThinSidewalk
                DBPrices.Cost_ThinSidewalk = Constants.cost_thinSidewalk;

                //End ThinSidewalk

                database.Insert(DBPrices);
            }

            RefreshList();

        }

        public void RefreshList()
        {
            AllList =
                 new ObservableCollection<ClientName>(database.Table<ClientName>());

            this.ClientList =
              new ObservableCollection<ClientName>(database.Table<ClientName>().ToList().Where(x => x.Name != null && x.IsSoftDeleted == false).ToList());

            this.EstimateList =
              new ObservableCollection<ClientName>(database.Table<ClientName>().ToList().Where(x => x.Name == null && x.IsSoftDeleted == false).ToList());

            SearchBarVisible();
            ESearchBarVisible();

        }

        public void GetClientStatusList()
        {
            StatusList = new List<string>();
            StatusList = Constants.statusList;
        }

        public void SearchBarVisible()
		{
			if(ClientList.Count >= 4 )
			{ShowSearch = true;}
			else
			{ShowSearch = false; }
		}

        public void ESearchBarVisible()
        {
            if (EstimateList.Count >= 4)
            { EShowSearch = true; }
            else
            { EShowSearch = false; }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}




