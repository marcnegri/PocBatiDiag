using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using BatiDiagMenu.Models;
using Xamarin.Forms;

namespace BatiDiagMenu.ViewModels
{
	public class BatiDiagMenuFormViewModel : BaseViewModel
	{

        // Accesseurs
        private ObservableCollection<Models.MenuItem> lstMenuItems;
        private Models.MenuItem selectedMenuItem;

        public Models.MenuItem SelectedMenuItem
        {
            get
            {
                return selectedMenuItem;
            }

            set
            {
                if (selectedMenuItem == value)
                    return;

                selectedMenuItem = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<Models.MenuItem> LstMenuItems         {             get             {                 return lstMenuItems;             }              set             {                 if (lstMenuItems == value)                     return;                  lstMenuItems = value;                 RaisePropertyChanged();             }         }

        //Init du ViewModel
        public BatiDiagMenuFormViewModel()
		{
            lstMenuItems = new ObservableCollection<Models.MenuItem>();
            selectedMenuItem = new Models.MenuItem();
            LstMenuItems = new ObservableCollection<Models.MenuItem>(App.Database.GetItems());
            CmdGetInfo = new Command(async () => await GetInfo());
		}

        public ICommand CmdGetInfo { protected set; get; }

        public async Task GetInfo()
        {
            MessagingCenter.Send<BatiDiagMenuFormViewModel, Models.MenuItem>(this, "GetInfoItem", SelectedMenuItem);
        }

        public async Task AddItem(Models.MenuItem currentItem)
		{
			IsBusy = true;
			try
			{
                lstMenuItems.Add(currentItem);
                App.Database.Insert(currentItem);
			}
			catch (Exception ex)
			{
				//LogsBL.LogError(App.CurrentUser, null, "EditProfileFormViewModel.SaveProfile()", ex.Message);
			}
			finally
			{
				IsBusy = false;
			}
		}

	}
}
