using SQLite;

namespace Calculator
{
    public class CalcHistoryModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CurrentCalculation { get; set; }
    }

}   