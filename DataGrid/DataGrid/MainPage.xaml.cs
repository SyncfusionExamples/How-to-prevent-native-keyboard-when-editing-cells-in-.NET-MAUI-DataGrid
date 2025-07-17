using System.Collections.ObjectModel;
using Syncfusion.Maui.DataGrid;
using System.Drawing;
using System.Globalization;
using Syncfusion.Maui.DataGrid.Helper;

namespace DataGrid
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            dataGrid.CellRenderers.Remove("Text");
            dataGrid.CellRenderers.Add("Text", new CustomTextCellRenderer());
        }

        public class CustomTextCellRenderer : DataGridTextBoxCellRenderer
        {
            public override void OnInitializeEditView(DataColumnBase dataColumn, SfDataGridEntry view)
            {
                base.OnInitializeEditView(dataColumn, view);
#if ANDROID
                if (view != null && view is SfDataGridEntry entry && DataGrid != null)
                {
                    DataGrid.Dispatcher.DispatchDelayed(TimeSpan.FromMilliseconds(100), () =>
                    {
                        var nativeEntry = entry.Handler?.PlatformView as Android.Widget.EditText;
                        if (nativeEntry != null)
                        {
                            nativeEntry.ShowSoftInputOnFocus = false;
                        }
                    });
                }
#endif
            }
        }

    }
    public class OrderInfo
    {
        private int orderID;
        private string customerID;
        private string customer;
        private string shipCity;
        private string shipCountry;

        public int OrderID
        {
            get { return orderID; }
            set { this.orderID = value;}
        }

        public string CustomerID
        {
            get { return customerID; }
            set { this.customerID = value; }
        }

        public string ShipCountry
        {
            get { return shipCountry; }
            set { this.shipCountry = value; }
        }

        public string Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
        }

        public string ShipCity
        {
            get { return shipCity; }
            set { this.shipCity = value; }
        }

        public OrderInfo(int orderId, string customerId, string country, string customer, string shipCity)
        {
            this.OrderID = orderId;
            this.CustomerID = customerId;
            this.Customer = customer;
            this.ShipCountry = country;
            this.ShipCity = shipCity;
        }
    }

    public class OrderInfoRepository
    {
        private ObservableCollection<OrderInfo> orderInfo;
        public ObservableCollection<OrderInfo> OrderInfoCollection
        {
            get { return orderInfo; }
            set { this.orderInfo = value; }
        }

        public OrderInfoRepository()
        {
            orderInfo = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        public void GenerateOrders()
        {
            orderInfo.Add(new OrderInfo(1001, "Maria Anders", "Germany", "ALFKI", "Berlin"));
            orderInfo.Add(new OrderInfo(1002, "Ana Trujillo", "Mexico", "ANATR", "Mexico D.F."));
            orderInfo.Add(new OrderInfo(1003, "Ant Fuller", "Mexico", "ANTON", "Mexico D.F."));
            orderInfo.Add(new OrderInfo(1004, "Thomas Hardy", "UK", "AROUT", "London"));
            orderInfo.Add(new OrderInfo(1005, "Tim Adams", "Sweden", "BERGS", "London"));
            orderInfo.Add(new OrderInfo(1006, "Hanna Moos", "Germany", "BLAUS", "Mannheim"));
            orderInfo.Add(new OrderInfo(1007, "Andrew Fuller", "France", "BLONP", "Strasbourg"));
            orderInfo.Add(new OrderInfo(1008, "Martin King", "Spain", "BOLID", "Madrid"));
            orderInfo.Add(new OrderInfo(1009, "Lenny Lin", "France", "BONAP", "Marsiella"));
            orderInfo.Add(new OrderInfo(1010, "John Carter", "Canada", "BOTTM", "Lenny Lin"));
            orderInfo.Add(new OrderInfo(1011, "Laura King", "UK", "AROUT", "London"));
            orderInfo.Add(new OrderInfo(1012, "Anne Wilson", "Germany", "BLAUS", "Mannheim"));
            orderInfo.Add(new OrderInfo(1013, "Martin King", "France", "BLONP", "Strasbourg"));
            orderInfo.Add(new OrderInfo(1014, "Gina Irene", "UK", "AROUT", "London"));
        }
    }

}
