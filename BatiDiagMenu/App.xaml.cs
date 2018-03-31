using BatiDiagMenu.Data;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;
using BatiDiagMenu.Views;
namespace BatiDiagMenu
{
    public partial class App : Application
    {
        static public double ScreenWidth;
        static public double ScreenHeight;
        public static MenuItemDatabase Database { get; private set; }
        public App()
        {
            InitializeComponent();
            Database = new MenuItemDatabase();
            FlowListView.Init();
            MainPage = new NavigationPage(new BatiDiagMenuPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
