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
    //Tab Which Contains All the documnets,Case Study and the its Details
	public partial class DocumentLibraryTab : ContentPage
	{
        
        public DocumentLibraryTab ()
		{
			InitializeComponent ();

            //Loading Data when Tab pages is Clicked
            MessagingCenter.Subscribe<object>(this, "document_library_tab", obj => {

                
                if (CrossConnectivity.Current.IsConnected)
                    BindingContext = new DocumentTabViewModel(Navigation);
                else
                    DisplayAlert("Warning!!", "Pls Enable your Internet Connection", "Done");

               
            });

        }




    }
}