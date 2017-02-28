using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class NamedColor
    {
        public NamedColor(string name, Color color, bool includeBigLabel = true)
        {
            this.Name = name;
            this.Color = color;
            this.IncludeBigLabel = includeBigLabel;
        }

        public string Name { private set; get; }

        public Color Color { private set; get; }

        public bool IncludeBigLabel { private set; get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
