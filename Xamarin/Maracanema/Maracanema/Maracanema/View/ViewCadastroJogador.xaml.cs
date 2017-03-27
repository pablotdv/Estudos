using Maracanema.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maracanema.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewCadastroJogador : ContentPage
    {
        public ViewCadastroJogador()
        {
            InitializeComponent();

            BindingContext = new JogadorViewModel();
        }
    }
}
