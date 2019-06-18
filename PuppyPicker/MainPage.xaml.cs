using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PuppyPicker
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            var masterPage = new MenuPage(this);
            Master = masterPage;
            Detail = new NavigationPage(new HomePage());

            InitializeComponent();
        }
    }
}
