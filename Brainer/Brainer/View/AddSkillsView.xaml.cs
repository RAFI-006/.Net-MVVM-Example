using Brainer.Data;
using Brainer.Model;
using Brainer.Repository;
using Brainer.ViewModel;
using Rg.Plugins.Popup.Services;
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
    //Class To Add Skills And Remove Skills For The LoginUSer
	public partial class AddSkillsView : ContentPage
	{
      
		public AddSkillsView ()
		{
            InitializeComponent();
            BindingContext = new AddSkillsViewModel(Navigation);



        }
    }
}