using Microsoft.Data.SqlClient;
using SfDataGridSample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample.Service
{
    public class DatabaseService
    {
        public const string ConnectionString = "You connection string here";

        public IEnumerable<Stocks> PopulateData()
        {
            var items = new ObservableCollection<Stocks>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                 conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Ticker, CompanyName, LastPrice, Change, ChangePercent, OpenColumn,HighColumn,LowColumn,Volume,MarketCap FROM Stocks", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new Stocks
                            {
                                Ticker = reader["Ticker"].ToString(),
                                CompanyName = reader["CompanyName"].ToString(),
                                LastPrice = Convert.ToDecimal(reader["LastPrice"]),
                                Change = Convert.ToDecimal(reader["Change"]),
                                ChangePercent = Convert.ToDecimal(reader["ChangePercent"]),
                                OpenColumn = Convert.ToDecimal(reader["OpenColumn"]),
                                HighColumn = Convert.ToDecimal(reader["HighColumn"]),
                                LowColumn = Convert.ToDecimal(reader["LowColumn"]),
                                Volume = Convert.ToInt64(reader["Volume"]),
                                MarketCap = Convert.ToDecimal(reader["MarketCap"])
                            });

                        }
                    }
                }

                return items;
            }
        }
    }
}
