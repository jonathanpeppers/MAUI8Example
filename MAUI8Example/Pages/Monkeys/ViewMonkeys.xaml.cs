using MAUI8Example.Data;

namespace MAUI8Example.Pages.Monkeys;

public partial class ViewMonkeys : ContentPage
{
	MonkeyService monkeyService;
	public ViewMonkeys(MonkeyService service)
	{
		InitializeComponent();
		this.monkeyService = service;
	}
    protected async override void OnAppearing()
    {
        base.OnAppearing();
		if(monkeyService._monkeys.Count() == 0)
		{
			await monkeyService.GetMonkeys();
		}
		SetUpList();
    }
    private void SetUpList()
	{
		List<MonkeyList> monkeyList = new List<MonkeyList>();
		int listNumber = 1;
		foreach(var m in monkeyService._monkeys)
		{
            monkeyList.Add(new MonkeyList { Name = m.Name, ListNumber = listNumber });
			listNumber++;
        }
        lvMonkey.ItemsSource = monkeyList;
	}

	public class MonkeyList
	{
        public string Name { get; set; }
		public int ListNumber { get; set; }
    }

    private async void lvMonkey_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		MonkeyList selectedMonkey = (MonkeyList)e.Item;
		await Shell.Current.GoToAsync($"monkeyDetails?Name={selectedMonkey.Name}");
    }
}