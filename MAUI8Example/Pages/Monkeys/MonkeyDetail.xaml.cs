using MAUI8Example.Data;
using MAUI8Example.Data.Models;

namespace MAUI8Example.Pages.Monkeys;
[QueryProperty(nameof(Name), "Name")]
public partial class MonkeyDetail : ContentPage
{
    MonkeyService monkeyService;
    string _Name;
    public string Name
    {
        get => _Name;
        set
        {
            _Name = value;
            SetParams();
        }
    }
    public Monkey selectedMonkey { get; set; }
    public MonkeyDetail(MonkeyService service)
	{
		InitializeComponent();
        this.monkeyService = service;
    }
    public void SetParams()
    {
        var selectedMonkey = monkeyService._monkeys.Where(m => m.Name == _Name).FirstOrDefault();
        if(selectedMonkey != null)
        {
            lblName.Text = selectedMonkey.Name;
            lblLocation.Text = selectedMonkey.Location;
            lblDetails.Text = selectedMonkey.Details;
        }
    }

}