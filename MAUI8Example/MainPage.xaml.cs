namespace MAUI8Example
{
    public partial class MainPage : ContentPage
    {        
        public MainPage()
        {
            InitializeComponent();
        }        

        private async void btnMonkeys_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("monkeys");
        }
    }

}
