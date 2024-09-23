namespace jeweller_app.Models
{
    public class DashboardMetrics
    {
        public decimal TotalSales { get; set; }
        public int TotalOrders { get; set; }
        public int TotalCustomers { get; set; }
        public decimal InventoryValue { get; set; }
        public int TotalProducts { get; internal set; }
    }
}

