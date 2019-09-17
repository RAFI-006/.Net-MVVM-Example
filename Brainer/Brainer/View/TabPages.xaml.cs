using Brainer.TabPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;
using Rg.Plugins.Popup.Services;
using Brainer.Utils;

namespace Brainer.View
{
    //Activtiy for Tabs  Implementation
	public partial class TabPages : Xamarin.Forms.TabbedPage
	{
        private ToolbarItem toolbarItem;
        public TabPages ()
		{
			InitializeComponent ();


            toolbarItem = new ToolbarItem(
                             "search", "setting.png", async () =>
                          {
                              
                              await PopupNavigation.PushAsync(new NavigationMenuPopUpPage());
                          }, 0, 0);
            ToolbarItems.Add(toolbarItem);


              //Platform Specific Code
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Android>().SetBarSelectedItemColor(Color.FromHex("#fedb0e"));
            On<Android>().SetBarItemColor(Color.White);
            On<Android>().SetIsSwipePagingEnabled(false);
                     
            
       
            this.CurrentPageChanged += CurrentPageChangedOfTAb;
        }

        
        protected override bool OnBackButtonPressed()
        {
            MessagingCenter.Send<object>(this, "backButtonPressed");
            


            return base.OnBackButtonPressed();
        }

        private void CurrentPageChangedOfTAb(object sender, EventArgs e)
        {
            int index = Children.IndexOf(CurrentPage);
            if(index==1)
            {
                MessagingCenter.Send<Object>(this, "peopleSearch_tab");
            }
            else if(index==2)
            {
                MessagingCenter.Send<Object>(this, "topic_skills_tab");

            }
            else if (index == 3)
            {
                MessagingCenter.Send<Object>(this, "document_library_tab");

            }

        }
    }

    #region Change Color of the ICon on Tab For IOS
    public class UnselectedTabColorEffect : RoutingEffect
    {
        public UnselectedTabColorEffect()
            : base($"AppEffects.{nameof(UnselectedTabColorEffect)}")
        {
        }
    }
    #endregion

    #region  Handling IOS default Effects of tab Icons
    public class HideTabLabelsEffect : RoutingEffect
    {
        public HideTabLabelsEffect()
            : base($"AppEffects.{nameof(HideTabLabelsEffect)}")
        {
        }
    }
    #endregion



}