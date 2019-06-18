using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PuppyPicker
{
    public partial class MenuPage : ContentPage
    {
        MasterDetailPage myMaster;

        public MenuPage(MasterDetailPage _myMaster)
        {
            myMaster = _myMaster;
            InitializeComponent();
        }

        void Home_Handle_Clicked(object sender, System.EventArgs e)
        {
            myMaster.Detail = new NavigationPage(new HomePage());
            myMaster.IsPresented = false;

        }


        void Match_Handle_Clicked(object sender, System.EventArgs e)
        {
            myMaster.Detail = new NavigationPage(new MatchPage());
            myMaster.IsPresented = false;
        }

        void Favorites_Handle_Clicked(object sender, System.EventArgs e)
        {
            myMaster.Detail = new NavigationPage(new FavoritesPage());
            myMaster.IsPresented = false;

        }

        void PM_Handle_Clicked(object sender, System.EventArgs e)
        {
            myMaster.Detail = new NavigationPage(new MatchHistoryPage());
            myMaster.IsPresented = false;
        }

        void Settings_Handle_Clicked(object sender, System.EventArgs e)
        {
            myMaster.Detail = new NavigationPage(new SettingsPage());
            myMaster.IsPresented = false;

        }

        void Support_Handle_Clicked(object sender, System.EventArgs e)
        {
            myMaster.Detail = new NavigationPage(new SupportPage());
            myMaster.IsPresented = false;

        }
		void Logout_Handle_Clicked(object sender, System.EventArgs e)
		{
			var myApp = Application.Current as App;
			myApp.OnLogout();

		}


	}
}
