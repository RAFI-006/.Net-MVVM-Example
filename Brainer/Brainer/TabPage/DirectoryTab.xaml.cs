using Brainer.Model;
using Brainer.Utils;
using Brainer.ViewModel;
using Plugin.Connectivity;
using System;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brainer.TabPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //Directory Tab Conatins Info all The diffrent  Section of the firm
    public partial class DirectoryTab : ContentPage
    {
        DirectoryTabViewModel mViewModel;
        public DirectoryTab()
        {
            InitializeComponent();

            mViewModel = new DirectoryTabViewModel();
            BindingContext = mViewModel;
         
        }
    }
}