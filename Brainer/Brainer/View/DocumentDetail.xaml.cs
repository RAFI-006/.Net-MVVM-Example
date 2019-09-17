using Brainer.Data;
using Brainer.Model;
using Brainer.Repository;
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
    // class to Show Details of the respective Documnets or Case Studies Uploaded By the User
	public partial class DocumentDetail : ContentPage
	{
       public DocumentDetail (DocumentModel model)
		{
			InitializeComponent ();
            BindingContext = new DocumentDetailViewModel(model);
       }

    }   
}