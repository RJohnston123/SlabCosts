using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CMPS_285
{
    public class OptionPriceViewModel
    {
        private static SQLiteConnection database;
        public DatabasePrices Prices { get; set; }

        public ICommand SaveCommand { get; set; }

        public INavigation Navigation { get; set; }

        

        public OptionPriceViewModel(INavigation navigation)
        {
            Navigation = navigation;

            CreateDatabase(1);

            SaveCommand = new Command(SaveOption);
        }

        public void SaveOption()
        {
            database.Update(Prices);

            Navigation.PopAsync();
        }

        public void CreateDatabase(int databaseID)
        {
            database =
        DependencyService.Get<IDatabaseConnection>().
        DbConnection();

            Prices = database.Table<DatabasePrices>().FirstOrDefault(database => database.Id == databaseID);

        }
    }
}
