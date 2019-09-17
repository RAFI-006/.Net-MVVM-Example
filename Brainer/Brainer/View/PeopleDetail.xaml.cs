using Brainer.Data;
using Brainer.Model;
using Brainer.Repository;
using Brainer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brainer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //Class to Show Employee Details of a Particular Employee
    public partial class PeopleDetail : ContentPage
    {
        public PeopleDetail(EmployeeDetailsModel models)
        {
            InitializeComponent();
            BindingContext = new PeopleDetailsViewModel(models, Navigation);
           
        }

    





    }
}