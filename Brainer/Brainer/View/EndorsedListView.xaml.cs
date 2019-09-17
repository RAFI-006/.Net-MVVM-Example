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
    //CLass To Show List Of Endorsers for a particular Skill of a Particular User
    public partial class EndorsedListView : ContentPage
    {
        public EndorsedListView(int empId, int skillsId)
        {
            InitializeComponent();

            BindingContext = new EndorsedListViewModel(empId, skillsId,Navigation);

        }


       }
}