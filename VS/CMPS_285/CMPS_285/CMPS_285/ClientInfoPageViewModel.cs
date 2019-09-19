using Plugin.Media;
using Plugin.Media.Abstractions;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CMPS_285
{
    class ClientInfoPageViewModel : INotifyPropertyChanged
    {

        private SQLiteConnection database;
        private static object collisionLock = new object();
        private readonly INavigation navigation;
		private List<string> statusList;

        public bool _isVisible;
        public bool _isNotVisible = true;

        public ClientPictures clientPics;

        public ICommand ShowCommand { get; set; }
        public ICommand HideCommand { get; set; }
        public ICommand SaveCommand { get; set; }
		public ICommand PicCommand  { get; set; }
		public ICommand TakePicCommand { get; set; }
		public ICommand RemovePicCommand { get; set; }
		public ICommand ViewPicCommand { get; set; }

		//Error Message Bools
		public bool errorVisible_Option;

        //Error Messages
        public String errorMsg_Option;

        //Error Message Visibility
        public bool ErrorOptionNameVis { get { return errorVisible_Option; } set { errorVisible_Option = value; OnPropertyChanged("ErrorOptionNameVis"); } }

        //Error Messages
        public String ErrorMsgOptionName { get { return errorMsg_Option; } set { errorMsg_Option = value; OnPropertyChanged("ErrorMsgOptionName"); } }

		//Get Client Status List
		public List<string> StatusList { get { return statusList; } set { statusList = value; OnPropertyChanged("StatusList"); } }

		//Get List of Pictures
		public ObservableCollection<ClientPictures> pictureList;
		public ObservableCollection<ClientPictures> PictureList { get { return pictureList; } set { pictureList = value; OnPropertyChanged("PictureList"); } }


        public ObservableCollection<ImageSource> pictureListConverted;
        public ObservableCollection<ImageSource> PictureListConverted { get { return pictureListConverted; } set { pictureListConverted = value; OnPropertyChanged("PictureListConverted"); } }

        //Converted Picture List
        public ObservableCollection<string> Test;
        public ObservableCollection<string> test { get { return Test; } set { Test = value; OnPropertyChanged("test"); } }


        public bool ItIsVisible { get { return _isVisible; } set { _isVisible = value; OnPropertyChanged("ItIsVisible"); } }
        public bool ItIsNotVisible { get { return _isNotVisible; } set { _isNotVisible = value; OnPropertyChanged("ItIsNotVisible"); } }

		public ImageSource img;
		public ImageSource IMG { get { return img; } set { img = value; OnPropertyChanged("IMG"); } }

		public event PropertyChangedEventHandler PropertyChanged;

        public ClientName Client { get; set;}

        public ClientPictures ClientPics { get; set; }

        public ClientInfoPageViewModel(INavigation navigation, int clientId)
        {
            this.navigation = navigation;
            PictureListConverted = new ObservableCollection<ImageSource>();

            database =
        DependencyService.Get<IDatabaseConnection>().
        DbConnection();


            Client = database.Table<ClientName>().FirstOrDefault(client => client.Id == clientId);

           

            CreateDatabase();

            ClientPics = database.Table<ClientPictures>().FirstOrDefault(client => client.Id == clientId);

            ShowCommand = new Command(ShowClient);
            HideCommand = new Command(HideClient);
            SaveCommand = new Command(OnSave);
			PicCommand  = new Command(AddPicture);
			TakePicCommand = new Command(TakePicture);
			RemovePicCommand = new Command<ImageSource>(RemovePicture);
			ViewPicCommand = new Command<ImageSource>(ViewPicture);


			GetClientStatusList();
            //IMG = GetImage(clientPics.Pictures);


		}

        public void RemovePicture(ImageSource pic)
        {
            int removeInt = PictureListConverted.IndexOf(pic);
            database.Delete(PictureList[removeInt]);
            database.Update(PictureList[removeInt]);
			ClientPictures picRemoved = PictureList[removeInt];

			PictureList.RemoveAt(removeInt);
            PictureListConverted.Remove(pic);

			RefreshList();
		}

		public void ShowClient()
        {
            ItIsVisible = true;
            ItIsNotVisible = false;
        }

        public void HideClient()
        {
            ItIsNotVisible = true;
            ItIsVisible = false;
        }

        public void OnSave()
        {
			//Set Status Color
			switch(Client.Status)
			{
				case "PENDING": 
					Client.StatusColor = Constants.statusPENDING;
					break;
				case "PAID":
					Client.StatusColor = Constants.statusPAID;
					break;
				case "FINISHED":
					Client.StatusColor = Constants.statusFINISHED;
					break;
			}

			//Save
			if(CheckClientEntries())
			{ 
			lock (collisionLock)
                if (Client.Id != 0)
                {
                    database.Update(Client);
					database.Update(ClientPics);
                }
                else
                {
                    database.Insert(Client);
					database.Insert(ClientPics);
				}

                navigation.PopAsync();
			}
        }

		public async void AddPicture()
		{
            clientPics = new ClientPictures
            {
                ClientId = Client.Id,
                Pictures = await Pic()
            };

			if(clientPics.Pictures != null)
			{
				PictureList.Add(clientPics);
				database.Insert(clientPics);
				IMG = GetImage(clientPics.Pictures);
			}
			database.Update(ClientPics);
            ConverterAsync();
        }

		public async void TakePicture()
		{
			clientPics = new ClientPictures
			{
				ClientId = Client.Id,
				Pictures = await TakePic()
			};

			if (clientPics.Pictures != null)
			{
				PictureList.Add(clientPics);
				database.Insert(clientPics);
				IMG = GetImage(clientPics.Pictures);
			}
			database.Update(ClientPics);
			ConverterAsync();
		}

		public void ViewPicture(ImageSource pic)
		{
			navigation.PushAsync(new FullScreenPic(pic));
		}

		public void ConverterAsync()
        {
            PictureListConverted.Clear();
            for (int i = 0; i < PictureList.Count; i++)
            {
                PictureListConverted.Add(GetImage(PictureList[i].Pictures));
            }
        }

		public async Task<byte[]> Pic()
		{
			try
			{ 
				var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions{
					PhotoSize = PhotoSize.Medium,
					CompressionQuality = 80,
				});

				//Return if Backed out of camera roll
				if (file == null)
					return null;

				using (var memoryStream = new MemoryStream())
				{
					file.GetStream().CopyTo(memoryStream);
					file.Dispose();
					return memoryStream.ToArray();
				}
			}
			catch(Exception)
			{ return null;}
		}

		public async Task<byte[]> TakePic()
		{
			try
			{
				var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
				{
					SaveToAlbum = true,
					PhotoSize = PhotoSize.Medium,
					CompressionQuality = 80,
				});

				//Return if Backed out of camera roll
				if (file == null)
					return null;

				using (var memoryStream = new MemoryStream())
				{
					file.GetStream().CopyTo(memoryStream);
					file.Dispose();
					return memoryStream.ToArray();
				}
			}
			catch(Exception)
			{return null; }
		}

		public ImageSource GetImage(byte[] pic)
		{
			return ImageSource.FromStream(() => new MemoryStream(pic));
		}

		public bool CheckClientEntries()
		{
			bool allowAdd = true;

			//Name
			if (Client.Name == string.Empty)
			{
                ErrorMsgOptionName = "Please Enter ALL Entry Fields!";
                ErrorOptionNameVis = true;
                allowAdd = false;
            }

			//Address
			if (Client.Address == string.Empty)
			{
                ErrorMsgOptionName = "Please Enter ALL Entry Fields!";
                ErrorOptionNameVis = true;
                allowAdd = false;
            }

			//Email
			if (Client.Email == string.Empty)
			{
                ErrorMsgOptionName = "Please Enter ALL Entry Fields!";
                ErrorOptionNameVis = true;
                allowAdd = false;
            }
			else
			if (!RegexUtil.ValidateEmailAddress().IsMatch(Client.Email))
			{
                ErrorMsgOptionName = "Please Enter ALL Entry Fields!";
                ErrorOptionNameVis = true;
                allowAdd = false;
            }

			//Phone Number
			if (Client.PhoneNumber == string.Empty)
			{
                ErrorMsgOptionName = "Please Enter ALL Entry Fields!";
                ErrorOptionNameVis = true;
                allowAdd = false;
            }
			else
			if (!RegexUtil.ValidatePhoneNumber().IsMatch(Client.PhoneNumber))
			{
                ErrorMsgOptionName = "Please Enter ALL Entry Fields!";
                ErrorOptionNameVis = true;
                allowAdd = false;
            }

			return allowAdd;
		}

		public void GetClientStatusList()
		{
			StatusList = new List<string>();
			StatusList = Constants.statusList;
		}

        public void CreateDatabase()
        {
            database.CreateTable<ClientPictures>();

            RefreshList();
        }

        public void RefreshList()
        {
            this.PictureList =
                new ObservableCollection<ClientPictures>(database.Table<ClientPictures>().ToList().Where(x => x.ClientId == Client.Id).ToList());
            
            if(PictureList != null)
            {
                ConverterAsync();
            }

		}

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

/*
    TODO
	Make an observable collection of image source and then make a method that goes through PictureList
	and converts everything inside of PictureList to an ImageSource. The bind the listview to the 
	ImageSource collection inside the xaml.

	Make a singular converter for when adding a single picture.
*/