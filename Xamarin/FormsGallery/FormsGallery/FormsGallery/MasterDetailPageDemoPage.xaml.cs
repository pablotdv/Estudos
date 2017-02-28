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
    public partial class MasterDetailPageDemoPage : MasterDetailPage
    {
        public MasterDetailPageDemoPage()
        {
            InitializeComponent();

            masterPage.NamedColors.ItemSelected += NamedColors_ItemSelected;            
        }

        private void NamedColors_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.Detail.BindingContext = e.SelectedItem;

            this.IsPresented = false;
        }
    }
}
