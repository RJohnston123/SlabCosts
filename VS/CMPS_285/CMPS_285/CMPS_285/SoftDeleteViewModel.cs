using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CMPS_285
{
    public class SoftDeleteViewModel : INotifyPropertyChanged
    {
        private SQLiteConnection database;

        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ClientName> clientList;
        private ObservableCollection<ClientName> estimateList;

        public ObservableCollection<ClientName> ClientList { get { return clientList; } set { clientList = value; OnPropertyChanged("ClientList"); } } //= new ObservableCollection<ClientName>(); 

        public ObservableCollection<ClientName> EstimateList { get { return estimateList; } set { estimateList = value; OnPropertyChanged("EstimateList"); } }

        public ICommand RemoveCommand { get; set; }

        public ICommand RestoreCommand { get; set; }



        //start
        public bool searchVisible;
        public bool esearchVisible;
        public bool searchListVisibility;
        public bool esearchListVisibility;
        public bool clientListVisibility = true;
        public bool estimateListVisibility = true;

        public string searchText = "";
        public string eSearchText = "";

        public string SearchText { get { return searchText; } set { searchText = value; OnPropertyChanged("SearchText"); } }
        public string ESearchText { get { return eSearchText; } set { eSearchText = value; OnPropertyChanged("ESearchText"); } }

        ObservableCollection<ClientName> searchedClientList;
        ObservableCollection<ClientName> eSearchedClientList;

        public ObservableCollection<ClientName> SearchedClientList { get { return searchedClientList; } set { searchedClientList = value; OnPropertyChanged("SearchedClientList"); } } //= new ObservableCollection<ClientName>();
        public ObservableCollection<ClientName> ESearchedClientList { get { return eSearchedClientList; } set { eSearchedClientList = value; OnPropertyChanged("ESearchedClientList"); } } //= new ObservableCollection<ClientName>();

        public bool ShowSearch { get { return searchVisible; } set { searchVisible = value; OnPropertyChanged("ShowSearch"); } }
        public bool EShowSearch { get { return esearchVisible; } set { esearchVisible = value; OnPropertyChanged("EShowSearch"); } }
        public bool SearchListVisibility { get { return searchListVisibility; } set { searchListVisibility = value; OnPropertyChanged("SearchListVisibility"); } }
        public bool ESearchListVisibility { get { return esearchListVisibility; } set { esearchListVisibility = value; OnPropertyChanged("ESearchListVisibility"); } }
        public bool ClientListVisibility { get { return clientListVisibility; } set { clientListVisibility = value; OnPropertyChanged("ClientListVisibility"); } }
        public bool EstimateListVisibility { get { return estimateListVisibility; } set { estimateListVisibility = value; OnPropertyChanged("EstimateListVisibility"); } }

        public ICommand SearchedTextCommand { get; set; }
        public ICommand ESearchedTextCommand { get; set; }

        //finsih

        public SoftDeleteViewModel(INavigation navigation)
        {
            Navigation = navigation;
            CreateDatabase();
            RemoveCommand = new Command<ClientName>(RemoveClientAsync);
            RestoreCommand = new Command<ClientName>(RestoreClientAsync);

            //start

            SearchedTextCommand = new Command(SearchTextChanged);

            ESearchedTextCommand = new Command(SearchETextChanged);


            SearchBarVisible();
            ESearchBarVisible();

            //finish
        }

        //start
        public void SearchTextChanged()
        {
            if (!SearchText.Equals(""))
            {
                SearchListVisibility = true;
                ClientListVisibility = false;

                SearchedClientList =
               new ObservableCollection<ClientName>(database.Table<ClientName>().ToList().Where(x => x.Name != null && x.IsSoftDeleted == true && (x.Name.ToUpper().Contains(SearchText.ToUpper())
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
              new ObservableCollection<ClientName>(database.Table<ClientName>().ToList().Where(x => x.Name == null && x.IsSoftDeleted == true && 
              (x.EstimateName.ToUpper().Contains(ESearchText.ToUpper()) || x.Status.ToUpper().Contains(ESearchText.ToUpper()))).ToList());

            }
            else
            {
                ESearchListVisibility = false;
                EstimateListVisibility = true;
            }

            RefreshList();
        }

        public void SearchBarVisible()
        {
            if (ClientList.Count >= 4)
            { ShowSearch = true; }
            else
            { ShowSearch = false; }
        }

        public void ESearchBarVisible()
        {
            if (EstimateList.Count >= 4)
            { EShowSearch = true; }
            else
            { EShowSearch = false; }
        }
        //finish

        private async void RemoveClientAsync(ClientName job)
        {
            bool result = await DeleteClientWarning();
            if (!result)
            {
                if (job.Name != null)
                    ClientList.Remove(job);
                else
                    EstimateList.Remove(job);

                database.Table<ClientName>().Delete(x => x.Id == job.Id);

                database.Update(job);

                //start
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
                //finish
            }
        }

        private async void RestoreClientAsync(ClientName job)
        {
            bool result = await RecoverClientWarning();
            if (!result)
            {
                if (job.Name != null)
                {
                job.IsSoftDeleted = false;
                ClientList.Remove(job);
                }
                else
                {
                    job.IsSoftDeleted = false;
                    EstimateList.Remove(job);                   
                }

                database.Update(job);

                //start
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
                //finish
            }
        }

        public async Task<bool> DeleteClientWarning()
        {
            return await Application.Current.MainPage.DisplayAlert("Deleting Permanently", "Are you sure you want to delete this selection permanently?", "No", "Yes");
        }

        public async Task<bool> RecoverClientWarning()
        {
            return await Application.Current.MainPage.DisplayAlert("Recover Permanently", "Are you sure you want to restore this selection?", "No", "Yes");
        }

        public void CreateDatabase()
        {
            database =
        DependencyService.Get<IDatabaseConnection>().
        DbConnection();

            database.CreateTable<ClientName>();

            RefreshList();
        }

        public void RefreshList()
        {
            this.ClientList =
              new ObservableCollection<ClientName>(database.Table<ClientName>().ToList().Where(x => x.Name != null && x.IsSoftDeleted == true).ToList());

            this.EstimateList =
                new ObservableCollection<ClientName>(database.Table<ClientName>().ToList().Where(x => x.Name == null && x.IsSoftDeleted == true).ToList());

            SearchBarVisible();
            ESearchBarVisible();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}