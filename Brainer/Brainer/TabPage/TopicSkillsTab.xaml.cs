using Brainer.Model;
using Brainer.View;
using Brainer.ViewModel;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brainer.TabPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
   // Tab Seperate Employees According to their Skills 
    public partial class TopicSkillsTab : ContentPage
	{
       
        public TopicSkillsTab ()
		{
			InitializeComponent ();

            //data is filling after topic skills tab is clicked
            MessagingCenter.Subscribe<object>(this, "topic_skills_tab", obj => {
               
                if (CrossConnectivity.Current.IsConnected)
                    BindingContext = new TopicSkillsViewModel(Navigation);
                else
                    DisplayAlert("Warning!!", "Pls Enable your Internet Connection", "Done");


            });

        }

      

      
    }
}