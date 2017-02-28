using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsGallery
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView NamedColors { get { return NamedColorListView; } }
        public MasterPage()
        {
            InitializeComponent();

            NamedColor[] namedColors = {
                new NamedColor ("Aqua", Color.Aqua),
                new NamedColor ("Black", Color.Black),
                new NamedColor ("Blue", Color.Blue),
                new NamedColor ("Fuchsia", Color.Fuchsia),
                new NamedColor ("Gray", Color.Gray),
                new NamedColor ("Green", Color.Green),
                new NamedColor ("Lime", Color.Lime),
                new NamedColor ("Maroon", Color.Maroon),
                new NamedColor ("Navy", Color.Navy),
                new NamedColor ("Olive", Color.Olive),
                new NamedColor ("Purple", Color.Purple),
                new NamedColor ("Red", Color.Red),
                new NamedColor ("Silver", Color.Silver),
                new NamedColor ("Teal", Color.Teal),
                new NamedColor ("White", Color.White),
                new NamedColor ("Yellow", Color.Yellow)
            };

            NamedColorListView.ItemsSource = namedColors;
        }
    }
}
