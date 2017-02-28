using System;
using System.Windows.Input;
using Xamarin.Forms;


namespace FormsGallery
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();

            NavigateCommand = new Command<Type>(OpenPage());

            BindingContext = this;
        }

        private Action<Type> OpenPage()
        {
            return async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await Navigation.PushAsync(page);
            };
        }

        public ICommand NavigateCommand { private set; get; }
    }
 }
