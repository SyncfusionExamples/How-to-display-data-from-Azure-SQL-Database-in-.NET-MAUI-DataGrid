using SfDataGridSample.Model;
using SfDataGridSample.Service;
using System.Collections.ObjectModel;

namespace SfDataGridSample.ViewModel
{
    public class StockViewModel
    {
        public ObservableCollection<Stocks> StockData { get; set; } = new();

        private DatabaseService _service = new();

        public void InitialyzeAsync()
        {
            foreach (var item in _service.PopulateData())
            {
                StockData.Add(item);
            }
        }

        public StockViewModel()
        {

        }
    }
}
