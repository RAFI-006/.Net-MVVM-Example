using Brainer.Model;
using Brainer.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Brainer.ViewModel
{
  public  class IntroScreensViewModel
    {
        public ObservableCollection<Slide> IntroSlides { get; }
        public ICommand SkipButtonClicked { get; set; }
        INavigation Navigation;

        public    IntroScreensViewModel(INavigation navigation)
        {
            Navigation = navigation;
            SkipButtonClicked = new Command(SkipButton_Tapped);
          IntroSlides = new ObservableCollection<Slide>(new[]
         {
                new Slide("directory.png",false),
                new Slide("peopleSearch.png",false),
                new Slide("topicSkills.png",false),
                new Slide("documentLibrary.png",true)
            });


        }

        #region Skip Button Handled
        private async  void SkipButton_Tapped(object obj)
        {
            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(TabPages))
                await Navigation.PushAsync(new TabPages());

        }
        #endregion
    }


}
