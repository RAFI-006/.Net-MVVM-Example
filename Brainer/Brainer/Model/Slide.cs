using System;
using System.Collections.Generic;
using System.Text;

namespace Brainer.Model
{
    public class Slide
    {
        public Slide(string image, bool isVisible )
        {
            Image = image;
            IsVisible = isVisible;

        }

        public string Image { get; set; }
        public bool IsVisible { get; set; }

    }
}
