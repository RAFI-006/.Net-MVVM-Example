using Brainer.Model;
using Brainer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brainer.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    //Class to Show total Case Study Uploaded by the Employees 
	public partial class CaseStudyView : ContentPage
    {
		public CaseStudyView (DocumentModel model)
		{
			InitializeComponent ();
            BindingContext = new CaseStudyViewModel(model,Navigation);
		}


    }
}