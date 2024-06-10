# How to display data from Azure SQL Database in .NET MAUI DataGrid ?

Displaying data from an Azure SQL Database in a [.NET MAUI DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid) involves several steps: setting up your Azure SQL Database, connecting to it from your .NET MAUI application, and displaying the retrieved data in a DataGrid. Below is a step-by-step guide to help you achieve this.


### Step 1: Set Up Azure SQL Database

#### 1. Create an Azure SQL Database:

* Log into the [Azure Portal](https://portal.azure.com/).
* Navigate to "SQL Databases" and click "Add".
* Fill in the required details (Database name, server, resource group, etc.) and create the database.
* After creation, go to the database's "Connection strings" and copy the ADO.NET connection string for later use.

#### 2 .Configure Firewall:

* Go to your database settings in the Azure Portal.
* Under "Firewalls and virtual networks", add your IP address to allow access to the database.

### Step 2: Connect to Azure SQL Database
* Install the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) package to interact with SQL Server

* Create a Data Access Layer.


##### C#

Create a class for accessing the database and retrieving data.Use the ADO .NET connection string copied earlier.

```C#
public class DatabaseService
{
    public const string ConnectionString = "Your connection string here";

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

```
##### ViewModel

Populate the data in the OnAppearing() method.

```C#
 public void InitialyzeAsync()
 {
     foreach (var item in _service.PopulateData())
     {
         StockData.Add(item);
     }
 }
```

#### XAML
```XML
<syncfusion:SfDataGrid x:Name="sfGrid" ColumnWidthMode="Auto"
              ItemsSource="{Binding StockData}"/>
```

The following screenshot shows how to to display data from Azure SQL Database in .NET MAUI DataGrid.

![Column formatted using binding](SfDataGridSample_Azure_SQL_DB.png)

[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-display-data-from-Azure-SQL-Database-in-.NET-MAUI-DataGrid)

Take a moment to pursue this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples.
Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid(SfDataGrid).

### Conclusion
I hope you enjoyed learning about how to to display data from Azure SQL Database in .NET MAUI DataGrid.

You can refer to our [.NET MAUI DataGrid's feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to know about its other groundbreaking feature representations. You can also explore our .NET MAUI DataGrid Documentation to understand how to present and manipulate data.
For current customers, you can check out our .NET MAUI components from the [License and Downloads](https://www.syncfusion.com/account/downloads) page. If you are new to Syncfusion, you can try our 30-day free trial to check out our .NET MAUI DataGrid and other .NET MAUI components.
If you have any queries or require clarifications, please let us know in comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/account/login?ReturnUrl=%2Faccount%2Fconnect%2Fauthorize%2Fcallback%3Fclient_id%3Dc54e52f3eb3cde0c3f20474f1bc179ed%26redirect_uri%3Dhttps%253A%252F%252Fsupport.syncfusion.com%252Fagent%252Flogincallback%26response_type%3Dcode%26scope%3Dopenid%2520profile%2520agent.api%2520integration.api%2520offline_access%2520kb.api%26state%3D8db41f98953a4d9ba40407b150ad4cf2%26code_challenge%3DvwHoT64z2h21eP_A9g7JWtr3vp3iPrvSjfh5hN5C7IE%26code_challenge_method%3DS256%26response_mode%3Dquery) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid). We are always happy to assist you!
