using CommunityToolkit.Mvvm.ComponentModel;


namespace Calculator
{
    public partial class CalcHistoryHelper : ObservableObject
    {

        public CalcHistoryHelper()
        {
            Calcs = new List<CalcHistoryModel>();
        }


        [ObservableProperty]
        public static List<CalcHistoryModel> calcs;


    }

}
