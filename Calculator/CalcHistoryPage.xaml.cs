namespace Calculator;

public partial class CalcHistoryPage : ContentPage
{

	public CalcHistoryPage(CalcHistoryDatabase calcDB, CalcHistoryModel CHM)
	{
		InitializeComponent();
		BindingContext = CHM;
		database = calcDB;
		getAllCalculations();

    }
    CalcHistoryDatabase database;
    public async void getAllCalculations()
	{
		//if (CalcHistoryHelper.calcs.Count > 0)
		//{
  //          CalcHistoryHelper.calcs.Clear();
  //      }
		CalcHistoryHelper.calcs = await database.GetItemsAsync();
		CalsHistory.ItemsSource = CalcHistoryHelper.calcs;
	}

    public async void deleteCalculations(object sender, EventArgs e)
    {
        await database.DeleteItemsAsync();
        getAllCalculations();
    }

}